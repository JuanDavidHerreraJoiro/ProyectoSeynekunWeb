using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LiquidacionCostosIndirectos
    {
        public IList<Insumo> Insumos;
        IList<MaquinariaYEquipo> MaquinariaYEquipos;
        IList<MaquilasYServicio> MaquilasYServicios;
        IList<LiquidacionCostosIndirectos> liquidacions;
        Insumo insumo;
        public LiquidacionCostosIndirectos()
        {
            Insumos = new List<Insumo>();
            MaquinariaYEquipos = new List<MaquinariaYEquipo>();
            MaquilasYServicios = new List<MaquilasYServicio>();
            insumo = new Insumo();
            liquidacions = new List<LiquidacionCostosIndirectos>();

        }

        public double SubtotalInsumoCostoTotal { get; set; }
        public double SubtotalInsumoPorcentaje { get; set; }
        public double SubtotalCostoMaquinariaYEquipo { get; set; }
        public double SubtotalMaquilasYServicios { get; set; }
        public double PorcentajeMaquinariaYEquipo { get; set; }
        public double PorcentajeInsumo { get; set; }
        public double PorcentajeMaquilasYServicios { get; set; }
        public double CostoFinalTotal { get; set; }
        public double sumador { get; set; }
        public double COSTO { get; set; }


        public string LlenarListaInsumos(Insumo insumo)
        {
            Insumos.Add(insumo);
            CalcularCostoInsumo();
            return "LLENO";
        }

        private void CalcularCostoInsumo()
        {
            SubtotalInsumoCostoTotal = Insumos.Sum(i => i.CostoTotal);
        }

        public string LlenarListaMaquinaria(MaquinariaYEquipo maquinariaYEquipo)
        {
            MaquinariaYEquipos.Add(maquinariaYEquipo);
            CalcularCostoMaquinaria();
            return "LLENO";
        }

        private void CalcularCostoMaquinaria()
        {
            SubtotalCostoMaquinariaYEquipo = MaquinariaYEquipos.Sum(i => i.CostoTotal);
        }

        public string LlenarListaMaquilas(MaquilasYServicio maquilasYServicio)
        {
            MaquilasYServicios.Add(maquilasYServicio);
            CalcularCostoMaquilas();
            return "LLENO";
        }

        private void CalcularCostoMaquilas()
        {
            SubtotalMaquilasYServicios = MaquinariaYEquipos.Sum(i => i.CostoTotal);
        }

        public void CalcularCostoTotalInsumo(double ConsumoUnitario, double Costo)
        {
            COSTO = ConsumoUnitario * Costo;
        }
        public void Acomulador(double valor)
        {
            sumador = 0;
            sumador += valor;
        }

        public void CalcularSubtotalCostoInsumo()
        {
            SubtotalInsumoCostoTotal = Insumos.Sum(i => i.CostoTotal);
        }
        public void CalcularSubtotalCostoMaquinariaYEquipo()
        {
            SubtotalCostoMaquinariaYEquipo = MaquinariaYEquipos.Sum(i => i.CostoTotal);
        }
        public void CalcularSubtotalCostoMaquilasYServicio()
        {
            SubtotalMaquilasYServicios = MaquilasYServicios.Sum(i => i.CostoTotal);
        }
        public void CalcularSubtotalPorcentajelInsumo()
        {
            PorcentajeInsumo = (SubtotalInsumoCostoTotal / CostoFinalTotal) * 100;
        }
        public void CalcularSubtotalPorcentajeMaquinariaYEquipo()
        {
            PorcentajeMaquinariaYEquipo = (SubtotalCostoMaquinariaYEquipo / CostoFinalTotal) * 100;
        }

        public void CalcularSubtotalPorcentajeMaquilasYServicio()
        {
            PorcentajeMaquilasYServicios = (SubtotalMaquilasYServicios / CostoFinalTotal) * 100;
        }
        public void ActualizarPorcentajes()
        {
            CalcularTotalOrdenProduccion();
            CalcularSubtotalPorcentajelInsumo();
            CalcularSubtotalPorcentajeMaquinariaYEquipo();
            CalcularSubtotalPorcentajeMaquilasYServicio();
        }
        public void ActualizarListas()
        {
            foreach (var item in Insumos)
            {
               // item.CalcularPorcentaje(PorcentajeInsumo / SubtotalInsumoCostoTotal);
            }
        }
        public void ActualizarCostos()
        {
            CalcularCostoInsumo();
            CalcularCostoMaquilas();
            CalcularCostoMaquinaria();
        }
        public void CalcularTotalOrdenProduccion()
        {
            CostoFinalTotal = SubtotalInsumoCostoTotal + SubtotalCostoMaquinariaYEquipo + SubtotalMaquilasYServicios;
        }
        public void CalcularTotalPorcentajeOrdenProduccionInsumos()
        {
            CalcularSubtotalPorcentajelInsumo();

        }
    }
}
