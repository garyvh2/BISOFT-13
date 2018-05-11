using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    class Program
    {
        public class Operacion
        {
            public string tipoOperacion { get; set; }
            public double[] valores { get; set; }
            public double resultado { get; set; }
        }

        // Instance of JSON Serializer
        private static JsonSerializer serializer = new JsonSerializer();
        private static Operacion op;
        private static HttpClient client;

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al sistema de operaciones");

            int operacion;
            do
            {
                DisplayMenuOperaciones();
                op = new Operacion();
                if (Int32.TryParse(Console.ReadLine(), out operacion))
                {
                    switch (operacion)
                    {
                        case 1:
                            op.tipoOperacion = "sumar";
                            op.valores = SolicitarNumeros("+");
                            op = CalcularAsync(op).Result;
                            break;
                        case 2:
                            op.tipoOperacion = "restar";
                            op.valores = SolicitarNumeros("-");
                            op = CalcularAsync(op).Result;
                            break;
                        case 3:
                            op.tipoOperacion = "multiplicar";
                            op.valores = SolicitarNumeros("*");
                            op = CalcularAsync(op).Result;
                            break;
                        case 4:
                            op.tipoOperacion = "dividir";
                            op.valores = SolicitarNumeros("/");
                            op = CalcularAsync(op).Result;
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
                    Console.WriteLine("Resultado: " + op.resultado);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("El valor ingresado no es un numero valido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
                op = null;
                Console.Clear();
            } while (operacion != -1);


        }

        private static async Task<Operacion> CalcularAsync(Operacion operacion)
        {
            //Se llama al metodo
            // Pepare Client
            // HTTP Request client
            client = new HttpClient();
            // Base URL
            client.BaseAddress = new Uri("http://localhost:54991/");
            // Clear Headers
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                return operacion = JsonConvert.DeserializeObject<Operacion>(await CalcularServidor(operacion));
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return null;
            }
        }



        static async Task<String> CalcularServidor(Operacion op)
        {
            // Server Call
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/post/operaciones", op);
            // Assure Success
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return await response.Content.ReadAsStringAsync();
        }

        // * Console Writting Methods
        private static void DisplayMenuOperaciones()
        {
            Console.WriteLine("Inserte la operacion deseada ('-1' salir)");
            Console.WriteLine("1. Suma");
            Console.WriteLine("2. Resta");
            Console.WriteLine("3. Multiplicacion");
            Console.WriteLine("4. Division");
        }
        private static double[] SolicitarNumeros(string join = ",")
        {
            Console.Clear();
            // Initial Definitions
            double numero;
            string input;
            List<double> numeros = new List<double>();
            do
            {

                Console.WriteLine("Ingrese Un Valor ('exit' salir)");
                Console.WriteLine("Actualmente: " + string.Join(join, numeros.ToArray()));

                input = Console.ReadLine();
                if (input == "exit")
                    Console.WriteLine("Finalmente: " + string.Join(join, numeros.ToArray()));
                else if (Double.TryParse(input, out numero))
                    numeros.Add(numero);
                else
                {
                    Console.Clear();
                    Console.WriteLine("El valor ingresado es invalido");
                    Console.WriteLine("Presione cualquier tecla para continuar ...");
                    Console.ReadKey();
                }
                Console.Clear();
            } while (input != "exit");
            return numeros.ToArray();
        }
    }
}
