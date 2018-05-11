using Entities.Classes;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Cliente.Lib.Requester
{
    public class RequestParams
    {
        public string Url { get; set; } = "";
        public HttpMethod Method { get; set; } = HttpMethod.Post;
        public List<RequestHeader> Headers { get; set; } = new List<RequestHeader>();
        public BaseEntity Body { get; set; } = new BaseEntity();

        public RequestParams ()
        {

        }
    }
}
