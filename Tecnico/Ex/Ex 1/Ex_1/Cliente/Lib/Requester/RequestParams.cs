using Entidades;
using Entidades.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Lib.Requester
{
    public class RequestParams
    {
        public string url { get; set; } = "";
        public HttpMethod method { get; set; } = HttpMethod.Get;
        public List<RequestHeader> headers { get; set; } = new List<RequestHeader>();
        public BaseEntity body { get; set; } = new BaseEntity();

        public RequestParams ()
        {

        }
    }
}
