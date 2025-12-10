using SportsClubMembership.Data;
using SportsClubMembership.Models;
using Npgsql;

namespace SportsClubMembership.Services
{
    public class MembresiaService
    {
        private readonly DbConnectionFactory _factory;

        public MembresiaService()
        {
            _factory = new DbConnectionFactory();
        }

        public int RenovarMembresia(int idMiembro, int idTipoMembresia)
        {
            using var conn = _factory.GetConnection();
            conn.Open();

            using var cmd = new NpgsqlCommand("SELECT renovar_membresia(@miembro, @tipo);", conn);

            cmd.Parameters.AddWithValue("@miembro", idMiembro);
            cmd.Parameters.AddWithValue("@tipo", idTipoMembresia);

            int idGenerado = Convert.ToInt32(cmd.ExecuteScalar());

            return idGenerado;
        }

        public List<Miembro> ObtenerMiembros()
        {
            var lista = new List<Miembro>();

            using var conn = _factory.GetConnection();
            conn.Open();

            string query = @"SELECT id, nombre, apellido_paterno, apellido_materno FROM miembros;";

            using var cmd = new NpgsqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Miembro
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    ApellidoPaterno = reader.GetString(2),
                    ApellidoMaterno = reader.GetString(3),
                });
            }

            return lista;
        }

        public List<TipoMembresia> ObtenerTiposMembresia()
        {
            var lista = new List<TipoMembresia>();

            using var conn = _factory.GetConnection();
            conn.Open();

            string query = @"SELECT id, nombre FROM tipos_membresia ORDER BY id;";

            using var cmd = new NpgsqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new TipoMembresia
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                });
            }

            return lista;
        }
    }
}
