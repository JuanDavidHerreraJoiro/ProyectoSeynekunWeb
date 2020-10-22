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
    public class InsumoRepository
    {
        List<Insumo> insumos;

        SqlConnection connection;
        SqlCommand command;
        public InsumoRepository(ConnectionManager connectionManager)
        {

            connection = connectionManager.connection;
            insumos = new List<Insumo>();
            command = new SqlCommand();
        }
        public void Guardar(Insumo insumo)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Insumos (CodigoInsumo,CodigoParametroReferencia,CantidadUnidadOrdenProduccion,CodigoCostosIndirectos,SubCodigoIndirecto,TipoInsumo,TipoUnidadConsumo,ConsumoUnitario,Costo,CostoTotal,PorcentajeCosto,SubtotalInsumoCostoTotal,SubtotalInsumoPorcentaje,CostoFinalTotal,PorcentajeFinalTotal) values (next value for seq_Insumo,@CodigoParametroReferencia,@CantidadUnidadOrdenProduccion,@CodigoCostosIndirectos,@SubCodigoIndirecto,@TipoInsumo,@TipoUnidadConsumo,@ConsumoUnitario,@Costo,@CostoTotal,@PorcentajeCosto,@SubtotalInsumoCostoTotal,@SubtotalInsumoPorcentaje,@CostoFinalTotal,@PorcentajeFinalTotal)";
                command.Parameters.AddWithValue("@CodigoInsumo", insumo.CodigoPK);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", insumo.ParametrosDeReferencia.Codigo);
                command.Parameters.AddWithValue("@CantidadUnidadOrdenProduccion", insumo.CantidadUnidadOrdenProduccion);
                command.Parameters.AddWithValue("@CodigoCostosIndirectos", insumo.CodigoCostosIndirecto);
                command.Parameters.AddWithValue("@SubCodigoIndirecto", insumo.SubCodigoIndirecto);
                command.Parameters.AddWithValue("@TipoInsumo", insumo.TipoInsumo);
                command.Parameters.AddWithValue("@TipoUnidadConsumo", insumo.TipoUnidadConsumo);
                command.Parameters.AddWithValue("@ConsumoUnitario", insumo.ConsumoUnitario);
                command.Parameters.AddWithValue("@Costo", insumo.Costo);
                command.Parameters.AddWithValue("@CostoTotal", insumo.CostoTotal);
                command.Parameters.AddWithValue("@PorcentajeCosto", insumo.PorcentajeCosto);
                command.Parameters.AddWithValue("@SubtotalInsumoCostoTotal", insumo.SubtotalInsumoCostoTotal);
                command.Parameters.AddWithValue("@SubtotalInsumoPorcentaje", insumo.SubtotalInsumoPorcentaje);
                command.Parameters.AddWithValue("@CostoFinalTotal", insumo.CostoFinalTotal);
                command.Parameters.AddWithValue("@PorcentajeFinalTotal", insumo.PorcentajeFinalTotal);

                command.ExecuteNonQuery();
            }
        }
        public List<Insumo> ConsultarTodo()
        {
            insumos.Clear();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT  Insumos.CodigoInsumo,Insumos.CodigoParametroReferencia,Insumos.CantidadUnidadOrdenProduccion,Insumos.CodigoCostosIndirectos,Insumos.SubCodigoIndirecto,Insumos.TipoInsumo,Insumos.TipoUnidadConsumo,Insumos.ConsumoUnitario,Insumos.Costo,Insumos.CostoTotal,Insumos.PorcentajeCosto,Insumos.SubtotalInsumoCostoTotal,Insumos.SubtotalInsumoPorcentaje,Insumos.CostoFinalTotal,Insumos.PorcentajeFinalTotal,ParametrosReferencia.ProductoExportar, ParametrosReferencia.PresentacionProducto FROM ParametrosReferencia  INNER JOIN Insumos ON ParametrosReferencia.Codigo = Insumos.CodigoParametroReferencia";
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Insumo insumo = DataReaderMapInsumo(dataReader);
                        insumos.Add(insumo);
                    }
                }
            }
            return insumos;
        }

        private Insumo DataReaderMapInsumo(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;

            Insumo insumo = new Insumo();

            insumo.CodigoPK = dataReader.GetInt32(0);
            insumo.ParametrosDeReferencia.Codigo = dataReader.GetString(1);
            insumo.CantidadUnidadOrdenProduccion = dataReader.GetDouble(2);
            insumo.CodigoCostosIndirecto = dataReader.GetString(3);
            insumo.SubCodigoIndirecto = dataReader.GetString(4);
            insumo.TipoInsumo = dataReader.GetString(5);
            insumo.TipoUnidadConsumo = dataReader.GetString(6);
            insumo.ConsumoUnitario = dataReader.GetDouble(7);
            insumo.Costo = dataReader.GetDouble(8);
            insumo.CostoTotal = dataReader.GetDouble(9);
            insumo.PorcentajeCosto = dataReader.GetDouble(10);
            insumo.SubtotalInsumoCostoTotal = dataReader.GetDouble(11);
            insumo.SubtotalInsumoPorcentaje = dataReader.GetDouble(12);
            insumo.CostoFinalTotal = dataReader.GetDouble(13);
            insumo.PorcentajeFinalTotal = dataReader.GetDouble(14);
            insumo.ParametrosDeReferencia.ProductoExportar = dataReader.GetString(15);
            insumo.ParametrosDeReferencia.PresentacionProducto = dataReader.GetDouble(16);

            return insumo;
        }

        public void Modificar(Insumo insumo)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Insumos SET CodigoParametroReferencia=@CodigoParametroReferencia,CantidadUnidadOrdenProduccion=@CantidadUnidadOrdenProduccion,CodigoCostosIndirectos=@CodigoCostosIndirectos,SubCodigoIndirecto=@SubCodigoIndirecto,TipoInsumo=@TipoInsumo,TipoUnidadConsumo=@TipoUnidadConsumo," +
                    "ConsumoUnitario=@ConsumoUnitario,Costo=@Costo,CostoTotal=@CostoTotal,PorcentajeCosto=@PorcentajeCosto,SubtotalInsumoCostoTotal=@SubtotalInsumoCostoTotal,SubtotalInsumoPorcentaje=@SubtotalInsumoPorcentaje,CostoFinalTotal=@CostoFinalTotal,PorcentajeFinalTotal=@PorcentajeFinalTotal WHERE CodigoParametroReferencia = @CodigoParametroReferencia and SubCodigoIndirecto = @SubCodigoIndirecto and CodigoCostosIndirectos = @CodigoCostosIndirectos";
                command.Parameters.AddWithValue("@CodigoInsumo", insumo.CodigoPK);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", insumo.ParametrosDeReferencia.Codigo);
                command.Parameters.AddWithValue("@CantidadUnidadOrdenProduccion", insumo.CantidadUnidadOrdenProduccion);
                command.Parameters.AddWithValue("@CodigoCostosIndirectos", insumo.CodigoCostosIndirecto);
                command.Parameters.AddWithValue("@SubCodigoIndirecto", insumo.SubCodigoIndirecto);
                command.Parameters.AddWithValue("@TipoInsumo", insumo.TipoUnidadConsumo);
                command.Parameters.AddWithValue("@TipoUnidadConsumo", insumo.TipoUnidadConsumo);
                command.Parameters.AddWithValue("@ConsumoUnitario", insumo.ConsumoUnitario);
                command.Parameters.AddWithValue("@Costo", insumo.Costo);
                command.Parameters.AddWithValue("@CostoTotal", insumo.CostoTotal);
                command.Parameters.AddWithValue("@PorcentajeCosto", insumo.PorcentajeCosto);
                command.Parameters.AddWithValue("@SubtotalInsumoCostoTotal", insumo.SubtotalInsumoCostoTotal);
                command.Parameters.AddWithValue("@SubtotalInsumoPorcentaje", insumo.SubtotalInsumoPorcentaje);
                command.Parameters.AddWithValue("@CostoFinalTotal", insumo.CostoFinalTotal);
                command.Parameters.AddWithValue("@PorcentajeFinalTotal", insumo.PorcentajeFinalTotal);

                command.ExecuteNonQuery();
            }
        }


        public void Eliminar(string codigoParametro, string subCodigo, string codigo)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE from Insumos where CodigoParametroReferencia = @CodigoParametroReferencia and SubCodigoIndirecto = @SubCodigoIndirecto and CodigoCostosIndirectos = @CodigoCostosIndirectos";
                command.Parameters.AddWithValue("@CodigoCostosIndirectos", codigo);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", codigoParametro);
                command.Parameters.AddWithValue("@SubCodigoIndirecto", subCodigo);
                command.ExecuteNonQuery();
            }
        }

        public List<Insumo> ValidarDato(string codigoParametro)
        {
            insumos = ConsultarTodo();
            return insumos.Where(i => i.ParametrosDeReferencia.Codigo.Equals(codigoParametro) && (i.CodigoCostosIndirecto.Equals("7301"))).ToList();
        }
        public List<Insumo> BuscarDato(string codigoParametro)
        {
            insumos = ConsultarTodo();
            return insumos.Where(i => i.ParametrosDeReferencia.Codigo.ToUpper().Trim().Contains(codigoParametro.ToUpper()) && (i.CodigoCostosIndirecto.Equals("7301"))).ToList();
        }
        public List<Insumo> BuscarTodo()
        {
            insumos = ConsultarTodo();
            return insumos.Where(i => i.CodigoCostosIndirecto.Equals("7301")).ToList();
        }

        public List<Insumo> BuscarDatoInsumo(string subcodigo, string codigoParametro)
        {
            insumos = ConsultarTodo();
            return insumos.Where(i => i.SubCodigoIndirecto.Trim().Equals(subcodigo.Trim()) && (i.ParametrosDeReferencia.Codigo.Trim().Equals(codigoParametro.Trim())) && (i.CodigoCostosIndirecto.Trim().Equals("7301"))).ToList();
        }
        public int ValidarSubcodigo(string subcodigo, string codigoParametro)
        {
            insumos = ConsultarTodo();
            return insumos.Where(i => i.SubCodigoIndirecto.Equals(subcodigo) && (i.ParametrosDeReferencia.Codigo.Equals(codigoParametro)) && (i.CodigoCostosIndirecto.Equals("7301"))).Count();
        }

        public double CalcularSubtotalInsumoCostoTotal(string codigoParametro)
        {
            insumos = ConsultarTodo();
            return insumos.Where(i => i.ParametrosDeReferencia.Codigo.Equals(codigoParametro) && (i.CodigoCostosIndirecto.Equals("7301"))).Sum(i => i.CostoTotal);
        }
        public double CalcularPorcentajeFinal(string codigoParametro)
        {
            insumos = ConsultarTodo();
            return (insumos.Where(i => i.ParametrosDeReferencia.Codigo.Equals(codigoParametro)).Sum(i => i.PorcentajeCosto));
        }
        public double CalcularCostoFinal(string codigoParametro)
        {
            insumos = ConsultarTodo();
            return insumos.Where(i => i.ParametrosDeReferencia.Codigo.Equals(codigoParametro)).Sum(i => i.CostoTotal);
        }
        public double CalcularSubTotalInsumoPorcentaje(string codigoParametro)
        {
            insumos = ConsultarTodo();
            return (insumos.Where(i => i.ParametrosDeReferencia.Codigo.Equals(codigoParametro) && (i.CodigoCostosIndirecto.Equals("7301"))).Sum(i => i.SubtotalInsumoCostoTotal) / insumos.Sum(i => i.CostoFinalTotal));
        }
        public double SumarCostoTotal(string codigoParametro)
        {
            insumos = ConsultarTodo();
            return insumos.Where(i=>i.ParametrosDeReferencia.Codigo.Equals(codigoParametro)).Sum(i=>i.CostoTotal);
        }
    }
}
