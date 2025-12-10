using System;
using System.Windows.Forms;

namespace SportsClubMembership.Forms
{
    partial class RegistrarMembresia
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblMiembro, lblTipo;
        private ComboBox cbMiembro, cbTipo;
        private Button btnRegistrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMiembro = new Label();
            this.lblTipo = new Label();

            this.cbMiembro = new ComboBox();
            this.cbTipo = new ComboBox();

            this.btnRegistrar = new Button();

            this.SuspendLayout();

            // Formularios
            this.ClientSize = new System.Drawing.Size(500, 250);
            this.Text = "Renovar Membresía";

            int lblX = 40, cbX = 180, startY = 30, gapY = 60;

            // MIEMBRO
            this.lblMiembro.Text = "Miembro:";
            this.lblMiembro.Location = new System.Drawing.Point(lblX, startY);

            this.cbMiembro.Location = new System.Drawing.Point(cbX, startY - 4);
            this.cbMiembro.Width = 250;
            this.cbMiembro.DropDownStyle = ComboBoxStyle.DropDownList;

            // TIPO DE MEMBRESÍA
            this.lblTipo.Text = "Tipo de Membresía:";
            this.lblTipo.Location = new System.Drawing.Point(lblX, startY + gapY);

            this.cbTipo.Location = new System.Drawing.Point(cbX, startY + gapY - 4);
            this.cbTipo.Width = 250;
            this.cbTipo.DropDownStyle = ComboBoxStyle.DropDownList;

            // BOTÓN
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.Location = new System.Drawing.Point(200, startY + 2 * gapY + 10);
            this.btnRegistrar.Width = 120;
            this.btnRegistrar.Click += new EventHandler(this.btnRegistrar_Click);

            // Añadir controles
            this.Controls.AddRange(new Control[] {
                lblMiembro, cbMiembro,
                lblTipo, cbTipo,
                btnRegistrar
            });

            this.Load += new EventHandler(this.RegistrarMembresia_Load);
            this.ClientSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
