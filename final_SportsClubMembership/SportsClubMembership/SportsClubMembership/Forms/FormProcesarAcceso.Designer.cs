namespace SportsClubMembership.Forms
{
    partial class FormProcesarAcceso
    {
        private System.ComponentModel.IContainer components = null;

        private ComboBox cbMiembros;
        private Button btnProcesar;
        private Label lblResultado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cbMiembros = new ComboBox();
            this.btnProcesar = new Button();
            this.lblResultado = new Label();
            this.SuspendLayout();

            // cbMiembros
            this.cbMiembros.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbMiembros.Location = new System.Drawing.Point(30, 30);
            this.cbMiembros.Size = new System.Drawing.Size(300, 30);

            // btnProcesar
            this.btnProcesar.Text = "Procesar Acceso";
            this.btnProcesar.Location = new System.Drawing.Point(30, 80);
            this.btnProcesar.Size = new System.Drawing.Size(150, 40);
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);

            // lblResultado
            this.lblResultado.Location = new System.Drawing.Point(30, 140);
            this.lblResultado.Size = new System.Drawing.Size(350, 60);
            this.lblResultado.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // FormProcesarAcceso
            this.ClientSize = new System.Drawing.Size(420, 250);
            this.Controls.Add(this.cbMiembros);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.lblResultado);
            this.Text = "Procesar Acceso";
            this.Load += new System.EventHandler(this.FormProcesarAcceso_Load);
            this.ClientSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
        }
    }
}
