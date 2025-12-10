using System;

namespace SportsClubMembership.Models
{
    public class Pago
    {
        public int MembresiaId { get; set; }
        public decimal Monto { get; set; }
        public string Metodo { get; set; }
    }
}
