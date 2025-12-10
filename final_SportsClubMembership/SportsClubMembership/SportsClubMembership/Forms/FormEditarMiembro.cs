using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SportsClubMembership.Models;
using SportsClubMembership.Services;

namespace SportsClubMembership.Forms
{
    public partial class FormEditarMiembro : Form
    {
        private readonly int _miembroId;
        private Miembro _miembro;
        private readonly MiembroService _miembroService;

        public FormEditarMiembro(int miembroId)
        {
            InitializeComponent();
            _miembroId = miembroId;
            _miembroService = new MiembroService();
            UIStyles.ApplyFormStyle(this);
        }

        private void FormEditarMiembro_Load(object sender, EventArgs e)
        {
            _miembro = _miembroService.ObtenerMiembroPorId(_miembroId);

            if (_miembro == null)
            {
                MessageBox.Show("No se encontró el miembro.");
                Close();
                return;
            }

            // Cargar datos actuales
            txtNombre.Text = _miembro.Nombre;
            txtApellidoPaterno.Text = _miembro.ApellidoPaterno;
            txtApellidoMaterno.Text = _miembro.ApellidoMaterno;
            txtDNI.Text = _miembro.DNI;

            cbStatus.Items.AddRange(new string[] { "Activo", "Inactivo" });
            cbStatus.SelectedItem = _miembro.Status;

            if (!string.IsNullOrEmpty(_miembro.PhotoPath) && File.Exists(_miembro.PhotoPath))
                picFoto.Image = Image.FromFile(_miembro.PhotoPath);
        }

        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Seleccionar foto";
            ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picFoto.Image = Image.FromFile(ofd.FileName);
                picFoto.Tag = ofd.FileName; // Guardamos temporalmente la ruta
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_miembro == null)
            {
                MessageBox.Show("Error: el miembro no está cargado.");
                return;
            }

            try
            {
                // Solo actualizar si el campo NO está vacío
                if (!string.IsNullOrWhiteSpace(txtNombre.Text))
                    _miembro.Nombre = txtNombre.Text;

                if (!string.IsNullOrWhiteSpace(txtApellidoPaterno.Text))
                    _miembro.ApellidoPaterno = txtApellidoPaterno.Text;

                if (!string.IsNullOrWhiteSpace(txtApellidoMaterno.Text))
                    _miembro.ApellidoMaterno = txtApellidoMaterno.Text;

                if (!string.IsNullOrWhiteSpace(txtDNI.Text))
                    _miembro.DNI = txtDNI.Text;

                if (cbStatus.SelectedItem != null)
                    _miembro.Status = cbStatus.SelectedItem.ToString();

                // Guardar foto solo si se eligió una nueva
                string nuevaFoto = picFoto.Tag as string;

                if (!string.IsNullOrEmpty(nuevaFoto))
                {
                    string carpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fotos");
                    Directory.CreateDirectory(carpeta);

                    string destino = Path.Combine(carpeta, $"{_miembro.Id}.jpg");
                    File.Copy(nuevaFoto, destino, true);

                    _miembro.PhotoPath = destino;
                }

                _miembroService.ActualizarMiembro(_miembro);

                MessageBox.Show("Miembro actualizado correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cambios: " + ex.Message);
            }
        }
    }
}
