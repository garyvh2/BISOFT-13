using CoreAPI.Integrations.Templates.TextEmailTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Integrations.Models
{
    public class EmailEnvelope
    {
        // >> Attributes
        public EmailPerson From { get; set; }
        public EmailPerson To { get; set; }
        public string Subject { get; set; }
        public EmailTemplate Content { get; set; }

        // >> Constructor
        public EmailEnvelope ()
        {
            Content = new EmailTemplate();
        }
    }
}
