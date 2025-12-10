using System;
using System.Windows.Forms;

namespace SportsClubMembership.Forms
{
    partial class RegistrarMiembro
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblNombre, lblApellidoPaterno, lblApellidoMaterno, lblDni,
                      lblTelefono, lblCorreo, lblDireccion, lblFecha,
                      lblTipoMembresia, lblFoto;

        private TextBox txtNombre, txtApellidoPaterno, txtApellidoMaterno,
                        txtDni, txtTelefono, txtCorreo, txtDireccion;

        private DateTimePicker dateIngreso;
        private ComboBox cbTipoMembresia;
        private Button btnRegistrar;

        private PictureBox picFoto;
        private Button btnSeleccionarFoto;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNombre = new Label();
            this.lblApellidoPaterno = new Label();
            this.lblApellidoMaterno = new Label();
            this.lblDni = new Label();
            this.lblTelefono = new Label();
            this.lblCorreo = new Label();
            this.lblDireccion = new Label();
            this.lblFecha = new Label();
            this.lblTipoMembresia = new Label();
            this.lblFoto = new Label();

            this.txtNombre = new TextBox();
            this.txtApellidoPaterno = new TextBox();
            this.txtApellidoMaterno = new TextBox();
            this.txtDni = new TextBox();
            this.txtTelefono = new TextBox();
            this.txtCorreo = new TextBox();
            this.txtDireccion = new TextBox();

            this.dateIngreso = new DateTimePicker();
            this.cbTipoMembresia = new ComboBox();

            this.btnRegistrar = new Button();

            // NUEVOS
            this.picFoto = new PictureBox();
            this.btnSeleccionarFoto = new Button();

            this.SuspendLayout();

            // FORM SIZE
            this.ClientSize = new System.Drawing.Size(650, 750);
            this.Text = "Registrar Miembro";

            int lblX = 40, txtX = 220, startY = 30, gapY = 55;

            // NOMBRE
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Location = new System.Drawing.Point(lblX, startY);
            this.txtNombre.Location = new System.Drawing.Point(txtX, startY - 4);
            this.txtNombre.Width = 350;

            // APELLIDO PATERNO
            this.lblApellidoPaterno.Text = "A. Paterno:";
            this.lblApellidoPaterno.Location = new System.Drawing.Point(lblX, startY + gapY);
            this.txtApellidoPaterno.Location = new System.Drawing.Point(txtX, startY + gapY - 4);
            this.txtApellidoPaterno.Width = 350;

            // APELLIDO MATERNO
            this.lblApellidoMaterno.Text = "A. Materno:";
            this.lblApellidoMaterno.Location = new System.Drawing.Point(lblX, startY + 2 * gapY);
            this.txtApellidoMaterno.Location = new System.Drawing.Point(txtX, startY + 2 * gapY - 4);
            this.txtApellidoMaterno.Width = 350;

            // DNI
            this.lblDni.Text = "DNI:";
            this.lblDni.Location = new System.Drawing.Point(lblX, startY + 3 * gapY);
            this.txtDni.Location = new System.Drawing.Point(txtX, startY + 3 * gapY - 4);
            this.txtDni.Width = 350;

            // TELEFONO
            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.Location = new System.Drawing.Point(lblX, startY + 4 * gapY);
            this.txtTelefono.Location = new System.Drawing.Point(txtX, startY + 4 * gapY - 4);
            this.txtTelefono.Width = 350;

            // CORREO
            this.lblCorreo.Text = "Correo:";
            this.lblCorreo.Location = new System.Drawing.Point(lblX, startY + 5 * gapY);
            this.txtCorreo.Location = new System.Drawing.Point(txtX, startY + 5 * gapY - 4);
            this.txtCorreo.Width = 350;

            // DIRECCION
            this.lblDireccion.Text = "Dirección:";
            this.lblDireccion.Location = new System.Drawing.Point(lblX, startY + 6 * gapY);
            this.txtDireccion.Location = new System.Drawing.Point(txtX, startY + 6 * gapY - 4);
            this.txtDireccion.Width = 350;

            // FECHA INGRESO
            this.lblFecha.Text = "F.Ingreso:";
            this.lblFecha.Location = new System.Drawing.Point(lblX, startY + 7 * gapY);
            this.dateIngreso.Location = new System.Drawing.Point(txtX, startY + 7 * gapY - 4);
            this.dateIngreso.Format = DateTimePickerFormat.Short;

            // TIPO MEMBRESIA
            this.lblTipoMembresia.Text = "T. Membresía:";
            this.lblTipoMembresia.Location = new System.Drawing.Point(lblX, startY + 8 * gapY);
            this.cbTipoMembresia.Location = new System.Drawing.Point(txtX, startY + 8 * gapY - 4);
            this.cbTipoMembresia.Width = 350;
            this.cbTipoMembresia.DropDownStyle = ComboBoxStyle.DropDownList;

            // FOTO (LABEL)
            this.lblFoto.Text = "Foto:";
            this.lblFoto.Location = new System.Drawing.Point(lblX, startY + 9 * gapY);

            // PICTUREBOX
            this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFoto.Location = new System.Drawing.Point(txtX, startY + 9 * gapY - 10);
            this.picFoto.Size = new System.Drawing.Size(100, 100);
            this.picFoto.SizeMode = PictureBoxSizeMode.Zoom;

            // BOTÓN SELECCIONAR FOTO
            this.btnSeleccionarFoto.Text = "Seleccionar Foto";
            this.btnSeleccionarFoto.Location = new System.Drawing.Point(txtX + 170, startY + 9 * gapY + 50);
            this.btnSeleccionarFoto.Click += new EventHandler(this.btnSeleccionarFoto_Click);

            // BOTÓN REGISTRAR
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.Location = new System.Drawing.Point(250, startY + 11 * gapY);
            this.btnRegistrar.Width = 150;
            this.btnRegistrar.Click += new EventHandler(this.btnRegistrar_Click);

            // ADD CONTROLS
            this.Controls.AddRange(new Control[] {
                lblNombre, txtNombre,
                lblApellidoPaterno, txtApellidoPaterno,
                lblApellidoMaterno, txtApellidoMaterno,
                lblDni, txtDni,
                lblTelefono, txtTelefono,
                lblCorreo, txtCorreo,
                lblDireccion, txtDireccion,
                lblFecha, dateIngreso,
                lblTipoMembresia, cbTipoMembresia,
                lblFoto, picFoto, btnSeleccionarFoto,
                btnRegistrar
            });

            this.Load += new EventHandler(this.RegistrarMiembro_Load);
            this.ClientSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
