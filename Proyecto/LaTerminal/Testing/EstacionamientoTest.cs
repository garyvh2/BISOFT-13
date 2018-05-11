using System;
using CoreAPI.Managers;
using Entities.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class EstacionamientoTest
    {
        // >> Dependencias
        /* Tener creado una terminal
         */

        public EstacionamientoManager EMng = new EstacionamientoManager();
        public Estacionamiento e = new Estacionamiento();

        [TestMethod]
        public void Create()
        {
            //Arrange
            e.Id = 1;
            e.Id_Terminal = "2-O345-532-TEST"; // Este es el ID de la terminal de prueba
            e.Numero = "1-TEST";
            e.Estado = "TEST";


            //Act
            var result = EMng.Create(e);
            //Assert
            Assert.IsInstanceOfType(result, typeof(Estacionamiento));
        }

        [TestMethod]
        public void RetrieveAll()
        {
            //Arrange

            //Act
            var list = EMng.RetrieveAll();

            //Assert
            CollectionAssert.AllItemsAreNotNull(list);
        }

        [TestMethod]
        public void RetrieveById()
        {
            //Arrange
            e.Id =1;
            //Act
            var estacionamiento = EMng.RetrieveById(e);

            //Assert
            Assert.IsInstanceOfType(estacionamiento, typeof(Estacionamiento));
        }

        [TestMethod]
        public void Update()
        {
            //Arrange
            e.Id = 1;
            e.Id_Terminal = "2-O345-532-TEST";
            e.Numero = "1-TEST";
            e.Estado = "TEST";
            //Act
            var result = EMng.Update(e);
            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Delete()
        {
            //Arrange
            e.Id = 1;
            //Act
            EMng.Delete(e);
            //Assert
        }
    }
}
