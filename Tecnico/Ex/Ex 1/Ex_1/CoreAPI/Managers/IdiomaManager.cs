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
    public class IdiomaManager : BaseManager
    {
        // >> CRUD Factory
        private IdiomaCrudFactory crudIdioma;
        // >> Constructor
        public IdiomaManager()
        {
            crudIdioma = new IdiomaCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public Idioma Create(Idioma idioma)
        {
            try
            {
                var dbUser = crudIdioma.Retrieve<Idioma>(idioma);

                if (dbUser != null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(1);
                }

                var missingFields = CheckMissingFields(idioma, new string[] { "Id", "Popularidad" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                return idioma = crudIdioma.Create<Idioma>(idioma);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public Idioma RetrieveById(Idioma idioma)
        {
            try
            {
                idioma = crudIdioma.Retrieve<Idioma>(idioma);

                return idioma;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<Idioma> RetrieveAll()
        {
            try
            {
                var idiomas = crudIdioma.RetrieveAll<Idioma>();

                return idiomas;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public Idioma Update(Idioma idioma)
        {
            try
            {
                var dbUser = crudIdioma.Retrieve<Idioma>(idioma);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                var missingFields = CheckMissingFields(idioma, new string[] { });
                missingFields.ForEach(missing =>
                {
                    idioma[missing] = dbUser[missing];
                });

                return idioma = crudIdioma.Update<Idioma>(idioma);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(Idioma idioma)
        {
            try
            {
                var dbUser = crudIdioma.Retrieve<Idioma>(idioma);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                crudIdioma.Delete(idioma);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> Obtener mas popular
        public Idioma RetrieveMasPopular()
        {
            try
            {
                var idioma = crudIdioma.RetrieveMasPopular<Idioma>();

                return idioma;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
    }
}
