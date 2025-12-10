using SportsClubMembership.Services;
using SportsClubMembership.Models;
using System;
using System.Windows.Forms;

namespace SportsClubMembership.Forms
{
    public partial class RegistrarPago : Form
    {
        private readonly PagoService _service;

        public RegistrarPago()
        {
            InitializeComponent();
            _service = new PagoService();
            UIStyles.ApplyFormStyle(this);
        }

        private void RegistrarPago_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar miembros pendientes
                var membresiasPendientes = _service.ObtenerMembresiasPendientes();
                cbMiembro.DataSource = membresiasPendientes;
                cbMiembro.DisplayMember = "NombreCompleto";
                cbMiembro.ValueMember = "Id";

                // Seleccionar el primer miembro al cargar
                if (cbMiembro.Items.Count > 0)
                    cbMiembro.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.Message);
            }
        }

        private void CbMiembro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMiembro.SelectedItem is MembresiaPendiente mp)
            {
                // Actualizar monto
                txtMonto.Text = mp.Precio.ToString("0.00");

                // Actualizar tipo
                txtTipo.Text = mp.TipoMembresia;
            }
            else
            {
                txtMonto.Text = "";
                txtTipo.Text = "";
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (cbMiembro.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un miembro.");
                return;
            }

            if (cbMetodo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un método de pago.");
                return;
            }

            int miembroId = Convert.ToInt32(cbMiembro.SelectedValue);
            decimal monto = Convert.ToDecimal(txtMonto.Text);
            string metodo = cbMetodo.SelectedItem.ToString();

            try
            {
                int idPago = _service.PagarMembresia(miembroId, monto, metodo);
                MessageBox.Show($"Pago registrado correctamente. ID={idPago}");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el pago: " + ex.Message);
            }
        }
    }
}
