using CoreAPI.Managers.ArchitectureComponents;
using DataAccess.CRUD;
using DataAccess.MAPPER;
using Entities.Classes;
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
    // >> ===================================================================================== <<
    public class HorariosManager : BaseManager, ICoreManager<Horarios>
    {
        // >> CRUD Factory
        private HorariosCrudFactory crudHorarios;
        // >> Constructor
        public HorariosManager()
        {
            crudHorarios = new HorariosCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public Horarios Create(Horarios horarios)
        {
            try
            {
                var dbUser = crudHorarios.Retrieve(horarios);

                if (dbUser != null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(1);
                }

                var missingFields = CheckMissingFields(horarios, new string[] { "porLetra" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                horarios = crudHorarios.Create(horarios);

                return horarios;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public Horarios RetrieveById(Horarios horarios)
        {
            try
            {
                horarios = crudHorarios.Retrieve(horarios);

                return horarios;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<Horarios> RetrieveAll()
        {
            try
            {
                var horarios = crudHorarios.RetrieveAll();

                return horarios;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public Horarios Update(Horarios horarios)
        {
            try
            {
                var dbUser = crudHorarios.Retrieve(horarios);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                var missingFields = CheckMissingFields(horarios, new string[] { });
                missingFields.ForEach(missing =>
                {
                    horarios[missing] = dbUser[missing];
                });

                return horarios = crudHorarios.Update(horarios);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(Horarios horarios)
        {
            try
            {
                var dbUser = crudHorarios.Retrieve(horarios);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                crudHorarios.Delete(horarios);

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

        public List<Horarios> ListarAsignaciones()
        {
            try
            {
                var EmpresaXterminal = crudHorarios.listarAsignacion();

                return EmpresaXterminal;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
    }
}
