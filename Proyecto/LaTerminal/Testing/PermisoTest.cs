using System;
using CoreAPI.Managers;
using Entities.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class PermisoTest
    {
        // >> Dependencias
        /*
         */

        PermisoManager pMng = new PermisoManager();
        Permiso p = new Permiso();
        [TestMethod]
        public void Create()
        {
            //Arrage

            //ID Incremental
            p.Nombre = "TEST";
            p.Icono = "fas fa-vial";
            p.Accion = "TEST";

            //Act
            var resul = pMng.Create(p);

            //Asset
            Assert.IsInstanceOfType(resul, typeof(Permiso));
        }

        [TestMethod]
        public void RetrieveAll()
        {
            //Arrage

            //Act
            var resul = pMng.RetrieveAll();

            //Asset
            CollectionAssert.AllItemsAreInstancesOfType(resul, typeof(Permiso));
        }

        [TestMethod]
        public void RetrieveByID()
        {
            //Arrage
            p.Id = 1;

            //Act
            var resul = pMng.RetrieveById(p);

            //Asset
            Assert.IsInstanceOfType(resul, typeof(Permiso));

        }

        [TestMethod]
        public void Update()
        {
            //Arrage
            p.Id = 12;
            p.Nombre = "TEST-UP";
            p.Icono = "fas fa-vial";
            p.Accion = "TEST";

            //Act
            var resul = pMng.Update(p);

            //Asset
            Assert.IsInstanceOfType(resul, typeof(Permiso));
        }

        [TestMethod]
        public void Delete()
        {
            //Arrage
            p.Id = 1;

            //Act
            pMng.Delete(p);

            //Asset

        }
    }
}
