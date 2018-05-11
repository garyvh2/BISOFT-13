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
        public int      IdTipoProduccion    { get; set; }
        public double   Cantidad        { get; set; }
        public DateTime FechaReg        { get; set; }
        // Consultas
        public DateTime RangoInicial    { get; set; }
        public DateTime RangoFinal      { get; set; }
        public string   CategoriaAnimal { get; set; }
        // Constructores
        public Produccion()
        {
        }
        // Agregue esta validacion improvisada basandome en lo que usted habia hecho pero 
        // no doy uso de ella ya que yo valido cada campo individualmente a traves de ObtenerDatosProduccion
        public Produccion(int IdAnimal, string Tipo, double Cantidad, double Valor, DateTime FechaReg)
        {
            if (Tipo == "" ||
                Cantidad <= 0 ||
                Valor <= 0)
            {
                throw new Exception("Todos los campos son requeridos");
            }
            else
            {
                this.IdAnimal = IdAnimal;
                this.Cantidad = Cantidad;
                this.FechaReg = FechaReg;
            }
        }
    }
}
