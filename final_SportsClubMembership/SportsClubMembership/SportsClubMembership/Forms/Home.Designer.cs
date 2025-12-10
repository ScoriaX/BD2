namespace SportsClubMembership.Forms
{
    partial class Home
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnRegistrarMiembro;
        private Button btnRegistrarMembresia;
        private Button btnRegistrarPago;
        private Button btnVerMiembros;
        private Button btnProcesar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnRegistrarMiembro = new System.Windows.Forms.Button();
            this.btnRegistrarMembresia = new System.Windows.Forms.Button();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.btnVerMiembros = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // btnRegistrarMiembro
            // 
            this.btnRegistrarMiembro.Location = new System.Drawing.Point(40, 40);
            this.btnRegistrarMiembro.Name = "btnRegistrarMiembro";
            this.btnRegistrarMiembro.Size = new System.Drawing.Size(200, 50);
            this.btnRegistrarMiembro.TabIndex = 0;
            this.btnRegistrarMiembro.Text = "Registrar Miembro";
            this.btnRegistrarMiembro.UseVisualStyleBackColor = true;
            this.btnRegistrarMiembro.Click += new System.EventHandler(this.btnRegistrarMiembro_Click);

            // 
            // btnRegistrarMembresia
            // 
            this.btnRegistrarMembresia.Location = new System.Drawing.Point(40, 110);
            this.btnRegistrarMembresia.Name = "btnRegistrarMembresia";
            this.btnRegistrarMembresia.Size = new System.Drawing.Size(200, 50);
            this.btnRegistrarMembresia.TabIndex = 1;
            this.btnRegistrarMembresia.Text = "Renovar Membresía";
            this.btnRegistrarMembresia.UseVisualStyleBackColor = true;
            this.btnRegistrarMembresia.Click += new System.EventHandler(this.btnRegistrarMembresia_Click);

            // 
            // btnRegistrarPago
            // 
            this.btnRegistrarPago.Location = new System.Drawing.Point(40, 180);
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.Size = new System.Drawing.Size(200, 50);
            this.btnRegistrarPago.TabIndex = 2;
            this.btnRegistrarPago.Text = "Registrar Pago";
            this.btnRegistrarPago.UseVisualStyleBackColor = true;
            this.btnRegistrarPago.Click += new System.EventHandler(this.btnRegistrarPago_Click);

            // 
            // btnVerMiembros
            // 
            this.btnVerMiembros.Location = new System.Drawing.Point(40, 250);
            this.btnVerMiembros.Name = "btnVerMiembros";
            this.btnVerMiembros.Size = new System.Drawing.Size(200, 50);
            this.btnVerMiembros.TabIndex = 3;
            this.btnVerMiembros.Text = "Ver Miembros";
            this.btnVerMiembros.UseVisualStyleBackColor = true;
            this.btnVerMiembros.Click += new System.EventHandler(this.btnVerMiembros_Click);

            // 
            // btnProcesar
            // 
            this.btnProcesar.Location = new System.Drawing.Point(40, 320);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(200, 50);
            this.btnProcesar.TabIndex = 4;
            this.btnProcesar.Text = "Procesar Acceso";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);

            // 
            // Home
            // 
            this.ClientSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Controls.Add(this.btnRegistrarMiembro);
            this.Controls.Add(this.btnRegistrarMembresia);
            this.Controls.Add(this.btnRegistrarPago);
            this.Controls.Add(this.btnVerMiembros);
            this.Controls.Add(this.btnProcesar);
            this.Name = "Home";
            this.Text = "Menú Principal";
            this.ResumeLayout(false);
        }
    }
}
