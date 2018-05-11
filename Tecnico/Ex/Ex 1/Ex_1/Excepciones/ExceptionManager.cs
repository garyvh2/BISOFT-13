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
        // >> Exception Manager Instance
        private static ExceptionManager ExMInstance;
        // >> Exception CRUD Instance
        private static AppExceptionCrudFactory crudException;
        // >> Business Exception Dictionary
        private static Dictionary<int, AppMessage> messages = new Dictionary<int, AppMessage>();

        // >> Constructor
        private ExceptionManager()
        {
            // Load Messages Once
            LoadMessages();
        }
        // >> Singleton Return Instance
        public static ExceptionManager GetInstance()
        {
            // If the instance is undefined then create it
            if (ExMInstance == null)
            {
                // >> CRUD Exception Instantiation
                crudException = new AppExceptionCrudFactory();
                // >> Exception Manager Instantiation
                ExMInstance = new ExceptionManager();
            }
            // Otherwise return the instance
            return ExMInstance;
        }
        // >> Process an exception
        public void Process(Exception ex)
        {
            // >> Instanciate Business Exception
            var bussinessException = new BussinessException();
            // >> Determine the Exception Type
            if (ex.GetType() == typeof(BussinessException))
            {
                bussinessException = (BussinessException)ex;
                bussinessException.AppMessage = GetMessage(bussinessException.ExceptionId, bussinessException.AdditionalInformation);
            }
            else
            {
                // Obtain the Business App Message
                AppMessage appMessage = GetMessage(0);
                bussinessException = new BussinessException(appMessage.Message, ex);
                bussinessException.AppMessage = appMessage;
            }

            ProcessBussinesException(bussinessException);

        }

        private void ProcessBussinesException(BussinessException bussinessException)
        {
            // >> App Exception Instance
            AppException appException = new AppException();

            // >> Set Exception Date
            appException.Date = DateTime.Now;
            // >> Set Exception Code
            appException.Code = bussinessException.ExceptionId;
            // >> Set Exception Message
            appException.Message = "In catch block of Main method.\n" +
                                   "Caught: " + bussinessException.AppMessage.Message;

            // >> Set Exception Stack Trace 
            appException.Stacktrace = bussinessException.StackTrace;

            if (bussinessException.InnerException != null)
            {
                appException.Message += "\n" +
                                        "\tInner Exception: " + bussinessException.InnerException.Message;
                appException.Stacktrace = bussinessException.InnerException.StackTrace;
            }

            // >> Store Exception
            crudException.Create(appException);

            // >> Throw Bussiness Exception
            throw bussinessException;

        }
        // >> Get Bussiness Exception Message
        public AppMessage GetMessage(int exceptionId, string additionalInformation = "")
        {
            // >> Default Message
            var appMessage = new AppMessage();
            appMessage.Message = "Message not found!";

            // >> Find Exception 
            if (messages.ContainsKey(exceptionId))
            {
                appMessage = messages[exceptionId];
                appMessage.Message += additionalInformation;
            }
            
            // >> Return Message
            return appMessage;

        }
        // >> Get All Business Messages
        private void LoadMessages()
        {
            // >> Message CRUD Instance
            var crudMessages = new AppMessagesCrudFactory();
            // >> Get all messages
            var listMessages = crudMessages.RetrieveAll<AppMessage>();
            // >> Store the retrieved messages 
            foreach (var appMessage in listMessages)
            {
                messages.Add(appMessage.Id, appMessage);
            }
        }
    }
}
