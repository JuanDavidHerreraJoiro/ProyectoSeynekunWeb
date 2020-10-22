using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class MargenContribucionRepository
    {
        List<MaquinariaYEquipo> maquinariaYEquipos;
        private string ruta = "MargenContribucion.txt";
        List<MargenDeContribucion> margenDeContribucions;

        SqlConnection connection;
        public MargenContribucionRepository(ConnectionManager connectionManager)
        {
            connection = connectionManager.connection;
            margenDeContribucions = new List<MargenDeContribucion>();
        }
        public void Guardar(MargenDeContribucion margen)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO MargenContribucion (CodigoMargenContribucion,CodigoParametroReferencia,UnidadesProducidas," +
                    "NumeroUnidadesTotal,PVUnitarioMercado,Ventas,CostoMateriaPrima,CostoManoDeObra,CostosIndirectosFabricacion,MargenDecontribucion," +
                    "GastosGenerales,TotalVentas,TotalCostoMateriaPrima,TotalCostoManoDeObra,TotalCostosIndirectosFabricacion,TotalMargenDecontribucion," +
                    "TotalGastosGenerales,UtilidadTotal,PorcentajeVentas,PorcentajeCostoMateriaPrima,PorcentajeCostoManoDeObra," +
                    "PorcentajeCostosIndirectosFabricacion,PorcentajeMargenDecontribucion,PorcentajeGastoGenerales,UtilidadPorcentaje,NumeroUtilidadesTotal) " +
                    "values (next value for seq_Margen,@CodigoParametroReferencia,@UnidadesProducidas," +
                    "@NumeroUnidadesTotal,@PVUnitarioMercado,@Ventas,@CostoMateriaPrima,@CostoManoDeObra,@CostosIndirectosFabricacion,@MargenDecontribucion," +
                    "@GastosGenerales,@TotalVentas,@TotalCostoMateriaPrima,@TotalCostoManoDeObra,@TotalCostosIndirectosFabricacion,@TotalMargenDecontribucion," +
                    "@TotalGastosGenerales,@UtilidadTotal,@PorcentajeVentas,@PorcentajeCostoMateriaPrima,@PorcentajeCostoManoDeObra," +
                    "@PorcentajeCostosIndirectosFabricacion,@PorcentajeMargenDecontribucion,@PorcentajeGastoGenerales,@UtilidadPorcentaje,@NumeroUtilidadesTotal)";
                command.Parameters.AddWithValue("@CodigoMargenContribucion", margen.CodigoPK);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", margen.parametrosDeReferencia.Codigo);
                command.Parameters.AddWithValue("@UnidadesProducidas", margen.UnidadesProducidas);
                command.Parameters.AddWithValue("@NumeroUnidadesTotal", margen.NumeroUnidadesTotal);
                command.Parameters.AddWithValue("@PVUnitarioMercado", margen.PVUnitarioMercado);
                command.Parameters.AddWithValue("@Ventas", margen.Ventas);
                command.Parameters.AddWithValue("@CostoMateriaPrima", margen.CostoMateriaPrima);
                command.Parameters.AddWithValue("@CostoManoDeObra", margen.CostoManoDeObra);
                command.Parameters.AddWithValue("@CostosIndirectosFabricacion", margen.CostosIndirectosFabricacion);
                command.Parameters.AddWithValue("@MargenDecontribucion", margen.MargenDecontribucion);
                command.Parameters.AddWithValue("@GastosGenerales", margen.GastosGenerales);
                command.Parameters.AddWithValue("@TotalVentas", margen.TotalVentas);
                command.Parameters.AddWithValue("@TotalCostoMateriaPrima", margen.TotalCostoMateriaPrima);
                command.Parameters.AddWithValue("@TotalCostoManoDeObra", margen.TotalCostoManoDeObra);
                command.Parameters.AddWithValue("@TotalCostosIndirectosFabricacion", margen.TotalCostosIndirectosFabricacion);
                command.Parameters.AddWithValue("@TotalMargenDecontribucion", margen.TotalMargenDecontribucion);
                command.Parameters.AddWithValue("@TotalGastosGenerales", margen.TotalGastosGenerales);
                command.Parameters.AddWithValue("@UtilidadTotal", margen.UtilidadTotal);
                command.Parameters.AddWithValue("@PorcentajeVentas", margen.PorcentajeVentas);
                command.Parameters.AddWithValue("@PorcentajeCostoMateriaPrima", margen.PorcentajeCostoMateriaPrima);
                command.Parameters.AddWithValue("@PorcentajeCostoManoDeObra", margen.PorcentajeCostoManoDeObra);
                command.Parameters.AddWithValue("@PorcentajeCostosIndirectosFabricacion", margen.PorcentajeCostosIndirectosFabricacion);
                command.Parameters.AddWithValue("@PorcentajeMargenDecontribucion", margen.PorcentajeMargenDecontribucion);
                command.Parameters.AddWithValue("@PorcentajeGastoGenerales", margen.PorcentajeGastoGenerales);
                command.Parameters.AddWithValue("@UtilidadPorcentaje", margen.UtilidadPorcentaje);
                command.Parameters.AddWithValue("@NumeroUtilidadesTotal", margen.NumeroUtilidadesTotal);

                command.ExecuteNonQuery();
            }
        }
        public List<MargenDeContribucion> ConsultarTodos()
        {
            
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT MC.CodigoMargenContribucion ,MC.CodigoParametroReferencia ,MC.UnidadesProducidas ,MC.NumeroUnidadesTotal ,MC.PVUnitarioMercado,MC.Ventas ,MC.CostoMateriaPrima ,MC.CostoManoDeObra ,MC.CostosIndirectosFabricacion ,MC.MargenDecontribucion ,MC.GastosGenerales ,MC.TotalVentas ,MC.TotalCostoMateriaPrima ,MC.TotalCostoManoDeObra ,MC.TotalCostosIndirectosFabricacion ,MC.TotalMargenDecontribucion ,MC.TotalGastosGenerales ,MC.UtilidadTotal ,MC.PorcentajeVentas ,MC.PorcentajeCostoMateriaPrima ,MC.PorcentajeCostoManoDeObra ,MC.PorcentajeCostosIndirectosFabricacion ,MC.PorcentajeMargenDecontribucion ,MC.PorcentajeGastoGenerales ,MC.UtilidadPorcentaje ,MC.NumeroUtilidadesTotal,PR.ProductoExportar,PR.CantidadExportar,PR.PresentacionProducto FROM MargenContribucion MC JOIN ParametrosReferencia PR ON MC.CodigoParametroReferencia=PR.Codigo";
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        MargenDeContribucion margen = DataReaderMapMargen(dataReader);
                        margenDeContribucions.Add(margen);
                    }
                }
            }
            return margenDeContribucions;
        }

        private MargenDeContribucion DataReaderMapMargen(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            MargenDeContribucion margen = new MargenDeContribucion();

            margen.CodigoPK = dataReader.GetInt32(0);
            margen.parametrosDeReferencia.Codigo = dataReader.GetString(1);
            margen.UnidadesProducidas = dataReader.GetDecimal(2);
            margen.NumeroUnidadesTotal = dataReader.GetDecimal(3);
            margen.PVUnitarioMercado = dataReader.GetDecimal(4);
            margen.Ventas = dataReader.GetDecimal(5);
            margen.CostoMateriaPrima = dataReader.GetDecimal(6);
            margen.CostoManoDeObra = dataReader.GetDecimal(7);
            margen.CostosIndirectosFabricacion = dataReader.GetDecimal(8);
            margen.MargenDecontribucion = dataReader.GetDecimal(9);
            margen.GastosGenerales = dataReader.GetDecimal(10);
            margen.TotalVentas = dataReader.GetDecimal(11);
            margen.TotalCostoMateriaPrima = dataReader.GetDecimal(12);
            margen.TotalCostoManoDeObra = dataReader.GetDecimal(13);
            margen.TotalCostosIndirectosFabricacion = dataReader.GetDecimal(14);
            margen.TotalMargenDecontribucion = dataReader.GetDecimal(15);
            margen.TotalGastosGenerales = dataReader.GetDecimal(16);
            margen.UtilidadTotal = dataReader.GetDecimal(17);
            margen.PorcentajeVentas = dataReader.GetDecimal(18);
            margen.PorcentajeCostoMateriaPrima = dataReader.GetDecimal(19);
            margen.PorcentajeCostoManoDeObra = dataReader.GetDecimal(20);
            margen.PorcentajeCostosIndirectosFabricacion = dataReader.GetDecimal(21);
            margen.PorcentajeMargenDecontribucion = dataReader.GetDecimal(22);
            margen.PorcentajeGastoGenerales = dataReader.GetDecimal(23);
            margen.UtilidadPorcentaje = dataReader.GetDecimal(24);
            margen.NumeroUtilidadesTotal = dataReader.GetDecimal(25);
            margen.parametrosDeReferencia.ProductoExportar = dataReader.GetString(26);
            margen.parametrosDeReferencia.CantidadExportar = dataReader.GetDouble(27);
            margen.parametrosDeReferencia.PresentacionProducto = dataReader.GetDouble(28);
            return margen;
        }
        public void Modificar(MargenDeContribucion margen)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE MargenContribucion SET CodigoParametroReferencia=@CodigoParametroReferencia,UnidadesProducidas=@UnidadesProducidas," +
                    "NumeroUnidadesTotal=@NumeroUnidadesTotal,PVUnitarioMercado=@PVUnitarioMercado,Ventas=@Ventas,CostoMateriaPrima=@CostoMateriaPrima,CostoManoDeObra=@CostoManoDeObra,CostosIndirectosFabricacion=@CostosIndirectosFabricacion,MargenDecontribucion=@MargenDecontribucion," +
                    "GastosGenerales=@GastosGenerales,TotalVentas=@TotalVentas,TotalCostoMateriaPrima=@TotalCostoMateriaPrima,TotalCostoManoDeObra=@TotalCostoManoDeObra,TotalCostosIndirectosFabricacion=@TotalCostosIndirectosFabricacion,TotalMargenDecontribucion=@TotalMargenDecontribucion," +
                    "TotalGastosGenerales=@TotalGastosGenerales,UtilidadTotal=@UtilidadTotal,PorcentajeVentas=@PorcentajeVentas,PorcentajeCostoMateriaPrima=@PorcentajeCostoMateriaPrima,PorcentajeCostoManoDeObra=@PorcentajeCostoManoDeObra," +
                    "PorcentajeCostosIndirectosFabricacion=@PorcentajeCostosIndirectosFabricacion,PorcentajeMargenDecontribucion=@PorcentajeMargenDecontribucion,PorcentajeGastoGenerales=@PorcentajeGastoGenerales,UtilidadPorcentaje=@UtilidadPorcentaje,NumeroUtilidadesTotal=@NumeroUtilidadesTotal WHERE CodigoParametroReferencia=@CodigoParametroReferencia";
                command.Parameters.AddWithValue("@CodigoMargenContribucion", margen.CodigoPK);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", margen.parametrosDeReferencia.Codigo);
                command.Parameters.AddWithValue("@UnidadesProducidas", margen.UnidadesProducidas);
                command.Parameters.AddWithValue("@NumeroUnidadesTotal", margen.NumeroUnidadesTotal);
                command.Parameters.AddWithValue("@PVUnitarioMercado", margen.PVUnitarioMercado);
                command.Parameters.AddWithValue("@Ventas", margen.Ventas);
                command.Parameters.AddWithValue("@CostoMateriaPrima", margen.CostoMateriaPrima);
                command.Parameters.AddWithValue("@CostoManoDeObra", margen.CostoManoDeObra);
                command.Parameters.AddWithValue("@CostosIndirectosFabricacion", margen.CostosIndirectosFabricacion);
                command.Parameters.AddWithValue("@MargenDecontribucion", margen.MargenDecontribucion);
                command.Parameters.AddWithValue("@GastosGenerales", margen.GastosGenerales);
                command.Parameters.AddWithValue("@TotalVentas", margen.TotalVentas);
                command.Parameters.AddWithValue("@TotalCostoMateriaPrima", margen.TotalCostoMateriaPrima);
                command.Parameters.AddWithValue("@TotalCostoManoDeObra", margen.TotalCostoManoDeObra);
                command.Parameters.AddWithValue("@TotalCostosIndirectosFabricacion", margen.TotalCostosIndirectosFabricacion);
                command.Parameters.AddWithValue("@TotalMargenDecontribucion", margen.TotalMargenDecontribucion);
                command.Parameters.AddWithValue("@TotalGastosGenerales", margen.TotalGastosGenerales);
                command.Parameters.AddWithValue("@UtilidadTotal", margen.UtilidadTotal);
                command.Parameters.AddWithValue("@PorcentajeVentas", margen.PorcentajeVentas);
                command.Parameters.AddWithValue("@PorcentajeCostoMateriaPrima", margen.PorcentajeCostoMateriaPrima);
                command.Parameters.AddWithValue("@PorcentajeCostoManoDeObra", margen.PorcentajeCostoManoDeObra);
                command.Parameters.AddWithValue("@PorcentajeCostosIndirectosFabricacion", margen.PorcentajeCostosIndirectosFabricacion);
                command.Parameters.AddWithValue("@PorcentajeMargenDecontribucion", margen.PorcentajeMargenDecontribucion);
                command.Parameters.AddWithValue("@PorcentajeGastoGenerales", margen.PorcentajeGastoGenerales);
                command.Parameters.AddWithValue("@UtilidadPorcentaje", margen.UtilidadPorcentaje);
                command.Parameters.AddWithValue("@NumeroUtilidadesTotal", margen.NumeroUtilidadesTotal);



                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(string codigo)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM MargenContribucion WHERE CodigoParametroReferencia=@CodigoParametroReferencia";
                command.Parameters.AddWithValue("@CodigoParametroReferencia", codigo);
                command.ExecuteNonQuery();
            }
        }

        public double ValidarRepetido(string codigo)
        {
            List<MargenDeContribucion> margenDeContribucions = ConsultarTodos();
            return margenDeContribucions.Where(i => i.parametrosDeReferencia.Codigo.ToUpper().Trim().Equals(codigo.ToUpper())).Count();
        }
        public List<MargenDeContribucion> DatoRepetido(string codigo)
        {
            List<MargenDeContribucion> margenDeContribucions = ConsultarTodos();
            return margenDeContribucions.Where(i => i.parametrosDeReferencia.Codigo.ToUpper().Trim().Equals(codigo.ToUpper())).ToList();
        }
        public IList<MargenDeContribucion> BuscarTodo()
        {
            IList<MargenDeContribucion> margenDeContribucions = ConsultarTodos();
            return margenDeContribucions.ToList();
        }
        public IList<MargenDeContribucion> BuscarCodigoParametro(string CodigoParametro)
        {
            IList<MargenDeContribucion> margenDeContribucions = ConsultarTodos();
            return margenDeContribucions.Where(i => i.parametrosDeReferencia.Codigo.ToUpper().Trim().Contains(CodigoParametro.ToUpper())).ToList();
        }
    }
}
