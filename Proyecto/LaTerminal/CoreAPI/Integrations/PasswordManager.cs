using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using Exceptions;
using System.Security;
using System.Web.Security;
using Entities.Entities;
using DataAccess.CRUD;
using DataAccess.CRUD.ArchitectureComponents;

namespace CoreAPI.Integrations
{
    public class PasswordManager
    {
        //PasswordManager Instance
        private static PasswordManager Instance;
        // Crud Persona Claves
        private static Persona_ClaveCrudFactory crudClaves;
        // Crud Usuario
        private static UsuarioCrudFactory crudUsuario;
        // Salt
        private string _salt = "*1234567890!@#$%^&*()14344*";

        // >> Constructor
        private PasswordManager()
        {
        }
        // >> Singleton Return Instance
        public static PasswordManager GetInstance()
        {
            // If the instance is undefined then create it
            if (Instance == null)
            {
                // >> Email Manager Instantiation
                Instance = new PasswordManager();
                crudClaves = new Persona_ClaveCrudFactory();
                crudUsuario = new UsuarioCrudFactory();
            }
            // Otherwise return the instance
            return Instance;
        }
        
        //Random Password Generator
        public bool VerificarClavesAnteriores (Usuario usuario)
        {
            try
            {
                var valida = true;

                var historial = crudClaves.UltimasClaves(usuario);
                if (historial.Count == 0)
                    return valida;
               
                historial.ForEach(registro =>
                {
                    if (registro.Clave == usuario.Clave)
                        valida = false;
                });

                return valida;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return false;
            }
        }
        

        //Random Password Generator
        public string GenerateRandom(int length = 12, int Number = 4)
        {
            return Membership.GeneratePassword(length, Number);
        }
        //MD5 Hasher
        public string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(Encoding.UTF8.GetBytes(_salt + text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

    }
}
