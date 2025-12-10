namespace SportsClubMembership.Forms
{
    partial class RegistrarPago
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblMiembro;
        private Label lblTipo;
        private Label lblMonto;
        private Label lblMetodo;

        private ComboBox cbMiembro;
        private TextBox txtTipo;
        private TextBox txtMonto;

        private ComboBox cbMetodo;
        private Button btnPagar;

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
            this.lblMonto = new Label();
            this.lblMetodo = new Label();

            this.cbMiembro = new ComboBox();
            this.txtTipo = new TextBox();
            this.txtMonto = new TextBox();

            this.cbMetodo = new ComboBox();
            this.btnPagar = new Button();

            this.SuspendLayout();

            // FORM
            this.ClientSize = new System.Drawing.Size(420, 330);
            this.Text = "Registrar Pago";

            int x1 = 40, x2 = 180, y = 40, gap = 50;

            // LABEL MIEMBRO
            lblMiembro.Text = "Miembro:";
            lblMiembro.Location = new System.Drawing.Point(x1, y);

            cbMiembro.Location = new System.Drawing.Point(x2, y - 4);
            cbMiembro.Width = 170;
            cbMiembro.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMiembro.SelectedIndexChanged += new System.EventHandler(this.CbMiembro_SelectedIndexChanged);

            // TIPO
            lblTipo.Text = "Tipo Membresía:";
            lblTipo.Location = new System.Drawing.Point(x1, y + gap);

            txtTipo.Location = new System.Drawing.Point(x2, y + gap - 4);
            txtTipo.Width = 170;
            txtTipo.ReadOnly = true; // solo lectura

            // MONTO
            lblMonto.Text = "Monto:";
            lblMonto.Location = new System.Drawing.Point(x1, y + 2 * gap);

            txtMonto.Location = new System.Drawing.Point(x2, y + 2 * gap - 4);
            txtMonto.Width = 170;
            txtMonto.ReadOnly = true;

            // METODO DE PAGO
            lblMetodo.Text = "Método Pago:";
            lblMetodo.Location = new System.Drawing.Point(x1, y + 3 * gap);

            cbMetodo.Location = new System.Drawing.Point(x2, y + 3 * gap - 4);
            cbMetodo.Width = 170;
            cbMetodo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMetodo.Items.AddRange(new string[] {
                "Efectivo",
                "Yape",
                "Plin",
                "Tarjeta"
            });

            // BOTON PAGAR
            btnPagar.Text = "Registrar Pago";
            btnPagar.Location = new System.Drawing.Point(130, y + 4 * gap);
            btnPagar.Width = 150;
            btnPagar.Click += new System.EventHandler(this.btnPagar_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblMiembro, cbMiembro,
                lblTipo, txtTipo,
                lblMonto, txtMonto,
                lblMetodo, cbMetodo,
                btnPagar
            });

            this.Load += new System.EventHandler(this.RegistrarPago_Load);

            this.ClientSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
