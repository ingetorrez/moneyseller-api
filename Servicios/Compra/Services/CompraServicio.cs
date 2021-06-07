using DataAccess.Entidades;
using DataAccess.Repositorios.Compra.Interfaces;
using Objects.Compra.Models;
using Objects.Compra.Requests;
using Servicios.Cambio.Services.Interfaces;
using Servicios.Compra.Services.Interfaces;
using Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Compra.Services
{
    public class CompraServicio : ICompraServicio
    {

        private readonly ICompraRepository CompraRepository;
        private readonly ICambioService CambioService;
        public CompraServicio(ICompraRepository compraRepository,
                                ICambioService cambioService)
        {
            CompraRepository = compraRepository;
            CambioService = cambioService;
        }

        public CompraModel Create(CompraRequest req)
        {
            
            //Obtener cambio
            decimal cambio = CambioService.GetCambio(req.Moneda);

            //Monto a comprar
            decimal montoCompra = req.Monto / cambio;

            ////obtener monto acumulado por moneda, usuario y mes actual
            decimal montoAcumulado = CompraRepository.GetMontoAcumulado(req.IdUsuario, req.Moneda);

            //Calcular el monto a acumular
            decimal nuevoMontoAcumular = montoAcumulado + montoCompra;

            //monto limite
            decimal montoLimite = (req.Moneda == "dolar") ? 200 : 300;

            //calcular monto disponible
            decimal montoDisponible = montoLimite - montoAcumulado;

            
            //Validar que no supera monto tope/limite ()monto, usuario y mes
            //Validar disponibilidad dolar=200 and real=300
            if (nuevoMontoAcumular > montoLimite)
            {
                //Mensaje de disponibilidad
                string msg = (montoDisponible == 0) ? "Límite superado" : string.Format("Solo dispone de : {0} {1}", decimal.Round(montoDisponible,3),(req.Moneda=="dolar"?"dólares":"reales"));

                throw new AppException(string.Format("Monto no disponible ({0}), {1}", decimal.Round(montoCompra,3), msg));
            }

            //Save transaction                       
            CompraEntidad entidad = CompraRepository.Create(new CompraEntidad() { 
                                                                IdUsuario = req.IdUsuario,
                                                                Moneda = req.Moneda,
                                                                Monto = req.Monto,
                                                                Cambio = cambio,
                                                                Fecha = DateTime.Now
                                                            });

            return new CompraModel()
            {
                Id = entidad.Id,
                IdUsuario = entidad.IdUsuario,
                Moneda = entidad.Moneda,
                Monto = entidad.Monto,
                Cambio = entidad.Cambio,
                Total = decimal.Round(entidad.Monto / entidad.Cambio,3),
                Fecha = entidad.Fecha
            };
        }

        public List<CompraModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public CompraModel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
