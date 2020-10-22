using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class MaquinariaYEquipo : CostosIndirectos
    {
        public string SubCodigoIndirecto { get; set; }
        public double CantidadUnidadOrdenProduccion { get; set; }
        public string TipoMaquinariaYEquipo { get; set; }
        public double Cantidad { get; set; }
        public double ValorMercado { get; set; }
        public double Costo { get; set; }
        public double CostoTotal { get; set; }
        public double TiempoMaquinaria { get; set; }
        public double SubtotalMaquinariaYEquipoCostoTotal { get; set; }
        public double SubtotalMaquinariaYEquipoPorcentajeTotal { get; set; }
        public int CodigoPK { get; set; }

        public void CalcularCosto(double diaAlMes, double horaTrabajoDia)
        {
            Costo = (ValorMercado/120)/diaAlMes/horaTrabajoDia/60;
        }
        public void CalcularCostoTotalMaquinariaYEquipo()
        {
            CostoTotal = TiempoMaquinaria * Costo;
        }
        public void CalcularPorcentajeMaquinariaYEquipo()
        {
            PorcentajeCosto = (CostoTotal * SubtotalMaquinariaYEquipoPorcentajeTotal) / SubtotalMaquinariaYEquipoCostoTotal;
        }

    }
}
