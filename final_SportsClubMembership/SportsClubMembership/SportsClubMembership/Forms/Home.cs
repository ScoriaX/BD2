    using SportsClubMembership.Forms;
    using System;
    using System.Windows.Forms;

    namespace SportsClubMembership.Forms
    {
        public partial class Home : Form
        {
            public Home()
            {
                InitializeComponent();
                UIStyles.ApplyFormStyle(this);
            }

            private void btnRegistrarMiembro_Click(object sender, EventArgs e)
            {
                var frm = new RegistrarMiembro();
                frm.ShowDialog();
            }

            private void btnRegistrarMembresia_Click(object sender, EventArgs e)
            {
                var frm = new RegistrarMembresia();
                frm.ShowDialog();
            }

            private void btnRegistrarPago_Click(object sender, EventArgs e)
            {
                var frm = new RegistrarPago();
                frm.ShowDialog();
            }

            private void btnVerMiembros_Click(object sender, EventArgs e)
            {
                var frm = new FormMiembros();
                frm.ShowDialog();
            }

            private void btnProcesar_Click(object sender, EventArgs e)
            {
                var frm = new FormProcesarAcceso();
                frm.ShowDialog();
            }
    }
    }
