using CodingChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Helpers
{
    public class Formulas
    {
        public static decimal CalcularArea(FormaGeometrica forma)
        {
            decimal area;
            switch (forma.Tipo)
            {
                case (int)FormaGeometrica.Tipos.Cuadrado: 
                    area = forma.Lado * forma.Lado;
                    break;
                case (int)FormaGeometrica.Tipos.Circulo: 
                    area = (decimal)Math.PI * (forma.Lado / 2) * (forma.Lado / 2);
                    break;
                case (int)FormaGeometrica.Tipos.TrianguloEquilatero: 
                    area = ((decimal)Math.Sqrt(3) / 4) * forma.Lado * forma.Lado;
                    break;
                case (int)FormaGeometrica.Tipos.Rectangulo:
                    area = forma.Lado * forma.Base;
                    break;
                case (int)FormaGeometrica.Tipos.TrapecioRectangulo:
                    area = ((forma.Base + forma.BaseMayor) / 2) * forma.Lado;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }

            return area;
        }

        public static decimal CalcularPerimetro(FormaGeometrica forma)
        {
            decimal perimetro;
            switch (forma.Tipo)
            {
                case (int)FormaGeometrica.Tipos.Cuadrado: 
                    perimetro = forma.Lado * 4;
                    break;
                case (int)FormaGeometrica.Tipos.Circulo: 
                    perimetro = (decimal)Math.PI * forma.Lado;
                    break;
                case (int)FormaGeometrica.Tipos.TrianguloEquilatero: 
                    perimetro = forma.Lado * 3;
                    break;
                case (int)FormaGeometrica.Tipos.Rectangulo:
                    perimetro = (forma.Lado + forma.Base) * 2;
                    break;
                case (int)FormaGeometrica.Tipos.TrapecioRectangulo:
                    perimetro = (decimal)Math.Sqrt((double)(((forma.BaseMayor - forma.Base) * (forma.BaseMayor - forma.Base)) + (forma.Lado * forma.Lado))) + forma.Lado + forma.BaseMayor + forma.Base;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }

            return perimetro;
        }
    }
}
