using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPP.Models.Controls
{
    public class CtrlAPIResponse<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
    }
}