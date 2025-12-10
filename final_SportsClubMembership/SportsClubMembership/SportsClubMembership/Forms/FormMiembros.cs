using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SportsClubMembership.Models;
using SportsClubMembership.Services;

namespace SportsClubMembership.Forms
{
    public partial class FormMiembros : Form
    {
        private readonly MiembroService _miembroService;

        public FormMiembros()
        {
            InitializeComponent();
            _miembroService = new MiembroService();
            UIStyles.ApplyFormStyle(this);
        }

        private void FormMiembros_Load(object sender, EventArgs e)
        {
            var miembros = _miembroService.ObtenerTodosLosMiembros();

            flowMiembros.Controls.Clear();

            foreach (var m in miembros)
            {
                flowMiembros.Controls.Add(VerMiembros(m));
            }
        }

        private Panel VerMiembros(Miembro m)
        {
            Panel card = new Panel()
            {
                Width = 220,
                Height = 330,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(10),
            };

            // Foto
            PictureBox pic = new PictureBox()
            {
                Width = 200,
                Height = 180,
                SizeMode = PictureBoxSizeMode.Zoom,
                Top = 10,
                Left = 10
            };

            if (!string.IsNullOrEmpty(m.PhotoPath) && File.Exists(m.PhotoPath))
                pic.Image = Image.FromFile(m.PhotoPath);

            // Nombre
            Label lblNombre = new Label()
            {
                Text = $"{m.Nombre} {m.ApellidoPaterno} {m.ApellidoMaterno}",
                AutoSize = false,
                Width = 200,
                Height = 40,
                Left = 10,
                Top = 200,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            // DNI
            Label lblDni = new Label()
            {
                Text = $"DNI: {m.DNI}",
                AutoSize = true,
                Left = 10,
                Top = 240
            };

            // Estado
            Label lblEstado = new Label()
            {
                Text = $"Estado: {m.Status}",
                AutoSize = true,
                Left = 10,
                Top = 260,
                ForeColor = m.Status == "Activo" ? Color.Green : Color.Red
            };

            // ⭐ Botón EDITAR
            Button btnEditar = new Button()
            {
                Text = "Editar",
                Width = 200,
                Height = 35,
                Top = 290,
                Left = 10,
                BackColor = Color.LightBlue
            };

            btnEditar.Click += (s, e) =>
            {
                FormEditarMiembro form = new FormEditarMiembro(m.Id);
                form.ShowDialog();

                // Recargar lista después de editar
                FormMiembros_Load(null, null);
            };

            card.Controls.Add(pic);
            card.Controls.Add(lblNombre);
            card.Controls.Add(lblDni);
            card.Controls.Add(lblEstado);
            card.Controls.Add(btnEditar);

            return card;
        }

    }
}
