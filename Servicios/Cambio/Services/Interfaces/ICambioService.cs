using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Cambio.Services.Interfaces
{
    public interface ICambioService
    {
        decimal GetCambio(string moneda);//dolar o real
    }
}
