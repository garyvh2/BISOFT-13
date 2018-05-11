using System;
using CoreAPI.Managers;
using Entities.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class RolTest
    {
        // >> Dependencias
        /*
         */
        RolManager rMng = new RolManager();
        Rol r = new Rol();
        [TestMethod]
        public void Create()
        {
            //Arrage

            //ID incremental
            r.Nombre = "TEST";
            r.Descripcion = "TEST";

            //Act
            var resul = rMng.Create(r);

            //Asset
            Assert.IsInstanceOfType(resul, typeof(Rol));
        }

        [TestMethod]
        public void RetrieveAll()
        {
            //Arrage

            //Act
            var resul = rMng.RetrieveAll();

            //Asset
            CollectionAssert.AllItemsAreInstancesOfType(resul, typeof(Permiso));
        }

        [TestMethod]
        public void RetrieveByID()
        {
            //Arrage
            r.Id = 8;

            //Act
            var resul = rMng.RetrieveById(r);

            //Asset
            Assert.IsInstanceOfType(resul, typeof(Rol));
        }

        [TestMethod]
        public void Update()
        {
            //Arrage
            r.Id = 8;
            r.Nombre = "TEST";
            r.Descripcion = "TEST";

            //Act
            var resul = rMng.Update(r);

            //Asset
            Assert.IsInstanceOfType(resul, typeof(Rol));
        }

        [TestMethod]
        public void Delete()
        {
            //Arrage
            r.Id = 7;
            //Act
            rMng.Delete(r);
            //Asset
        }
    }
}
