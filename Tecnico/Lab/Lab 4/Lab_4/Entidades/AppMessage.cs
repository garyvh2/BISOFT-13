using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AppMessage : BaseEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }

    }
}
