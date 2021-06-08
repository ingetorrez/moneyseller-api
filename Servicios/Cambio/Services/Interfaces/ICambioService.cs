using Objects.Compra.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Cambio.Services.Interfaces
{
    public interface ICambioService
    {
        decimal GetCambio(string moneda);//dolar o real
        BothCurrencyModel GetAll();//obtiene ambos dolar y real
    }
}
