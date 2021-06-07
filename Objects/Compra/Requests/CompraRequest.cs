using System;
using System.Collections.Generic;
using System.Text;

namespace Objects.Compra.Requests
{
    public class CompraRequest
    {
        public int IdUsuario { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; }
    }
}
