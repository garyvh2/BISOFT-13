using System;
using CoreAPI.Managers;
using Entities.Entities;
using Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class UsuarioTest
    {
        
        public UsuarioManager uMng = new UsuarioManager();
        public Usuario u = new Usuario();

        [TestMethod]
        public void Create()
        {
            ////Arrange
            u.Identificacion = "4-098-582-TEST";
            u.Id_Rol = 1; 
            u.PNombre = "Kristin-TEST";
            u.SApellido = "Sofia-TEST";
            u.PApellido = "Gonzales-TEST";
            u.SApellido = "Carpiñia";
            u.Genero = "2";
            u.Fecha_Nac = DateTime.Parse("05/08/1996");
            u.Telefono = "85-34-71-60-TEST";
            u.Correo = "ksofiag@gemail.com-TEST";
            u.Direccion = "San Jose,Costa Rica-TEST";
            u.Clave = "kris96love236-TEST";
            u.Clave_Salt = "sdfweaferg3244gw";

            //Act

            var result = uMng.Create(u);


            //Assert
            Assert.IsInstanceOfType(result, typeof(Usuario));
        }

        [TestMethod]
        public void RetrieveAll()
        {
            //Arrange

            //Act
            var list = uMng.RetrieveAll();
            //Assert
            CollectionAssert.AllItemsAreNotNull(list);
        }

        [TestMethod]
        public void RetrieveById()
        {
            //Arrange
           u.Identificacion = "4-098-582-TEST";

            //Act
            var usuario = uMng.RetrieveById(u);

            //Assert
            Assert.IsInstanceOfType(usuario, typeof(Usuario));

        }

        [TestMethod]
        public void Update()
        {
            ////Arrange
            u.Identificacion = "4-098-582-TEST";
            //u.Id_Rol = 1;  //EN la base de datos es un INT y en las entidades es un String
            u.PNombre = "Kristin-TEST";
            u.SApellido = "Sofia-TEST";
            u.PApellido = "Gonzales-TEST";
            u.SApellido = "Carpiñia";
            u.Genero = "2";
            u.Fecha_Nac = DateTime.Parse("05/08/1996");
            u.Telefono = "85-34-71-60-TEST";
            u.Correo = "ksofiag@gemail.com-TEST";
            u.Direccion = "San Jose,Costa Rica-TEST";
            u.Clave = "kris96love236-TEST";
            u.Clave_Salt = "sdfweaferg3244gw";

            //Act
            var resul = uMng.Update(u);
            //Assert
            Assert.IsNull(resul);
        }

        [TestMethod]
        public void Delete()
        {
            //Arrange
            u.Identificacion = "4-098-582-TEST";

            //Act
            uMng.Delete(u);
            //Assert
        }

        [TestMethod]
        public void Login()
        {
            //Arrange
            u.Correo = "quantumcodingcr@gmail.com";
            u.Clave = "C@pz!hTX+$9l";

            //Act
            var resul = uMng.Login(u);

            //Assert
            Assert.IsInstanceOfType(resul, typeof(Usuario));
        }

        [TestMethod]
        public void Recover()
        {
            //Arrange
            u.Correo = "quantumcodingcr@gmail.com";

            //Act
            var resul = uMng.Recover(u);

            //Assert
            Assert.IsInstanceOfType(resul, typeof(Usuario));
        }
    }
}
