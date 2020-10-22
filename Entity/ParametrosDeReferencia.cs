using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ParametrosDeReferencia
    {
        public const double TONELADA = 1000000;
        public ParametrosDeReferencia()
        {
             FichaTecnica = new FichaTecnica();
        }
        public FichaTecnica FichaTecnica { get; set; }
        public string Codigo { get; set; }
        public string Empresa  { get; set; }
        public DateTime FechaDeCosteo { get; set; }
        public string ProductoExportar { get; set; }
        public double CantidadExportar { get; set; }
        public double PresentacionProducto { get; set; }
        public string Cliente  { get; set; }
        public decimal FactorPrestacionalSalarioNormal { get; set; }
        public decimal FactorAplicableALosContratistas { get; set; }
        public int DiaAlMes { get; set; }
        public int HoraDeTrabajoPorDia { get; set; }
        public double ComisionPorVenta { get; set; }
        public double MargenDeRentabilidadEsperado { get; set; }

        public double CalcularCantidadUnidadOrdenProduccion()
        {
           return (TONELADA * CantidadExportar)/ PresentacionProducto;
        }

}
}
