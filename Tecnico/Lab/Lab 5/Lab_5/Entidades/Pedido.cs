using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido : BaseEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime Fecha { get; set; }
        public string Comercio { get; set; }
        public string Direccion { get; set; }
        public double Total { get; set; }
        public EstadoPedido Estado { get; set; }
        public List<LineaDetalle> LineasDePedido { get; set; }

        

        public Pedido ()
        {

        }
    }
}
