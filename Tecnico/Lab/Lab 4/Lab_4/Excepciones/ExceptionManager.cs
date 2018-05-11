using AccesoDatos.CRUD;
using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ExceptionManager
    {

        public string PATH = @"C:\_temp\logs\";

        private static ExceptionManager instance;


        private static ExceptionCrudFactory crudException;

        private static Dictionary<int, AppMessage> messages = new Dictionary<int, AppMessage>();

        private ExceptionManager()
        {
            LoadMessages();
        }

        public static ExceptionManager GetInstance()
        {
            if (instance == null)
            {
                crudException = new ExceptionCrudFactory();
                instance = new ExceptionManager();
            }

            return instance;
        }

        public void Process(Exception ex)
        {

            var bex = new BussinessException();

            if (ex.GetType() == typeof(BussinessException))
            {
                bex = (BussinessException)ex;
            }
            else
            {
                bex = new BussinessException(0, ex);
            }

            ProcessBussinesException(bex);

        }

        private void ProcessBussinesException(BussinessException bex)
        {
            var today = DateTime.Now.ToString("yyyyMMdd");
            var logName = PATH + today + "_" + "log.txt";

            var message = bex.Message + "\n" + bex.StackTrace + "\n";

            if (bex.InnerException != null)
                message += bex.InnerException.Message + "\n" + bex.InnerException.StackTrace;

            using (StreamWriter w = File.AppendText(logName))
            {
                Log(message, w);
            }

            bex.AppMessage = GetMessage(bex);

            AppException aex = new AppException();
            aex.Date = DateTime.Now;
            aex.Message = bex.Message + '\n' + bex.AppMessage.Message;
            aex.Stacktrace = bex.StackTrace;

            crudException.Create(aex);

            throw bex;

        }

        public AppMessage GetMessage(BussinessException bex)
        {

            var appMessage = new AppMessage();
            appMessage.Message = "Message not found!";

            if (messages.ContainsKey(bex.ExceptionId))
                appMessage = messages[bex.ExceptionId];

            return appMessage;

        }

        private void LoadMessages()
        {

            var crudMessages = new AppMessagesCrudFactory();

            var lstMessages = crudMessages.RetrieveAll<AppMessage>();

            foreach (var appMessage in lstMessages)
            {
                messages.Add(appMessage.Id, appMessage);
            }

        }

        private void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }

    }
}
