using DataAccess.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositorios.Compra.Interfaces
{
    public interface ICompraRepository
    {
        CompraEntidad Create(CompraEntidad entity);
        decimal GetMontoAcumulado(int idUsuario, string moneda);
     
    }
}
