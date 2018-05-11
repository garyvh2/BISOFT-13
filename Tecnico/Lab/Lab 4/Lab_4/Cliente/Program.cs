using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    class Program
    {
        private static AnimalManagement mngAnimal;
        private static ProduccionManagement mngProduccion;
        static void Main(string[] args)
        {
            // Initialize global variables
            mngAnimal = new AnimalManagement();
            mngProduccion = new ProduccionManagement();


            Console.WriteLine("La Granja de Animales de Cenfotec");

            int operacion;
            do
            {
                Console.Clear();
                DisplayMenu();

                // Select option

                if (Int32.TryParse(Console.ReadLine(), out operacion))
                {

                    Console.Clear();
                    switch (operacion)
                    {
                        case 1:
                            DisplayAnimalesMantenimiento();
                            break;
                        case 2:
                            DisplayConsultaAnimales();
                            break;
                        case 3:
                            DisplayConsultaProduccion();
                            break;
                        case -1:
                            Console.WriteLine("Gracias por utilzar el sistema. Adios");
                            Console.ReadKey();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("El valor ingresado no es una opcion valida");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("El valor ingresado no es un numero valido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
            } while (operacion != -1);
        }
        // ============================================================
        //      Sub Menus De Mantenimiento
        // ============================================================
        private static void DisplayAnimalesMantenimiento()
        {
            string option;
            do
            {
                option = "";
                try
                {
                    Console.Clear();
                    // Get Animales
                    Console.WriteLine("Animales:");
                    Console.WriteLine("");
                    List<int> options = MostrarAnimales();
                    Console.WriteLine("");
                    Console.WriteLine("Escoja un animal o escriba 'crear' ('atras' para retroceder)");

                    // Option processing
                    int selectedId;
                    option = Console.ReadLine();
                    if (option == "atras")
                    {
                        Console.Clear();
                        Console.WriteLine("Actualmente:");
                        MostrarAnimales();
                        Console.WriteLine("Presione cualquier tecla para continuar ...");
                        Console.ReadKey();
                    }
                    else if (option == "crear")
                    {
                        // Crear Animal
                        Animal AnimalNuevo = new Animal();
                        ObtenerDatosAnimal(ref AnimalNuevo);
                        mngAnimal.Create(AnimalNuevo);
                    }
                    else if (Int32.TryParse(option, out selectedId))
                    {
                        // If the selected id is within the contained values
                        if (options.Contains(selectedId))
                        {
                            // Get selected Object
                            Animal AnimalActual = new Animal() {Id = selectedId};
                            AnimalActual = mngAnimal.Retrieve(AnimalActual);

                            int operacion;
                            bool completado = false;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine(AnimalRowBuilder(AnimalActual));
                                Console.WriteLine();
                                SubCRUDsAnimal();
                                // Select option
                                if (Int32.TryParse(Console.ReadLine(), out operacion))
                                {
                                    switch (operacion)
                                    {
                                        case 1:
                                            // Registrar Produccion
                                            Console.Clear();
                                            DisplayProduccionMantenimiento(AnimalActual);
                                            completado = true;
                                            break;
                                        case 2:
                                            // Eliminar
                                            DialogResult dialogResult = MessageBox.Show(
                                                "Todos los registros de produccion para este animal seran aliminados",
                                                "Eliminacion recursiva", MessageBoxButtons.YesNo);
                                            if (dialogResult == DialogResult.Yes)
                                            {
                                                mngAnimal.Delete(AnimalActual);
                                                completado = true;
                                            }

                                            break;
                                        case 3:
                                            // Actualizar
                                            ObtenerDatosAnimal(ref AnimalActual, true);
                                            mngAnimal.Update(AnimalActual);
                                            completado = true;
                                            break;
                                        case 4:
                                            // Cancelar
                                            completado = true;
                                            break;
                                        default:
                                            Console.Clear();
                                            Console.WriteLine("El valor ingresado no es una opcion valida");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("El valor ingresado es invalido");
                                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                                    Console.ReadKey();
                                }
                            } while (completado != true);
                        }
                        // Otherwise show an error
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("El valor ingresado no es parte de los disponibles");
                            Console.WriteLine("Presione cualquier tecla para continuar ...");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("El valor ingresado es invalido");
                        Console.WriteLine("Presione cualquier tecla para continuar ...");
                        Console.ReadKey();
                    }

                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    BussinessException bex = (BussinessException) ex;
                    MessageBox.Show(bex.AppMessage.Message);
                }
            } while (option != "atras");

        }
        private static void DisplayProduccionMantenimiento(Animal animal)
        {
            string option;
            do
            {
                // Get Animales
                Console.WriteLine(AnimalRowBuilder(animal));
                Console.WriteLine("");
                Console.WriteLine("Produccion:");
                Console.WriteLine("");
                List<int> options = MostrarProduccionesPorAnimal(animal);
                Console.WriteLine("");
                Console.WriteLine("Escoja una produccion o escriba 'crear' ('atras' para retroceder)");

                // Option processing
                int selectedId;
                option = Console.ReadLine();
                if (option == "atras")
                {
                    Console.Clear();
                    Console.WriteLine("Actualmente:");
                    MostrarProduccionesPorAnimal(animal);
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
                else if (option == "crear")
                {
                    // Crear Animal
                    Produccion ProduccionNuevo = new Produccion();
                    ObtenerDatosProduccion(ref ProduccionNuevo);
                    ProduccionNuevo.IdAnimal = animal.Id;
                    mngProduccion.Create(ProduccionNuevo);
                }
                else if (Int32.TryParse(option, out selectedId))
                {
                    // If the selected id is within the contained values
                    if (options.Contains(selectedId))
                    {
                        // Get selected Object
                        Produccion ProduccionActual = new Produccion() { Id = selectedId };
                        ProduccionActual = mngProduccion.Retrieve(ProduccionActual);

                        int operacion;
                        bool completado = false;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine(ProduccionRowBuilder(ProduccionActual));
                            Console.WriteLine();
                            SubCRUDsProduccion();
                            // Select option
                            if (Int32.TryParse(Console.ReadLine(), out operacion))
                            {
                                switch (operacion)
                                {
                                    case 1:
                                        // Eliminar
                                        mngProduccion.Delete(ProduccionActual);
                                        completado = true;
                                        break;
                                    case 2:
                                        // Actualizar
                                        ObtenerDatosProduccion(ref ProduccionActual, true);
                                        ProduccionActual.IdAnimal = animal.Id;
                                        mngProduccion.Update(ProduccionActual);
                                        completado = true;
                                        break;
                                    case 3:
                                        // Cancelar
                                        completado = true;
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("El valor ingresado no es una opcion valida");
                                        break;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("El valor ingresado es invalido");
                                Console.WriteLine("Presione cualquier tecla para continuar ...");
                                Console.ReadKey();
                            }
                        } while (completado != true);
                    }
                    // Otherwise show an error
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("El valor ingresado no es parte de los disponibles");
                        Console.WriteLine("Presione cualquier tecla para continuar ...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
                Console.Clear();
            } while (option != "atras");

        }
        private static void DisplayConsultaProduccion()
        {
            string option;
            // Get Animales
            int consulta;
            bool result;
            do
            {
                Console.Clear();
                DisplayConsultasProduccion();

                option = Console.ReadLine();

                // Select option
                if (option == "atras")
                {
                    Console.Clear();
                }
                else if (Int32.TryParse(option, out consulta))
                {
                    Produccion ProduccionConsulta = new Produccion();
                    switch (consulta)
                    {
                        case 1:
                            // Consultar produccion por rango
                            ObtenerDatosConsultaProduccion(ref ProduccionConsulta);
                            Console.Clear();
                            result = MostrarProduccionesPorRango(ProduccionConsulta);
                            if (result)
                            {
                                Console.ReadKey();
                                Console.Clear();
                            }
                            // Consultar
                            break;
                        case 2:
                            // Consutlar produccion por rango y categoria
                            ObtenerDatosConsultaProduccion(ref ProduccionConsulta);
                            // Categoria
                            do
                            {
                                Console.WriteLine("Ingrese la categoria de animal");
                                ProduccionConsulta.CategoriaAnimal = Console.ReadLine();
                            } while (!(ProduccionConsulta.CategoriaAnimal is string));
                            Console.Clear();
                            result = MostrarProduccionesPorRangoCategoria(ProduccionConsulta);
                            if (result)
                            {
                                Console.ReadKey();
                                Console.Clear();
                            }
                            // Consultar
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("El valor ingresado no es una opcion valida");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
            } while (option != "atras");

        }
        private static void DisplayConsultaAnimales()
        {
            string option;
            // Get Produccion
            int consulta;
            bool result;
            do
            {
                Console.Clear();
                DisplayConsultasAnimal();

                option = Console.ReadLine();

                // Select option
                if (option == "atras")
                {
                    Console.Clear();
                }
                else if (Int32.TryParse(option, out consulta))
                {
                    Animal AnimalConsulta = new Animal();
                    switch (consulta)
                    {
                        case 1:
                            // Consultar produccion por rango
                            do
                            {
                                Console.WriteLine("Ingrese la categoria de animal");
                                AnimalConsulta.Categoria = Console.ReadLine();
                            } while (!(AnimalConsulta.Categoria is string));
                            Console.Clear();
                            result = MostrarAnimalesPorCategoria(AnimalConsulta);
                            if (result)
                            {
                                Console.ReadKey();
                                Console.Clear();
                            }
                            // Consultar
                            break;
                        case 2:
                            // Consultar produccion por rango
                            do
                            {
                                Console.WriteLine("Ingrese el nombre de animal");
                                AnimalConsulta.Nombre = Console.ReadLine();
                            } while (!(AnimalConsulta.Nombre is string));
                            Console.Clear();
                            result = MostrarAnimalesPorNombre(AnimalConsulta);
                            if (result)
                            {
                                Console.ReadKey();
                                Console.Clear();
                            }
                            // Consultar
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("El valor ingresado no es una opcion valida");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
            } while (option != "atras");

        }
        // ============================================================
        //      Obtencion de datos
        // ============================================================
        private static void ObtenerDatosAnimal(ref Animal animal, Boolean update = false)
        {
            // Flag to know when the value is valid
            bool selected;
            string value;
            // Nombre
            do
            {
                Console.WriteLine("Ingrese el nombre del animal");
                if (update) Console.WriteLine("Actual: " + animal.Nombre);
                value = Console.ReadLine();
                if (value == "")
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("");
                }
                else
                {
                    animal.Nombre = value;
                }
            } while (!(animal.Nombre is string) || value == "");
            // Categoria
            do
            {
                Console.WriteLine("Ingrese la categoria del animal");
                if (update) Console.WriteLine("Actual: " + animal.Categoria);
                value = Console.ReadLine();
                if (value == "")
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("");
                }
                else
                {
                    animal.Categoria = value;
                }
            } while (!(animal.Categoria is string) || value == "");
            // Alimento
            do
            {
                Console.WriteLine("Ingrese el alimento favorito del animal");
                if (update) Console.WriteLine("Actual: " + animal.Alimento);
                value = Console.ReadLine();
                if (value == "")
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("");
                }
                else
                {
                    animal.Alimento = value;
                }
            } while (!(animal.Alimento is string) || value == "");
            // Edad
            selected = false;
            do
            {
                Console.WriteLine("Ingrese la edad del animal");
                if (update) Console.WriteLine("Actual: " + animal.Edad.ToString());
                double edad;
                if (Double.TryParse(Console.ReadLine(), out edad))
                {
                    animal.Edad = edad;
                    selected = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
            } while (selected != true);
            // Fecha Nac
            selected = false;
            do
            {
                Console.WriteLine("Ingrese la fecha de nacimiento del animal");
                if (update) Console.WriteLine("Actual: " + animal.FechaNac);
                DateTime fechaNac;
                if (DateTime.TryParse(Console.ReadLine(), out fechaNac))
                {
                    animal.FechaNac = fechaNac;
                    selected = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
            } while (selected != true);
            // Genero
            do
            {
                Console.WriteLine("Ingrese el genero del animal");
                if (update) Console.WriteLine("Actual: " + animal.Genero);
                value = Console.ReadLine();
                if (value == "")
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("");
                }
                else
                {
                    animal.Genero = value;
                }
            } while (!(animal.Genero is string) || value == "");
        }
        private static void ObtenerDatosProduccion(ref Produccion produccion, Boolean update = false)
        {
            // Flag to know when the value is valid
            bool selected;
            string value;
            // Fecha de produccion
            produccion.FechaReg = DateTime.Now;

            // Tipo de produccion
            do
            {
                Console.WriteLine("Ingrese el tipo de produccion");
                if (update) Console.WriteLine("Actual: " + produccion.Tipo);
                produccion.Tipo = Console.ReadLine();
                value = Console.ReadLine();
                if (value == "")
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("");
                }
                else
                {
                    produccion.Tipo = value;
                }
            } while (!(produccion.Tipo is string) || value == "");
            // Cantidad de producccion
            selected = false;
            do
            {
                Console.WriteLine("Ingrese la cantidad de produccion");
                if (update) Console.WriteLine("Actual: " + produccion.Cantidad.ToString());
                double cantidad;
                if (Double.TryParse(Console.ReadLine(), out cantidad))
                {
                    produccion.Cantidad = cantidad;
                    selected = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
            } while (selected != true);
            // Valor de producccion
            selected = false;
            do
            {
                Console.WriteLine("Ingrese el valor de produccion");
                if (update) Console.WriteLine("Actual: " + produccion.Valor.ToString());
                double valor;
                if (Double.TryParse(Console.ReadLine(), out valor))
                {
                    produccion.Valor = valor;
                    selected = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
            } while (selected != true);

        }
        private static void ObtenerDatosConsultaProduccion(ref Produccion produccion)
        {
            // Flag to know when the value is valid
            bool selected;

            // Rango Inicial
            selected = false;
            do
            {
                Console.WriteLine("Ingrese el rango de fecha inicial");
                DateTime rangoInicial;
                if (DateTime.TryParse(Console.ReadLine(), out rangoInicial))
                {
                    produccion.RangoInicial = rangoInicial;
                    selected = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
            } while (selected != true);
            // Rango Final
            selected = false;
            do
            {
                Console.WriteLine("Ingrese el rango de fecha final");
                DateTime rangoFinal;
                if (DateTime.TryParse(Console.ReadLine(), out rangoFinal))
                {
                    produccion.RangoFinal = rangoFinal;
                    selected = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
            } while (selected != true);
        }
        // ============================================================
        //      Metodos de impresion
        // ============================================================
        // Menu Principal
        private static void DisplayMenu()
        {
            Console.WriteLine("Inserte la operacion deseada ('-1' salir)");
            Console.WriteLine("1. Mantenimiento De Animales y Produccion");
            Console.WriteLine("2. Listado de animales (Tipo y Nombre)");
            Console.WriteLine("3. Listado de produccion (Fechas de registro y Tipo de animal)");
        }
        private static void DisplayConsultasProduccion()
        {
            Console.WriteLine("Escoja un tipo de consulta ('atras' retroceder)");
            Console.WriteLine("1. Produccion por rango de fechas");
            Console.WriteLine("2. Produccion por rango de fechas y categoria de animal");
        }
        private static void DisplayConsultasAnimal()
        {
            Console.WriteLine("Escoja un tipo de consulta ('atras' retroceder)");
            Console.WriteLine("1. Animales por Categoria");
            Console.WriteLine("2. Animales por Nombre");
        }
        // Sub CRUDs
        private static void SubCRUDsAnimal()
        {
            Console.WriteLine("Seleccione una operacion");
            Console.WriteLine("1. Administrar Produccion de animal");
            Console.WriteLine("2. Eliminar");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Cancelar");
        }
        private static void SubCRUDsProduccion()
        {
            Console.WriteLine("Seleccione una operacion");
            Console.WriteLine("1. Eliminar");
            Console.WriteLine("2. Actualizar");
            Console.WriteLine("3. Cancelar");
        }
        // Listas De Objetos
        private static List<int> MostrarAnimales()
        {
            // Get all planets
            List<Animal> animales = mngAnimal.RetrieveAll();
            // List of options
            List<int> options = new List<int>();
            // If there are planets then continue
            if (animales != null)
            {
                animales.ForEach(animal =>
                {
                    // Options to select
                    int option = options.Count + 1;
                    options.Add(animal.Id);
                    // Print Option
                    Console.WriteLine(AnimalRowBuilder(animal));

                });
            }
            return options;
        }
        private static Boolean MostrarAnimalesPorNombre(Animal Animal)
        {
            // Get all planets
            List<Animal> animales = mngAnimal.RetrieveAllByNombre(Animal);
            // List of options
            List<int> options = new List<int>();
            // If there are planets then continue
            if (animales != null && animales.Count > 0)
            {
                animales.ForEach(animal =>
                {
                    // Options to select
                    int option = options.Count + 1;
                    options.Add(animal.Id);
                    // Print Option
                    Console.WriteLine(AnimalRowBuilder(animal));

                });
                return true;
            }
            else
            {
                MessageBox.Show("No se encontraron resultados");
                return false;
            }
        }
        private static Boolean MostrarAnimalesPorCategoria(Animal Animal)
        {
            // Get all planets
            List<Animal> animales = mngAnimal.RetrieveAllByCategoria(Animal);
            // List of options
            List<int> options = new List<int>();
            // If there are planets then continue
            if (animales != null && animales.Count > 0)
            {
                animales.ForEach(animal =>
                {
                    // Options to select
                    int option = options.Count + 1;
                    options.Add(animal.Id);
                    // Print Option
                    Console.WriteLine(AnimalRowBuilder(animal));

                });
                return true;
            }
            else
            {
                MessageBox.Show("No se encontraron resultados");
                return false;
            }
        }
        private static List<int> MostrarProducciones()
        {
            // Get all planets
            List<Produccion> producciones = mngProduccion.RetrieveAll();
            // List of options
            List<int> options = new List<int>();
            // If there are planets then continue
            if (producciones != null)
            {
                producciones.ForEach(produccion =>
                {
                    // Options to select
                    int option = options.Count + 1;
                    options.Add(produccion.Id);
                    // Print Option
                    Console.WriteLine(ProduccionRowBuilder(produccion));

                });
            }
            return options;
        }
        private static List<int> MostrarProduccionesPorAnimal(Animal Animal)
        {
            // Get all planets
            List<Produccion> producciones = mngProduccion.RetrieveAllByAnimal(Animal);
            // List of options
            List<int> options = new List<int>();
            // If there are planets then continue
            if (producciones != null)
            {
                producciones.ForEach(produccion =>
                {
                    // Options to select
                    int option = options.Count + 1;
                    options.Add(produccion.Id);
                    // Print Option
                    Console.WriteLine(ProduccionRowBuilder(produccion));

                });
            }
            return options;
        }
        private static Boolean MostrarProduccionesPorRango(Produccion Produccion)
        {
            // Get all planets
            List<Produccion> producciones = mngProduccion.RetrieveAllByRango(Produccion);
            // List of options
            List<int> options = new List<int>();
            // If there are planets then continue
            if (producciones != null && producciones.Count > 0)
            {
                producciones.ForEach(produccion =>
                {
                    // Options to select
                    int option = options.Count + 1;
                    options.Add(produccion.Id);
                    // Print Option
                    Console.WriteLine(ProduccionRowBuilder(produccion));

                });
                return true;
            }
            else
            {
                MessageBox.Show("No se encontraron resultados");
                return false;
            }
        }
        private static Boolean MostrarProduccionesPorRangoCategoria(Produccion Produccion)
        {
            // Get all planets
            List<Produccion> producciones = mngProduccion.RetrieveAllByRangoCategoria(Produccion);
            // List of options
            List<int> options = new List<int>();
            // If there are planets then continue
            if (producciones != null && producciones.Count > 0)
            {
                producciones.ForEach(produccion =>
                {
                    // Options to select
                    int option = options.Count + 1;
                    options.Add(produccion.Id);
                    // Print Option
                    Console.WriteLine(ProduccionRowBuilder(produccion));

                });
                return true;
            }
            else
            {
                MessageBox.Show("No se encontraron resultados");
                return false;
            }
        }
        /*private static List<int> MostrarProduccionesPorRango(Produccion produccion)
        {
            // Get all planets
            List<Produccion> producciones = mngProduccion.RetrieveAllByAnimal(animal);
            // List of options
            List<int> options = new List<int>();
            // If there are planets then continue
            if (producciones != null)
            {
                producciones.ForEach(produccion =>
                {
                    // Options to select
                    int option = options.Count + 1;
                    options.Add(produccion.Id);
                    // Print Option
                    Console.WriteLine(ProduccionRowBuilder(produccion));

                });
            }
            return options;
        }
        private static List<int> MostrarProduccionesPorRangoTipo(Produccion produccion)
        {
            // Get all planets
            List<Produccion> producciones = mngProduccion.RetrieveAllByAnimal(animal);
            // List of options
            List<int> options = new List<int>();
            // If there are planets then continue
            if (producciones != null)
            {
                producciones.ForEach(produccion =>
                {
                    // Options to select
                    int option = options.Count + 1;
                    options.Add(produccion.Id);
                    // Print Option
                    Console.WriteLine(ProduccionRowBuilder(produccion));

                });
            }
            return options;
        }*/
        // ============================================================
        //      Constructores de filas por tipo
        // ============================================================
        private static string ProduccionRowBuilder(Produccion produccion)
        {
            // Animal
            Animal animal = new Animal() { Id = produccion.IdAnimal };
            animal = mngAnimal.Retrieve(animal);
            // Row
            return produccion.Id + ". " + animal.Nombre + " / " + produccion.Tipo + " ( Registro: " + produccion.FechaReg + " )\n\tCantidad:" + produccion.Cantidad + "\n\tValor: " + produccion.Valor;
        }
        private static string AnimalRowBuilder(Animal animal)
        {
            // Row
            return animal.Id + ". " + animal.Nombre + " / " + animal.Categoria + " / " + animal.Genero + " (" + animal.FechaNac + ")";
        }
    }
}
