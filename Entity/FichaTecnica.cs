using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class FichaTecnica
    {
        public FichaTecnica()
        {
            Cliente = new Cliente();
        }

        public Cliente Cliente { get; set; }
        public string Codigo { get; set; }
        public string RazonSocial { get; set; }
        public string NombreDelGerente { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string ConsultorDeExportacion { get; set; }
        public string CelularConsultor { get; set; }
        public string Objetivo { get; set; }
        public string CorreoConsultor { get; set; }
        public string PaisObjetivo { get; set; }
        public string PaisAlterno { get; set; }
        public string PaisContingente { get; set; }
        public string TipoCanalDeDistribucion { get; set; }
        public string SegmentoObjetivo { get; set; }

              

     }
}
