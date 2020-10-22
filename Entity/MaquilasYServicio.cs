using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class MaquilasYServicio : CostosIndirectos
    {
        public string SubCodigoIndirecto { get; set; }
        public double CantidadUnidadOrdenProduccion { get; set; }
        public string TipoMaquilasYServicio { get; set; }
        public double Cantidad { get; set; }
        public double Costo { get; set; }
        public double ConsumoUnitario { get; set; }
        public double CostoTotal { get; set; }
        public double SubtotalMaquilasYServicioCostoTotal { get; set; }
        public double SubtotalMaquilasYServicioPorcentajeTotal { get; set; }
        public int CodigoPK { get; set; }

        public void CalcularCostoTotalMaquilasYServicio()
        {
            CostoTotal = (ConsumoUnitario * Costo) / Cantidad;
        }
        public void CalcularPorcentajeMaquilasYServicio()
        {
            PorcentajeCosto = (CostoTotal * SubtotalMaquilasYServicioPorcentajeTotal) / SubtotalMaquilasYServicioCostoTotal;
        }

    }
}
