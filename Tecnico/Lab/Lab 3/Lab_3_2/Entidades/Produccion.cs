using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Produccion : BaseEntity
    {
        // Propiedades (Get / Set)
        public int      Id              { get; set; }
        public int      IdAnimal        { get; set; }
        public string   Tipo            { get; set; }
        public double   Cantidad        { get; set; }
        public double   Valor           { get; set; }
        public DateTime FechaReg        { get; set; }
        // Consultas
        public DateTime RangoInicial    { get; set; }
        public DateTime RangoFinal      { get; set; }
        public string   CategoriaAnimal { get; set; }
        // Constructores
        public Produccion()
        {
        }
    }
}
