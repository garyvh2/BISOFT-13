using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Integrations.Models
{
    public class PasswordPerson
    {
        // >> Atributos
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Fecha { get; set; }

        // >> Constructor
        public PasswordPerson(string Nombre, string Correo)
        {
            this.Correo = Correo;
            this.Password = Password;
            this.Fecha = Fecha;
        }
    }
}
