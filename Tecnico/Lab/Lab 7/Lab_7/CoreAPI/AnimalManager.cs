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
    public class AnimalManager : BaseManager
    {
        // >> CRUD Factory
        private AnimalCrudFactory crudAnimal;
        // >> Constructor
        public AnimalManager()
        {
            crudAnimal = new AnimalCrudFactory();
        }
        // >>=========================================================================<<
        //                          >> BASIC CRUD Operations <<
        // >>=========================================================================<<
        // >> Create
        public Animal Create(Animal animal)
        {
            try
            {
                var dbUser = crudAnimal.Retrieve<Animal>(animal);

                if (dbUser != null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(1);
                }
                

                var missingFields = CheckMissingFields(animal, new string[] { "Id" });
                if (missingFields.Count > 0)
                    throw new BussinessException(2, ": " + String.Join(",", missingFields.ToArray()));

                return animal = crudAnimal.Create<Animal>(animal);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Read
        public Animal RetrieveById(Animal animal)
        {
            try
            {
                animal = crudAnimal.Retrieve<Animal>(animal);

                return animal;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> List
        public List<Animal> RetrieveAll()
        {
            try
            {
                var animals = crudAnimal.RetrieveAll<Animal>();

                return animals;
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Update
        public Animal Update(Animal animal)
        {
            try
            {
                var dbUser = crudAnimal.Retrieve<Animal>(animal);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                var missingFields = CheckMissingFields(animal, new string[] { });
                missingFields.ForEach(missing =>
                {
                    animal[missing] = dbUser[missing];
                });

                return animal = crudAnimal.Update<Animal>(animal);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return null;
            }
        }
        // >> Delete
        public void Delete(Animal animal)
        {
            try
            {
                var dbUser = crudAnimal.Retrieve<Animal>(animal);

                if (dbUser == null)
                {
                    // >> Object is already on the DB
                    throw new BussinessException(3);
                }

                crudAnimal.Delete(animal);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
