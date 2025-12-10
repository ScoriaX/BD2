using System;
using System.Drawing;
using System.Windows.Forms;
using SportsClubMembership.Services;
using SportsClubMembership.Models;

namespace SportsClubMembership.Forms
{
    public partial class FormProcesarAcceso : Form
    {
        private readonly MiembroService _miembroService;
        private readonly AccesoService _accesoService;

        public FormProcesarAcceso()
        {
            InitializeComponent();
            _miembroService = new MiembroService();
            _accesoService = new AccesoService();
            UIStyles.ApplyFormStyle(this);
        }

        private void FormProcesarAcceso_Load(object sender, EventArgs e)
        {
            try
            {
                var miembros = _accesoService.ObtenerMiembros();

                foreach (var m in miembros)
                {
                    m.Nombre = $"{m.ApellidoPaterno} {m.ApellidoMaterno}, {m.Nombre}";
                }

                cbMiembros.DataSource = miembros;
                cbMiembros.DisplayMember = "Nombre";
                cbMiembros.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar miembros: " + ex.Message);
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (cbMiembros.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un miembro.");
                return;
            }

            int miembroId = Convert.ToInt32(cbMiembros.SelectedValue);

            try
            {
                Acceso resultado = _accesoService.ProcesarAcceso(miembroId);

                lblResultado.Text = resultado.Mensaje;
                lblResultado.ForeColor =
                    resultado.Permitido ? Color.Green : Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar acceso: " + ex.Message);
            }
        }
    }
}
