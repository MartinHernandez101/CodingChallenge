/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using CodingChallenge.Data.Helpers;
using CodingChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public class Reporte
    {
        public static string Imprimir(List<FormaGeometrica> formas, int idioma = (int)Idiomas.Lenguas.Ingles)
        {
            try
            {
                var sb = new StringBuilder();

                if (!formas.Any())
                {
                    sb.Append(Idiomas.IdiomasFrases[idioma][0]);
                }
                else
                {
                    if (ValidarFormas(formas))
                    {
                        // Hay por lo menos una forma
                        // HEADER
                        sb.Append(Idiomas.IdiomasFrases[idioma][1]);

                        var totales = new List<ResultadosTotales>();
                        for (var i = 0; i < formas.Count; i++)
                        {
                            formas[i].Area = Formulas.CalcularArea(formas[i]);
                            formas[i].Perimetro = Formulas.CalcularPerimetro(formas[i]);
                            if (!totales.Any(x => x.Forma.Tipo == formas[i].Tipo))
                            {
                                totales.Add(new ResultadosTotales
                                {
                                    NumeroTotal = 1,
                                    AreaTotal = formas[i].Area,
                                    PerimetroTotal = formas[i].Perimetro,
                                    Forma = formas[i],
                                });
                            }
                            else
                            {
                                int indice = totales.FindIndex(x => x.Forma.Tipo == formas[i].Tipo);
                                totales[indice].AreaTotal += formas[i].Area;
                                totales[indice].PerimetroTotal += formas[i].Perimetro;
                                totales[indice].NumeroTotal++;
                            }
                        }

                        foreach (var item in totales)
                        {
                            sb.Append(ObtenerLinea(item.NumeroTotal, item.AreaTotal, item.PerimetroTotal, item.Forma.Tipo, idioma));
                        }

                        // FOOTER
                        sb.Append(Idiomas.IdiomasFrases[idioma][2]);
                        sb.Append(totales.Sum(x => x.NumeroTotal).ToString() + " " + Idiomas.IdiomasFrases[idioma][3] + " ");
                        sb.Append(Idiomas.IdiomasFrases[idioma][4] + " " + totales.Sum(x => x.PerimetroTotal).ToString("#.##") + " ");
                        sb.Append(Idiomas.IdiomasFrases[idioma][5] + " " + totales.Sum(x => x.AreaTotal).ToString("#.##"));
                    }
                    else
                    {
                        sb.Append(Idiomas.IdiomasFrases[idioma][16]);
                    }
                }

                return sb.ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad > 0)
            {
                return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | {Idiomas.IdiomasFrases[idioma][5]} {area:#.##} | {Idiomas.IdiomasFrases[idioma][4]} {perimetro:#.##} <br/>";
            }
            return string.Empty;
        }

        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            switch (tipo)
            {
                case (int)FormaGeometrica.Tipos.Cuadrado:
                    return cantidad > 1 ? Idiomas.IdiomasFrases[idioma][7] : Idiomas.IdiomasFrases[idioma][6];
                case (int)FormaGeometrica.Tipos.Circulo:
                    return cantidad > 1 ? Idiomas.IdiomasFrases[idioma][9] : Idiomas.IdiomasFrases[idioma][8];
                case (int)FormaGeometrica.Tipos.TrianguloEquilatero:
                    return cantidad > 1 ? Idiomas.IdiomasFrases[idioma][11] : Idiomas.IdiomasFrases[idioma][10];
                case (int)FormaGeometrica.Tipos.Rectangulo:
                    return cantidad > 1 ? Idiomas.IdiomasFrases[idioma][15] : Idiomas.IdiomasFrases[idioma][14];
                case (int)FormaGeometrica.Tipos.TrapecioRectangulo:
                    return cantidad > 1 ? Idiomas.IdiomasFrases[idioma][13] : Idiomas.IdiomasFrases[idioma][12];
            }

            return string.Empty;
        }

        public static void GenerarArchivoHTML(string texto)
        {
            try
            {
                string nombreArchivo = $"Reporte_{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.htm";
                File.WriteAllText(string.Concat(@"C:\Users\Dell\Desktop\", nombreArchivo), texto);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private static bool ValidarFormas(List<FormaGeometrica> formas)
        {
            bool valido = true;
            foreach(var item in formas)
            {
                if (item.Tipo <= 0 || item.Tipo > (int)FormaGeometrica.Tipos.Rectangulo) valido = false;
                if (item.Tipo == (int)FormaGeometrica.Tipos.Rectangulo && (item.Lado <= 0 || item.Base <= 0)) valido = false;
                if ((item.Tipo == (int)FormaGeometrica.Tipos.Cuadrado || item.Tipo == (int)FormaGeometrica.Tipos.Circulo || item.Tipo == (int)FormaGeometrica.Tipos.TrianguloEquilatero) && item.Lado <= 0) valido = false;
                if (item.Tipo == (int)FormaGeometrica.Tipos.TrapecioRectangulo && (item.Lado <= 0 || item.Base <= 0 || item.BaseMayor <= 0 || item.Base >= item.BaseMayor)) valido = false;
            }

            return valido;
        }
    }
}
