using SportsClubMembership.Data;
using SportsClubMembership.Models;
using Npgsql;

namespace SportsClubMembership.Services
{
    public class PagoService
    {
        private readonly DbConnectionFactory _factory;

        public PagoService()
        {
            _factory = new DbConnectionFactory();
        }

        public int PagarMembresia(int MembresiaId, decimal Monto, string Metodo)
        {
            using var conn = _factory.GetConnection();
            conn.Open();

            using var cmd = new NpgsqlCommand("SELECT pagar_membresia(@membresia, @monto, @metodo);", conn);

            cmd.Parameters.AddWithValue("@membresia", MembresiaId);
            cmd.Parameters.AddWithValue("@monto", Monto);
            cmd.Parameters.AddWithValue("@metodo", Metodo);

            int idGenerado = Convert.ToInt32(cmd.ExecuteScalar());

            return idGenerado;
        }

        public List<MembresiaPendiente> ObtenerMembresiasPendientes()
        {
            var lista = new List<MembresiaPendiente>();

            using var conn = _factory.GetConnection();
            conn.Open();

            string query = @"
        SELECT 
            me.id,
            m.nombre,
            m.apellido_paterno,
            m.apellido_materno,
            tm.nombre AS tipo_membresia,
            me.precio,
            me.fecha_fin
        FROM membresias me
        JOIN miembros m ON m.id = me.id_miembro
        JOIN tipos_membresia tm ON tm.id = me.id_tipo
        WHERE me.estado = 'Pendiente'
        ORDER BY me.id;
    ";

            using var cmd = new NpgsqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new MembresiaPendiente
                {
                    Id = reader.GetInt32(0),
                    NombreCompleto = $"{reader.GetString(1)} {reader.GetString(2)} {reader.GetString(3)}",
                    TipoMembresia = reader.GetString(4),
                    Precio = reader.GetDecimal(5),
                    FechaFin = reader.GetDateTime(6)
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
