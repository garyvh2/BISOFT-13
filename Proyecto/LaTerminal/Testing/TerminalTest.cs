using CoreAPI.Managers;
using Entities.Entities;
using Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class TerminalTest 
    {
        // >> Dependencias
        /* 
         */

        public TerminalManager terminalMng = new TerminalManager();
        public Terminal t = new Terminal();

        
        [TestMethod]
        public void Create()
        {
            //Arrange

            t.CEDULA_JUR = "2-O345-532-TEST";
            t.NOMBRE = "Terminal-TEST";
            t.DIRECCION = "Direccion-TEST";
            t.LAT = 783;
            t.LONG = 982;
            t.TELEFONO = "89-65-40-20-TEST";
            t.CORREO = "terminal@correo.com-TEST";
            t.ESTADO = 1;

            //Act
            var resul = terminalMng.Create(t);

            //Assert
            Assert.IsInstanceOfType(resul, typeof(Terminal));
        }

        [TestMethod]
        public void RetrieveAll()
        {
            //Arrange

            //Act
            var list = terminalMng.RetrieveAll();

            //Assert
            CollectionAssert.AllItemsAreNotNull(list);
        }

        [TestMethod]
        public void RetrieveById()
        {
            //Arrange
            t.CEDULA_JUR = "1-O345-532-TEST";

            //Act
            var terminal = terminalMng.RetrieveById(t);

            //Assert
            Assert.IsInstanceOfType(terminal, typeof(Terminal));
        }

        [TestMethod]
        public void Update()
        {
            //Arrange

            t.CEDULA_JUR = "1-O345-532-TEST";
            t.NOMBRE = "UP-Terminal-TEST"; // Cambio
            t.DIRECCION = "UP-Direccion-TEST";
            t.LAT = 783;
            t.LONG = 982;
            t.TELEFONO = "UP-89-65-40-20-TEST";
            t.CORREO = "UP-@gmail.com";
            t.ESTADO = 1;

            //Act
            var resul = terminalMng.Update(t);
            //Assert
            Assert.IsNull(resul);
        }

        [TestMethod]
        public void Delete()
        {
            //Arrange
            t.CEDULA_JUR = "1-O345-532-TEST";

            //Act
            terminalMng.Delete(t);
            //Assert

        }
    }
}
