using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ManoDeObraEtapas : ManoDeObra
    {
        public int ManoDeObraEtapasPk { get; set; }
        public double NumeroEmpleado { get; set; }
        public double DiasHabilesAño { get; set; }
        public double DiasHabilesMes { get; set; }
        public double HorasDiaProductivas{ get; set; }
        public double HorasTrabajoEfectivo { get; set; }
        public double TotalHorasMes { get; set; }
        public double CostoHora { get; set; }
        public double CostoMinuto { get; set; }
        public double NumeroEmpleadoTotal { get; set; }
        public double DiasHabilesAñoTotal { get; set; }
        public double DiasHabilesMesTotal { get; set; }
        public double HorasDiaProductivasTotal { get; set; }
        public double HorasTrabajoEfectivoTotal { get; set; }
        public double TotalHorasMesTotal { get; set; }
        public double CostoHoraTotal { get; set; }
        public double CostoMinutoTotal { get; set; }

        public void CalcularHorasTrabajoEfectivo()
        {
            HorasTrabajoEfectivo = NumeroEmpleado * HorasDiaProductivas;
        }
        public void CalcularTotalHorasMes()
        {
            TotalHorasMes = HorasTrabajoEfectivo * DiasHabilesMes;
        }
        public void CalcularCostoHora(Double ValorTotalFinalTipo)
        {
            CostoHora = ValorTotalFinalTipo / TotalHorasMes;
        }
        public void CalcularCostoMinuto()
        {
            CostoMinuto = CostoHora / 60;
        }

    }
}
