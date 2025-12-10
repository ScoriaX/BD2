using Npgsql;
using System;
using System.Windows.Forms;

namespace SportsClubMembership
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string connString = "Host=localhost;Port=5432;Username=postgres;Password=2506;Database=postgres";

            using var conn = new NpgsqlConnection(connString);
            try
            {
                conn.Open();
                MessageBox.Show("Conexión exitosa con PostgreSQL");

                // Listar tablas del esquema public
                string query = @"
                    SELECT tablename 
                    FROM pg_tables
                    WHERE schemaname = 'public'
                    ORDER BY tablename;
                ";

                using var cmd = new NpgsqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                string tablas = "";
                while (reader.Read())
                {
                    tablas += reader.GetString(0) + Environment.NewLine;
                }

                if (string.IsNullOrEmpty(tablas))
                    tablas = "No se encontraron tablas en el esquema public.";

                MessageBox.Show("Tablas en public:\n" + tablas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
