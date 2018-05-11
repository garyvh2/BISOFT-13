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
    public class TraduccionManager : BaseManager
    {
        // >> CRUD Factory
        private TraduccionCrudFactory crudTraduccion;
        // >> Constructor
        public TraduccionManager()
        {
            crudTraduccion = new TraduccionCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public Traduccion Create(Traduccion traduccion)
        {
            try
            {
                var dbUser = crudTraduccion.Retrieve<Traduccion>(traduccion);

                if (dbUser != null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(1);
                }

                var missingFields = CheckMissingFields(traduccion, new string[] { "Id", "Popularidad_Total", "Id_Idioma", "Id_Traduccion" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                return traduccion = crudTraduccion.Create<Traduccion>(traduccion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public Traduccion RetrieveById(Traduccion traduccion)
        {
            try
            {
                traduccion = crudTraduccion.Retrieve<Traduccion>(traduccion);

                return traduccion;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<Traduccion> RetrieveAll()
        {
            try
            {
                var traduccions = crudTraduccion.RetrieveAll<Traduccion>();

                return traduccions;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public Traduccion Update(Traduccion traduccion)
        {
            try
            {
                var dbUser = crudTraduccion.Retrieve<Traduccion>(traduccion);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                var missingFields = CheckMissingFields(traduccion, new string[] { });
                missingFields.ForEach(missing =>
                {
                    traduccion[missing] = dbUser[missing];
                });

                return traduccion = crudTraduccion.Update<Traduccion>(traduccion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(Traduccion traduccion)
        {
            try
            {
                var dbUser = crudTraduccion.Retrieve<Traduccion>(traduccion);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                crudTraduccion.Delete(traduccion);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> Calcular Popularidad
        public Traduccion CalcularPopularidad(Traduccion traduccion)
        {
            try
            {
                var dbUser = crudTraduccion.Retrieve<Traduccion>(traduccion);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                traduccion = crudTraduccion.CalcularPopularidad<Traduccion>(traduccion);

                var missingFields = CheckMissingFields(traduccion, new string[] { });
                missingFields.ForEach(missing =>
                {
                    traduccion[missing] = dbUser[missing];
                });
                
                return traduccion = crudTraduccion.Update<Traduccion>(traduccion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
    }
}
