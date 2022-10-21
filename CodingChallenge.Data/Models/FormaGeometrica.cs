using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Models
{
    public class FormaGeometrica
    {
        public int Tipo { get; set; }
        public decimal Lado { get; set; }
        public decimal Base { get; set; }
        public decimal BaseMayor { get; set; }
        public decimal Area { get; set; }
        public decimal Perimetro { get; set; }
        public enum Tipos
        {
            Cuadrado = 1,
            TrianguloEquilatero,
            Circulo,
            TrapecioRectangulo,
            Rectangulo,
        }
    }
}
