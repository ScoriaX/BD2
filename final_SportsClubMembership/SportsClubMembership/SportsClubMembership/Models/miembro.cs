namespace SportsClubMembership.Models
{
    public class Miembro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string PhotoPath { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Status { get; set; } = "Activo"; 
    }
}
