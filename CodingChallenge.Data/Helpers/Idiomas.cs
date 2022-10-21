using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Helpers
{
    public static class Idiomas
    {
        public enum Lenguas
        {
            Castellano = 1,
            Ingles,
            Italiano,
        }

        public static Dictionary<int, List<string>> IdiomasFrases = new Dictionary<int, List<string>>{
            { 1, new List<string>{ "<h1>Lista vacía de formas!</h1>", "<h1>Reporte de Formas</h1>", "TOTAL:<br/>", "formas", "Perímetro", "Área", "Cuadrado", "Cuadrados", "Círculo", "Círculos", "Triángulo", "Triángulos", "Trapecio", "Trapecios", "Rectángulo", "Rectángulos", "La lista contiene datos de forma inválidos", } },
            { 2, new List<string>{ "<h1>Empty list of shapes!</h1>", "<h1>Shapes report</h1>", "TOTAL:<br/>", "shapes", "Perimeter", "Area", "Square", "Squares", "Circle", "Circles", "Triangle", "Triangles", "Trapeze", "Trapezes", "Rectangle", "Rectangles", "The list contains invalid shape data", } },
            { 3, new List<string>{ "<h1>Elenco vuoto di forme!</h1>", "<h1>Raporto di forme</h1>", "TOTALE:<br/>", "forme", "Perimetro", "Area", "Quadrato", "Quadrati", "Cerchio", "Cerchi", "Triangolo", "Triangoli", "Trapezio", "Trapezi", "Rettangolo", "Rettangoli", "L'elenco contiene dati di forma non validi" } }
        };
    }
}
