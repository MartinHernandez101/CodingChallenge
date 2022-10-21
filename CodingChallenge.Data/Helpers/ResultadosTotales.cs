using CodingChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Helpers
{
    public class ResultadosTotales
    {
        public int NumeroTotal { get; set; } = 0;
        public decimal AreaTotal { get; set; } = 0;
        public decimal PerimetroTotal { get; set; } = 0;
        public FormaGeometrica Forma { get; set; } = new FormaGeometrica();
    }
}
