namespace SportsClubMembership.Forms
{
    partial class FormEditarMiembro
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtNombre;
        private TextBox txtApellidoPaterno;
        private TextBox txtApellidoMaterno;
        private TextBox txtDNI;
        private ComboBox cbStatus;
        private PictureBox picFoto;
        private Button btnSeleccionarFoto;
        private Button btnGuardar;
        private Label lbl1, lbl2, lbl3, lbl4, lbl5;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtNombre = new TextBox();
            this.txtApellidoPaterno = new TextBox();
            this.txtApellidoMaterno = new TextBox();
            this.txtDNI = new TextBox();
            this.cbStatus = new ComboBox();
            this.picFoto = new PictureBox();
            this.btnSeleccionarFoto = new Button();
            this.btnGuardar = new Button();

            this.lbl1 = new Label();
            this.lbl2 = new Label();
            this.lbl3 = new Label();
            this.lbl4 = new Label();
            this.lbl5 = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();

            // Labels
            lbl1.Text = "Nombre:";
            lbl1.Location = new Point(20, 20);
            lbl2.Text = "Apellido Paterno:";
            lbl2.Location = new Point(20, 70);
            lbl3.Text = "Apellido Materno:";
            lbl3.Location = new Point(20, 120);
            lbl4.Text = "DNI:";
            lbl4.Location = new Point(20, 170);
            lbl5.Text = "Estado:";
            lbl5.Location = new Point(20, 220);

            // Textboxes
            txtNombre.Location = new Point(150, 20);
            txtNombre.Width = 200;

            txtApellidoPaterno.Location = new Point(150, 70);
            txtApellidoPaterno.Width = 200;

            txtApellidoMaterno.Location = new Point(150, 120);
            txtApellidoMaterno.Width = 200;

            txtDNI.Location = new Point(150, 170);
            txtDNI.Width = 200;

            // ComboBox
            cbStatus.Location = new Point(150, 220);
            cbStatus.Width = 200;
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            // PictureBox
            picFoto.Location = new Point(380, 20);
            picFoto.Size = new Size(150, 150);
            picFoto.BorderStyle = BorderStyle.FixedSingle;
            picFoto.SizeMode = PictureBoxSizeMode.Zoom;

            // Botón seleccionar foto
            btnSeleccionarFoto.Text = "Cambiar Foto";
            btnSeleccionarFoto.Location = new Point(380, 180);
            btnSeleccionarFoto.Click += new EventHandler(this.btnSeleccionarFoto_Click);

            // Botón guardar
            btnGuardar.Text = "Guardar";
            btnGuardar.Location = new Point(200, 280);
            btnGuardar.Width = 150;
            btnGuardar.Click += new EventHandler(this.btnGuardar_Click);

            // Form
            this.ClientSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Controls.AddRange(new Control[] {
                lbl1, lbl2, lbl3, lbl4, lbl5,
                txtNombre, txtApellidoPaterno, txtApellidoMaterno, txtDNI,
                cbStatus, picFoto, btnSeleccionarFoto, btnGuardar
            });

            this.Text = "Editar Miembro";
            this.Load += new EventHandler(this.FormEditarMiembro_Load);

            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
