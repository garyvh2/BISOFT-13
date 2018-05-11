using System;
using CoreAPI.Managers;
using Entities.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class Empresa_BusTest
    {

        // >> Dependencias
        /*
         */

        public Empresa_BusManager E_BMng = new Empresa_BusManager();
        public Empresa_Bus eb = new Empresa_Bus();

        [TestMethod]
        public void Create()
        {
            //Arrange
            eb.CEDULA_JUR = "454-6789-TEST";
            eb.LOGO = "Logo";
            eb.CODIGO = "LM-TEST";
            eb.NOMBRE = "Lumaca-TEST";
            eb.TELEFONO = "2574-76-45-TEST";
            eb.CORREO = "lumacacr@gmail.com-TEST";
            eb.ESTADO = "1-TEST";

            //Act
            var result = E_BMng.Create(eb);
            //Assert
            Assert.IsInstanceOfType(result, typeof(Estacionamiento));
        }

        [TestMethod]
        public void RetrieveAll()
        {
            //Arrange

            var list = E_BMng.RetrieveAll();

            //Assert
            CollectionAssert.AllItemsAreNotNull(list);
        }

        [TestMethod]
        public void RetrieveById()
        {
            //Arrange
            eb.CEDULA_JUR = "454-6789-TEST";
            //Act
            var empresaBus = E_BMng.RetrieveById(eb);

            //Assert
            Assert.IsInstanceOfType(empresaBus, typeof(Empresa_Bus));
        }

        [TestMethod]
        public void Update()
        {
            //Arrange
            eb.CEDULA_JUR = "454-6789-TEST";
            eb.LOGO = "Logo";
            eb.CODIGO = "LM-TEST";
            eb.NOMBRE = "Lumaca-TEST";
            eb.TELEFONO = "2574-76-45-TEST";
            eb.CORREO = "lumacacr@gmail.com-TEST";
            eb.ESTADO = "1-TEST";

            //Act
            var result = E_BMng.Update(eb);
            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Delete()
        {
            //Arrange
            eb.CEDULA_JUR = "454-6789-TEST";
            //Act
            E_BMng.Delete(eb);
            //Assert
        }
    }
}
