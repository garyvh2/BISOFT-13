using System;
using CoreAPI.Managers;
using Entities.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class HorariosTest
    {
        // >> Dependencias
        /* Tener creado una Ruta (NO IMPLEMENTADO)
         * Tener creado un bus (NO IMPLEMENTADO)
         */

        // NOTA* = Si hay dependencias no implementadas 
        //         el test no se puede probar al 100% (Regritros con valores null)

        public HorariosManager HMng = new HorariosManager();
        public Horarios h = new Horarios();

        [TestMethod]
        public void Create()
        {
            TimeSpan timeSalida=new TimeSpan(10, 0, 0);
            TimeSpan timeLLegada = new TimeSpan(22, 30, 0);

            //Arrange

            // ID es Incremental
            h.Id_Ruta = "402-TEST";  // ID de la ruta de prueba
            h.Id_Bus = "023"; // ID del bus
            h.Salida = "" ; //Time
            h.Llegada = ""; //Time
            h.Estado = "";

            //Act
            var resul = HMng.Create(h);

            //Assert
            Assert.IsInstanceOfType(resul, typeof(Horarios));
        }

        [TestMethod]
        public void RetrieveAll()
        {
            //Arrange

            //Act
            var list = HMng.RetrieveAll();

            //Assert
            CollectionAssert.AllItemsAreNotNull(list);
        }

        [TestMethod]
        public void RetrieveById()
        {
            //Arrange
            h.Id = "98";
            //Act
            var horario = HMng.RetrieveById(h);

            //Assert
            Assert.IsInstanceOfType(horario, typeof(Horarios));
        }

        [TestMethod]
        public void Update()
        {
            TimeSpan timeSalida = new TimeSpan(10, 0, 0);
            TimeSpan timeLLegada = new TimeSpan(22, 30, 0);

            //Arrange

            // ID es Incremental
            h.Id_Ruta = "402-TEST";  // ID de la ruta de prueba
            h.Id_Bus = "023"; // ID del bus
            h.Salida = ""; //Time
            h.Llegada = ""; //Time
            h.Estado = "";

            //Act
            var result = HMng.Update(h);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Delete()
        {
            //Arrange
            h.Id = "98";
            //Act
            HMng.Delete(h);
            //Assert
        }
    }
}
