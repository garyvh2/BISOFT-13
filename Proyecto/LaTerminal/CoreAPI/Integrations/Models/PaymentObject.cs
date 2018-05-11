using CoreAPI.Integrations.Models;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Integrations.Models
{
    public class PaymentObject<T>
    {
        public Payment Payment { get; set; }
        public Usuario Comprador { get; set; }
        public Usuario Vendedor { get; set; }
        public T Producto { get; set; }
        public string Detalle { get; set; }

        public PaymentObject()
        {

        }
    }
}
