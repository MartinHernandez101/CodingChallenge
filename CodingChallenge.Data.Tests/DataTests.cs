using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using CodingChallenge.Data.Helpers;
using CodingChallenge.Data.Models;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                Reporte.Imprimir(new List<FormaGeometrica>(), (int)Idiomas.Lenguas.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                Reporte.Imprimir(new List<FormaGeometrica>(), (int)Idiomas.Lenguas.Ingles));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> { new FormaGeometrica { Tipo = (int)FormaGeometrica.Tipos.Cuadrado, Lado = 5, } };

            var resumen = Reporte.Imprimir(cuadrados, (int)Idiomas.Lenguas.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>1 Cuadrado | Área 25 | Perímetro 20 <br/>TOTAL:<br/>1 formas Perímetro 20 Área 25", 
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Cuadrado, Lado = 5 },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Cuadrado, Lado = 1 },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Cuadrado, Lado = 3 },
            };

            var resumen = Reporte.Imprimir(cuadrados, (int)Idiomas.Lenguas.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Cuadrado, Lado = 5, },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Circulo, Lado = 3, },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.TrianguloEquilatero, Lado = 4, },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Cuadrado, Lado = 2, },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.TrianguloEquilatero, Lado = 9, },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Circulo, Lado = 2.75m, },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.TrianguloEquilatero, Lado = 4.2m, },
            };

            var resumen = Reporte.Imprimir(formas, (int)Idiomas.Lenguas.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Cuadrado, Lado = 5, },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Circulo, Lado = 3 },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.TrianguloEquilatero, Lado = 4 },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Cuadrado, Lado = 2 },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.TrianguloEquilatero, Lado = 9 },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Circulo, Lado = 2.75m },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.TrianguloEquilatero, Lado = 4.2m },
            };

            var resumen = Reporte.Imprimir(formas, (int)Idiomas.Lenguas.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Área 29 | Perímetro 28 <br/>2 Círculos | Área 13,01 | Perímetro 18,06 <br/>3 Triángulos | Área 49,64 | Perímetro 51,6 <br/>TOTAL:<br/>7 formas Perímetro 97,66 Área 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Cuadrado, Lado = 2 },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.TrapecioRectangulo, Lado = 2, Base = 3, BaseMayor = 5, },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Cuadrado, Lado = 4 },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Circulo, Lado = 10 },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.TrianguloEquilatero, Lado = 2, Base = 4 },
            };

            var resumen = Reporte.Imprimir(formas, (int)Idiomas.Lenguas.Italiano);

            Assert.AreEqual(
                "<h1>Raporto di forme</h1>2 Quadrati | Area 20 | Perimetro 24 <br/>1 Trapezio | Area 8 | Perimetro 12,83 <br/>1 Cerchio | Area 78,54 | Perimetro 31,42 <br/>1 Triangolo | Area 1,73 | Perimetro 6 <br/>TOTALE:<br/>5 forme Perimetro 74,24 Area 108,27",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConLadosEnCeroEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Cuadrado, Lado = 0 },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.TrapecioRectangulo, Lado = 0, Base = 3, BaseMayor = 5, },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Cuadrado, Lado = 0 },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Circulo, Lado = 0 },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.TrianguloEquilatero, Lado = 0, Base = 4 },
            };

            var resumen = Reporte.Imprimir(formas, (int)Idiomas.Lenguas.Italiano);

            Assert.AreEqual("L'elenco contiene dati di forma non validi", resumen);
        }

        [TestCase]
        public void TestResumenListaTrapecioRectanguloBaseMayorEsMenorABaseEnIngles()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.TrapecioRectangulo, Lado = 5, Base = 12, BaseMayor = 4, },
            };

            var resumen = Reporte.Imprimir(formas);

            Assert.AreEqual("The list contains invalid shape data", resumen);
        }

        [TestCase]
        public void TestResumenListaFormasConDatosNegativosEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.TrapecioRectangulo, Lado = -5, Base = -12, BaseMayor = -4, },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Cuadrado, Lado = -4 },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Circulo, Lado = -10 },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.TrianguloEquilatero, Lado = -2, Base = -4 },
            };

            var resumen = Reporte.Imprimir(formas, (int)Idiomas.Lenguas.Italiano);

            Assert.AreEqual("L'elenco contiene dati di forma non validi", resumen);
        }

        [TestCase]
        public void TestResumenListaFormasConDatosNegativosYPositivosEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.TrapecioRectangulo, Lado = 8, Base = 54, BaseMayor = -6, },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Cuadrado, Lado = 4 },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Circulo, Lado = 7 },
                new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.TrianguloEquilatero, Lado = 4, Base = -4 },
            };

            var resumen = Reporte.Imprimir(formas, (int)Idiomas.Lenguas.Castellano);

            Assert.AreEqual("La lista contiene datos de forma inválidos", resumen);
        }

        [TestCase]
        public void TestResumenListaFormasCienMilCuadradosEnItaliano()
        {
            var formas = new List<FormaGeometrica>();
            for (int i = 0; i < 100000; i++)
            {
                formas.Add(new FormaGeometrica { Tipo = (int)FormaGeometrica.Tipos.Cuadrado, Lado = 4, });
            }

            var resumen = Reporte.Imprimir(formas, (int)Idiomas.Lenguas.Italiano);

            Assert.AreEqual(
                "<h1>Raporto di forme</h1>100000 Quadrati | Area 1600000 | Perimetro 1600000 <br/>TOTALE:<br/>100000 forme Perimetro 1600000 Area 1600000", 
                resumen);
        }
    }
}
