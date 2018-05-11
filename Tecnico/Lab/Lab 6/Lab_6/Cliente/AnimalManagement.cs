using AccesoDatos.CRUD;
using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    public class AnimalManagement
    {
        private AnimalCrudFactory crudAnimal;

        public AnimalManagement()
        {
            crudAnimal = new AnimalCrudFactory();
        }

        public void Create(Animal animal)
        {
            try
            {
                var a = crudAnimal.Retrieve<Animal>(animal);

                if (a != null)
                {
                    //Animal already exist
                    throw new BussinessException(3);
                }

                a = crudAnimal.RetrieveByNombre<Animal>(animal);

                if (a != null)
                {
                    //Animal with same name exist
                    throw new BussinessException(4);
                }

                DateTime today = DateTime.Now.AddDays(-1);
                DateTime lessThanToday = new DateTime(today.Year, today.Month, today.Day -1, 23, 59, 59);


                if (DateTime.Compare(lessThanToday, animal.FechaNac) <= 0)
                {
                    // Animal should be born less than current day
                    throw new BussinessException(5);
                }

                if (animal.Edad >= 0.6 && GetAgeInMonths(animal.FechaNac) > 6)
                    crudAnimal.Create(animal);
                else
                    throw new BussinessException(2);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        public Animal Retrieve(Animal animal)
        {
            return crudAnimal.Retrieve<Animal>(animal);
        }
        public Animal RetrieveByNombre(Animal animal)
        {
            return crudAnimal.RetrieveByNombre<Animal>(animal);
        }
        public List<Animal> RetrieveAll()
        {
            return crudAnimal.RetrieveAll<Animal>();
        }
        public List<Animal> RetrieveAllByCategoria(Animal animal)
        {
            return crudAnimal.RetrieveAllByCategoria<Animal>(animal);
        }
        public List<Animal> RetrieveAllByNombre(Animal animal)
        {
            return crudAnimal.RetrieveAllByNombre<Animal>(animal);
        }
        public void Update(Animal animal)
        {
            try
            {
                DateTime today = DateTime.Now.AddDays(-1);
                DateTime lessThanToday = new DateTime(today.Year, today.Month, today.Day - 1, 23, 59, 59);


                if (DateTime.Compare(lessThanToday, animal.FechaNac) <= 0)
                {
                    // Animal should be born less than current day
                    throw new BussinessException(5);
                }

                if (animal.Edad >= 0.6 && GetAgeInMonths(animal.FechaNac) > 6)
                    crudAnimal.Update(animal);
                else
                    throw new BussinessException(2);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        public void Delete(Animal animal)
        {
            crudAnimal.Delete(animal);
        }
        public double GetAgeInMonths(DateTime date)
        {
            // >> Current Date
            var today = DateTime.Today;

            // >> Months
            int months = today.Month - date.Month;
            // >> Years
            int years = today.Year - date.Year;
            
            if (today.Day < date.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            return Double.Parse((years * 12 + months).ToString());
        }
    }
}
