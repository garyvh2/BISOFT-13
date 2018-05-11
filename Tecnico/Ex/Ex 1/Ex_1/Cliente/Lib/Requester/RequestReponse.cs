using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Lib.Requester
{
    public class RequestReponse<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
