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
    public class MaquilasServiciosRepository
    {
        List<MaquilasYServicio> maquilasYServicios;
        private string ruta = "MaquilasYServicio.txt";
        SqlConnection connection;
        public MaquilasServiciosRepository(ConnectionManager connectionManager)
        {
            connection = connectionManager.connection;
            maquilasYServicios = new List<MaquilasYServicio>();
        }

        public void Guardar(MaquilasYServicio maquilas)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO MaquilasYServicios (CodigoMaquilasYServicios,CodigoParametroReferencia,CantidadUnidadOrdenProduccion,CodigoCostosIndirectos,SubCodigoIndirecto," +
                    "TipoMaquilasYServicios,Cantidad,Costo,ConsumoUnitario,CostoTotal,PorcentajeCosto,SubtotalMaquilasYServicioCostoTotal,SubtotalMaquilasYServicioPorcentajeTotal,CostoFinalTotal,PorcentajeFinalTotal) values (next value for seq_Maquilas,@CodigoParametroReferencia,@CantidadUnidadOrdenProduccion,@CodigoCostosIndirectos,@SubCodigoIndirecto,@TipoMaquilasYServicios,@Cantidad,@Costo,@ConsumoUnitario,@CostoTotal,@PorcentajeCosto,@SubtotalMaquilasYServicioCostoTotal,@SubtotalMaquilasYServicioPorcentajeTotal,@CostoFinalTotal,@PorcentajeFinalTotal)";
                command.Parameters.AddWithValue("@CodigoMaquinariaYEquipo", maquilas.CodigoPK);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", maquilas.ParametrosDeReferencia.Codigo);
                command.Parameters.AddWithValue("@CantidadUnidadOrdenProduccion", maquilas.CantidadUnidadOrdenProduccion);
                command.Parameters.AddWithValue("@CodigoCostosIndirectos", maquilas.CodigoCostosIndirecto);
                command.Parameters.AddWithValue("@SubCodigoIndirecto", maquilas.SubCodigoIndirecto);
                command.Parameters.AddWithValue("@TipoMaquilasYServicios", maquilas.TipoMaquilasYServicio);
                command.Parameters.AddWithValue("@Cantidad", maquilas.Cantidad);
                command.Parameters.AddWithValue("@Costo", maquilas.Costo);
                command.Parameters.AddWithValue("@ConsumoUnitario", maquilas.ConsumoUnitario);
                command.Parameters.AddWithValue("@CostoTotal", maquilas.CostoTotal);
                command.Parameters.AddWithValue("@PorcentajeCosto", maquilas.PorcentajeCosto);
                command.Parameters.AddWithValue("@SubtotalMaquilasYServicioCostoTotal", maquilas.SubtotalMaquilasYServicioCostoTotal);
                command.Parameters.AddWithValue("@SubtotalMaquilasYServicioPorcentajeTotal", maquilas.SubtotalMaquilasYServicioPorcentajeTotal);
                command.Parameters.AddWithValue("@CostoFinalTotal", maquilas.CostoFinalTotal);
                command.Parameters.AddWithValue("@PorcentajeFinalTotal", maquilas.PorcentajeFinalTotal);

                command.ExecuteNonQuery();
            }
        }
        public List<MaquilasYServicio> ConsultarTodo()
        {
            maquilasYServicios.Clear();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT MaquilasYServicios.CodigoMaquilasYServicios,MaquilasYServicios.CodigoParametroReferencia,MaquilasYServicios.CantidadUnidadOrdenProduccion,MaquilasYServicios.CodigoCostosIndirectos,MaquilasYServicios.SubCodigoIndirecto,MaquilasYServicios.TipoMaquilasYServicios,MaquilasYServicios.Cantidad,MaquilasYServicios.Costo,MaquilasYServicios.ConsumoUnitario,MaquilasYServicios.CostoTotal,MaquilasYServicios.PorcentajeCosto,MaquilasYServicios.SubtotalMaquilasYServicioCostoTotal,MaquilasYServicios.SubtotalMaquilasYServicioPorcentajeTotal,MaquilasYServicios.CostoFinalTotal,MaquilasYServicios.PorcentajeFinalTotal,ParametrosReferencia.ProductoExportar, ParametrosReferencia.PresentacionProducto FROM ParametrosReferencia INNER JOIN MaquilasYServicios ON ParametrosReferencia.Codigo = MaquilasYServicios.CodigoParametroReferencia";
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        MaquilasYServicio maquilas = DataReaderMapMaquilas(dataReader);
                        maquilasYServicios.Add(maquilas);
                    }
                }
            }
            return maquilasYServicios;
        }

        private MaquilasYServicio DataReaderMapMaquilas(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;

            MaquilasYServicio maquilas = new MaquilasYServicio();

            maquilas.CodigoPK = dataReader.GetInt32(0);
            maquilas.ParametrosDeReferencia.Codigo = dataReader.GetString(1);
            maquilas.CantidadUnidadOrdenProduccion = dataReader.GetDouble(2);
            maquilas.CodigoCostosIndirecto = dataReader.GetString(3);
            maquilas.SubCodigoIndirecto = dataReader.GetString(4);
            maquilas.TipoMaquilasYServicio = dataReader.GetString(5);
            maquilas.Cantidad = dataReader.GetDouble(6);
            maquilas.Costo = dataReader.GetDouble(7);
            maquilas.ConsumoUnitario = dataReader.GetDouble(8);
            maquilas.CostoTotal = dataReader.GetDouble(9);
            maquilas.PorcentajeCosto = dataReader.GetDouble(10);
            maquilas.SubtotalMaquilasYServicioCostoTotal = dataReader.GetDouble(11);
            maquilas.SubtotalMaquilasYServicioPorcentajeTotal = dataReader.GetDouble(13);
            maquilas.CostoFinalTotal = dataReader.GetDouble(13);
            maquilas.PorcentajeFinalTotal = dataReader.GetDouble(14);
            maquilas.ParametrosDeReferencia.ProductoExportar = dataReader.GetString(15);
            maquilas.ParametrosDeReferencia.PresentacionProducto = dataReader.GetDouble(16);

            return maquilas;
        }

        public void Modificar(MaquilasYServicio maquilas)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE MaquilasYServicios SET CodigoParametroReferencia=@CodigoParametroReferencia,CantidadUnidadOrdenProduccion=@CantidadUnidadOrdenProduccion,CodigoCostosIndirectos=@CodigoCostosIndirectos,SubCodigoIndirecto=@SubCodigoIndirecto" +
                    ",TipoMaquilasYServicios=@TipoMaquilasYServicios,Cantidad=@Cantidad,Costo=@Costo,ConsumoUnitario=@ConsumoUnitario,CostoTotal=@CostoTotal,PorcentajeCosto=@PorcentajeCosto,SubtotalMaquilasYServicioCostoTotal=@SubtotalMaquilasYServicioCostoTotal,SubtotalMaquilasYServicioPorcentajeTotal=@SubtotalMaquilasYServicioPorcentajeTotal,CostoFinalTotal=@CostoFinalTotal,PorcentajeFinalTotal=@PorcentajeFinalTotal where CodigoParametroReferencia = @CodigoParametroReferencia and SubCodigoIndirecto = @SubCodigoIndirecto and CodigoCostosIndirectos = @CodigoCostosIndirectos";
                command.Parameters.AddWithValue("@CodigoMaquinariaYEquipo", maquilas.CodigoPK);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", maquilas.ParametrosDeReferencia.Codigo);
                command.Parameters.AddWithValue("@CantidadUnidadOrdenProduccion", maquilas.CantidadUnidadOrdenProduccion);
                command.Parameters.AddWithValue("@CodigoCostosIndirectos", maquilas.CodigoCostosIndirecto);
                command.Parameters.AddWithValue("@SubCodigoIndirecto", maquilas.SubCodigoIndirecto);
                command.Parameters.AddWithValue("@TipoMaquilasYServicios", maquilas.TipoMaquilasYServicio);
                command.Parameters.AddWithValue("@Cantidad", maquilas.Cantidad);
                command.Parameters.AddWithValue("@Costo", maquilas.Costo);
                command.Parameters.AddWithValue("@ConsumoUnitario", maquilas.ConsumoUnitario);
                command.Parameters.AddWithValue("@CostoTotal", maquilas.CostoTotal);
                command.Parameters.AddWithValue("@PorcentajeCosto", maquilas.PorcentajeCosto);
                command.Parameters.AddWithValue("@SubtotalMaquilasYServicioCostoTotal", maquilas.SubtotalMaquilasYServicioCostoTotal);
                command.Parameters.AddWithValue("@SubtotalMaquilasYServicioPorcentajeTotal", maquilas.SubtotalMaquilasYServicioPorcentajeTotal);
                command.Parameters.AddWithValue("@CostoFinalTotal", maquilas.CostoFinalTotal);
                command.Parameters.AddWithValue("@PorcentajeFinalTotal", maquilas.PorcentajeFinalTotal);

                command.ExecuteNonQuery();
            }
        }
        public void Eliminar(string codigoParametro, string codigo, string subCodigo)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE from MaquinariaYEquipo where CodigoParametroReferencia = @CodigoParametroReferencia and SubCodigoIndirecto = @SubCodigoIndirecto and CodigoCostosIndirectos = @CodigoCostosIndirectos";
                command.Parameters.AddWithValue("@CodigoCostosIndirectos", codigo);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", codigoParametro);
                command.Parameters.AddWithValue("@SubCodigoIndirecto", subCodigo);
                command.ExecuteNonQuery();
            }
        }
        public List<MaquilasYServicio> BuscarDatoMaquilas(string subcodigo, string codigoParametro)
        {
            maquilasYServicios = ConsultarTodo();
            return maquilasYServicios.Where(i => i.SubCodigoIndirecto.Trim().Equals(subcodigo.Trim()) && (i.ParametrosDeReferencia.Codigo.Trim().Equals(codigoParametro.Trim())) && (i.CodigoCostosIndirecto.Trim().Equals("7303"))).ToList();
        }
        public List<MaquilasYServicio> ValidarDato(string codigoParametro)
        {
            maquilasYServicios = ConsultarTodo();
            return maquilasYServicios.Where(i => i.ParametrosDeReferencia.Codigo.Equals(codigoParametro) && (i.CodigoCostosIndirecto.Equals("7303"))).ToList();
        }
        public List<MaquilasYServicio> BuscarDato(string codigoParametro)
        {
            maquilasYServicios = ConsultarTodo();
            return maquilasYServicios.Where(i => i.ParametrosDeReferencia.Codigo.ToUpper().Trim().Contains(codigoParametro.ToUpper()) && (i.CodigoCostosIndirecto.Equals("7303"))).ToList();
        }
        public List<MaquilasYServicio> BuscarTodo()
        {
            maquilasYServicios = ConsultarTodo();
            return maquilasYServicios.Where(i => i.CodigoCostosIndirecto.Equals("7303")).ToList();
        }
        public int ValidarSubcodigo(string subcodigo, string codigoParametro)
        {
            maquilasYServicios = ConsultarTodo();
            return maquilasYServicios.Where(i => i.SubCodigoIndirecto.Equals(subcodigo) && (i.ParametrosDeReferencia.Codigo.Equals(codigoParametro)) && (i.CodigoCostosIndirecto.Equals("7303"))).Count();
        }

        public double CalcularSubtotalMaquilasYServicioCostoTotal(string codigoParametro)
        {
            maquilasYServicios = ConsultarTodo();
            return maquilasYServicios.Where(i => i.ParametrosDeReferencia.Codigo.Equals(codigoParametro) && (i.CodigoCostosIndirecto.Equals("7303"))).Sum(i => i.CostoTotal);
        }
        public double CalcularPorcentajeFinal(string codigoParametro)
        {
            maquilasYServicios = ConsultarTodo();
            return maquilasYServicios.Where(i => i.ParametrosDeReferencia.Codigo.Equals(codigoParametro)).Sum(i => i.PorcentajeCosto);
        }
        public double CalcularCostoFinal(string codigoParametro)
        {
            maquilasYServicios = ConsultarTodo();
            return maquilasYServicios.Where(i => i.ParametrosDeReferencia.Codigo.Equals(codigoParametro)).Sum(i => i.CostoTotal);
        }
        public double CalcularSubTotalMaquilasYServicioPorcentaje(string codigoParametro)
        {
            maquilasYServicios = ConsultarTodo();
            return maquilasYServicios.Where(i => i.ParametrosDeReferencia.Codigo.Equals(codigoParametro) && (i.CodigoCostosIndirecto.Equals("7303"))).Sum(i => i.SubtotalMaquilasYServicioCostoTotal) / maquilasYServicios.Sum(i => i.CostoFinalTotal);
        }
        public double SumarCostoTotal(string codigoParametro)
        {
            maquilasYServicios = ConsultarTodo();
            return maquilasYServicios.Where(i => i.ParametrosDeReferencia.Codigo.Equals(codigoParametro)).Sum(i => i.CostoTotal);
        }
    }
}
