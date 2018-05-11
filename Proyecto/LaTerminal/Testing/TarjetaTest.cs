using System;
using CoreAPI.Managers;
using Entities.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class TarjetaTest
    {
        // >> Dependencias
        /* Tener creado un usuario
         * Tener creado una terminal
         * Tener creado un tipo de tarjeta
         */
        public TarjetaManager tMng = new TarjetaManager();
        public Tarjeta t = new Tarjeta();

        [TestMethod]
        public void Create()
        {
            //Arrange
            t.Codigo = "87545-9849-098132G234-TEST";
            t.Id_Usuario = "4-098-582-TEST"; // Este es el ID del usuario de prueba
            t.Id_Terminal = "2-O345-532-TEST"; // Este es el ID de la terminal de prueba
            t.Id_Tipo = 1; // ID del tipo de tarjeta de prueba
            t.Saldo = 3850;
            t.Fecha_Emision = DateTime.Now;
            t.Fecha_Vencimiento = DateTime.Now.AddYears(2) ;
            t.Estado = "TEST";

            //Act
            var result = tMng.Create(t);
            //Assert
            Assert.IsInstanceOfType(result, typeof(Tarjeta));
        }

        [TestMethod]
        public void RetrieveAll()
        {
            //Arrange

            //Act
            var list = tMng.RetrieveAll();

            //Assert
            CollectionAssert.AllItemsAreNotNull(list);
        }

        [TestMethod]
        public void RetrieveById()
        {
            //Arrange
            t.Codigo = "87545-9849-098132G234-TEST";

            //Act
            var tarjeta = tMng.RetrieveById(t);

            //Assert
            Assert.IsInstanceOfType(tarjeta, typeof(Tarjeta));
        }

        [TestMethod]
        public void Update()
        {
            //Arrange
            t.Codigo = "87545-9849-098132G234-TEST";
            t.Id_Usuario = "4-098-582-TEST"; // Este es el ID del usuario de prueba
            t.Id_Terminal = "2-O345-532-TEST"; // Este es el ID de la terminal de prueba
            t.Id_Tipo = 1; // ID del tipo de tarjeta de prueba
            t.Saldo = 0;
            t.Fecha_Emision = DateTime.Now;
            t.Fecha_Vencimiento = DateTime.Now.AddYears(2);
            t.Estado = "TEST";
            //Act
            var resul = tMng.Update(t);
            //Assert
            Assert.IsNull(resul);
        }

        [TestMethod]
        public void Delete()
        {
            //Arrange
            t.Codigo = "87545-9849-098132G234-TEST";

            //Act
            tMng.Delete(t);
            //Assert
        }

        [TestMethod]
        public void Recargar()
        {
            //Arrange
            t.Id_Usuario = "4-098-582-TEST";
            t.Saldo = 200;

            //Act
            var resul = tMng.Recargar(t);

            //Assert
            Assert.IsTrue(resul);
        }

        [TestMethod]
        public void Reponer()
        {
            //Arrange
            t.Id_Usuario = "4-098-582-TEST";
            t.Saldo = 100;

            //Act
            var resul = tMng.Reponer(t);

            //Assert
            Assert.IsTrue(resul);
        }

        [TestMethod]
        public void solicitarTarjetaUsJuridico()
        {
            //Arrange
            t.Id_Usuario = "4-098-582-TEST"; // ID de usuario juridico
            t.Saldo = 3000;

            var cantEstudiantes = 5;
            var cantTuristas = 5;

            Terminal terminal = new Terminal();
            TerminalManager terminalManager = new TerminalManager();
            terminal.CEDULA_JUR = "2-O345-532-TEST";
            terminal = terminalManager.RetrieveById(terminal);

            //Act
            var resul = tMng.solicitarTarjetaUsJuridico(t, cantTuristas, cantEstudiantes, terminal);

            //Assert
            Assert.IsTrue(resul);
        }
    }
}
