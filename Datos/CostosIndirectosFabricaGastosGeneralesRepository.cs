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
    public class CostosIndirectosFabricaGastosGeneralesRepository
    {
        private string ruta = " CostosIndirectosFabricaGastosGenerales.txt";
        List<CostosIndirectosFabricaGastosGenerales> costosIndirectosFabricaciónes;
        SqlConnection connection;
        SqlCommand command;

        public CostosIndirectosFabricaGastosGeneralesRepository(ConnectionManager connectionManager)
        {
            connection = connectionManager.connection;
            command = new SqlCommand();
            costosIndirectosFabricaciónes = new List<CostosIndirectosFabricaGastosGenerales>();
        }
        public void Guardar(CostosIndirectosFabricaGastosGenerales costosIndirectosFabricación)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO CostosIndirectosFabricaGastosGenerales (CodigoCostosIndirectosFabricaGastosGenerales,CodigoCostosYGastosMensuales,SubCodigo,Fecha,Monto)" +
                    " values (Next value for seq_CostosIndirectosFabricaGastosGenerales,@CodigoCostosYGastosMensuales,@SubCodigo,@Fecha,@Monto)";
                
                command.Parameters.AddWithValue("@CodigoCostosYGastosMensuales", costosIndirectosFabricación.Codigo);
                command.Parameters.AddWithValue("@SubCodigo", costosIndirectosFabricación.SubCodigo);
                command.Parameters.AddWithValue("@Fecha", costosIndirectosFabricación.Fecha);
                command.Parameters.AddWithValue("@Monto", costosIndirectosFabricación.Monto);

                command.ExecuteNonQuery();
            }
        }
        public List<CostosIndirectosFabricaGastosGenerales> ConsultarTodos()
        {
            costosIndirectosFabricaciónes.Clear();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT CostosIndirectosFabricaGastosGenerales.CodigoCostosIndirectosFabricaGastosGenerales,CostosIndirectosFabricaGastosGenerales.CodigoCostosYGastosMensuales,CostosIndirectosFabricaGastosGenerales.SubCodigo,CostosIndirectosFabricaGastosGenerales.Fecha,CostosIndirectosFabricaGastosGenerales.Monto,CostosYGastosMensuales.TIPO FROM CostosIndirectosFabricaGastosGenerales INNER JOIN CostosYGastosMensuales ON CostosIndirectosFabricaGastosGenerales.SubCodigo = CostosYGastosMensuales.SubCodigo";
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        CostosIndirectosFabricaGastosGenerales costosYGastos = DataReaderMapCostosGenerales(dataReader);
                        costosIndirectosFabricaciónes.Add(costosYGastos);
                    }
                }
            }
            return costosIndirectosFabricaciónes;
        }

        private CostosIndirectosFabricaGastosGenerales DataReaderMapCostosGenerales(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            CostosIndirectosFabricaGastosGenerales costosIndirectos = new CostosIndirectosFabricaGastosGenerales();

            costosIndirectos.CodigoPK = dataReader.GetInt32(0);
            costosIndirectos.Codigo = dataReader.GetString(1);
            costosIndirectos.SubCodigo = dataReader.GetString(2);
            costosIndirectos.Fecha = dataReader.GetDateTime(3);
            costosIndirectos.Monto = dataReader.GetDouble(4);
            costosIndirectos.Tipo = dataReader.GetString(5);

            return costosIndirectos;
        }
        public void Modificar(CostosIndirectosFabricaGastosGenerales costosIndirectosFabricación)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE CostosIndirectosFabricaGastosGenerales SET " +
                                      "CodigoCostosYGastosMensuales=@CodigoCostosYGastosMensuales,SubCodigo=@SubCodigo,Fecha=@Fecha,Monto=@Monto " +
                                      "where CodigoCostosYGastosMensuales=@CodigoCostosYGastosMensuales and SubCodigo=@SubCodigo and Fecha=@Fecha";

                command.Parameters.AddWithValue("@CodigoCostosIndirectosFabricaGastosGenerales", costosIndirectosFabricación.CodigoPK);
                command.Parameters.AddWithValue("@CodigoCostosYGastosMensuales", costosIndirectosFabricación.Codigo);
                command.Parameters.AddWithValue("@SubCodigo", costosIndirectosFabricación.SubCodigo);
                command.Parameters.AddWithValue("@Fecha", costosIndirectosFabricación.Fecha);
                command.Parameters.AddWithValue("@Monto", costosIndirectosFabricación.Monto);

                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(string codigo, string Subcodigo,int dia, int mes, int año)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $@"DELETE from CostosIndirectosFabricaGastosGenerales where DAY(Fecha) = {dia}  and MONTH(Fecha) = {mes} and YEAR(Fecha) = {año} and 
                 CodigoCostosYGastosMensuales = @CodigoCostosYGastosMensuales and SubCodigo = @SubCodigo";
                command.Parameters.AddWithValue("@CodigoCostosYGastosMensuales", codigo);
                command.Parameters.AddWithValue("@SubCodigo", Subcodigo);
                command.ExecuteNonQuery();
            }
        }
        public int ValidarSubcodigo(string subcodigo, string codigo)
        {
            costosIndirectosFabricaciónes = ConsultarTodos();
            return costosIndirectosFabricaciónes.Where(i => i.Codigo.Equals(codigo) && (i.SubCodigo.Equals(subcodigo))).Count();
        }

        public int ValidarRegistro(int Mes, int Año, string SubCodigo)
        {
            List<CostosIndirectosFabricaGastosGenerales> costosIndirectosFabricaGastosGenerales = ConsultarTodos();
            return costosIndirectosFabricaGastosGenerales.Where(i => i.Fecha.Year.Equals(Año) && (i.Fecha.Month.Equals(Mes)) && (i.SubCodigo.Equals(SubCodigo))).Count();
        }
        public double TotalGastosgenerales(int Mes, int Año)
        {
            List<CostosIndirectosFabricaGastosGenerales> costosIndirectosFabricaciónes = ConsultarTodos();
            return costosIndirectosFabricaciónes.Where(i => i.Fecha.Year.Equals(Año) && (i.Fecha.Month.Equals(Mes))).Sum(i => i.Monto);
        }
        public List<CostosIndirectosFabricaGastosGenerales> BuscarDatoCostoIndirectoMensuales(int mes, int año, string subcodigo, string codigo)
        {
            costosIndirectosFabricaciónes = ConsultarTodos();
            return costosIndirectosFabricaciónes.Where(i => i.Codigo.Trim().Equals(codigo.Trim()) && (i.SubCodigo.Trim().Equals(subcodigo.Trim())) && (i.Fecha.Year.Equals(año)) && (i.Fecha.Month.Equals(mes))).ToList();
        }
        public List<CostosIndirectosFabricaGastosGenerales> BuscarTodo()
        {
            costosIndirectosFabricaciónes = ConsultarTodos();
            return costosIndirectosFabricaciónes.ToList();
        }
        public List<CostosIndirectosFabricaGastosGenerales> BuscarCodigo(string Codigo)
        {
            costosIndirectosFabricaciónes = ConsultarTodos();
            return costosIndirectosFabricaciónes.Where(i => i.Codigo.ToUpper().Trim().Contains(Codigo.ToUpper())).ToList();
        }
        public List<CostosIndirectosFabricaGastosGenerales> BuscarSubCodigo(string SubCodigo)
        {
            costosIndirectosFabricaciónes = ConsultarTodos();
            return costosIndirectosFabricaciónes.Where(i => i.SubCodigo.ToUpper().Trim().Contains(SubCodigo.ToUpper())).ToList();
        }
        public List<CostosIndirectosFabricaGastosGenerales> BuscarTipo(string Tipo)
        {
            costosIndirectosFabricaciónes = ConsultarTodos();
            return costosIndirectosFabricaciónes.Where(i => i.Tipo.ToUpper().Trim().Contains(Tipo.ToUpper())).ToList();
        }
        
        public IList<CostosIndirectosFabricaGastosGenerales> BuscarFecha(int Mes, int Año)
        {
            IList<CostosIndirectosFabricaGastosGenerales> costosIndirectosFabricaciónes = ConsultarTodos();
            return costosIndirectosFabricaciónes.Where(i => i.Fecha.Year.Equals(Año) && (i.Fecha.Month.Equals(Mes))).ToList();
        }
    }
}
