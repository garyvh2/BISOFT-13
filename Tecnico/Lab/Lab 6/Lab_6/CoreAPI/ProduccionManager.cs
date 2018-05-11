using AccesoDatos.CRUD;
using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class ProduccionManager : BaseManager
    {
        // >> CRUD Factory
        private ProduccionCrudFactory crudProduccion;
        private TipoProduccionCrudFactory crudTipoProduccion;
        private AnimalCrudFactory crudAnimal;
        // >> Constructor
        public ProduccionManager()
        {
            crudProduccion = new ProduccionCrudFactory();
            crudTipoProduccion = new TipoProduccionCrudFactory();
            crudAnimal = new AnimalCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public Produccion Create(Produccion produccion)
        {
            try
            {
                var dbUser = crudProduccion.Retrieve<Produccion>(produccion);

                if (dbUser != null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(1);
                }

                var tipo = crudTipoProduccion.Retrieve<TipoProduccion>(new TipoProduccion()
                {
                    Id = produccion.IdTipoProduccion
                });

                if (tipo == null)
                {
                    throw new BussinessException(23);
                }

                var animal = crudAnimal.Retrieve<Animal>(new Animal()
                {
                    Id = produccion.IdAnimal
                });

                if (animal == null)
                {
                    throw new BussinessException(7);
                }


                var missingFields = CheckMissingFields(produccion, new string[] { "Id", "RangoInicial", "RangoFinal", "CategoriaAnimal" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                return produccion = crudProduccion.Create<Produccion>(produccion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public Produccion RetrieveById(Produccion produccion)
        {
            try
            {
                produccion = crudProduccion.Retrieve<Produccion>(produccion);

                return produccion;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<Produccion> RetrieveAll()
        {
            try
            {
                var produccions = crudProduccion.RetrieveAll<Produccion>();

                return produccions;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public Produccion Update(Produccion produccion)
        {
            try
            {
                var dbUser = crudProduccion.Retrieve<Produccion>(produccion);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                var missingFields = CheckMissingFields(produccion, new string[] { });
                missingFields.ForEach(missing =>
                {
                    produccion[missing] = dbUser[missing];
                });

                return produccion = crudProduccion.Update<Produccion>(produccion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(Produccion produccion)
        {
            try
            {
                var dbUser = crudProduccion.Retrieve<Produccion>(produccion);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                crudProduccion.Delete(produccion);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
