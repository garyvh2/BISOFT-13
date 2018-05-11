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
        public AppMessage AppMessage { get; set; }

        public BussinessException()
        {

        }

        public BussinessException(int exceptionId)
        {
            ExceptionId = exceptionId;
        }

        public BussinessException(int exceptionId, Exception innerException)
        {
            ExceptionId = exceptionId;
        }
    }
}
