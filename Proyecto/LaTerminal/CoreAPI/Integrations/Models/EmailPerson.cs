using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Integrations.Models
{
    public class EmailPerson
    {
        // >> Atributos
        public string Nombre { get; set; }
        public string Correo { get; set; }

        // >> Constructor
        public EmailPerson (string Nombre, string Correo)
        {
            this.Nombre = Nombre;
            this.Correo = Correo;
        }

        public override string ToString()
        {
            return this.Nombre + " (" + this.Correo + ")";
        }
    }
}
