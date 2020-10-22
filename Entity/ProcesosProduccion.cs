using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{//
    public class ProcesosProduccion
    {
        public ProcesosProduccion()
        {
            ParametrosDeReferencia = new ParametrosDeReferencia();
        }

        public ParametrosDeReferencia ParametrosDeReferencia { get; set; }
        public int CodigoProcesosProduccionPK { get; set; }
        public string Codigo { get; set; }
        public double Cantidad { get; set; }
        public string Tipo { get; set; }
        public double TiempoCicloTotal { get; set; }
        public double TiempoAlistamiento { get; set; }
        public double TiempoOperacion { get; set; }
        public double NumeroMaquinas { get; set; }
        public double NumeroOperarios { get; set; }
        public double PorcentajeRechazo { get; set; }
        public double NumeroTurnos { get; set; }
        public double Distancia { get; set; }
        public double Disponibilidad { get; set; }
        public double MantenimientoCorrectivo { get; set; }
        public double ParadasMenores { get; set; }
        public decimal UptimeFactorEficienciaProceso { get; set; }
        public double HorasTotalesDia { get; set; }
        public double MinutosTotalesDia { get; set; }
        public double HoraAlmuerzo{ get; set; }
        public double ParadasDescanzo { get; set; }
        public double TiempoNetoDisponibleMinutos{ get; set; }

        public void CalcularDisponibilidad()
        {
            Disponibilidad = TiempoNetoDisponibleMinutos * NumeroOperarios;
        }

        public void CalcularUptimeFactorEficienciaProceso()
        {
            UptimeFactorEficienciaProceso = Convert.ToDecimal((TiempoCicloTotal / (Disponibilidad + MantenimientoCorrectivo + ParadasMenores)/0.01));
        }
        public void CalcularMinutosTotalesDia()
        {
            MinutosTotalesDia = HorasTotalesDia * 60;
        }
        public void CalcularTiempoNetoDisponibleMinutos()
        {
            TiempoNetoDisponibleMinutos = (MinutosTotalesDia - HoraAlmuerzo - ParadasDescanzo);
        }

    }
}
