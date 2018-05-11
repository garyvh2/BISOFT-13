using CoreAPI.Managers.ArchitectureComponents;
using DataAccess.CRUD;
using DataAccess.MAPPER;
using Entities.Classes;
using Entities.Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Managers
{
    // >> ===================================================================================== <<
    // >> {Type}Manager <<
    // >> Es la clase encargada de procesar los datos sobre la logica del negocio
    // >> =====================================================================================
    public class PermisoManager : BaseManager, ICoreManager<Permiso>
    {
        // >> CRUD Factory
        private PermisoCrudFactory crudPermiso;
        // >> Constructor
        public PermisoManager()
        {
            crudPermiso = new PermisoCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public Permiso Create(Permiso permiso)
        {
            try
            {
                var missingFields = CheckMissingFields(permiso, new string[] { "Id", "Id_Rol" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                permiso = crudPermiso.Create(permiso);

                return permiso;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public Permiso RetrieveById(Permiso permiso)
        {
            try
            {
                permiso = crudPermiso.Retrieve(permiso);

                return permiso;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<Permiso> RetrieveAll()
        {
            try
            {
                var permiso = crudPermiso.RetrieveAll();

                return permiso;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public Permiso Update(Permiso permiso)
        {
            try
            {
                var dbUser = crudPermiso.Retrieve(permiso);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                var missingFields = CheckMissingFields(permiso, new string[] { });
                missingFields.ForEach(missing =>
                {
                    permiso[missing] = dbUser[missing];
                });

                return permiso = crudPermiso.Update(permiso);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(Permiso permiso)
        {
            try
            {
                var dbUser = crudPermiso.Retrieve(permiso);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                crudPermiso.Delete(permiso);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> 
        public List<Permiso> RetrieveAllByRol(Rol Rol)
        {
            try
            {
                var permisos = crudPermiso.RetrieveAllByRol(Rol);

                return permisos;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }

    }
}
