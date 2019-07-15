using System;
using CustomExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_04;

namespace UnitTestProject
{
    [TestClass]
    public class TestUnitarios
    {
        [TestMethod]
        public void CorreoListTendriaQueEstarInstanciada()
        {
            Correo correo = new Correo();

            Assert.AreEqual(correo.Paquetes.Count, 0);
        }
        
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void CorreoListDeberiaLanzarExceptionSiYaEstaEseTrackingID()
        {
            Correo correo = new Correo();
            
            correo += new Paquete("Av. Siempre viva 1234", "12332");
            Assert.AreEqual(correo.Paquetes.Count, 1);
            
            correo += new Paquete("Av. Siempre viva 1234", "12332");
        }
    }
}
