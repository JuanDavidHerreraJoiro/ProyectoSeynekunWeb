using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ManoDeObraAnalisis: ManoDeObra
    {

        public ManoDeObraAnalisis()
        {
            procesosProduccion = new ProcesosProduccion();
            manoDeObraEtapas = new ManoDeObraEtapas();
        }
        public int ManoDeObraAnalisisPK { get; set; }
        public ProcesosProduccion  procesosProduccion { get; set; }
        public ManoDeObraEtapas manoDeObraEtapas { get; set; }
        public double Costo { get; set; }

        public void CalcularCosto()
        {
            Costo = procesosProduccion.TiempoCicloTotal * manoDeObraEtapas.CostoMinuto;
        }

    }
}
