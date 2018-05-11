using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Integrations.Models
{
    public class SMSPerson
    {
        // >> Atributos
        public string Nombre { get; set; }
        public string Numero { get; set; }

        // >> Constructor
        public SMSPerson(string Nombre, string Numero)
        {
            this.Nombre = Nombre;
            this.Numero = Numero;
        }


        public override string ToString()
        {
            return this.Nombre + " (" + this.Numero + ")";
        }
    }
}
