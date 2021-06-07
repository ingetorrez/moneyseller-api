using Objects.Compra.Models;
using Objects.Compra.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Compra.Services.Interfaces
{
    public interface ICompraServicio
    {
        CompraModel Create(CompraRequest req);
        List<CompraModel> GetAll();
        CompraModel GetById(int id);
    }
}
