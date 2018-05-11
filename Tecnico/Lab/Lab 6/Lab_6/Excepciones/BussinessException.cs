using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Excepciones
{
    public class BussinessException : Exception
    {
        public int ExceptionId { get; set; }
        public string AdditionalInformation { get; set; }
        public AppMessage AppMessage { get; set; }

        public BussinessException()
        {

        }

        public BussinessException(int exceptionId)
        {
            ExceptionId = exceptionId;
        }

        public BussinessException(int exceptionId, string additionalInformation)
        {
            ExceptionId = exceptionId;
            AdditionalInformation = additionalInformation;
        }

        public BussinessException(String message, Exception innerException) : base (message, innerException) {
        
        }
    }
}
