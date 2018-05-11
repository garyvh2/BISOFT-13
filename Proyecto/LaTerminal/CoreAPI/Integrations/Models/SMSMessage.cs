using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Integrations.Models
{
    public class SMSMessage
    {
        // >> Attributes
        public SMSPerson From { get; set; }
        public SMSPerson To { get; set; }
        public string Content { get; set; } = "";

        // >> Constructores
        public SMSMessage ()
        {

        }

    }
}
