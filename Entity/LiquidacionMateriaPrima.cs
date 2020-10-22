using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LiquidacionMateriaPrima
    {
        List<MateriaPrima> materiaPrimas;
        public LiquidacionMateriaPrima()
        {
            materiaPrimas = new List<MateriaPrima>();
        }
        public double PorcentajeParteDelCosto { get; set; }
        public double SubtotalCostoTotalMateriaPrimaNacional { get; set; }
        public double SubtotalCostoTotalMateriaPrimaImportadas { get; set; }
        public double SubtotalPorcentajeMateriaPrimaNacional { get; set; }
        public double SubtotalPorcentajeMateriaPrimaImportadas { get; set; }

        public double TotalOrdenProduccion { get; set; }
        public double TotalPorcentajeOrdenProduccion { get; set; }

        public void LlenarLista(MateriaPrima materiaPrima)
        {
            materiaPrimas.Add(materiaPrima);
        }
        public double CalcularSubtotalCostoTotalMateriaPrimaNacional(string codigo)
        {
            return SubtotalCostoTotalMateriaPrimaNacional = materiaPrimas.Where(i => i.Codigo.Equals("7102") && (i.ParametrosDeReferencia.Codigo.Equals(codigo))).Sum(i => i.CostosTotal);
        }
        public double CalcularSubtotalCostoTotalMateriaPrimaImportadas(string codigo)
        {
            return SubtotalCostoTotalMateriaPrimaImportadas = materiaPrimas.Where(i => i.Codigo.Equals("7101") && (i.ParametrosDeReferencia.Codigo.Equals(codigo))).Sum(i => i.CostosTotal);
        }
        public void CalcularSubtotalPorcentajeMateriaPrimaNacional(string codigo)
        {
            SubtotalPorcentajeMateriaPrimaNacional = ((CalcularSubtotalCostoTotalMateriaPrimaNacional(codigo) / CalcularTotalOrdenProduccion(codigo)) / 0.01);
        }
        public void CalcularSubtotalPorcentajeMateriaPrimaImportadas(string codigo)
        {
            SubtotalPorcentajeMateriaPrimaImportadas = ((CalcularSubtotalCostoTotalMateriaPrimaImportadas(codigo) / CalcularTotalOrdenProduccion(codigo)) / 0.01);
        }
        public double CalcularTotalOrdenProduccion(string codigo)
        {
            return SubtotalCostoTotalMateriaPrimaImportadas = materiaPrimas.Where(i => i.ParametrosDeReferencia.Codigo.Equals(codigo)).Sum(i => i.CostosTotal);
        }
        public void CalcularTotalPorcentajeOrdenProduccion()
        {
            TotalPorcentajeOrdenProduccion = SubtotalPorcentajeMateriaPrimaNacional + SubtotalPorcentajeMateriaPrimaImportadas;
        }

        public double ConsultarTipo(string Tipo, string codigo)
        {
            return Convert.ToDouble(materiaPrimas.Where(i => i.Codigo.Equals(Tipo) && i.ParametrosDeReferencia.Codigo.Equals(codigo)).Count());
        }


      }
    }

