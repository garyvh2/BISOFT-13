using AccesoDatos.CRUD;
using Entidades.Classes;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Managers
{
    public class UsuarioManager : BaseManager
    {
        // >> CRUD Factory
        private UsuarioCrudFactory crudUsuario;
        // >> Constructor
        public UsuarioManager()
        {
            crudUsuario = new UsuarioCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public Usuario Create(Usuario usuario)
        {
            try
            {
                var dbUser = crudUsuario.Retrieve<Usuario>(usuario);

                if (dbUser != null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(1);
                }

                var missingFields = CheckMissingFields(usuario, new string[] { "Id" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));
                
                return usuario = crudUsuario.Create<Usuario>(usuario);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public Usuario RetrieveById(Usuario usuario)
        {
            try
            {
                usuario = crudUsuario.Retrieve<Usuario>(usuario);

                return usuario;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<Usuario> RetrieveAll()
        {
            try
            {
                var usuarios = crudUsuario.RetrieveAll<Usuario>();

                return usuarios;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public Usuario Update(Usuario usuario)
        {
            try
            {
                var dbUser = crudUsuario.Retrieve<Usuario>(usuario);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                var missingFields = CheckMissingFields(usuario, new string[] { });
                missingFields.ForEach(missing =>
                {
                    usuario[missing] = dbUser[missing];
                });

                return usuario = crudUsuario.Update<Usuario>(usuario);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(Usuario usuario)
        {
            try
            {
                var dbUser = crudUsuario.Retrieve<Usuario>(usuario);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                crudUsuario.Delete(usuario);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
