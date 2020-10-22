using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class FamiliaProductos
    {
        public FamiliaProductos()
        {
            parametrosDeReferencia = new ParametrosDeReferencia();
        }
        public int CodigoPK { get; set; }
        public ParametrosDeReferencia parametrosDeReferencia { get; set; }
        public string FamiliaProducto { get; set; }
        public double UnidadesVendidasMes { get; set; }
        public double VolumenVentas {get; set; }
        public double PorcentajeUnidadVendidas { get; set; }
        public double PorcentajeVolumenVentas { get; set; }
        public double PorcentajeUnidadVolumen { get; set; }
        public double CostosYGastosFamilia { get; set; }
        public double GastoAsignable { get; set; }
        public double TotalUnidadesVendidasMes { get; set; }
        public double TotalVolumenVentas { get; set; }
        public double TotalPorcentajeUnidadVendidas { get; set; }
        public double TotalPorcentajeVolumenVentas { get; set; }
        public double TotalPorcentajeUnidadVolumen { get; set; }
        public double TotalCostosYGastosFamilia { get; set; }
        public double TotalGastoAsignable { get; set; }

        public void CalcularVolumenVentas()
        {
            VolumenVentas = UnidadesVendidasMes * 6000;
        }
        public void CalcularPorcentajeUnidadVendidas()
        {
            PorcentajeUnidadVendidas = (UnidadesVendidasMes/ (TotalUnidadesVendidasMes)) * 100;
        }
        public void CalcularPorcentajeVolumenVentas()
        {
            PorcentajeVolumenVentas = (VolumenVentas / (TotalVolumenVentas)) * 100;
        }
        public void CalcularPorcentajeUnidadVolumen()
        {
            PorcentajeUnidadVolumen =  ((PorcentajeUnidadVendidas + PorcentajeVolumenVentas) / 2);
        }
        public void CalcularCostosYGastosFamilia(double GastosGenerales)
        {
            CostosYGastosFamilia = (PorcentajeUnidadVolumen * GastosGenerales);
        }
        public void CalcularGastoAsignable()
        {
            GastoAsignable =  (CostosYGastosFamilia / UnidadesVendidasMes);
        }
    }
}
