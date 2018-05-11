using Cliente.Lib;
using Cliente.Lib.Requester;
using Entidades.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cliente.Lib.PropProc
{
    public class PropertyProcessor
    {
        public static string GetString(string msg, string update = null)
        {
            var str = "";
            do
            {
                Console.WriteLine(msg);
                if (update != null) Console.WriteLine("Actual: " + update);
                str = Regex.Replace(Console.ReadLine(), @"\t|\n|\r", "");
            } while (str == "");
            return str;
        }
        public static DateTime GetDateTime(string msg, string update = null)
        {
            DateTime value;
            var valid = false;

            do
            {
                Console.WriteLine(msg);
                if (update != null) Console.WriteLine("Actual: " + update);

                if (DateTime.TryParse(Console.ReadLine(), out value))
                {
                    valid = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
            } while (valid != true);

            return value;
        }
        public static double GetDouble(string msg, string update = null)
        {
            double value;
            var valid = false;

            do
            {
                Console.WriteLine(msg);
                if (update != null) Console.WriteLine("Actual: " + update);

                if (Double.TryParse(Console.ReadLine(), out value))
                {
                    valid = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
            } while (valid != true);

            return value;
        }


        public static int GetInt(string msg, string update = null)
        {
            int value;
            var valid = false;

            do
            {
                Console.WriteLine(msg);
                if (update != null) Console.WriteLine("Actual: " + update);

                if (int.TryParse(Console.ReadLine(), out value))
                {
                    valid = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
            } while (valid != true);

            return value;
        }

        public static T GetBaseEntity<T> (string msg, List<string> displayValues, bool create = false, string update = null) where T : BaseEntity
        {
            T value = null;
            var typeName = typeof(T).Name.ToLower();

            var opcion = "";
            do
            {
                Console.Clear();
                List<string> opciones = ListEntity(typeName, displayValues).GetAwaiter().GetResult();
                Console.WriteLine(">>======================================<<");
                Console.WriteLine(msg);
                Console.WriteLine(">>======================================<<");
                if (create) Console.WriteLine("'Crear' para crear un objeto nuevo");
                opcion = Console.ReadLine().ToLower();
                if (opcion == "crear" && create)
                {
                    return null;
                }
                else if (opciones.Contains(opcion))
                {
                    value = PullFromServer<T>(typeName, opcion).GetAwaiter().GetResult();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado no es invalido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
            } while (value == null);

            return value;
        }

        // Listar opciones disponibles
        private static async Task<List<string>> ListEntity(string method, List<string> displayValues)
        {
            List<string> opciones = new List<string>();
            await new Request(new RequestParams()
            {
                url = "http://localhost:61021/api/" + method
            }).RunAsync<List<Idioma>>(idiomas =>
            {
                Console.Clear();
                Console.WriteLine(">>======================================<<");
                Console.WriteLine("Escoja un valor");
                Console.WriteLine(">>======================================<<");
                opciones = PrintList<Idioma>(idiomas.Data, "Id", displayValues);
            });
            return opciones;
        }
        // Pull from server
        private static async Task<T> PullFromServer<T>(string method, string id) where T : BaseEntity
        {
            T item = null;
            try
            {
                // Ingresar al sistema
                await new Request(new RequestParams()
                {
                    url = "http://localhost:61021/api/" + method + "/" + id
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
    }
}
