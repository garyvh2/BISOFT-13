using System;
using CoreAPI.Managers;
using Entities.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{

    [TestClass]
    public class QuejasTest
    {
        // >> Dependencias
        /* Tener creado un viaje (NO IMPLEMENTADO)
         * Tener creado un usuario
         */

        // NOTA* = Si hay dependencias no implementadas 
        //         el test no se puede probar al 100% (Regritros con valores null)

        Queja q = new Queja();
        QuejaManager qMng = new QuejaManager();
        
        [TestMethod]
        public void Create()
        {
            //Arrange
            q.ID_VIAJE = 1; // ID incremental
            q.ID_USUARIO = "4-098-582-TEST"; // Este es el ID del usuario de
            q.DETALLE = "Detalle-TEST";
            q.ESTADO = 1;

            //Act
            var resul = qMng.Create(q);

            //Assert
            Assert.IsInstanceOfType(resul, typeof(Queja));
        }

        [TestMethod]
        public void RetrieveAll()
        {
            //Arrange

            //Act
            var list = qMng.RetrieveAll();

            //Assert
            CollectionAssert.AllItemsAreNotNull(list);
        }

        [TestMethod]
        public void RetrieveById()
        {
            //Arrange
            q.ID = 1;
            //Act
            var resul = qMng.RetrieveById(q);

            //Assert
            Assert.IsInstanceOfType(resul, typeof(Queja));
        }

        [TestMethod]
        public void Update()
        {
            //Arrange
            q.ID_VIAJE = 1; // ID incremental
            q.ID_USUARIO = "4-098-582-TEST"; // Este es el ID del usuario de
            q.DETALLE = "Detalle-TEST";
            q.ESTADO = 2;
            //Act
            var resul = qMng.Update(q);
            //Assert
            Assert.IsInstanceOfType(resul, typeof(Queja));
        }

        [TestMethod]
        public void Delete()
        {
            //Arrange
            q.ID = 1;
            //Act
            qMng.Delete(q);
            //Assert
        }
    }
}
