using CoreAPI.Managers;
using Entities.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    [TestClass]
    public class SancionTest
    {
        // >> Dependencias
        /* Tener creada una empresa de bus 
         */

        public SancionManager SancionMng = new SancionManager();
        public Sancion s = new Sancion();

        [TestMethod]
        public void Create()
        {
            //Arrange
            
            // ID Incremental
            s.Id_Empresa_Bus = "454-6789-TEST"; // ID Empresa de Bus
            s.Detalle = "Detalle-TEST";
            s.Fecha = DateTime.Now;
            s.Monto = 25000;
            s.Tipo = 1; 
            s.Estado =1;

            //Act
            var result = SancionMng.Create(s);
            //Assert
            Assert.IsInstanceOfType(result, typeof(Sancion));
        }

        [TestMethod]
        public void RetrieveAll()
        {
            //Arrange

            //Act
            var list = SancionMng.RetrieveAll();

            //Assert
            CollectionAssert.AllItemsAreNotNull(list);
        }

        [TestMethod]
        public void RetrieveById()
        {
            //Arrange
            s.Id = 1;
            //Act
            var sancion = SancionMng.RetrieveById(s);

            //Assert
            Assert.IsInstanceOfType(sancion, typeof(Sancion));
        }

        [TestMethod]
        public void Update()
        {
            //Arrange

            // ID Incremental
            s.Id_Empresa_Bus = "454-6789-TEST"; // ID Empresa de Bus
            s.Detalle = "Detalle-TEST";
            s.Fecha = DateTime.Now;
            s.Monto = 25000;
            s.Tipo = 1;
            s.Estado = 1;

            //Act
            var result = SancionMng.Update(s);
            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Delete()
        {
            //Arrange
            s.Id = 1;
            //Act
            SancionMng.Delete(s);
            //Assert
        }
    }
}
