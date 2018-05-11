using CoreAPI.Integrations.Models;
using DataAccess.CRUD.ArchitectureComponents;
using Entities.Entities;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Integrations
{
    public class EmailManager
    {
        // >> EmailManager Instance
        private static EmailManager Instance;
        // >> Notificacion CRUD
        private static NotificacionCrudFactory NotificacionCrud;
        // >> Send Grid Client
        private static SendGridClient SGClient;
        // >> API Key
        private const string API_KEY = "";
        // >> Sender
        public EmailPerson ORG  { get; set; }

        // >> Constructor
        private EmailManager (string ORG_NAME = "La Terminal CR", string ORG_EMAIL = "ayuda@laterminal.co.cr")
        {
            this.ORG = new EmailPerson(ORG_NAME, ORG_EMAIL);
        }
        // >> Singleton Return Instance
        public static EmailManager GetInstance()
        {
            // If the instance is undefined then create it
            if (Instance == null)
            {
                // >> Email Manager Instantiation
                Instance = new EmailManager();
                // >> Send Grid Client instantiation
                SGClient = new SendGridClient(API_KEY);
                // >> Notificacion CRUD
                NotificacionCrud = new NotificacionCrudFactory();
            }
            // Otherwise return the instance
            return Instance;
        }
        // >> Email Sender
        public Task<Response> SendMail(EmailEnvelope envelope)
        {
            // >> sender
            if (envelope.From == null) envelope.From = ORG;
            
            // >> Add Sender Email On Template
            envelope.Content.Sender = envelope.From.Correo;

            var from    = new EmailAddress(envelope.From.Correo, envelope.From.Nombre);
            var to      = new EmailAddress(envelope.To.Correo, envelope.To.Nombre);
            var msg     = MailHelper.CreateSingleEmail(from, to, envelope.Subject, envelope.Content.Plain, envelope.Content.GetHtml());

            // >> Almacenar registro de notificacion
            var notificacion = new Notificacion
            {
                Remitente = envelope.From.ToString(),
                Destinatario = envelope.To.ToString(),
                Fecha = DateTime.Now,
                Mensaje = envelope.Content.Plain,
                Tipo = "MAIL"
            };
            NotificacionCrud.Create(notificacion);

            return SGClient.SendEmailAsync(msg);
        }
    }

}
