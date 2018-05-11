using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class LineaDetalle : BaseEntity
    {
        public int Id { get; set; }
        public int IdTipo { get; set; }
        public int IdPedido { get; set; }
        public string Nombre { get; set; }
        public double Cantidad { get; set; }
        public double Total { get; set; }

        public LineaDetalle()
        {

        }

    }
}
