using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Insumo:CostosIndirectos
    {
        public string SubCodigoIndirecto { get; set; }
        public string TipoInsumo { get; set; }
        public string TipoUnidadConsumo { get; set; }
        public double CantidadUnidadOrdenProduccion { get; set; }
        public double ConsumoUnitario { get; set; }
        public double Costo { get; set; }
        public double CostoTotal { get; set; }
        public double TiempoMaquinaria { get; set; }
        public double SubtotalInsumoCostoTotal { get; set; }
        public double SubtotalInsumoPorcentaje { get; set; }
        public int CodigoPK { get; set; }
        public void CalcularCostoTotalInsumo()
        {
            CostoTotal = ConsumoUnitario * Costo;
        }
        public void CalcularPorcentaje()
        {
            PorcentajeCosto = CostoTotal * SubtotalInsumoPorcentaje / SubtotalInsumoCostoTotal;
        }
    }

}
