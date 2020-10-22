using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CosteoGeneral
    {
        public CosteoGeneral()
        {
            ParametrosDeReferencia = new ParametrosDeReferencia();
            Trm = new TRM();
        }
        public int CosteoGeneralPK { get; set; }
        public ParametrosDeReferencia ParametrosDeReferencia { get; set; }
        public TRM Trm { get; set; }
        public decimal Op { get; set; }
        public decimal NumeroUnidades { get; set; }
        public decimal MateriaPrimaCOP { get; set; }
        public decimal ManoDeObraCOP { get; set; }
        public decimal CostosIndirectosDeFabricacionCOP { get; set; }
        public decimal TotalCostosProuduccionCOP { get; set; }
        public decimal GastosGeneralesCOP { get; set; }
        public decimal TotalCostoProductoCOP { get; set; }
        public decimal ComisionCOP { get; set; }
        public decimal UtilidadDeseadaCOP { get; set; }
        public decimal PrecioVentaSinGastosCOP { get; set; }
        public decimal PrecioVentaConGastosCOP { get; set; }
        public decimal PrecioReferenciaDelMercadoCOP { get; set; }
        public decimal MateriaPrimaSobreElCosto { get; set; }
        public decimal MateriaPrimaSobreLasVentas { get; set; }
        public decimal ManoDeObraSobreElCosto { get; set; }
        public decimal ManoDeObraSobreLasVentas { get; set; }
        public decimal CostosIndirectosDeFabricacionSobreElCosto { get; set; }
        public decimal CostosIndirectosDeFabricacionSobreLasVentas { get; set; }
        public decimal TotalCostosProduccionSobreElCosto { get; set; }
        public decimal TotalCostosProduccionSobreLasVentas { get; set; }
        public decimal GastosGeneralesSobreElCosto { get; set; }
        public decimal GastosGeneralesSobreLasVentas { get; set; }
        public decimal TotalCostoProductoSobreElCosto { get; set; }
        public decimal TotalCostoProductoSobreLasVentas { get; set; }
        public decimal ComisionSobreLasVentas { get; set; }
        public decimal UtilidadDeseadaLasVentas { get; set; }
        public decimal PrecioSinGastosSobreLasVentas { get; set; }
        public decimal PrecioConGastosSobreLasVentas { get; set; }
        public decimal MateriaPrimaUSD { get; set; }
        public decimal ManoDeObraUSD { get; set; }
        public decimal CostosIndirectosDeFabricacionUSD { get; set; }
        public decimal TotalCostosProuduccionUSD { get; set; }
        public decimal GastosGeneralesUSD { get; set; }
        public decimal TotalCostoProductoUSD { get; set; }
        public decimal ComisionUSD { get; set; }
        public decimal UtilidadDeseadaUSD { get; set; }
        public decimal PrecioVentaSinGastosUSD { get; set; }
        public decimal PrecioVentaConGastosUSD { get; set; }
        public decimal PrecioReferenciaDelMercadoUSD { get; set; }

        public decimal CalcularCambio(decimal COP, decimal TRM)
        {
            decimal cambio;
            cambio = COP / TRM;
            return cambio;
        }
        public void CalcularTotalCostosProduccionCOP()
        {
            TotalCostosProuduccionCOP = MateriaPrimaCOP + ManoDeObraCOP + CostosIndirectosDeFabricacionCOP;
        }
        public void CalcularTotalCostosProduccionUSD(decimal TRM)
        {
            TotalCostosProuduccionUSD = TotalCostosProuduccionCOP / TRM;
        }
        public void CalcularCostoTotalProducto()
        {
            TotalCostoProductoCOP = MateriaPrimaCOP + ManoDeObraCOP + CostosIndirectosDeFabricacionCOP + GastosGeneralesCOP;
        }
        public void CalcularPrecioVentaConGastos()
        {
            PrecioVentaConGastosCOP = (TotalCostoProductoCOP / (100 - UtilidadDeseadaLasVentas - ComisionSobreLasVentas))/Convert.ToDecimal(0.01);
        }
        public void CalcularComisionCOP()
        {
            ComisionCOP = PrecioVentaConGastosCOP * ComisionSobreLasVentas;
        }
        public void CalcularUtilidadCOP()
        {
            UtilidadDeseadaCOP = PrecioVentaConGastosCOP * UtilidadDeseadaLasVentas;
        }
        public void CulcularPrecioVentaSinGastos()
        {
            PrecioVentaSinGastosCOP = PrecioVentaConGastosCOP - GastosGeneralesCOP;
        }
        public void CalcularReferenciaMercadoUnitario()
        {
            PrecioReferenciaDelMercadoCOP = PrecioVentaConGastosCOP / NumeroUnidades;
        }
        public void CalcularPorcentajeMateriaPrima(string tipo)
        {
            if (tipo.Equals("SobreElCosto"))
            {
                MateriaPrimaSobreElCosto = MateriaPrimaCOP / PrecioVentaConGastosCOP;
            }
            MateriaPrimaSobreLasVentas = MateriaPrimaCOP / PrecioVentaConGastosCOP;
        }
        public decimal CalcularProcentajesSobreElCosto(decimal valor)
        {
            decimal sobreElCosto;
            sobreElCosto = (valor / TotalCostoProductoCOP)*100;

            return sobreElCosto;
        }

        public decimal CalcularPorcentajesSobreLasVentas(decimal valor)
        {
            decimal sobreElCosto;
            sobreElCosto = (valor / PrecioVentaConGastosCOP)*100;

            return sobreElCosto;
        }
    }
}
