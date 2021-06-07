using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Servicios.Cambio.Services;
using Servicios.Cambio.Services.Interfaces;
using Servicios.Helpers;
using System;
using System.Collections.Generic;
using System.Text;


namespace Tests
{
    [TestClass]
    public class CambioTest
    {

        Dictionary<string, string> inMemorySettings;
        IConfiguration configuration;
        public CambioTest()
        {
            inMemorySettings = new Dictionary<string, string> {
                {"Monedas_Permitida", "dolar, real"},
                {"Dolar_URL", "https://www.bancoprovincia.com.ar/Principal/Dolar" },
                {"Real_URL","" }
            };

             configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
        }

        [TestMethod]
        public void GetCambioShuldGetCambioMoneda()
        {
            //Arrange
            string moneda = "dolar";
            decimal expected = 0;
            var _cambiar = new CambioService(configuration);

            //Act          
            decimal cambio = _cambiar.GetCambio(moneda);

            //Assert
            Assert.IsNotNull(cambio);
            Assert.IsTrue(cambio> expected);
        }


        [TestMethod]
        [ExpectedException(typeof(AppException))]
        public void GetCambio_ShuldThrowAppException()
        {
            //Arrange
            string moneda = "cordoba";
            var _cambiar = new CambioService(configuration);

            //Act          
            _cambiar.GetCambio(moneda);

        }
    }
    
}
