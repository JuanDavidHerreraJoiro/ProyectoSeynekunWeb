using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class CostosIndirectos
    {
        public CostosIndirectos()
        {
            ParametrosDeReferencia = new ParametrosDeReferencia();
            MateriaPrima = new MateriasPrimasNacionales();
        }
        public ParametrosDeReferencia ParametrosDeReferencia { get; set; }
        public MateriaPrima MateriaPrima { get; set; }
        public string CodigoCostosIndirecto { get; set; }
        public double PorcentajeCosto { get; set; }
        public double CostoFinalTotal { get; set; }
        public double PorcentajeFinalTotal { get; set; }

    }
}
