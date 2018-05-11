using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPP.Models.Controls
{
    public class CtrlAPIResponse<T>
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public T items { get; set; }
    }
}