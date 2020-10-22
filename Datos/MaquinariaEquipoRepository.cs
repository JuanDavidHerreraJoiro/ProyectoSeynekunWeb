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
    public class MaquinariaEquipoRepository
    {
        List<MaquinariaYEquipo> maquinariaYEquipos;
        SqlConnection connection;
        public MaquinariaEquipoRepository(ConnectionManager connectionManager)
        {
            connection = connectionManager.connection;
            maquinariaYEquipos = new List<MaquinariaYEquipo>();
        }
        public void Guardar(MaquinariaYEquipo maquinaria)
        {

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO MaquinariaYEquipo (CodigoMaquinariaYEquipo,CodigoParametroReferencia,CantidadUnidadOrdenProduccion,CodigoCostosIndirectos,SubCodigoIndirecto," +
                    "TipoMaquinariaYEquipo,Cantidad,ValorMercado,Costo,TiempoMaquinaria,CostoTotal,PorcentajeDeCosto,SubtotalMaquinariaYEquipoCostoTotal,SubtotalMaquinariaYEquipoPorcentajeTotal,CostoFinalTotal,PorcentajeFinalTotal) values (next value for seq_Maquinas,@CodigoParametroReferencia,@CantidadUnidadOrdenProduccion,@CodigoCostosIndirectos,@SubCodigoIndirecto,@TipoMaquinariaYEquipo,@Cantidad,@ValorMercado,@Costo,@TiempoMaquinaria,@CostoTotal,@PorcentajeDeCosto,@SubtotalMaquinariaYEquipoCostoTotal,@SubtotalMaquinariaYEquipoPorcentajeTotal,@CostoFinalTotal,@PorcentajeFinalTotal)";
                command.Parameters.AddWithValue("@CodigoMaquinariaYEquipo", maquinaria.CodigoPK);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", maquinaria.ParametrosDeReferencia.Codigo);
                command.Parameters.AddWithValue("@CantidadUnidadOrdenProduccion", maquinaria.CantidadUnidadOrdenProduccion);
                command.Parameters.AddWithValue("@CodigoCostosIndirectos", maquinaria.CodigoCostosIndirecto);
                command.Parameters.AddWithValue("@SubCodigoIndirecto", maquinaria.SubCodigoIndirecto);
                command.Parameters.AddWithValue("@TipoMaquinariaYEquipo", maquinaria.TipoMaquinariaYEquipo);
                command.Parameters.AddWithValue("@Cantidad", maquinaria.Cantidad);
                command.Parameters.AddWithValue("@ValorMercado", maquinaria.ValorMercado);
                command.Parameters.AddWithValue("@Costo", maquinaria.Costo);
                command.Parameters.AddWithValue("@TiempoMaquinaria", maquinaria.TiempoMaquinaria);
                command.Parameters.AddWithValue("@CostoTotal", maquinaria.CostoTotal);
                command.Parameters.AddWithValue("@PorcentajeDeCosto", maquinaria.PorcentajeCosto);
                command.Parameters.AddWithValue("@SubtotalMaquinariaYEquipoCostoTotal", maquinaria.SubtotalMaquinariaYEquipoCostoTotal);
                command.Parameters.AddWithValue("@SubtotalMaquinariaYEquipoPorcentajeTotal", maquinaria.SubtotalMaquinariaYEquipoPorcentajeTotal);
                command.Parameters.AddWithValue("@CostoFinalTotal", maquinaria.CostoFinalTotal);
                command.Parameters.AddWithValue("@PorcentajeFinalTotal", maquinaria.PorcentajeFinalTotal);

                command.ExecuteNonQuery();
            }
        }
        public List<MaquinariaYEquipo> ConsultarTodo()
        {
            maquinariaYEquipos.Clear();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT  MaquinariaYEquipo.CodigoMaquinariaYEquipo,MaquinariaYEquipo.CodigoParametroReferencia,MaquinariaYEquipo.CantidadUnidadOrdenProduccion,MaquinariaYEquipo.CodigoCostosIndirectos,MaquinariaYEquipo.SubCodigoIndirecto,MaquinariaYEquipo.TipoMaquinariaYEquipo,MaquinariaYEquipo.Cantidad,MaquinariaYEquipo.ValorMercado,MaquinariaYEquipo.Costo,MaquinariaYEquipo.TiempoMaquinaria,MaquinariaYEquipo.CostoTotal,MaquinariaYEquipo.PorcentajeDeCosto,MaquinariaYEquipo.SubtotalMaquinariaYEquipoCostoTotal,MaquinariaYEquipo.SubtotalMaquinariaYEquipoPorcentajeTotal,MaquinariaYEquipo.CostoFinalTotal,MaquinariaYEquipo.PorcentajeFinalTotal,ParametrosReferencia.ProductoExportar,  ParametrosReferencia.CantidadExportar FROM ParametrosReferencia INNER JOIN MaquinariaYEquipo ON ParametrosReferencia.Codigo = MaquinariaYEquipo.CodigoParametroReferencia";
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        MaquinariaYEquipo maquinaria = DataReaderMapMaquinaria(dataReader);
                        maquinariaYEquipos.Add(maquinaria);
                    }
                }
            }
            return maquinariaYEquipos;
        }

        private MaquinariaYEquipo DataReaderMapMaquinaria(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;

            MaquinariaYEquipo maquinaria = new MaquinariaYEquipo();

            maquinaria.CodigoPK = dataReader.GetInt32(0);
            maquinaria.ParametrosDeReferencia.Codigo = dataReader.GetString(1);
            maquinaria.CantidadUnidadOrdenProduccion = dataReader.GetDouble(2);
            maquinaria.CodigoCostosIndirecto = dataReader.GetString(3);
            maquinaria.SubCodigoIndirecto = dataReader.GetString(4);
            maquinaria.TipoMaquinariaYEquipo = dataReader.GetString(5);
            maquinaria.Cantidad = dataReader.GetDouble(6);
            maquinaria.ValorMercado = dataReader.GetDouble(7);
            maquinaria.Costo = dataReader.GetDouble(8);
            maquinaria.TiempoMaquinaria = dataReader.GetDouble(9);
            maquinaria.CostoTotal = dataReader.GetDouble(10);
            maquinaria.PorcentajeCosto = dataReader.GetDouble(11);
            maquinaria.SubtotalMaquinariaYEquipoCostoTotal = dataReader.GetDouble(12);
            maquinaria.SubtotalMaquinariaYEquipoPorcentajeTotal = dataReader.GetDouble(13);
            maquinaria.CostoFinalTotal = dataReader.GetDouble(14);
            maquinaria.PorcentajeFinalTotal = dataReader.GetDouble(15);
            maquinaria.ParametrosDeReferencia.ProductoExportar = dataReader.GetString(16);
            maquinaria.ParametrosDeReferencia.CantidadExportar = dataReader.GetDouble(17);

            return maquinaria;
        }

        public void Modificar(MaquinariaYEquipo maquinaria)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE MaquinariaYEquipo SET CodigoParametroReferencia=@CodigoParametroReferencia,CantidadUnidadOrdenProduccion=@CantidadUnidadOrdenProduccion,CodigoCostosIndirectos=@CodigoCostosIndirectos,SubCodigoIndirecto=@SubCodigoIndirecto,TipoMaquinariaYEquipo=@TipoMaquinariaYEquipo,Cantidad=@Cantidad,ValorMercado=@ValorMercado,Costo=@Costo,TiempoMaquinaria=@TiempoMaquinaria,CostoTotal=@CostoTotal,PorcentajeDeCosto=@PorcentajeDeCosto,SubtotalMaquinariaYEquipoCostoTotal=@SubtotalMaquinariaYEquipoCostoTotal,SubtotalMaquinariaYEquipoPorcentajeTotal=@SubtotalMaquinariaYEquipoPorcentajeTotal,CostoFinalTotal=@CostoFinalTotal,PorcentajeFinalTotal=@PorcentajeFinalTotal where CodigoParametroReferencia = @CodigoParametroReferencia and SubCodigoIndirecto = @SubCodigoIndirecto and CodigoCostosIndirectos = @CodigoCostosIndirectos";
                command.Parameters.AddWithValue("@CodigoMaquinariaYEquipo", maquinaria.CodigoPK);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", maquinaria.ParametrosDeReferencia.Codigo);
                command.Parameters.AddWithValue("@CantidadUnidadOrdenProduccion", maquinaria.CantidadUnidadOrdenProduccion);
                command.Parameters.AddWithValue("@CodigoCostosIndirectos", maquinaria.CodigoCostosIndirecto);
                command.Parameters.AddWithValue("@SubCodigoIndirecto", maquinaria.SubCodigoIndirecto);
                command.Parameters.AddWithValue("@TipoMaquinariaYEquipo", maquinaria.TipoMaquinariaYEquipo);
                command.Parameters.AddWithValue("@Cantidad", maquinaria.Cantidad);
                command.Parameters.AddWithValue("@ValorMercado", maquinaria.ValorMercado);
                command.Parameters.AddWithValue("@Costo", maquinaria.Costo);
                command.Parameters.AddWithValue("@TiempoMaquinaria", maquinaria.TiempoMaquinaria);
                command.Parameters.AddWithValue("@CostoTotal", maquinaria.CostoTotal);
                command.Parameters.AddWithValue("@PorcentajeDeCosto", maquinaria.PorcentajeCosto);
                command.Parameters.AddWithValue("@SubtotalMaquinariaYEquipoCostoTotal", maquinaria.SubtotalMaquinariaYEquipoCostoTotal);
                command.Parameters.AddWithValue("@SubtotalMaquinariaYEquipoPorcentajeTotal", maquinaria.SubtotalMaquinariaYEquipoPorcentajeTotal);
                command.Parameters.AddWithValue("@CostoFinalTotal", maquinaria.CostoFinalTotal);
                command.Parameters.AddWithValue("@PorcentajeFinalTotal", maquinaria.PorcentajeFinalTotal);

                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(string codigoParametros, string codigo, string Subcodigo)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE from MaquinariaYEquipo where CodigoParametroReferencia = @CodigoParametroReferencia and SubCodigoIndirecto = @SubCodigoIndirecto and CodigoCostosIndirectos = @CodigoCostosIndirectos";
                command.Parameters.AddWithValue("@CodigoCostosIndirectos", codigo);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", codigoParametros);
                command.Parameters.AddWithValue("@SubCodigoIndirecto", Subcodigo);
                command.ExecuteNonQuery();
            }
        }

        public List<MaquinariaYEquipo> BuscarDatoMaquinaria(string subcodigo, string codigoParametro)
        {
            maquinariaYEquipos = ConsultarTodo();
            return maquinariaYEquipos.Where(i => i.SubCodigoIndirecto.Trim().Equals(subcodigo.Trim()) && (i.ParametrosDeReferencia.Codigo.Trim().Equals(codigoParametro.Trim())) && (i.CodigoCostosIndirecto.Trim().Equals("7302"))).ToList();
        }

        public List<MaquinariaYEquipo> ValidarDato(string codigoParametro)
        {
            maquinariaYEquipos = ConsultarTodo();
            return maquinariaYEquipos.Where(i => i.ParametrosDeReferencia.Codigo.Equals(codigoParametro) && (i.CodigoCostosIndirecto.Equals("7302"))).ToList();
        }
        public List<MaquinariaYEquipo> BuscarDato(string codigoParametro)
        {
            maquinariaYEquipos = ConsultarTodo();
            return maquinariaYEquipos.Where(i => i.ParametrosDeReferencia.Codigo.ToUpper().Trim().Contains(codigoParametro.ToUpper()) && (i.CodigoCostosIndirecto.Equals("7302"))).ToList();
        }
        public List<MaquinariaYEquipo> BuscarTodo()
        {
            maquinariaYEquipos = ConsultarTodo();
            return maquinariaYEquipos.Where(i => i.CodigoCostosIndirecto.Equals("7302")).ToList();
        }
        public int ValidarSubcodigo(string subcodigo, string codigoParametro)
        {
            maquinariaYEquipos = ConsultarTodo();
            return maquinariaYEquipos.Where(i => i.SubCodigoIndirecto.Equals(subcodigo) && (i.ParametrosDeReferencia.Codigo.Equals(codigoParametro)) && (i.CodigoCostosIndirecto.Equals("7302"))).Count();
        }

        public double CalcularSubtotalMaquinariaYEquipoCostoTotal(string codigoParametro)
        {
            maquinariaYEquipos = ConsultarTodo();
            return maquinariaYEquipos.Where(i => i.ParametrosDeReferencia.Codigo.Equals(codigoParametro) && (i.CodigoCostosIndirecto.Equals("7302"))).Sum(i => i.CostoTotal);
        }
        public double CalcularPorcentajeFinal(string codigoParametro)
        {
            maquinariaYEquipos = ConsultarTodo();
            return maquinariaYEquipos.Where(i => i.ParametrosDeReferencia.Codigo.Equals(codigoParametro)).Sum(i => i.PorcentajeCosto);
        }
        public double CalcularCostoFinal(string codigoParametro)
        {
            maquinariaYEquipos = ConsultarTodo();
            return maquinariaYEquipos.Where(i => i.ParametrosDeReferencia.Codigo.Equals(codigoParametro)).Sum(i => i.CostoTotal);
        }
        public double CalcularSubTotalMaquinariaYEquipoPorcentaje(string codigoParametro)
        {
            maquinariaYEquipos = ConsultarTodo();
            return maquinariaYEquipos.Where(i => i.ParametrosDeReferencia.Codigo.Equals(codigoParametro) && (i.CodigoCostosIndirecto.Equals("7302"))).Sum(i => i.SubtotalMaquinariaYEquipoCostoTotal) / maquinariaYEquipos.Sum(i => i.CostoFinalTotal);
        }
        public double SumarCostoTotal(string codigoParametro)
        {
            maquinariaYEquipos = ConsultarTodo();
            return maquinariaYEquipos.Where(i => i.ParametrosDeReferencia.Codigo.Equals(codigoParametro)).Sum(i => i.CostoTotal);
        }
    }
}
