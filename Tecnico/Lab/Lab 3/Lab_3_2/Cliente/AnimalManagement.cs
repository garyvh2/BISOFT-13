using AccesoDatos.CRUD;
using Entidades;
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

        public void Create(Animal customer)
        {
            crudAnimal.Create(customer);
        }
        public Animal Retrieve(Animal animal)
        {
            return crudAnimal.Retrieve<Animal>(animal);
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
            crudAnimal.Update(animal);
        }
        public void Delete(Animal animal)
        {
            crudAnimal.Delete(animal);
        }
    }
}
