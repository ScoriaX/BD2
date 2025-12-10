using System;
using System.Windows.Forms;
using SportsClubMembership.Services;
using SportsClubMembership.Models;

namespace SportsClubMembership.Forms
{
    public partial class RegistrarMiembro : Form
    {
        private readonly MiembroService _service;

        public RegistrarMiembro()
        {
            InitializeComponent();
            _service = new MiembroService();
            UIStyles.ApplyFormStyle(this);
        }

        private void RegistrarMiembro_Load(object sender, EventArgs e)
        {
            try
            {
                var tipos = _service.ObtenerTiposMembresia();
                cbTipoMembresia.DataSource = tipos;
                cbTipoMembresia.DisplayMember = "Nombre";
                cbTipoMembresia.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipos de membresía: " + ex.Message);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoPaterno.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoMaterno.Text) ||
                txtDni.Text.Length != 8)
            {
                MessageBox.Show("Complete todos los campos obligatorios y verifique el DNI.");
                return;
            }

            string rutaFinalImagen = null;

            if (picFoto.Tag != null)
            {
                string carpetaFotos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fotos");
                Directory.CreateDirectory(carpetaFotos);

                string nombreArchivo = $"{Guid.NewGuid()}{Path.GetExtension(picFoto.Tag.ToString())}";
                rutaFinalImagen = Path.Combine(carpetaFotos, nombreArchivo);

                File.Copy(picFoto.Tag.ToString(), rutaFinalImagen, true);
            }

            // --- Crear objeto Miembro ---
            var miembro = new Miembro
            {
                Nombre = txtNombre.Text.Trim(),
                ApellidoPaterno = txtApellidoPaterno.Text.Trim(),
                ApellidoMaterno = txtApellidoMaterno.Text.Trim(),
                DNI = txtDni.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                FechaIngreso = dateIngreso.Value,
                Status = "Activo",
                PhotoPath = rutaFinalImagen
            };

            try
            {
                int tipoId = (int)cbTipoMembresia.SelectedValue;

                int nuevoId = _service.RegistrarMiembroTransaccion(miembro, tipoId);

                MessageBox.Show($"Miembro registrado correctamente.\nID = {nuevoId}");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el miembro: " + ex.Message);
            }
        }

        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Seleccionar una foto";
            ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = ofd.FileName;

                // Mostrar imagen en el PictureBox
                picFoto.Image = Image.FromFile(selectedPath);
                picFoto.Tag = selectedPath; // guardamos la ruta temporalmente
            }
        }
    }
}
