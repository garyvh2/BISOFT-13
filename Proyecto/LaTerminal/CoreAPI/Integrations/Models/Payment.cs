using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Integrations.Models
{
    public class Payment
    {
        // >> Token de transaccion
        public string Nonce { get; set; }
        // >> Monto a Cobrar
        public float Monto { get; set; }

        public Payment ()
        {

        }
    }
}
