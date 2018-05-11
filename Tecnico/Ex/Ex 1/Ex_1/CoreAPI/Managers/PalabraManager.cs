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
    public class PalabraManager : BaseManager
    {
        // >> CRUD Factory
        private PalabraCrudFactory crudPalabra;
        private IdiomaCrudFactory crudIdioma;
        // >> Constructor
        public PalabraManager()
        {
            crudPalabra = new PalabraCrudFactory();
            crudIdioma = new IdiomaCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public Palabra Create(Palabra palabra)
        {
            try
            {
                var dbUser = crudPalabra.Retrieve<Palabra>(palabra);

                if (dbUser != null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(1);
                }

                var missingFields = CheckMissingFields(palabra, new string[] { "Id", "DiaSemana", "Popularidad" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                return palabra = crudPalabra.Create<Palabra>(palabra);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public Palabra RetrieveById(Palabra palabra)
        {
            try
            {
                palabra = crudPalabra.Retrieve<Palabra>(palabra);

                return palabra;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // Read by palabra
        public Palabra RetrieveByFamiliaAndIdioma(Palabra palabra)
        {
            try
            {
                palabra = crudPalabra.RetrieveByFamiliaAndIdioma<Palabra>(palabra);

                return palabra;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // Read by palabra
        public Palabra RetrieveByPalabra(Palabra palabra)
        {
            try
            {
                palabra = crudPalabra.RetrieveByPalabra<Palabra>(palabra);

                return palabra;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<Palabra> RetrieveAll()
        {
            try
            {
                var palabras = crudPalabra.RetrieveAll<Palabra>();

                return palabras;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> By Idioma
        public List<Palabra> RetrieveAllByIdioma(Idioma idioma)
        {
            try
            {
                var dbIdioma = crudIdioma.Retrieve<Idioma>(idioma);
                var palabras = crudPalabra.RetrieveAllByIdioma<Palabra>(dbIdioma);

                return palabras;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public Palabra Update(Palabra palabra)
        {
            try
            {
                var dbUser = crudPalabra.Retrieve<Palabra>(palabra);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                var missingFields = CheckMissingFields(palabra, new string[] {  });
                missingFields.ForEach(missing =>
                {
                    palabra[missing] = dbUser[missing];
                });

                return palabra = crudPalabra.Update<Palabra>(palabra);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(Palabra palabra)
        {
            try
            {
                var dbUser = crudPalabra.Retrieve<Palabra>(palabra);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                crudPalabra.Delete(palabra);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        // >>=========================================================================<<
        //                          >> Additional Operations <<
        // >>=========================================================================<<
        // >> Top 100 Palabras
        public List<Palabra> RetrieveTop100()
        {
            try
            {
                var palabras = crudPalabra.RetrieveTop100<Palabra>();

                return palabras;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Top 10 Palabras por dia
        public List<Palabra> RetrieveTop10Dia(Palabra palabra)
        {
            try
            {
                var palabras = crudPalabra.RetrieveTop10Dia<Palabra>(palabra);

                return palabras;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
    }
}
