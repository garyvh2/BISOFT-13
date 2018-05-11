using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class Operacion
    {
        public string tipoOperacion { get; set; }
        public double[] valores { get; set; }
        public double resultado { get; set; }
        public Operacion procesar(Operacion op)
        {
            switch (op.tipoOperacion)
            {
                case "sumar":
                    op.resultado = op.sumar();
                    break;
                case "restar":
                    op.resultado = op.restar();
                    break;
                case "multiplicar":
                    op.resultado = op.multiplicar();
                    break;
                case "dividir":
                    op.resultado = op.dividir();
                    break;
            }
            return op;
        }
        private double sumar()
        {
            double res = 0;
            foreach (double valor in this.valores)
            {
                res += valor;
            }
            return res;
        }
        private double restar()
        {
            double res = Double.NaN;
            foreach (double valor in this.valores)
            {
                if (Double.IsNaN(res)) res = valor;
                else res -= valor;
            }
            return res;
        }
        private double multiplicar()
        {
            double res = 1;
            foreach (double valor in this.valores)
            {
                res *= valor;
            }
            return res;
        }
        private double dividir()
        {
            double res = Double.NaN;
            foreach (double valor in this.valores)
            {
                if (Double.IsNaN(res)) res = valor;
                else res /= valor;
            }
            return res;
        }
    }
}