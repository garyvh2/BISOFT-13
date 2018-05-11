﻿using Entidades.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AppException : BaseEntity
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public string Stacktrace { get; set; }
        public DateTime Date { get; set; }
    }
}
