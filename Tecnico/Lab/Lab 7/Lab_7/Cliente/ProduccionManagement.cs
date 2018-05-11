using AccesoDatos.CRUD;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Cliente
{
    public class ProduccionManagement
    {
        private ProduccionCrudFactory crudProduccion;
        private AnimalCrudFactory crudAnimal;

        public ProduccionManagement()
        {
            crudProduccion = new ProduccionCrudFactory();
            crudAnimal = new AnimalCrudFactory();
        }

        public void Create(Produccion produccion)
        {
            try
            {
                var a = crudProduccion.Retrieve<Animal>(produccion);

                if (a != null)
                {
                    //Produccion already exist
                    throw new BussinessException(3);
                }

                Animal animal = new Animal();
                animal.Id = produccion.IdAnimal;

                a = crudAnimal.Retrieve<Animal>(animal);

                if (a == null)
                {
                    //Produccion already exist
                    throw new BussinessException(23);
                }



                if (produccion.Cantidad > 0 && produccion.Valor > 0)
                    // Se que esto es un hyper bad practice, pero es la unica forma que se me ocurrio de momento para no tener que cambiar demasiado
                    /*switch (a.Categoria)
                    {
                        case "Cerdo":
                            if (produccion.Tipo == "Carne")
                            {
                                crudProduccion.Create(produccion);
                            }
                            else
                            {
                                throw new BussinessException(8);
                            }
                            break;
                        case "Vaca":
                            if (produccion.Tipo == "Leche" && a.Genero == "Hembra")
                            {
                                crudProduccion.Create(produccion);
                            }
                            else if (produccion.Tipo == "Carne" && a.Genero == "Macho")
                            {
                                crudProduccion.Create(produccion);
                            }
                            else
                            {
                                throw new BussinessException(9);
                            }
                            break;
                        case "Gallina":
                            if (produccion.Tipo == "Huevos" && a.Genero == "Hembra")
                            {
                                crudProduccion.Create(produccion);
                            }
                            else if (produccion.Tipo == "Carne" && a.Genero == "Macho")
                            {
                                crudProduccion.Create(produccion);
                            }
                            else
                            {
                                throw new BussinessException(10);
                            }
                            break;
                        default:
                            throw new BussinessException(11);
                    }*/
                    crudProduccion.Create(produccion);
                else
                    throw new BussinessException(6);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
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
        public void Update(Produccion produccion)
        {
            try
            {

                Animal animal = new Animal();
                animal.Id = produccion.IdAnimal;

                var a = crudAnimal.Retrieve<Animal>(animal);

                if (a == null)
                {
                    //Animal doesn't exist
                    throw new BussinessException(7);
                }



                if (produccion.Cantidad > 0 && produccion.Valor > 0)
                    // Se que esto es un hyper bad practice, pero es la unica forma que se me ocurrio de momento para no tener que cambiar demasiado
                    /*switch (a.Categoria)
                    {
                        case "Cerdo":
                            if (produccion.Tipo == "Carne")
                            {
                                crudProduccion.Update(produccion);
                            }
                            else
                            {
                                throw new BussinessException(8);
                            }
                            break;
                        case "Vaca":
                            if (produccion.Tipo == "Leche" && a.Genero == "Hembra")
                            {
                                crudProduccion.Update(produccion);
                            }
                            else if (produccion.Tipo == "Carne" && a.Genero == "Macho")
                            {
                                crudProduccion.Update(produccion);
                            }
                            else
                            {
                                throw new BussinessException(9);
                            }
                            break;
                        case "Gallina":
                            if (produccion.Tipo == "Huevos" && a.Genero == "Hembra")
                            {
                                crudProduccion.Update(produccion);
                            }
                            else if (produccion.Tipo == "Carne" && a.Genero == "Macho")
                            {
                                crudProduccion.Update(produccion);
                            }
                            else
                            {
                                throw new BussinessException(10);
                            }
                            break;*/
                            crudProduccion.Update(produccion);
                    
                        /*default:
                            throw new BussinessException(11);*/
                    
                else
                    throw new BussinessException(6);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        public void Delete(Produccion Produccion)
        {
            crudProduccion.Delete(Produccion);
        }
    }
}
