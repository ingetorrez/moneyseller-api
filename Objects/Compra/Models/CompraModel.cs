using System;
using System.Collections.Generic;
using System.Text;

namespace Objects.Compra.Models
{
    public class CompraModel
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; }
        public decimal Cambio { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
    }
}
