using Npgsql;
using SportsClubMembership.Data;
using SportsClubMembership.Models;
using System;

namespace SportsClubMembership.Services
{
    public class AccesoService
    {
        private readonly DbConnectionFactory _factory;

        public AccesoService()
        {
            _factory = new DbConnectionFactory();
        }

        public Acceso ProcesarAcceso(int idMiembro)
        {
            using var conn = _factory.GetConnection();
            conn.Open();

            using var cmd = new NpgsqlCommand(
                "SELECT * FROM procesar_acceso(@p_id)", conn);

            cmd.Parameters.AddWithValue("p_id", idMiembro);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Acceso
                {
                    Permitido = reader.GetBoolean(0),
                    Mensaje = reader.GetString(1)
                };
            }

            throw new Exception("La función procesar_acceso no devolvió resultados.");
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
    }
}
