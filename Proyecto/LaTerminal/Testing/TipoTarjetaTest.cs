using System;
using CoreAPI.Managers;
using Entities.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class TipoTarjetaTest
    {
        public TipoTarjetaManager ttMng = new TipoTarjetaManager();
        public TipoTarjeta tt = new TipoTarjeta();

        [TestMethod]
        public void Create()
        {
            //Arrange
            
            //ID Incremental
            tt.NOMBRE = "Tipo-TEST";
            tt.BENEFICIO = 30;

            //Act
            var resul = ttMng.Create(tt);

            //Assert
            Assert.IsInstanceOfType(resul, typeof(TipoTarjeta));
        }

        [TestMethod]
        public void RetrieveAll()
        {
            //Arrage

            //Act
            var resul = ttMng.RetrieveAll();

            //Asset
            CollectionAssert.AllItemsAreInstancesOfType(resul, typeof(TipoTarjeta));
        }

        [TestMethod]
        public void RetrieveByID()
        {
            //Arrage
            tt.ID = 5;

            //Act
            var resul = ttMng.RetrieveById(tt);

            //Asset
            Assert.IsInstanceOfType(resul, typeof(TipoTarjeta));
        }

        [TestMethod]
        public void Update()
        {
            //Arrage
            tt.ID = 5;
            tt.NOMBRE = "Tipo-TEST";
            tt.BENEFICIO = 30;

            //Act
            var resul = ttMng.Update(tt);

            //Asset
            Assert.IsInstanceOfType(resul, typeof(TipoTarjeta));
        }

        [TestMethod]
        public void Delete()
        {
            //Arrage
            tt.ID = 5;

            //Act
            ttMng.Delete(tt);

            //Asset
        }
    }
}
