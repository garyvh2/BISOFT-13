using DataAccess.CRUD;
using DataAccess.CRUD.ArchitectureComponents;
using DataAccess.MAPPER.ArchitectureComponents;
using Entities.Classes.ArquitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
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
        public void Process(Exception ex, bool storeOnly = false)
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
                bussinessException = new BussinessException(appMessage.Mensaje, ex);
                bussinessException.AppMessage = appMessage;
            }

            ProcessBussinesException(bussinessException, storeOnly);

        }

        private void ProcessBussinesException(BussinessException bussinessException, bool storeOnly)
        {
            // >> App Exception Instance
            AppException appException = new AppException();

            // >> Set Exception Date
            appException.Fecha = DateTime.Now;
            // >> Set Exception Code
            appException.Codigo = bussinessException.ExceptionId;
            // >> Set Exception Message
            appException.Mensaje = "In catch block of Main method.\n" +
                                   "Caught: " + bussinessException.AppMessage.Mensaje;

            // >> Set Exception Stack Trace 
            appException.Stacktrace = bussinessException.StackTrace ?? "";

            if (bussinessException.InnerException != null)
            {
                appException.Mensaje += "\n" +
                                        "\tInner Exception: " + bussinessException.InnerException.Message;
                appException.Stacktrace = bussinessException.InnerException.StackTrace ?? "";
            }

            // >> Store Exception
            crudException.Create(appException);

            // >> Throw Bussiness Exception
            if (!storeOnly)
            {
                throw bussinessException;
            }

        }
        // >> Get Bussiness Exception Message
        public AppMessage GetMessage(int exceptionId, string additionalInformation = "")
        {
            // >> Default Message
            var appMessage = new AppMessage();
            appMessage.Mensaje = "Message not found!";

            // >> Find Exception 
            if (messages.ContainsKey(exceptionId))
            {
                appMessage.Id = exceptionId;
                appMessage.Mensaje = messages[exceptionId].Mensaje + additionalInformation;
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
            var listMessages = crudMessages.RetrieveAll();
            // >> Store the retrieved messages 
            foreach (var appMessage in listMessages)
            {
                messages.Add(appMessage.Id, appMessage);
            }
        }
    }
}
