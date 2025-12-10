namespace SportsClubMembership.Forms
{
    partial class FormMiembros
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowMiembros;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowMiembros = new System.Windows.Forms.FlowLayoutPanel();

            this.SuspendLayout();

            // 
            // flowMiembros
            // 
            this.flowMiembros.AutoScroll = true;
            this.flowMiembros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowMiembros.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flowMiembros.WrapContents = true;
            this.flowMiembros.Padding = new System.Windows.Forms.Padding(10);
            this.flowMiembros.Name = "flowMiembros";
            this.flowMiembros.Size = new System.Drawing.Size(800, 450);
            this.flowMiembros.BackColor = System.Drawing.Color.WhiteSmoke;

            // 
            // FormMiembros
            // 
            this.ClientSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Controls.Add(this.flowMiembros);
            this.Name = "FormMiembros";
            this.Text = "Listado de Miembros";
            this.Load += new System.EventHandler(this.FormMiembros_Load);

            this.ResumeLayout(false);
        }
    }
}
