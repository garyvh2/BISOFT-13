using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Animal : BaseEntity
    {
        // Propiedades (Get / Set)
        public int      Id              { get; set; }
        public int      IdTipoAnimal    { get; set; }
        public string   Nombre          { get; set; }
        public string   Alimento        { get; set; }
        public double   Edad            { get; set; }
        public DateTime FechaNac        { get; set; }
        // Constructores
        public Animal ()
        {
        }
        // Agregue esta validacion improvisada basandome en lo que usted habia hecho pero 
        // no doy uso de ella ya que yo valido cada campo individualmente a traves de ObtenerDatosAnimal
        public Animal(string Nombre, string Categoria, string Alimento, double Edad, DateTime FechaNac, string Genero)
        {
            if (Nombre == "" ||
                Categoria == "" ||
                Alimento == "" ||
                Edad <= 0 ||
                Genero == "")
            {
                throw new Exception("Todos los campos son requeridos");
            }
            else
            {
                this.Nombre = Nombre;
                this.Alimento = Alimento;
                this.Edad = Edad;
                this.FechaNac = FechaNac;
            }
        }
    }
}
