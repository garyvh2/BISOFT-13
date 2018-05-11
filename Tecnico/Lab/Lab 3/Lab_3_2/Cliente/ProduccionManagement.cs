using AccesoDatos.CRUD;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    public class ProduccionManagement
    {
        private ProduccionCrudFactory crudProduccion;

        public ProduccionManagement()
        {
            crudProduccion = new ProduccionCrudFactory();
        }

        public void Create(Produccion customer)
        {
            crudProduccion.Create(customer);
        }
        public Produccion Retrieve(Produccion Produccion)
        {
            return crudProduccion.Retrieve<Produccion>(Produccion);
        }
        public List<Produccion> RetrieveAll()
        {
            return crudProduccion.RetrieveAll<Produccion>();
        }
        public List<Produccion> RetrieveAllByAnimal(Animal animal)
        {
            return crudProduccion.RetrieveAllByAnimal<Produccion>(animal);
        }
        public List<Produccion> RetrieveAllByRango (Produccion produccion)
        {
            return crudProduccion.RetrieveAllByRango<Produccion>(produccion);
        }
        public List<Produccion> RetrieveAllByRangoCategoria(Produccion produccion)
        {
            return crudProduccion.RetrieveAllByRangoCategoria <Produccion>(produccion);
        }
        public void Update(Produccion Produccion)
        {
            crudProduccion.Update(Produccion);
        }
        public void Delete(Produccion Produccion)
        {
            crudProduccion.Delete(Produccion);
        }
    }
}
