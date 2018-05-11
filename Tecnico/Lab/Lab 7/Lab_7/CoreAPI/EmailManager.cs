using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class EmailManager
    {
        // >> Exception Manager Instance
        private static EmailManager EmailManagerInstance;
        // >> SMTP Server Instance
        private static SmtpClient STMPServer;

        // >> Constants
        private static string ORG_EMAIL = "gvalverdeh@ucenfotec.ac.cr";

        // >> Constructor
        private EmailManager ()
        {
            CreateSMTPClient();
        }
        // >> Set SMTP Server
        private void CreateSMTPClient()
        {
            STMPServer.Port = 25;
            STMPServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            STMPServer.UseDefaultCredentials = false;
            STMPServer.Host = "smtp.gmail.com";
        }

        // >> Singleton Return Instance
        public static EmailManager GetInstance()
        {
            // If the instance is undefined then create it
            if (EmailManagerInstance == null)
            {
                // >> Exception Manager Instantiation
                STMPServer = new SmtpClient();
                EmailManagerInstance = new EmailManager();
            }
            // Otherwise return the instance
            return EmailManagerInstance;
        }

        public void SendMail (string recipient, string recipientName, string subject, string body, string bodyHTML)
        {
            var apiKey = "";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(ORG_EMAIL, "Granja Cenfotec");
            var to = new EmailAddress(recipient, recipientName);
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, body, bodyHTML);

            var response = client.SendEmailAsync(msg);
        }
    }
}
