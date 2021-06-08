using Microsoft.Extensions.Configuration;
using Servicios.Cambio.Services.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Servicios.Helpers;
using Objects.Compra.Models;

namespace Servicios.Cambio.Services
{
    public class CambioService:ICambioService
    {
        public IConfiguration Configuration { get; }
        public CambioService(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public decimal GetCambio(string moneda)
        {
            var monedasPermitidas = Configuration
                           .GetSection("Monedas_Permitida").Value.ToString().Split(',');
                           
            if (!monedasPermitidas.Contains(moneda))
            {
                throw new AppException("Solo es permitido: dólar y real");
            }


            string dolarEndpoint = Configuration.GetSection("Dolar_URL").Value;
            string realEndpoint = Configuration.GetSection("Real_URL").Value;
            

            try
            {
                var client = new RestClient((realEndpoint!="" && moneda=="real")? realEndpoint:dolarEndpoint);
                var request = new RestRequest(Method.GET);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("authorization", "Basic Og==");
                IRestResponse response = client.Execute(request);

                List<string> result = JsonConvert.DeserializeObject<List<string>>(response.Content);

                
                decimal monto = Convert.ToDecimal(result[0].ToString());

                return (moneda == "dolar" || (realEndpoint != "" && moneda == "real")) ? monto : monto / 4;
            }
            catch (Exception)
            {
                throw new Exception("Huvo inconveniente al intentar obtener el cambio");
            }



        }

        public BothCurrencyModel GetAll()
        {
            decimal dolar = GetCambio("dolar");

            return new BothCurrencyModel()
            {
                Dolar = dolar,
                Real = dolar / 4
            };
        }
    }
}
