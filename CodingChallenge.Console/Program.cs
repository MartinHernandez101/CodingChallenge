using CodingChallenge.Data.Classes;
using CodingChallenge.Data.Helpers;
using CodingChallenge.Data.Models;
using System;
using System.Collections.Generic;

namespace CodingChallenge.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<FormaGeometrica> formas = new List<FormaGeometrica>
                {
                    new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Cuadrado, Lado = 2 },
                    new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.TrapecioRectangulo, Lado = 2, Base = 3, BaseMayor = 5,},
                    new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Cuadrado, Lado = 4 },
                    new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.Circulo, Lado = 10 },
                    new FormaGeometrica{ Tipo = (int)FormaGeometrica.Tipos.TrianguloEquilatero, Lado = 2, Base = 4 },
                };

                string textoArchivo = Reporte.Imprimir(formas, (int)Idiomas.Lenguas.Italiano);
                Reporte.GenerarArchivoHTML(textoArchivo);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
