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
    public class FamiliaProductosRepository
    {
        private string ruta = "FamiliaProductos.txt";
        List<FamiliaProductos> familiaProductos;
        SqlConnection connection;
        SqlCommand command;

        public FamiliaProductosRepository(ConnectionManager connectionManager)
        {
            connection = connectionManager.connection;
            command = new SqlCommand();
            familiaProductos = new List<FamiliaProductos>();
        }
        public void Guardar(FamiliaProductos familiaProducto)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO FamiliaDeProductos (CodigoFamiliaDeProductos,CodigoParametroReferencia,FamilaProducto,UnidadesVendidasMes,VolumenVentas,PorcentajeUnidadVendidas,PorcentajeVolumenVentas," +
                    "PorcentajeUnidadVolumen,CostosYGastosFamilia,GastoAsignable,TotalUnidadesVendidasMes,TotalVolumenVentas,TotalPorcentajeUnidadVendidas,TotalPorcentajeVolumenVentas,TotalPorcentajeUnidadVolumen,TotalCostosYGastosFamilia,TotalGastoAsignable)" +
                    " values (Next value for seq_FamiliaDeProductos,@CodigoParametroReferencia,@FamilaProducto,@UnidadesVendidasMes,@VolumenVentas,@PorcentajeUnidadVendidas,@PorcentajeVolumenVentas," +
                    "@PorcentajeUnidadVolumen,@CostosYGastosFamilia,@GastoAsignable,@TotalUnidadesVendidasMes,@TotalVolumenVentas,@TotalPorcentajeUnidadVendidas,@TotalPorcentajeVolumenVentas,@TotalPorcentajeUnidadVolumen,@TotalCostosYGastosFamilia,@TotalGastoAsignable)";
                command.Parameters.AddWithValue("@CodigoParametroReferencia", familiaProducto.parametrosDeReferencia.Codigo);
                command.Parameters.AddWithValue("@FamilaProducto", familiaProducto.FamiliaProducto);
                command.Parameters.AddWithValue("@UnidadesVendidasMes", familiaProducto.UnidadesVendidasMes);
                command.Parameters.AddWithValue("@VolumenVentas", familiaProducto.VolumenVentas);
                command.Parameters.AddWithValue("@PorcentajeUnidadVendidas", familiaProducto.PorcentajeUnidadVendidas);
                command.Parameters.AddWithValue("@PorcentajeVolumenVentas", familiaProducto.PorcentajeVolumenVentas);
                command.Parameters.AddWithValue("@PorcentajeUnidadVolumen", familiaProducto.PorcentajeUnidadVolumen);
                command.Parameters.AddWithValue("@CostosYGastosFamilia", familiaProducto.CostosYGastosFamilia);
                command.Parameters.AddWithValue("@GastoAsignable", familiaProducto.GastoAsignable);
                command.Parameters.AddWithValue("@TotalUnidadesVendidasMes", familiaProducto.TotalUnidadesVendidasMes);
                command.Parameters.AddWithValue("@TotalVolumenVentas", familiaProducto.TotalVolumenVentas);
                command.Parameters.AddWithValue("@TotalPorcentajeUnidadVendidas", familiaProducto.TotalPorcentajeUnidadVendidas);
                command.Parameters.AddWithValue("@TotalPorcentajeVolumenVentas", familiaProducto.TotalPorcentajeVolumenVentas);
                command.Parameters.AddWithValue("@TotalPorcentajeUnidadVolumen", familiaProducto.TotalPorcentajeUnidadVolumen);
                command.Parameters.AddWithValue("@TotalCostosYGastosFamilia", familiaProducto.TotalCostosYGastosFamilia);
                command.Parameters.AddWithValue("@TotalGastoAsignable", familiaProducto.TotalGastoAsignable);

                command.ExecuteNonQuery();
            }
        }

        public List<FamiliaProductos> ConsultarTodos()
        {
            familiaProductos.Clear();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from FamiliaDeProductos";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    FamiliaProductos familiaProducto = DataReaderMapFamilia(dataReader);
                    familiaProductos.Add(familiaProducto);
                }
            }
            return familiaProductos;
        }

        private FamiliaProductos DataReaderMapFamilia(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            FamiliaProductos familiaProducto = new FamiliaProductos();

            familiaProducto.CodigoPK = dataReader.GetInt32(0);
            familiaProducto.parametrosDeReferencia.Codigo= dataReader.GetString(1);
            familiaProducto.FamiliaProducto= dataReader.GetString(2);
            familiaProducto.UnidadesVendidasMes= dataReader.GetDouble(3);
            familiaProducto.VolumenVentas= dataReader.GetDouble(4);
            familiaProducto.PorcentajeUnidadVendidas= dataReader.GetDouble(5);
            familiaProducto.PorcentajeVolumenVentas= dataReader.GetDouble(6);
            familiaProducto.PorcentajeUnidadVolumen= dataReader.GetDouble(7);
            familiaProducto.CostosYGastosFamilia= dataReader.GetDouble(8);
            familiaProducto.GastoAsignable= dataReader.GetDouble(9);
            familiaProducto.TotalUnidadesVendidasMes= dataReader.GetDouble(10);
            familiaProducto.TotalVolumenVentas= dataReader.GetDouble(11);
            familiaProducto.TotalPorcentajeUnidadVendidas= dataReader.GetDouble(12);
            familiaProducto.TotalPorcentajeVolumenVentas= dataReader.GetDouble(13);
            familiaProducto.TotalPorcentajeUnidadVolumen= dataReader.GetDouble(14);
            familiaProducto.TotalCostosYGastosFamilia= dataReader.GetDouble(15);
            familiaProducto.TotalGastoAsignable= dataReader.GetDouble(16);

            return familiaProducto;
        }

        public void Modificar(FamiliaProductos familiaProducto)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE FamiliaDeProductos SET CodigoParametroReferencia=@CodigoParametroReferencia,FamilaProducto=@FamilaProducto,UnidadesVendidasMes=@UnidadesVendidasMes,VolumenVentas=@VolumenVentas,PorcentajeUnidadVendidas=@PorcentajeUnidadVendidas,PorcentajeVolumenVentas=@PorcentajeVolumenVentas," +
                    "PorcentajeUnidadVolumen=@PorcentajeUnidadVolumen,CostosYGastosFamilia=@CostosYGastosFamilia,GastoAsignable=@GastoAsignable,TotalUnidadesVendidasMes=@TotalUnidadesVendidasMes,TotalVolumenVentas=@TotalVolumenVentas,TotalPorcentajeUnidadVendidas=@TotalPorcentajeUnidadVendidas,TotalPorcentajeVolumenVentas=@TotalPorcentajeVolumenVentas," +
                    "TotalPorcentajeUnidadVolumen=@TotalPorcentajeUnidadVolumen,TotalCostosYGastosFamilia=@TotalCostosYGastosFamilia,TotalGastoAsignable=@TotalGastoAsignable " +
                    "WHERE CodigoFamiliaDeProductos=@CodigoFamiliaDeProductos";
                command.Parameters.AddWithValue("@CodigoFamiliaDeProductos", familiaProducto.CodigoPK);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", familiaProducto.parametrosDeReferencia.Codigo);
                command.Parameters.AddWithValue("@FamilaProducto", familiaProducto.FamiliaProducto);
                command.Parameters.AddWithValue("@UnidadesVendidasMes", familiaProducto.UnidadesVendidasMes);
                command.Parameters.AddWithValue("@VolumenVentas", familiaProducto.VolumenVentas);
                command.Parameters.AddWithValue("@PorcentajeUnidadVendidas", familiaProducto.PorcentajeUnidadVendidas);
                command.Parameters.AddWithValue("@PorcentajeVolumenVentas", familiaProducto.PorcentajeVolumenVentas);
                command.Parameters.AddWithValue("@PorcentajeUnidadVolumen", familiaProducto.PorcentajeUnidadVolumen);
                command.Parameters.AddWithValue("@CostosYGastosFamilia", familiaProducto.CostosYGastosFamilia);
                command.Parameters.AddWithValue("@GastoAsignable", familiaProducto.GastoAsignable);
                command.Parameters.AddWithValue("@TotalUnidadesVendidasMes", familiaProducto.TotalUnidadesVendidasMes);
                command.Parameters.AddWithValue("@TotalVolumenVentas", familiaProducto.TotalVolumenVentas);
                command.Parameters.AddWithValue("@TotalPorcentajeUnidadVendidas", familiaProducto.TotalPorcentajeUnidadVendidas);
                command.Parameters.AddWithValue("@TotalPorcentajeVolumenVentas", familiaProducto.TotalPorcentajeVolumenVentas);
                command.Parameters.AddWithValue("@TotalPorcentajeUnidadVolumen", familiaProducto.TotalPorcentajeUnidadVolumen);
                command.Parameters.AddWithValue("@TotalCostosYGastosFamilia", familiaProducto.TotalCostosYGastosFamilia);
                command.Parameters.AddWithValue("@TotalGastoAsignable", familiaProducto.TotalGastoAsignable);

                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(int codigoPk)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE from FamiliaDeProductos where CodigoFamiliaDeProductos = @CodigoFamiliaDeProductos ";
                command.Parameters.AddWithValue("@CodigoFamiliaDeProductos",codigoPk);
                command.ExecuteNonQuery();
            }
        }


        public List<FamiliaProductos> BuscarTodo()
        {
            List<FamiliaProductos> familiaProductos = ConsultarTodos();
            return familiaProductos.ToList();
        }
        public List<FamiliaProductos> ConsultaIndividual(string Codigo)
        {
            List<FamiliaProductos> familiaProductos = ConsultarTodos();
            return familiaProductos.Where(i => i.parametrosDeReferencia.Codigo.Equals(Codigo)).ToList();
        }
        public double TotalSumaUnidadesVendidasMes(string Codigo)
        {
            List<FamiliaProductos> familiaProductos = ConsultarTodos();
            return familiaProductos.Where(i => i.parametrosDeReferencia.Codigo.Equals(Codigo)).Sum(i => i.UnidadesVendidasMes);
        }
        public double TotalSumaVolumenVentas(string Codigo)
        {
            List<FamiliaProductos> familiaProductos = ConsultarTodos();
            return familiaProductos.Where(i => i.parametrosDeReferencia.Codigo.Equals(Codigo)).Sum(i => i.VolumenVentas);
        }
        public double TotalSumaPorcentajeUnidadVendidas(string Codigo)
        {
            List<FamiliaProductos> familiaProductos = ConsultarTodos();
            return familiaProductos.Where(i => i.parametrosDeReferencia.Codigo.Equals(Codigo)).Sum(i => i.PorcentajeUnidadVendidas);
        }
        public double TotalSumaPorcentajeVolumenVentas(string Codigo)
        {
            List<FamiliaProductos> familiaProductos = ConsultarTodos();
            return familiaProductos.Where(i => i.parametrosDeReferencia.Codigo.Equals(Codigo)).Sum(i => i.PorcentajeVolumenVentas);
        }
        public double TotalSumaPorcentajeUnidadVolumen(string Codigo)
        {
            List<FamiliaProductos> familiaProductos = ConsultarTodos();
            return familiaProductos.Where(i => i.parametrosDeReferencia.Codigo.Equals(Codigo)).Sum(i => i.PorcentajeUnidadVolumen);
        }
        public double TotalSumaCostosYGastosFamilia(string Codigo)
        {
            List<FamiliaProductos> familiaProductos = ConsultarTodos();
            return familiaProductos.Where(i => i.parametrosDeReferencia.Codigo.Equals(Codigo)).Sum(i => i.CostosYGastosFamilia);
        }
        public List<FamiliaProductos> BuscarCodigoPK(int CodigoPk)
        {
            List<FamiliaProductos> familiaProductos = ConsultarTodos();
            return familiaProductos.Where(i => i.CodigoPK == CodigoPk).ToList();
        }
        public double TotalSumaGastoAsignable(string Codigo)
        {
            List<FamiliaProductos> familiaProductos = ConsultarTodos();
            return familiaProductos.Where(i => i.parametrosDeReferencia.Codigo.Equals(Codigo)).Sum(i => i.GastoAsignable);
        }
    }
}
