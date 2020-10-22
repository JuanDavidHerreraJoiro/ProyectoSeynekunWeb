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
    public class CostosYGastosMensualesRepository
    {
        private string ruta = "CostosYGastosMensuales.txt";
        List<CostosYGastosMensuales> costosYGastosMensuales;
        SqlConnection connection;
        SqlCommand command;

        public CostosYGastosMensualesRepository(ConnectionManager connectionManager)
        {
            connection = connectionManager.connection;
            command = new SqlCommand();
            costosYGastosMensuales = new List<CostosYGastosMensuales>();
        }
        public void Guardar(CostosYGastosMensuales costosYGastosMensuales)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO CostosYGastosMensuales (CodigoCostosYGastosMensuales,Codigo,SubCodigo,Tipo)" +
                    " values (Next value for seq_CostosYGastosMensuales,@Codigo,@SubCodigo,@Tipo)";
                //command.Parameters.AddWithValue("@CodigoCostosYGastosMensuales", costosYGastosMensuales.CodigoPK);
                command.Parameters.AddWithValue("@Codigo", costosYGastosMensuales.Codigo.Trim());
                command.Parameters.AddWithValue("@SubCodigo", costosYGastosMensuales.SubCodigo.Trim());
                command.Parameters.AddWithValue("@Tipo", costosYGastosMensuales.Tipo.Trim());

                command.ExecuteNonQuery();
            }
        }

        public List<CostosYGastosMensuales> ConsultarTodos()
        {
            costosYGastosMensuales.Clear();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT * from CostosYGastosMensuales";
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        CostosYGastosMensuales costosYGastos = DataReaderMapCostosMensuales(dataReader);
                        costosYGastosMensuales.Add(costosYGastos);
                    }
                }
            }
            return costosYGastosMensuales;
        }

        private CostosYGastosMensuales DataReaderMapCostosMensuales(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;

            CostosYGastosMensuales costosMensuales = new CostosYGastosMensuales();

            costosMensuales.CodigoPK = dataReader.GetInt32(0);
            costosMensuales.Codigo = dataReader.GetString(1).Trim();
            costosMensuales.SubCodigo = dataReader.GetString(2).Trim();
            costosMensuales.Tipo = dataReader.GetString(3).Trim();

            return costosMensuales;
        }

        public void Modificar(CostosYGastosMensuales costosYGastosMensuales)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE CostosYGastosMensuales SET " +
                                      "Codigo=@Codigo," +
                                      "SubCodigo=@SubCodigo," +
                                      "Tipo=@Tipo WHERE Codigo=@Codigo AND SubCodigo=@SubCodigo ";

                command.Parameters.AddWithValue("@CodigoCostosYGastosMensuales", costosYGastosMensuales.CodigoPK);
                command.Parameters.AddWithValue("@Codigo", costosYGastosMensuales.Codigo);
                command.Parameters.AddWithValue("@SubCodigo", costosYGastosMensuales.SubCodigo);
                command.Parameters.AddWithValue("@Tipo", costosYGastosMensuales.Tipo);

                command.ExecuteNonQuery();
            }
        }
        public void Eliminar(string codigo, string subCodigo)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE from CostosYGastosMensuales where Codigo = @Codigo and SubCodigo = @SubCodigo";
                command.Parameters.AddWithValue("@Codigo", codigo);
                command.Parameters.AddWithValue("@SubCodigo", subCodigo);
                command.ExecuteNonQuery();
            }
        }
        public int ValidarSubcodigo(string subcodigo, string codigo)
        {
            costosYGastosMensuales = ConsultarTodos();
            return costosYGastosMensuales.Where(i => i.Codigo.Equals(codigo.Trim()) && (i.SubCodigo.Equals(subcodigo.Trim()))).Count();
        }
        public List<CostosYGastosMensuales> BuscarDatosMensuales(string codigo, string SubCodigo)
        {
            costosYGastosMensuales = ConsultarTodos();
            return costosYGastosMensuales.Where(i => i.Codigo.Trim().Equals(codigo.Trim()) && (i.SubCodigo.Trim().Equals(SubCodigo.Trim()))).ToList();
        }
        public List<CostosYGastosMensuales> LlenarCombo(string codigo)
        {
            costosYGastosMensuales = ConsultarTodos();
            return costosYGastosMensuales.Where(i => i.Codigo.Equals(codigo)).ToList();
        }
        public List<CostosYGastosMensuales> BuscarTodo()
        {
            costosYGastosMensuales = ConsultarTodos();
            return costosYGastosMensuales.ToList();
        }
        public List<CostosYGastosMensuales> BuscarCodigo(string Codigo)
        {
            costosYGastosMensuales = ConsultarTodos();
            return costosYGastosMensuales.Where(i => i.Codigo.ToUpper().Trim().Contains(Codigo.ToUpper())).ToList();
        }
        public List<CostosYGastosMensuales> BuscarSubCodigo(string SubCodigo)
        {
            costosYGastosMensuales = ConsultarTodos();
            return costosYGastosMensuales.Where(i => i.SubCodigo.ToUpper().Trim().Contains(SubCodigo.ToUpper())).ToList();
        }
        public List<CostosYGastosMensuales> BuscarTipo(string Tipo)
        {
            costosYGastosMensuales = ConsultarTodos();
            return costosYGastosMensuales.Where(i => i.Tipo.ToUpper().Trim().Contains(Tipo.ToUpper())).ToList();
        }
    }
}
