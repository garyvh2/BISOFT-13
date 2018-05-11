using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Classes;
using Cliente.Lib.Requester;
using Cliente.Lib.PropProc;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Cliente
{
    class Program
    {
        // >> CONSTANTS
        private const string SERVER_BASE_URL = "http://localhost:61021/";

        static void Main(string[] args)
        {
            string option;
            do
            {
                Console.Clear();
                var options = DisplayMenuPrincipalAsync().GetAwaiter().GetResult();

                // Select option
                option = Console.ReadLine().ToLower();
                if (option == "salir")
                {
                    Console.WriteLine("Gracias por utilzar el sistema. Adios");
                    Console.ReadKey();
                }
                else if (option == "crear")
                {
                    // Crear un usuario
                    var usuario = CrearUsuario();
                    Console.WriteLine(usuario.ToString());

                }
                else if (options.Contains(option))
                {
                    Console.WriteLine("Ingresando al sistema, por favor espera");
                    var usuario = PullFromServer<Usuario>("usuario", option).GetAwaiter().GetResult();
                    IngresarAlSistema (usuario);
                }
                else
                {
                    Console.WriteLine("El valor ingresado no es un numero valido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
            } while (option != "salir");
        }
        // >>=========================================================================<<
        //                        >> Metodos de impresion <<
        // >>=========================================================================<<
        // Menu Principal
        private static async Task<List<string>> DisplayMenuPrincipalAsync()
        {
            var opciones = new List<string>();
            try
            {
                Console.WriteLine("Cargando el menu principal, por favor espera");
                await new Request(new RequestParams()
                {
                    url = SERVER_BASE_URL + "api/usuario/"
                }).RunAsync<List<Usuario>>(usuarios =>
                {
                    Console.Clear();
                    Console.WriteLine(">>=====================================<<");
                    Console.WriteLine("        >>Bienvenido a Poli-Bot<<        ");
                    Console.WriteLine("          >>El Robot Traductor<<         ");
                    Console.WriteLine(">>=====================================<<");
                    Console.WriteLine("        >>Usuarios Disponibles:<<        ");
                    Console.WriteLine(">>=====================================<<");
                    opciones = PrintList<Usuario>(usuarios.Data, "Id", new List<string>() { "Nombre", "Apellido"});
                    Console.WriteLine(">>=====================================<<");
                    Console.WriteLine("          >>Escoja un usuario<<          ");
                    Console.WriteLine("      >>Escriba 'Crear' crear uno<<      ");
                    Console.WriteLine("                 >> o <<                 ");
                    Console.WriteLine("      >>Escriba 'Salir' para salir<<     ");
                    Console.WriteLine(">>=====================================<<");
                });
                return opciones;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Imposible Mostrar la lista de usuarios", ex);
                return null;
            }
        }
        // Ingreso al sistema
        private static void DisplayMenuIngresoSistema (Usuario usuario)
        {
            Console.WriteLine(">>==================================================<<");
            Console.WriteLine("Bienvenido, " + usuario.Nombre + " " + usuario.Apellido);
            Console.WriteLine(">>==================================================<<");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine(">>==================================================<<");
            Console.WriteLine("2. Idiomas disponibles");
            Console.WriteLine("3. Palabras disponibles (Agrupado por idioma)");
            Console.WriteLine("4. Diccionario de Palabras Por Idioma");
            Console.WriteLine(">>==================================================<<");
            Console.WriteLine("5. Idioma mas popular");
            Console.WriteLine("6. 100 Palabras mas populares");
            Console.WriteLine("7. 10 Palabras mas populares por dia de la semana");
            Console.WriteLine("8. Historia de traducciones por palabra");
            Console.WriteLine("9. Usuario con mas traducciones");
            Console.WriteLine(">>==================================================<<");
            Console.WriteLine("                 >>Escoja una opcion<<                ");
            Console.WriteLine("                        >> o <<                       ");
            Console.WriteLine("           >>Escriba 'Atras' para regresar<<          ");
            Console.WriteLine(">>==================================================<<");
        }
        // >>=========================================================================<<
        //                       >> Sub menus del sistema <<
        // >>=========================================================================<<
        // Ingresar al sistema
        private static void IngresarAlSistema (Usuario usuario)
        {
            Console.Clear();
            string option = "";

            do
            {
                Console.Clear();
                DisplayMenuIngresoSistema(usuario);
                option = Console.ReadLine().ToLower();
                
                Console.Clear();
                switch (option)
                {
                    case "1":
                        Traducir(usuario);
                        break;
                    case "2":
                        ListarIdiomas().Wait();
                        Console.WriteLine(">>======================================<<");
                        Console.WriteLine("Presione cualquier tecla para continuar ...");
                        Console.WriteLine(">>======================================<<");
                        Console.Read();
                        break;
                    case "3":
                        ListarPalabrasPorFamilia().Wait();
                        Console.WriteLine(">>======================================<<");
                        Console.WriteLine("Presione cualquier tecla para continuar ...");
                        Console.WriteLine(">>======================================<<");
                        Console.Read();
                        break;
                    case "4":
                        MostrarPalabrasPorIdioma();
                        Console.Read();
                        break;
                    case "5":
                        ObtenerIdiomaMasPopularAsync().Wait();
                        Console.WriteLine(">>======================================<<");
                        Console.WriteLine("Presione cualquier tecla para continuar ...");
                        Console.WriteLine(">>======================================<<");
                        Console.Read();
                        break;
                    case "6":
                        ListarTop100Palabras().Wait();
                        Console.WriteLine(">>======================================<<");
                        Console.WriteLine("Presione cualquier tecla para continuar ...");
                        Console.WriteLine(">>======================================<<");
                        Console.Read();
                        break;
                    case "7":
                        DayOfWeek dia = 0;
                        bool valid = false;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Escoja un dia de la semana");
                            Console.WriteLine("1. Domingo");
                            Console.WriteLine("2. Lunes");
                            Console.WriteLine("3. Martes");
                            Console.WriteLine("4. Miercoles");
                            Console.WriteLine("5. Jueves");
                            Console.WriteLine("6. Viernes");
                            Console.WriteLine("7. Sabado");
                            int diaOpcion;
                            if (int.TryParse(Console.ReadLine(), out diaOpcion))
                            {
                                switch (diaOpcion)
                                {
                                    case 1:
                                        dia = DayOfWeek.Sunday;
                                        valid = true;
                                        break;
                                    case 2:
                                        dia = DayOfWeek.Monday;
                                        valid = true;
                                        break;
                                    case 3:
                                        dia = DayOfWeek.Tuesday;
                                        valid = true;
                                        break;
                                    case 4:
                                        dia = DayOfWeek.Wednesday;
                                        valid = true;
                                        break;
                                    case 5:
                                        dia = DayOfWeek.Thursday;
                                        valid = true;
                                        break;
                                    case 6:
                                        dia = DayOfWeek.Friday;
                                        valid = true;
                                        break;
                                    case 7:
                                        dia = DayOfWeek.Saturday;
                                        valid = true;
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("El valor ingresado es invalido");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("El valor ingresado es invalido");
                                Console.ReadKey();
                            }
                        } while (valid == false);
                        ListarTop10Palabras(dia).Wait();
                        Console.WriteLine(">>======================================<<");
                        Console.WriteLine("Presione cualquier tecla para continuar ...");
                        Console.WriteLine(">>======================================<<");
                        Console.Read();
                        break;
                    case "8":
                        break;
                    case "9":
                        break;
                    case "atras":
                        Console.WriteLine("Regresando al menu principal");
                        break;
                    default:
                        Console.WriteLine("El valor ingresado no es una opcion valida");
                        break;
                }
            } while (option != "atras");
        }
        // Listar Palabras por idioma
        private static void MostrarPalabrasPorIdioma()
        {
            string option;
            do
            {
                Console.Clear();
                var idiomas = ListarIdiomas().GetAwaiter().GetResult();
                Console.WriteLine(">>==================================================<<");
                Console.WriteLine("                 >>Escoja una opcion<<                ");
                Console.WriteLine("                        >> o <<                       ");
                Console.WriteLine("           >>Escriba 'Atras' para regresar<<          ");
                Console.WriteLine(">>==================================================<<");

                // Select option
                option = Console.ReadLine().ToLower();
                if (option == "atras")
                {
                    Console.WriteLine("Regresando");
                    break;
                }
                else if (idiomas.Contains(option))
                {
                    Console.WriteLine("Mostrando palabras, por favor espera");
                    var idioma = PullFromServer<Idioma>("idioma", option).GetAwaiter().GetResult();
                    ListarPalabrasPorIdioma(idioma).Wait();
                    Console.WriteLine(">>==================================================<<");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.WriteLine(">>==================================================<<");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("El valor ingresado no es un numero valido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
            } while (option != "atras");
        }
        // Traducir
        private static void Traducir(Usuario usuario)
        {
            // >> estado de traduccion
            var cancelar = false;

            // >> Perparar la traduccion
            var traduccion = PrepararTraduccion();
            traduccion.Id_Usuario = usuario.Id;

            // >> Obtener las palabras de la frase original
            var palabrasOriginales = new List<Palabra>();
            var palabras = CleanStringSpaces(traduccion.Frase_Original).Split(' ').ToList();
            palabras.ForEach(palabra =>
            {
                var dbPalabra = ProcesarPalabraOriginal(new Palabra()
                {
                    _Palabra = palabra,
                    Id_Idioma = traduccion.Idioma_Original,
                }, usuario);
                palabrasOriginales.Add(dbPalabra);
            });

            // >> Obtener la traduccion de las palabras
            var palabrasTraduccion = new List<Palabra>();
            palabrasOriginales.ForEach(palabra =>
            {
                if (cancelar == true) return;
                var dbPalabra = ProcesarPalabraTraduccion(new Palabra()
                {
                    Id_Idioma = traduccion.Idioma_Destino,
                    Familia = palabra.Familia
                }, usuario, palabra._Palabra);
                if (dbPalabra == null)
                {
                    cancelar = true;
                    return;
                };
                traduccion.Frase_Traducida += dbPalabra._Palabra + " ";
                palabrasTraduccion.Add(dbPalabra);
            });
            traduccion.Frase_Traducida = CleanStringSpaces(traduccion.Frase_Traducida);

            if (cancelar == false)
            {
                Console.Clear();
                Console.WriteLine(">>==================================================<<");
                Console.WriteLine("La frase en " + traduccion.Original.ToString() + ":");
                Console.WriteLine(traduccion.Frase_Original);
                Console.WriteLine("Se traduce en " + traduccion.Destino.ToString() + " a:");
                Console.WriteLine(traduccion.Frase_Traducida);
                Console.WriteLine(">>==================================================<<");
                Console.WriteLine("Presione cualquier tecla para continuar ...");
                Console.ReadKey();

                // >> Guardar traduccion
                traduccion = CrearTraduccion(traduccion);

                // >> Asignar palabras a traduccion
                AsignarPalabrasTraduccion(palabrasOriginales, traduccion);
                AsignarPalabrasTraduccion(palabrasTraduccion, traduccion);

                // >> Calcular y asignar popularidad
                traduccion.Id_Traduccion = traduccion.Id;
                traduccion.Id_Idioma = traduccion.Idioma_Original;
                CalcularPopularidad(traduccion);
            }


        }
        // Asignar palabras a traduccion
        private static void AsignarPalabrasTraduccion (List<Palabra> palabras, Traduccion traduccion)
        {
            var index = 1;
            palabras.ForEach(palabra =>
            {
                TraduccionPalabra traduccionPalabra = new TraduccionPalabra()
                {
                    Id_Traduccion = traduccion.Id,
                    Id_Palabra = palabra.Id,
                    Orden = index
                };
                CrearTraduccionPalabra(traduccionPalabra);
            });
        }
        // Procesar palabras
        private static Palabra ProcesarPalabraOriginal(Palabra palabra, Usuario usuario)
        {
            // >> Buscar palabra en la base de datos
            var dbPalabra = SendToServer<Palabra>(new RequestParams()
            {
                url = SERVER_BASE_URL + "api/palabra/palabra/" + palabra._Palabra
            }).GetAwaiter().GetResult();
            // >> Si la palabra es de origen (Espanol) y no existe entonces se registra
            if (dbPalabra == null)
            {
                return CrearPalabra(usuario, Guid.NewGuid().ToString(), palabra, "");
            }
            else
            {
                return dbPalabra;
            }
        }
        private static Palabra ProcesarPalabraTraduccion(Palabra palabra, Usuario usuario, string palabraOriginal)
        {
            // >> Buscar palabra en la base de datos
            var dbPalabra = SendToServer<Palabra>(new RequestParams()
            {
                url = SERVER_BASE_URL + "api/palabra/familia_idioma",
                method = HttpMethod.Post,
                body = palabra
            }).GetAwaiter().GetResult();
            // >> Si la palabra es de origen (Espanol) y no existe entonces se registra
            if (dbPalabra == null)
            {
                Idioma idioma = PullFromServer<Idioma>("idioma", palabra.Id_Idioma.ToString()).GetAwaiter().GetResult();

                Console.Clear();
                Console.WriteLine(">>==================================================<<");
                Console.WriteLine("La traduccion de la palabra " + palabraOriginal + " en " + idioma.ToString() + " es desconocida");
                Console.WriteLine(">>==================================================<<");
                Console.WriteLine("Desea ingresarla? (Si / No)");
                Console.WriteLine(">>==================================================<<");
                var respuesta = Console.ReadLine().ToLower();
                if (respuesta == "si")
                {
                    return CrearPalabra(usuario, palabra.Familia, palabra, palabraOriginal);
                }
                else
                {
                    Console.WriteLine(">>==================================================<<");
                    Console.WriteLine("Imposible traducir la frase completa");
                    Console.WriteLine(">>==================================================<<");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();

                    return null;
                }
            }
            else
            {
                return dbPalabra;
            }

            return palabra;
        }
        // >>=========================================================================<<
        //                        >> Metodos de listado <<
        // >>=========================================================================<<
        // Listar Idiomas
        private static async Task<List<string>> ListarIdiomas ()
        {
            List<string> opciones = new List<string>();
            await new Request(new RequestParams()
            {
                url = SERVER_BASE_URL + "api/idioma/"
            }).RunAsync<List<Idioma>>(idiomas =>
            {
                Console.Clear();
                Console.WriteLine(">>======================================<<");
                Console.WriteLine("    >>Lista de idiomas en el sistema<<   ");
                Console.WriteLine(">>======================================<<");
                opciones = PrintList<Idioma>(idiomas.Data, "Id", new List<string>() { "Codigo", "Nombre" });
            });
            return opciones;
        }
        // Listar Idiomas por Familia
        private static async Task<List<string>> ListarPalabrasPorFamilia()
        {
            List<string> opciones = new List<string>();
            await new Request(new RequestParams()
            {
                url = SERVER_BASE_URL + "api/palabra/"
            }).RunAsync<List<Palabra>>(palabras =>
            {
                Console.WriteLine(">>======================================<<");
                Console.WriteLine("    >>Lista de palabras en el sistema<<   ");
                Console.WriteLine(">>======================================<<");
                var familias = palabras.Data.GroupBy(palabra =>
                {
                    return palabra.Familia;
                })
                .Select(group => group.ToList())
                .ToList();
                var index = 1;
                foreach (List<Palabra> groupPalabras in familias)
                {
                    Console.WriteLine(index + ":");
                    index++;
                    groupPalabras.ForEach(palabra =>
                    {
                        palabra.Idioma = PullFromServer<Idioma>("idioma", palabra.Id_Idioma.ToString()).GetAwaiter().GetResult();
                    });
                    PrintList<Palabra>(groupPalabras, "Id", new List<string>() { "_Palabra", "Idioma" });
                }
            });
            return opciones;
        }
        // Listar Palabras por idioma
        private static async Task<List<string>> ListarPalabrasPorIdioma(Idioma idioma)
        {
            List<string> opciones = new List<string>();
            await new Request(new RequestParams()
            {
                url = SERVER_BASE_URL + "api/palabra/idioma/" + idioma.Id
            }).RunAsync<List<Palabra>>(palabras =>
            {
                Console.Clear();
                Console.WriteLine(">>======================================<<");
                Console.WriteLine("Palabras en idioma " + idioma.Codigo + " " + idioma.Nombre);
                Console.WriteLine(">>======================================<<");
                opciones = PrintList<Palabra>(palabras.Data, "Id", new List<string>() { "_Palabra" });
            });
            return opciones;
        }
        // >>=========================================================================<<
        //                        >> Metodos de creacion <<
        // >>=========================================================================<<
        // Crear un usuario
        private static Usuario CrearUsuario()
        {
            Usuario nuevoUsuario = new Usuario()
            {
                Nombre = PropertyProcessor.GetString("Ingrese el nombre"),
                Apellido = PropertyProcessor.GetString("Ingrese el apellido"),
            };
            return SendToServer<Usuario>(new RequestParams()
            {
                url = SERVER_BASE_URL + "api/usuario/",
                method = HttpMethod.Post,
                body = nuevoUsuario
            }).GetAwaiter().GetResult();
        }
        // Crear un idioma
        private static Idioma CrearIdioma()
        {
            Idioma nuevoIdioma = new Idioma()
            {
                Codigo = PropertyProcessor.GetString("Ingrese el codigo del idioma (ISO)"),
                Nombre = PropertyProcessor.GetString("Ingrese el nombre del idioma")
            };
            return SendToServer<Idioma>(new RequestParams()
            {
                url = SERVER_BASE_URL + "api/idioma/",
                method = HttpMethod.Post,
                body = nuevoIdioma
            }).GetAwaiter().GetResult();
        }
        // Crear un usuario
        private static Palabra CrearPalabra(Usuario usuario, string familia, Palabra palabra, string palabraOrigen)
        {
            Idioma idioma = PullFromServer<Idioma>("idioma", palabra.Id_Idioma.ToString()).GetAwaiter().GetResult();
            Palabra nuevaPalabra = new Palabra()
            {
                Idioma = idioma,
                Id_Idioma = palabra.Id_Idioma,
                Id_Traductor = usuario.Id,
                Familia = familia,
                _Palabra = palabra._Palabra != null ? palabra._Palabra : PropertyProcessor.GetString("Ingrese la traduccion de la palabra " + palabraOrigen + " en " + idioma.ToString()),
                Fecha = DateTime.Today
            };
            return SendToServer<Palabra>(new RequestParams()
            {
                url = SERVER_BASE_URL + "api/palabra/",
                method = HttpMethod.Post,
                body = nuevaPalabra
            }).GetAwaiter().GetResult();
        }
        // Prepara una traduccion
        private static Traduccion PrepararTraduccion()
        {
            var idioma_destino = PropertyProcessor.GetBaseEntity<Idioma>("Escoja el idioma destino", new List<string>() { "Codigo", "Nombre" }, true);
            if (idioma_destino == null) idioma_destino = CrearIdioma();
            Traduccion nuevaTraduccion = new Traduccion()
            {
                Idioma_Original = 3, // Español
                Idioma_Destino = idioma_destino.Id,
                Frase_Original = PropertyProcessor.GetString("Ingrese la frase original (En Español)"),
                Frase_Traducida = "",
                Fecha = DateTime.Today
            };
            nuevaTraduccion.Original = PullFromServer<Idioma>("idioma", nuevaTraduccion.Idioma_Original.ToString()).GetAwaiter().GetResult();
            nuevaTraduccion.Destino = PullFromServer<Idioma>("idioma", nuevaTraduccion.Idioma_Destino.ToString()).GetAwaiter().GetResult();
            return nuevaTraduccion;
        }
        // Crear una traduccion
        private static Traduccion CrearTraduccion(Traduccion traduccion)
        {
            return SendToServer<Traduccion>(new RequestParams()
            {
                url = SERVER_BASE_URL + "api/traduccion/",
                method = HttpMethod.Post,
                body = traduccion
            }).GetAwaiter().GetResult();
        }
        // Crear una traduccion / palabra
        private static Traduccion CrearTraduccionPalabra(TraduccionPalabra traduccionPalabra)
        {
            return SendToServer<Traduccion>(new RequestParams()
            {
                url = SERVER_BASE_URL + "api/traduccionpalabra/",
                method = HttpMethod.Post,
                body = traduccionPalabra
            }).GetAwaiter().GetResult();
        }
        // >>=========================================================================<<
        //                        >> Metodos de reporte <<
        // >>=========================================================================<<
        // Calcular popularidad 
        private static Traduccion CalcularPopularidad(Traduccion traduccion)
        {
            return SendToServer<Traduccion>(new RequestParams()
            {
                url = SERVER_BASE_URL + "api/traduccion/popularidad",
                method = HttpMethod.Put,
                body = traduccion
            }).GetAwaiter().GetResult();
        }
        // Obtener idioma mas popular
        private static async Task<Idioma> ObtenerIdiomaMasPopularAsync()
        {
            Idioma MasPopular = null;
            await new Request(new RequestParams()
            {
                url = SERVER_BASE_URL + "api/idioma/mas_popular",
            }).RunAsync<Idioma>(res =>
            {
                var idioma = res.Data;
                Console.Clear();
                Console.WriteLine(">>======================================<<");
                Console.WriteLine("El idioma mas popular es:");
                Console.WriteLine(idioma.Codigo + " " + idioma.Nombre + " (Popularidad: " + idioma.Popularidad + ")");
                Console.WriteLine(">>======================================<<");

                MasPopular = idioma;
            });
            return MasPopular;

        }
        // Listar top 100 palabras
        private static async Task<List<string>> ListarTop100Palabras()
        {
            List<string> opciones = new List<string>();
            await new Request(new RequestParams()
            {
                url = SERVER_BASE_URL + "api/palabra/top100/"
            }).RunAsync<List<Palabra>>(palabras =>
            {
                Console.Clear();
                Console.WriteLine(">>======================================<<");
                Console.WriteLine("           >>Top 100 Palabras<<           ");
                Console.WriteLine(">>======================================<<");
                opciones = PrintList<Palabra>(palabras.Data, "Id", new List<string>() { "_Palabra", "Popularidad" });
            });
            return opciones;
        }
        // Listar top 10 palabras
        private static async Task<List<string>> ListarTop10Palabras(DayOfWeek dia)
        {
            List<string> opciones = new List<string>();
            await new Request(new RequestParams()
            {
                url = SERVER_BASE_URL + "api/palabra/top10Dia/" + (int)dia
            }).RunAsync<List<Palabra>>(palabras =>
            {
                Console.Clear();
                Console.WriteLine(">>======================================<<");
                Console.WriteLine("Top 10: Dia " + dia.ToString());
                Console.WriteLine(">>======================================<<");
                opciones = PrintList<Palabra>(palabras.Data, "Id", new List<string>() { "_Palabra", "Popularidad" });
            });
            return opciones;
        }
        // >>=========================================================================<<
        //                          >> Data Threatment <<
        // >>=========================================================================<<
        // Print Object list
        private static List<String> PrintList<T>(List<T> list, string idfield, List<string> display) where T : BaseEntity
        {
            // List of options
            List<string> options = new List<string>();
            // If there are planets then continue
            try
            {
                if (list != null && list.Count > 0)
                {
                    list.ForEach(item =>
                    {
                        var castedItem = (T)item;
                        // Options to select
                        options.Add(item[idfield].ToString());
                        // Print Option
                        var displayName = "";
                        display.ForEach(dis => {
                            displayName += item[dis] + " ";
                        });
                        Console.WriteLine(item[idfield] + ". " + displayName);

                    });
                }
                else
                {
                    Console.WriteLine("No hay resultados en este momento");
                }
                return options;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to display list", ex);
                return null;
            }
        }
        // Pull from server
        private static async Task<T> PullFromServer<T> (string method, string id) where T: BaseEntity
        {
            T item = null;
            try
            {
                // Ingresar al sistema
                await new Request(new RequestParams()
                {
                    url = SERVER_BASE_URL + "api/" + method + "/" + id
                }).RunAsync<T>(dbItem =>
                {
                    if (dbItem.Message != null) Console.WriteLine(dbItem.Message);
                    item = dbItem.Data;
                });
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable To Pull Object", ex);
                Console.ReadKey();
                return item;
            }
        }
        // Pull from server
        private static async Task<T> SendToServer<T>(RequestParams requestParams) where T : BaseEntity
        {
            T item = null;
            try
            {
                // Ingresar al sistema
                await new Request(requestParams).RunAsync<T>(dbItem =>
                {
                    if (dbItem.Message != null) Console.WriteLine(dbItem.Message);
                    item = dbItem.Data;
                });
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable To Pull Object");
                Console.ReadKey();
                return item;
            }
        }
        // Clean Strings
        private static string CleanStringSpaces (string str)
        {
            Regex trimmer = new Regex(@"\s\s+");
            return trimmer.Replace(str, " ").ToLower();
        } 
    }
}
