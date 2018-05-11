using Entities.Classes.ArquitectureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    // >> ===================================================================================== <<
    // >> BussinessException <<
    // >> Es una extencion de exceptiones para el manejo de mensajes de la logica del sistema
    // >> ===================================================================================== <<
    public class BussinessException : Exception
    {
        // >> Propiedades
        public int ExceptionId { get; set; }
        public string AdditionalInformation { get; set; } = "";
        public AppMessage AppMessage { get; set; }

        // >> Constructores
        // Vacio
        public BussinessException() { }
        // Bussiness Exception
        public BussinessException(int exceptionId)
        {
            ExceptionId = exceptionId;
        }
        // Extensive Bussines Exception
        public BussinessException(int exceptionId, string additionalInformation)
        {
            ExceptionId = exceptionId;
            AdditionalInformation = additionalInformation;
        }
        // Inner Exception
        public BussinessException(String message, Exception innerException) : base(message, innerException) { }
    }
}
