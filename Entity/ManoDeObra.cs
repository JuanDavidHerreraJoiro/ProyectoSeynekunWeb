using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ManoDeObra
    {
        public ManoDeObra()
        {
            ProcesosProduccion = new ProcesosProduccion();
            ParametrosDeReferencia = new ParametrosDeReferencia();
        }
        public int ManoDeObraPk { get; set; }
        public ProcesosProduccion ProcesosProduccion { get; set; }
        public ParametrosDeReferencia ParametrosDeReferencia { get; set; }
        public string CodigoManoDeObra { get; set; }
        public string SubCodigoManoDeObra { get; set; }
        public string Operario { get; set; }
        public double SalarioNetoMensual { get; set; }
        public string NominaServicio { get; set; }
        public double Bonificacion { get; set; }
        public double ValorTotal { get; set; }
        public double Porcentaje { get; set; }

        public double ValorTotalFinal { get; set; }
        public double PorcentajeFinal { get; set; }

        public void CalcularValorTotal()
        {
            ValorTotal = Convert.ToDouble((Convert.ToDecimal(SalarioNetoMensual) * ParametrosDeReferencia.FactorPrestacionalSalarioNormal) + Convert.ToDecimal(Bonificacion));
        }
        public void CalcularPorcentaje()
        {
            Porcentaje = ValorTotal / ValorTotalFinal;
        }

    }
}
