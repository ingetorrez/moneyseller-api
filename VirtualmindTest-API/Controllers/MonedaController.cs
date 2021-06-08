using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Objects.Compra.Models;
using Objects.Compra.Requests;
using Servicios.Cambio.Services.Interfaces;
using Servicios.Compra.Services.Interfaces;
using Servicios.Helpers;

namespace VirtualmindTest_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonedaController : ControllerBase
    {
        private readonly ICambioService CambioService;
        private readonly ICompraServicio CompraServicio;
        private readonly ILogger Logger;

        public MonedaController(ICambioService cambioService
                                , ICompraServicio compraServicio
                                , ILogger<MonedaController> logger
            )
        {
            CambioService = cambioService;
            CompraServicio = compraServicio;
            Logger = logger;
        }


        [HttpGet]
        [Route("GetAll")]
        public ActionResult<BothCurrencyModel> GetAll()
        {
            try
            {
                BothCurrencyModel cambio = CambioService.GetAll();

                Logger.LogTrace("Cambio obtenido con éxito");

                return Ok(cambio);
            }
            catch (AppException e)
            {
                Logger.LogError(string.Format("AppException : {0}", e.Message));
                return BadRequest(e.Message);

            }


        }

        /// <summary>
        /// Endpoint para obtener el cambio de peso argentino a dolar o real
        /// </summary>
        /// <param name="moneda">tipo de moneda (dolar, real)</param>
        /// <returns>El cambio de la moneda actualizado</returns>
        [HttpGet]
        [Route("GetCambio/{moneda}")]
        public ActionResult<decimal> Get(string moneda)
        {
            

            try
            {
                decimal cambio = CambioService.GetCambio(moneda);
                
                Logger.LogTrace("Cambio obtenido con éxito");

                return Ok(cambio);
            }
            catch (AppException e)
            {
                Logger.LogError(string.Format("AppException : {0}", e.Message));
                return BadRequest(e.Message);

            }
            
            
        }

        /// <summary>
        /// Almacena una compra de moneda (dolar o real) basado en el peso argentino,  manejo de limite (200 dolares o 300 reales por mes y por usuario)
        /// </summary>
        /// <param name="req">id de usuario, moneda (dolar o real) y monto a comprar</param>
        /// <returns>Data sobre la transaccion/compra realizada</returns>
        [HttpPost]
        [Route("Comprar")]
        public ActionResult<CompraModel> Comprar(CompraRequest req)
        {
            try
            {
                CompraModel compra = CompraServicio.Create(req);
                
                Logger.LogTrace("Compra efectuada con éxito");

                return Ok(compra);
            }
            catch (AppException e)
            {
                Logger.LogError(string.Format("AppException : {0}", e.Message));
                return BadRequest(e.Message);

            }
            
        }
    }
}
