using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CalcularTRM
    {
        public CalcularTRM()
        {
            NumeroDesviacionesTrm = 2;
        }
        public decimal PromedioTrm { get; set; }
        public decimal DesviacionEstandarTrm { get; set; }
        public decimal NumeroDesviacionesTrm { get; set; }
        public decimal LimiteInferiorTrm { get; set; }
        public decimal CoverturaCambiariaTrm { get; set; }

        public void CalcularPromedioTrm(decimal SumarTodo, double Cantidad)
        {
            PromedioTrm = Math.Round((SumarTodo) / Convert.ToDecimal(Cantidad),2);
        }

        public void CalcularDesviacionTrm(IList<TRM> trm)
        {
            decimal M = 0;
            decimal S = 0;
            int K = 1;
            foreach (var item in trm)
            {
                decimal tmpM = M;
                M += (item.ValorTrm - tmpM) / K;
                S += (item.ValorTrm - tmpM) * (item.ValorTrm - M);
                K++;
            }
            DesviacionEstandarTrm = Math.Round(Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(S/(K-1)))),2);
        }

        public void CalcularLimiteInferiorTrm()
        {
            LimiteInferiorTrm = Math.Round(PromedioTrm - (DesviacionEstandarTrm * NumeroDesviacionesTrm),2);
        }

        public void CalcularCoberturaCambiaria(decimal ValorTrm)
        {
            CoverturaCambiariaTrm = Math.Round(ValorTrm - LimiteInferiorTrm,2);
        }

    }
}
