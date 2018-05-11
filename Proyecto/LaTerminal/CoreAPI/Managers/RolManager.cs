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
    public class RolManager : BaseManager, ICoreManager<Rol>
    {
        // >> CRUD Factory
        private RolCrudFactory crudRol;
        private PermisoCrudFactory crudPermiso;
        // >> Constructor
        public RolManager()
        {
            crudRol = new RolCrudFactory();
            crudPermiso = new PermisoCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public Rol Create(Rol rol)
        {
            var rollback = false;
            try
            {
                var permisos = rol.Permisos;

                // Debe haber algun permiso
                if (permisos == null || permisos.Count == 0)
                    throw new BussinessException(11);
                
                var missingFields = CheckMissingFields(rol, new string[] { "Id" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                // Crear Rol
                rol = crudRol.Create(rol);
                // Delete the rol if something happens after this
                rollback = true;

                // Asignar permisos
                permisos.ForEach(permiso =>
                {
                    permiso.Id_Rol = rol.Id;
                    crudRol.AsignarPermiso(permiso);
                });

                return rol;
            }
            catch (Exception ex)
            {
                if (rollback) crudRol.Delete(rol);
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public Rol RetrieveById(Rol rol)
        {
            try
            {
                rol = crudRol.Retrieve(rol);

                rol.Permisos = crudPermiso.RetrieveAllByRol(rol);

                return rol;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<Rol> RetrieveAll()
        {
            try
            {
                var roles = crudRol.RetrieveAll();

                roles.ForEach(rol =>
                {
                    rol.Permisos = crudPermiso.RetrieveAllByRol(rol);
                });


                return roles;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public Rol Update(Rol rol)
        {
            try
            {
                // El rol debe existir
                var dbRol = crudRol.Retrieve(rol);
                if (dbRol == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                // Debe haber algun permiso
                if (rol.Permisos == null || rol.Permisos.Count == 0)
                    throw new BussinessException(11);

                // >> Permisos asignados al rol
                var dbPermisos = crudPermiso.RetrieveAllByRol(rol);
                var dbPermisosId = dbPermisos.Select(permiso => permiso.Id).ToArray();

                // Buscar en target los permisos que no esten en source
                var porAsignar = rol.Permisos.FindAll(permiso => !dbPermisosId.Contains(permiso.Id));

                // Buscar en source los permisos que no esten en target
                var localPermisosId = rol.Permisos.Select(permiso => permiso.Id).ToArray();
                var porDesasignar = dbPermisos.FindAll(permiso => !localPermisosId.Contains(permiso.Id));

                // Hacer campos efectivos
                porAsignar.ForEach(permiso => 
                {
                    permiso.Id_Rol = rol.Id;
                    crudRol.AsignarPermiso(permiso);
                });
                porDesasignar.ForEach(permiso =>
                {
                    permiso.Id_Rol = rol.Id;
                    crudRol.DesasignarPermiso(permiso);
                });

                var missingFields = CheckMissingFields(rol, new string[] { });
                missingFields.ForEach(missing =>
                {
                    rol[missing] = dbRol[missing];
                });

                return rol = crudRol.Update(rol);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(Rol rol)
        {
            try
            {
                var dbUser = crudRol.Retrieve(rol);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                crudRol.Delete(rol);

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


    }
}
