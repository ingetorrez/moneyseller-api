using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace DataAccess.Entidades
{
    [Table("tblCompra")]
    public class CompraEntidad
    {
        [Key]
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; }
        public decimal Cambio { get; set; }
        public DateTime Fecha { get; set; }

    }
}
