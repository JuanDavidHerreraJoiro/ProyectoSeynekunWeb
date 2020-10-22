using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class MateriaPrima
    {
        public MateriaPrima()
        {
            ParametrosDeReferencia = new ParametrosDeReferencia();
            LiquidacionMateriaPrima = new LiquidacionMateriaPrima();
        }

        public LiquidacionMateriaPrima LiquidacionMateriaPrima { get; set; }
        public ParametrosDeReferencia ParametrosDeReferencia { get; set; }
        public int CodigoPK { get; set; }
        public string Codigo { get; set; }
        public string SubCodigo { get; set; }
        public string Tipo { get; set; }
        public string UnidadConsumo { get; set; }
        public double ConsumoOP { get; set; }
        public double Costos { get; set; }
        public double CostosTotal { get; set; }
        public double PorcentajeParteDelCosto { get; set; }
        public double CantidadUnidadOrdenProduccion { get; set; }
        public double CostoTotalMateriaPrimaOrdenProduccion { get; set; }
        public double CostoPorcentajeTotalMateriaPrimaOrdenProduccion { get; set; }
  
        public void CalcularCostoTotal()
        {
            CostosTotal = ConsumoOP * Costos;
        }
        public abstract double CalcularPorcentajeParteDelCosto();
    }
        
}
