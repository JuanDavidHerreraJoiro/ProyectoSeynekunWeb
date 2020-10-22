using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CostosIndirectosFabricaGastosGenerales:CostosYGastosMensuales
    {
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public int CodigoPK { get; set; }
    }
}
