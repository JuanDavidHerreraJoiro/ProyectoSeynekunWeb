using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class MateriasPrimasNacionales : MateriaPrima
    {
        public override double CalcularPorcentajeParteDelCosto()
        {
            return (CostosTotal *  LiquidacionMateriaPrima.SubtotalPorcentajeMateriaPrimaNacional) / LiquidacionMateriaPrima.SubtotalCostoTotalMateriaPrimaNacional;
        }

    }
}
