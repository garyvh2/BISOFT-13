using CoreAPI.Integrations.Models;
using DataAccess.CRUD.ArchitectureComponents;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CoreAPI.Integrations
{
    public class SMSManager
    {
        // >> EmailManager Instance
        private static SMSManager Instance;
        // >> Notificacion CRUD
        private static NotificacionCrudFactory NotificacionCrud;
        // >> API Key
        private const string API_KEY = "";
        private const string ACCOUNT_ID = "";
        // >> Sender
        public SMSPerson SENDER { get; set; }

        // >> Constructor
        private SMSManager (string SENDERNumber = "+12523470357", string SENDERName = "La Terminal CR")
        {
            this.SENDER = new SMSPerson(SENDERName, SENDERNumber);
        }
        // >> Singleton Return Instance
        public static SMSManager GetInstance()
        {
            // If the instance is undefined then create it
            if (Instance == null)
            {
                // >> Email Manager Instantiation
                Instance = new SMSManager();
                // >> Send Grid Client instantiation
                TwilioClient.Init(ACCOUNT_ID, API_KEY);
                // >> Notificacion CRUD
                NotificacionCrud = new NotificacionCrudFactory();
            }
            // Otherwise return the instance
            return Instance;
        }

        // >> SMS Sender
        public MessageResource SendSMS(SMSMessage smsMessage)
        {
            // >> Users
            var to      = new PhoneNumber(smsMessage.To.Numero);
            var from    = new PhoneNumber(SENDER.Numero);

            // >> Validate the Sender
            if (smsMessage.From != null) from = new PhoneNumber(smsMessage.From.Numero);

            // >> Sent the 
            var message = MessageResource.Create(
                to: to,
                from: from,
                body: smsMessage.Content);

            // >> Almacenar registro de notificacion
            var notificacion = new Notificacion
            {
                Remitente = from.ToString(),
                Destinatario = to.ToString(),
                Fecha = DateTime.Now,
                Mensaje = smsMessage.Content,
                Tipo = "SMS"
            };
            NotificacionCrud.Create(notificacion);

            return message;
        }
    }
}
