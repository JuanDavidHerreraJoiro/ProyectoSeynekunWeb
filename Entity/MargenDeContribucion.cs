using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class MargenDeContribucion
    {
        public MargenDeContribucion()
        {
            parametrosDeReferencia = new ParametrosDeReferencia();
        }
        public ParametrosDeReferencia parametrosDeReferencia { get; set; }
        public int CodigoPK { get; set; }
        public decimal UnidadesProducidas { get; set; }
        public decimal PVUnitarioMercado { get; set; }
        public decimal Ventas { get; set; }
        public decimal CostoMateriaPrima { get; set; }
        public decimal CostoManoDeObra { get; set; }
        public decimal CostosIndirectosFabricacion { get; set; }
        public decimal MargenDecontribucion { get; set; }
        public decimal TotalVentas { get; set; }
        public decimal TotalCostoMateriaPrima { get; set; }
        public decimal TotalCostoManoDeObra { get; set; }
        public decimal TotalCostosIndirectosFabricacion { get; set; }
        public decimal TotalMargenDecontribucion { get; set; }
        public decimal TotalGastosGenerales { get; set; }
        public decimal PorcentajeVentas { get; set; }
        public decimal PorcentajeCostoMateriaPrima { get; set; }
        public decimal PorcentajeCostoManoDeObra { get; set; }
        public decimal PorcentajeCostosIndirectosFabricacion { get; set; }
        public decimal PorcentajeMargenDecontribucion { get; set; }
        public decimal GastosGenerales { get; set; }
        public decimal UtilidadPorcentaje { get; set; }
        public decimal PorcentajeGastoGenerales { get; set; }
        public decimal UtilidadTotal { get; set; }
        public decimal NumeroUnidades { get; set; }
        public decimal NumeroUnidadesTotal { get; set; }
        public decimal NumeroUtilidadesTotal { get; set; }

        public void CalcularMargenContribucion()
        {
            MargenDecontribucion = Ventas - CostoMateriaPrima - CostoManoDeObra - CostosIndirectosFabricacion;
        }
        public void CalcularUnidades()
        {
            NumeroUnidades = GastosGenerales / MargenDecontribucion;
        }
        public decimal CalcularUnitario(decimal valor)
        {
            decimal calculo;
            calculo = valor / PVUnitarioMercado;
            return calculo;
        }
        public decimal CalcularTotales(decimal valor)
        {
            decimal calculo;
            calculo = valor * UnidadesProducidas;
            return calculo;
        }
        public void CalcularTotalMargenContribucion()
        {
            TotalMargenDecontribucion = TotalVentas - TotalCostoMateriaPrima - TotalCostoManoDeObra - TotalCostosIndirectosFabricacion;
        }
        public void CalcularUtilidad()
        {
            NumeroUnidadesTotal = TotalMargenDecontribucion - TotalGastosGenerales;
        }
        public decimal CalcularPorcentajes(decimal valor)
        {
            decimal calcular;
            calcular = (valor / TotalVentas)*100;
            return calcular;
        }
    }
}
