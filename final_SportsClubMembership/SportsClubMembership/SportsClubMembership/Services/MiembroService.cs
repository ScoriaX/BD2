using SportsClubMembership.Data;
using SportsClubMembership.Models;
using Npgsql;

namespace SportsClubMembership.Services
{
    public class MiembroService
    {
        private readonly DbConnectionFactory _factory;

        public MiembroService()
        {
            _factory = new DbConnectionFactory();
        }

        public int RegistrarMiembroTransaccion(Miembro miembro, int idTipoMembresia)
        {
            using var conn = _factory.GetConnection();
            conn.Open();

            using var cmd = new NpgsqlCommand("SELECT registrar_nuevo_miembro(@nombre, @apellido_paterno, @apellido_materno, @dni, @tipo_membresia, @telefono, @correo, @direccion, @photo_path)", conn);

            cmd.Parameters.AddWithValue("nombre", miembro.Nombre);
            cmd.Parameters.AddWithValue("apellido_paterno", miembro.ApellidoPaterno);
            cmd.Parameters.AddWithValue("apellido_materno", miembro.ApellidoMaterno);
            cmd.Parameters.AddWithValue("dni", miembro.DNI);
            cmd.Parameters.AddWithValue("tipo_membresia", idTipoMembresia);
            cmd.Parameters.AddWithValue("telefono", (object)miembro.Telefono ?? DBNull.Value);
            cmd.Parameters.AddWithValue("correo", (object)miembro.Correo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("direccion", (object)miembro.Direccion ?? DBNull.Value);
            cmd.Parameters.AddWithValue("photo_path", (object)miembro.PhotoPath ?? DBNull.Value);

            return Convert.ToInt32(cmd.ExecuteScalar());
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

        public List<Miembro> ObtenerTodosLosMiembros()
        {
            var lista = new List<Miembro>();

            using var conn = _factory.GetConnection();
            conn.Open();

            string query = @"SELECT id, nombre, apellido_paterno, apellido_materno, dni, telefono, correo, direccion, photo_path, fecha_creacion FROM miembros;";

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
                    DNI = reader.GetString(4),
                    Telefono = reader.GetString(5),
                    Correo = reader.GetString(6),
                    Direccion = reader.GetString(7),
                    PhotoPath = reader.IsDBNull(8) ? null : reader.GetString(8),
                    FechaCreacion = reader.GetDateTime(9)
                });
            }

            return lista;
        }

        public Miembro ObtenerMiembroPorId(int id)
        {
            using var conn = _factory.GetConnection();
            conn.Open();

            string q = @"SELECT id, nombre, apellido_paterno, apellido_materno, dni, status, photo_path
                 FROM miembros
                 WHERE id = @id";

            using var cmd = new NpgsqlCommand(q, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var r = cmd.ExecuteReader();
            if (r.Read())
            {
                return new Miembro
                {
                    Id = r.GetInt32(0),
                    Nombre = r.GetString(1),
                    ApellidoPaterno = r.GetString(2),
                    ApellidoMaterno = r.GetString(3),
                    DNI = r.GetString(4),
                    Status = r.GetString(5),
                    PhotoPath = r.IsDBNull(6) ? null : r.GetString(6)
                };
            }

            return null;
        }

        public void ActualizarMiembro(Miembro m)
        {
            using var conn = _factory.GetConnection();
            conn.Open();

            string q = @"
        UPDATE miembros SET
            nombre = @nombre,
            apellido_paterno = @ap,
            apellido_materno = @am,
            dni = @dni,
            status = @status,
            photo_path = @foto
        WHERE id = @id";

            using var cmd = new NpgsqlCommand(q, conn);

            cmd.Parameters.AddWithValue("@id", m.Id);
            cmd.Parameters.AddWithValue("@nombre", m.Nombre);
            cmd.Parameters.AddWithValue("@ap", m.ApellidoPaterno);
            cmd.Parameters.AddWithValue("@am", m.ApellidoMaterno);
            cmd.Parameters.AddWithValue("@dni", m.DNI);
            cmd.Parameters.AddWithValue("@status", m.Status);
            cmd.Parameters.AddWithValue("@foto", (object?)m.PhotoPath ?? DBNull.Value);

            cmd.ExecuteNonQuery();
        }

    }
}
