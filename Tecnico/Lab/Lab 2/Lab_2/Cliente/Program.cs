using AccesoDatos;
using AccesoDatos.Mappers;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    class Program
    {
        private static PlanetaMapper PlanetaM;
        private static SistemaMapper SistemaM;

        static void Main(string[] args)
        {
            // Instancia
            PlanetaM = new PlanetaMapper();
            SistemaM = new SistemaMapper();


            Console.WriteLine("Bienvenido al programa de sistemas solares");

            int operacion;
            do
            {
                Console.Clear();
                DisplayMenuOperaciones();

                // Select option

                if (Int32.TryParse(Console.ReadLine(), out operacion))
                {

                    Console.Clear();
                    switch (operacion)
                    {
                        case 1:
                            DisplaySistemasCRUD();
                            break;
                        case 2:
                            if (SistemaM.findAll () != null)
                            {
                                DisplayPlanetasCRUD();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Debe insertar algun Sistema");
                                Console.WriteLine("Presione cualquier tecla para continuar ...");
                                Console.ReadKey();
                            }
                            break;
                        case 3:
                            bool exit = false;
                            do
                            {
                                Console.WriteLine("Sistemas:");
                                List<int> options = MostrarSistemas();
                                Console.WriteLine("Escoja un sistema solar");
                                string option = Console.ReadLine();
                                int id;
                                if (Int32.TryParse(option, out id))
                                {
                                    if (options.Contains(id))
                                    {
                                        Sistema ActualSistema = SistemaM.findById(id);
                                        DisplaySolarSistem(ActualSistema);
                                        exit = true;
                                    }
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
                                    Console.WriteLine("El valor ingresado no valido");
                                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                                    Console.ReadKey();
                                }
                            } while (exit != true);
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
        private static void DisplayPlanetasCRUD()
        {
            string option;
            do
            {
                Console.WriteLine("Planetas:");
                List<int> options = MostrarPlanetas();
                Console.WriteLine("Escoja un planeta o escriba 'crear' ('atras' para retroceder)");
                option = Console.ReadLine();
                int id;
                if (option == "atras")
                {
                    Console.Clear();
                    Console.WriteLine("Actualmente:");
                    MostrarPlanetas();
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
                else if (option == "crear")
                {
                    Planeta NuevoPlaneta = new Planeta();
                    ObtenerDatosPlaneta(ref NuevoPlaneta);
                    PlanetaM.insert(NuevoPlaneta);
                }
                else if (Int32.TryParse(option, out id))
                {
                    if (options.Contains(id))
                    {
                        Planeta ActualPlaneta = PlanetaM.findById(id);
                        int operacion;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine(ActualPlaneta._Id + ". " + ActualPlaneta._Nombre + " / " + ActualPlaneta.Sistema._Nombre + " (" + ActualPlaneta._Fecha + ")");
                            Console.WriteLine();
                            SubCRUDs();
                            // Select option
                            if (Int32.TryParse(Console.ReadLine(), out operacion))
                            {
                                switch (operacion)
                                {
                                    case 1:
                                        PlanetaM.delete(ActualPlaneta);
                                        operacion = 3;
                                        break;
                                    case 2:
                                        ObtenerDatosPlaneta(ref ActualPlaneta, true);
                                        PlanetaM.update(ActualPlaneta);
                                        operacion = 3;
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("El valor ingresado no es una opcion valida");
                                        break;
                                }
                            }
                        } while (operacion != 3);
                    }
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
        private static void DisplaySistemasCRUD()
        {
            string option;
            do
            {
                Console.WriteLine("Sistemas:");
                List<int> options = MostrarSistemas();
                Console.WriteLine("Escoja un planeta o escriba 'crear' ('atras' para retroceder)");
                option = Console.ReadLine();
                int id;
                if (option == "atras")
                {
                    Console.Clear();
                    Console.WriteLine("Actualmente:");
                    MostrarSistemas();
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
                else if (option == "crear")
                {
                    Sistema NuevoSistema = new Sistema();
                    ObtenerDatosSistema(ref NuevoSistema);
                    SistemaM.insert(NuevoSistema);
                }
                else if (Int32.TryParse(option, out id))
                {
                    if (options.Contains(id))
                    {
                        Sistema ActualSistema = SistemaM.findById(id);
                        int operacion;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine(ActualSistema._Id + ". " + ActualSistema._Nombre + " (" + ActualSistema._Fecha + ")");
                            Console.WriteLine();
                            SubCRUDs();
                            // Select option
                            if (Int32.TryParse(Console.ReadLine(), out operacion))
                            {
                                switch (operacion)
                                {
                                    case 1:
                                        SistemaM.delete(ActualSistema);
                                        operacion = 3;
                                        break;
                                    case 2:
                                        ObtenerDatosSistema(ref ActualSistema, true);
                                        SistemaM.update(ActualSistema);
                                        operacion = 3;
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("El valor ingresado no es una opcion valida");
                                        break;
                                }
                            }
                        } while (operacion != 3);
                    }
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

        // ================================================
        //      Planeta
        // ================================================
        private static void ObtenerDatosPlaneta (ref Planeta planeta, Boolean update = false)
        {
            // Fecha de creacion
            planeta._Fecha = DateTime.Now;
            // Nombre
            do
            {
                Console.WriteLine("Ingrese el nombre del planeta");
                if (update) Console.WriteLine("Actual " + planeta._Nombre);
                planeta._Nombre = Console.ReadLine();
            } while (!(planeta._Nombre is string));
            bool selected = false;
            do
            {
                Console.WriteLine("Ingrese la distancia al sol");
                if (update) Console.WriteLine("Actual " + planeta._SunDistance.ToString());
                int distancia;
                if (Int32.TryParse(Console.ReadLine(), out distancia))
                {
                    planeta._SunDistance = distancia;
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
            // Sistema
            selected = false;
            do
            {
                Console.WriteLine("Sistemas:");
                List<int> options = MostrarSistemas();
                Console.WriteLine("Escoja un sistema solar");
                if (update) Console.WriteLine("Actual: " + planeta.Sistema._Nombre);
                string option = Console.ReadLine();
                int id;
                if (Int32.TryParse(option, out id))
                {
                    if (options.Contains(id))
                    {
                        planeta._IdSistema = id;
                        selected = true;
                    }
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
                    Console.WriteLine("El valor ingresado no valido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
            } while (selected != true);
        }
        // ================================================
        //      Sistema
        // ================================================
        private static void ObtenerDatosSistema(ref Sistema sistema, Boolean update = false)
        {
            // Fecha de creacion
            sistema._Fecha = DateTime.Now;
            // Nombre
            do
            {
                Console.WriteLine("Ingrese el nombre del sistema");
                if (update) Console.WriteLine("Actual " + sistema._Nombre);
                sistema._Nombre = Console.ReadLine();
            } while (!(sistema._Nombre is string));
            
        }

        // Metodos de Impresion
        private static void DisplayMenuOperaciones()
        {
            Console.WriteLine("Inserte la operacion deseada ('-1' salir)");
            Console.WriteLine("1. CRUD Sistema");
            Console.WriteLine("2. CRUD Planeta");
            Console.WriteLine("3. Mostrar Sistema");
        }
        public static void SubCRUDs()
        {
            Console.WriteLine("Seleccione Una Operacion");
            Console.WriteLine("1. Eliminar");
            Console.WriteLine("2. Actualizar");
            Console.WriteLine("3. Cancelar");
        }

        public static void DisplaySolarSistem(Sistema ActualSistema)
        {
            List<Planeta> planetas = PlanetaM.findBySistema(ActualSistema);
            List<int> distancias = new List<int>();

            int steps = 0;
            string display1 = "";
            string display2 = "";
            string display3 = "";


            planetas.ForEach(planeta =>
            {
                for (int i = steps; i < planeta._SunDistance; i++)
                {
                    steps++;
                    display1 += "  ";
                    display2 += "  ";
                    display3 += "  ";
                }
                display1 += @" .-. ";
                display2 += @"|   |";
                display3 += @" `'´ ";
            });



            Console.OutputEncoding = System.Text.Encoding.UTF7;
            Console.WriteLine(@"      ;   :   ;");
            Console.WriteLine(@"   .   \_,!,_/   ,");
            Console.WriteLine(@"    `.,'     `.,'");
            Console.WriteLine(@"     /         \      " + display1);
            Console.WriteLine(@"~ -- :         : -- ~ " + display2);
            Console.WriteLine(@"     \         /      " + display3);
            Console.WriteLine(@"    ,'`._   _.'`.");
            Console.WriteLine(@"   '   / `!` \   `");
            Console.WriteLine(@"      ;   :   ;");
            Console.ReadKey();
        }
        private static List<int> MostrarPlanetas()
        {
            // Get all planets
            List<Planeta> planetas = PlanetaM.findAll();
            // List of options
            List<int> options = new List<int>();
            // If there are planets then continue
            if (planetas != null)
            {
                planetas.ForEach(planeta =>
                {
                    // Options to select
                    int option = options.Count + 1;
                    options.Add(planeta._Id);
                    // Print Option
                    Console.WriteLine(planeta._Id + ". " + planeta._Nombre + " / " + planeta.Sistema._Nombre + " (" + planeta._Fecha + ")");

                });
            }
            return options;
        }
        private static List<int> MostrarSistemas()
        {
            // Get all planets
            List<Sistema> sistemas = SistemaM.findAll();
            // List of options
            List<int> options = new List<int>();
            // If there are planets then continue
            if (sistemas != null)
            {
                sistemas.ForEach(sistema =>
                {
                    // Options to select
                    int option = options.Count + 1;
                    options.Add(sistema._Id);
                    // Print Option
                    Console.WriteLine(sistema._Id + ". " + sistema._Nombre + " (" + sistema._Fecha + ")");

                });
            }
            return options;
        }
    }
}
