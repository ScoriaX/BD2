using SportsClubMembership.Models;
using SportsClubMembership.Services;
using System;
using System.Windows.Forms;

namespace SportsClubMembership.Forms
{
    public partial class RegistrarMembresia : Form
    {
        private readonly MembresiaService _service;

        public RegistrarMembresia()
        {
            InitializeComponent();
            _service = new MembresiaService();
            UIStyles.ApplyFormStyle(this);
        }

        private void RegistrarMembresia_Load(object sender, EventArgs e)
        {
            try
            {
                var miembros = _service.ObtenerMiembros();

                foreach (var m in miembros)
                {
                    m.Nombre = $"{m.ApellidoPaterno} {m.ApellidoMaterno}, {m.Nombre}";
                }

                cbMiembro.DataSource = miembros;
                cbMiembro.DisplayMember = "Nombre";
                cbMiembro.ValueMember = "Id";

                var tipos = _service.ObtenerTiposMembresia();
                cbTipo.DataSource = tipos;
                cbTipo.DisplayMember = "Nombre";
                cbTipo.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.Message);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cbMiembro.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un miembro.");
                return;
            }

            if (cbTipo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar el tipo de membresía.");
                return;
            }

            int miembroId = Convert.ToInt32(cbMiembro.SelectedValue);
            int tipoId = Convert.ToInt32(cbTipo.SelectedValue);

            try
            {
                int nuevoId = _service.RenovarMembresia(miembroId, tipoId);
                MessageBox.Show($"Membresía registrada correctamente. ID={nuevoId}");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la membresía: " + ex.Message);
            }
        }
    }
}
