using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using Entity;
using System.Data.SqlClient;

namespace Datos
{
    public class MateriaPrimaRepository
    {
        private string ruta = "MateriaPrima.txt";
        List<MateriaPrima> materiaPrimas;
        SqlConnection Connection;
        SqlCommand command;
        public MateriaPrimaRepository(ConnectionManager connectionManager)
        {
            Connection = connectionManager.connection;
            command = new SqlCommand();
            materiaPrimas = new List<MateriaPrima>();
        }
        public void Guardar(MateriaPrima materiaPrima)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO MateriaPrima" +
                                      "(CodigoMateriaPrima,Codigo,SubCodigo,Tipo,UnidadConsumo,ConsumoOP,Costos,CostosTotal,PorcentajeParteDelCosto,CantidadUnidadOrdenProduccion,CostoTotalMateriaPrimaOrdenProduccion,CostoPorcentajeTotalMateriaPrimaOrdenProduccion,CodigoParametroReferencia)" +
                                      "values" +
                                      "(next value for seq_MateriaPrima,@Codigo,@SubCodigo,@Tipo,@UnidadConsumo,@ConsumoOP,@Costos,@CostosTotal,@PorcentajeParteDelCosto,@CantidadUnidadOrdenProduccion,@CostoTotalMateriaPrimaOrdenProduccion,@CostoPorcentajeTotalMateriaPrimaOrdenProduccion,@CodigoParametroReferencia)";
                
                command.Parameters.AddWithValue("@Codigo", materiaPrima.Codigo);
                command.Parameters.AddWithValue("@SubCodigo", materiaPrima.SubCodigo);
                command.Parameters.AddWithValue("@Tipo", materiaPrima.Tipo);
                command.Parameters.AddWithValue("@UnidadConsumo", materiaPrima.UnidadConsumo);
                command.Parameters.AddWithValue("@ConsumoOP", materiaPrima.ConsumoOP);
                command.Parameters.AddWithValue("@Costos", materiaPrima.Costos);
                command.Parameters.AddWithValue("@CostosTotal", materiaPrima.CostosTotal);
                command.Parameters.AddWithValue("@PorcentajeParteDelCosto", materiaPrima.PorcentajeParteDelCosto);
                command.Parameters.AddWithValue("@CantidadUnidadOrdenProduccion", materiaPrima.CantidadUnidadOrdenProduccion);
                command.Parameters.AddWithValue("@CostoTotalMateriaPrimaOrdenProduccion", materiaPrima.CostoTotalMateriaPrimaOrdenProduccion);
                command.Parameters.AddWithValue("@CostoPorcentajeTotalMateriaPrimaOrdenProduccion", materiaPrima.CostoPorcentajeTotalMateriaPrimaOrdenProduccion);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", materiaPrima.ParametrosDeReferencia.Codigo);
                
                command.ExecuteNonQuery();
            }
        }

        public List<MateriaPrima> ConsultarTodos()
        {
            materiaPrimas.Clear();
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "select * from MateriaPrima";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    MateriaPrima materiaPrima = Mapear(dataReader);
                    materiaPrimas.Add(materiaPrima);
                }
            }
            return materiaPrimas;
        }
        private MateriaPrima Mapear(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            MateriaPrima materiaPrima = CrearMateriaPrima(dataReader);
            materiaPrima.CodigoPK = dataReader.GetInt32(0);
            materiaPrima.Codigo = dataReader.GetString(1);
            materiaPrima.SubCodigo = dataReader.GetString(2);
            materiaPrima.Tipo = dataReader.GetString(3);
            materiaPrima.UnidadConsumo = dataReader.GetString(4);
            materiaPrima.ConsumoOP = dataReader.GetDouble(5);
            materiaPrima.Costos = dataReader.GetDouble(6);
            materiaPrima.CostosTotal = dataReader.GetDouble(7);
            materiaPrima.PorcentajeParteDelCosto = dataReader.GetDouble(8);
            materiaPrima.CantidadUnidadOrdenProduccion = dataReader.GetDouble(9);
            materiaPrima.CostoTotalMateriaPrimaOrdenProduccion = dataReader.GetDouble(10);
            materiaPrima.CostoPorcentajeTotalMateriaPrimaOrdenProduccion = dataReader.GetDouble(11);
            materiaPrima.ParametrosDeReferencia.Codigo = dataReader.GetString(12);
            return materiaPrima;
        }
        private static MateriaPrima CrearMateriaPrima(SqlDataReader dataReader)
        {
            MateriaPrima materiaPrima;
            if (dataReader.GetString(1).Equals("7101"))
            {
                materiaPrima = new MateriasPrimasImportadas();
            }
            else
            {
                materiaPrima = new MateriasPrimasNacionales();
            }

            return materiaPrima;
        }
        public bool BuscarNacionales(string subcodigo, string codigoParametro)
        {
            List<MateriaPrima> materiaPrimas = ConsultarTodos();
            bool aceptado = false;
            foreach (var item in materiaPrimas)
            {
                if (item.SubCodigo.Trim().Equals(subcodigo.Trim()) && item.Codigo.Trim().Equals("7102") && item.ParametrosDeReferencia.Codigo.Trim().Equals(codigoParametro.Trim()))
                {
                    aceptado = true;
                }
                else
                {
                    aceptado = false;
                }
            }
            return aceptado;
        }
        public bool BuscarImportados(string subcodigo,string codigoParametro)
        {
            List<MateriaPrima> materiaPrimas = ConsultarTodos();
            bool aceptado = false;
            foreach (var item in materiaPrimas)
            {
                if (item.SubCodigo.Equals(subcodigo) && item.Codigo.Equals("7101") && item.ParametrosDeReferencia.Codigo.Equals(codigoParametro))
                {
                    aceptado = true;
                }
                else
                {
                    aceptado = false;
                }
            }
            return aceptado;
        }
        public List<MateriaPrima> BuscarDatosSubcodigo(string subcodigo)
        {
            List<MateriaPrima> materiaPrimas = ConsultarTodos();

            foreach (var item in materiaPrimas)
            {
                if (item.SubCodigo.Equals(subcodigo))
                {
                    return materiaPrimas;
                }
            }
            return null;
        }
        public List<MateriaPrima> BuscarDatosCodigoParametro(string codigoParametro)
        {
            List<MateriaPrima> materiaPrimas = ConsultarTodos();

            foreach (var item in materiaPrimas)
            {
                if (item.ParametrosDeReferencia.Codigo.Equals(codigoParametro))
                {
                    return materiaPrimas;
                }
            }
            return null;
        }
        public List<MateriaPrima> BuscarLista(string codigoParametro,string codigoMateria)
        {
            List<MateriaPrima> materiaPrimas = ConsultarTodos();

            foreach (var item in materiaPrimas)
            {
                if (item.ParametrosDeReferencia.Codigo.Equals(codigoParametro) && item.Codigo.Equals(codigoMateria))
                {
                    return materiaPrimas;
                }
            }
            return null;
        }
        public MateriaPrima BuscarMateriaPrima(string codigoParametro)
        {
            List<MateriaPrima> materiaPrimas = ConsultarTodos();

            foreach (var item in materiaPrimas)
            {
                if (item.ParametrosDeReferencia.Codigo.Equals(codigoParametro))
                {
                    return item;
                }
            }
            return null;
        }
        public MateriaPrima Consultar(string subcodigo)
        {
            List<MateriaPrima> materiaPrimas = ConsultarTodos();

            foreach (var item in materiaPrimas)
            {
                if (item.SubCodigo.Equals(subcodigo))
                {
                    return item;
                }
            }
            return null;
        }
        public void Modificar(MateriaPrima materiaPrimaNueva)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "UPDATE MateriaPrima SET " +
                                      "Codigo=@Codigo," +
                                      "SubCodigo=@SubCodigo," +
                                      "Tipo=@Tipo," +
                                      "UnidadConsumo=@UnidadConsumo," +
                                      "ConsumoOP=@ConsumoOP," +
                                      "Costos=@Costos," +
                                      "CostosTotal=@CostosTotal," +
                                      "PorcentajeParteDelCosto=@PorcentajeParteDelCosto," +
                                      "CantidadUnidadOrdenProduccion=@CantidadUnidadOrdenProduccion," +
                                      "CostoTotalMateriaPrimaOrdenProduccion=@CostoTotalMateriaPrimaOrdenProduccion," +
                                      "CostoPorcentajeTotalMateriaPrimaOrdenProduccion=@CostoPorcentajeTotalMateriaPrimaOrdenProduccion," +
                                      "CodigoParametroReferencia=@CodigoParametroReferencia " +
                                      "WHERE Codigo=@Codigo AND SubCodigo=@SubCodigo AND CodigoParametroReferencia=@CodigoParametroReferencia";

                command.Parameters.AddWithValue("@CodigoMateriaPrima", materiaPrimaNueva.CodigoPK);
                command.Parameters.AddWithValue("@Codigo", materiaPrimaNueva.Codigo);
                command.Parameters.AddWithValue("@SubCodigo", materiaPrimaNueva.SubCodigo);
                command.Parameters.AddWithValue("@Tipo", materiaPrimaNueva.Tipo);
                command.Parameters.AddWithValue("@UnidadConsumo", materiaPrimaNueva.UnidadConsumo);
                command.Parameters.AddWithValue("@ConsumoOP", materiaPrimaNueva.ConsumoOP);
                command.Parameters.AddWithValue("@Costos", materiaPrimaNueva.Costos);
                command.Parameters.AddWithValue("@CostosTotal", materiaPrimaNueva.CostosTotal);
                command.Parameters.AddWithValue("@PorcentajeParteDelCosto", materiaPrimaNueva.PorcentajeParteDelCosto);
                command.Parameters.AddWithValue("@CantidadUnidadOrdenProduccion", materiaPrimaNueva.CantidadUnidadOrdenProduccion);
                command.Parameters.AddWithValue("@CostoTotalMateriaPrimaOrdenProduccion", materiaPrimaNueva.CostoTotalMateriaPrimaOrdenProduccion);
                command.Parameters.AddWithValue("@CostoPorcentajeTotalMateriaPrimaOrdenProduccion", materiaPrimaNueva.CostoPorcentajeTotalMateriaPrimaOrdenProduccion);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", materiaPrimaNueva.ParametrosDeReferencia.Codigo);

                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(string Codigo, string SubCodigo,string CodigoParametro)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM MateriaPrima WHERE Codigo=@Codigo and SubCodigo=@SubCodigo and CodigoParametroReferencia=@CodigoParametroReferencia";
                command.Parameters.AddWithValue("@Codigo", Codigo);
                command.Parameters.AddWithValue("@SubCodigo", SubCodigo);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", CodigoParametro);
                command.ExecuteNonQuery();
            }
        }
        // sentencia
        public double BuscarDato(string CodigoParametro, string SubCodigo, string CodigoMateriaPrima)
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.ParametrosDeReferencia.Codigo.Trim().Equals(CodigoParametro) && (i.Codigo.Trim().Equals(CodigoMateriaPrima)) && (i.SubCodigo.Trim().Equals(SubCodigo))).Count();
        }
        public IList<MateriaPrima> ListaDato(string CodigoParametro, string SubCodigo, string CodigoMateriaPrima)
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.ParametrosDeReferencia.Codigo.Trim().Equals(CodigoParametro) && (i.Codigo.Trim().Equals(CodigoMateriaPrima)) && (i.SubCodigo.Trim().Equals(SubCodigo))).ToList();
        }
        public IList<MateriaPrima> LlenarCostoNacional(double CostoTotal)
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.CostosTotal.Equals(CostoTotal) && (i.Codigo.Equals("7102"))).ToList();
        }
        public IList<MateriaPrima> LlenarCostoImportada(double CostoTotal)
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.CostosTotal.Equals(CostoTotal) && (i.Codigo.Equals("7101"))).ToList();
        }
        public double BuscarSubcostoTotalNacional(double CostoTotal )
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.CostosTotal.Equals(CostoTotal) && (i.Codigo.Equals("7102"))).Sum(i => i.CostosTotal);
        }
        public double BuscarSubcostoTotalImportada(double CostoTotal)
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.CostosTotal.Equals(CostoTotal) && (i.Codigo.Equals("7101"))).Sum(i => i.CostosTotal);
        }
        public double BuscarSubporcentajeNacional(double CostoTotal)
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.CostosTotal.Equals(CostoTotal) && (i.Codigo.Equals("7102"))).Sum(i => i.PorcentajeParteDelCosto);
        }
        public double BuscarSubporcentajeImportada(double CostoTotal)
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.CostosTotal.Equals(CostoTotal) && (i.Codigo.Equals("7101"))).Sum(i => i.PorcentajeParteDelCosto);
        }
        //
        public IList<MateriaPrima> LlenarCodigoNacional(string CodigoParametros)
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.ParametrosDeReferencia.Codigo.ToUpper().Contains(CodigoParametros.ToUpper()) && (i.Codigo.Equals("7102"))).ToList();
        }
        public IList<MateriaPrima> LlenarCodigoImportada(string CodigoParametros)
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.ParametrosDeReferencia.Codigo.ToUpper().Contains(CodigoParametros.ToUpper()) && (i.Codigo.Equals("7101"))).ToList();
        }
        public double BuscarCodigoCostoTotalNacional(string CodigoParametros)
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.ParametrosDeReferencia.Codigo.ToUpper().Contains(CodigoParametros.ToUpper()) && (i.Codigo.Equals("7102"))).Sum(i => i.CostosTotal);
        }
        public double BuscarCodigoCostoTotalImportada(string CodigoParametros)
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.ParametrosDeReferencia.Codigo.ToUpper().Contains(CodigoParametros.ToUpper()) && (i.Codigo.Equals("7101"))).Sum(i => i.CostosTotal);
        }
        public double BuscarCodigoPorcentajeNacional(string CodigoParametros)
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.ParametrosDeReferencia.Codigo.ToUpper().Contains(CodigoParametros.ToUpper()) && (i.Codigo.Equals("7102"))).Sum(i => i.PorcentajeParteDelCosto);
        }
        public double BuscarCodigoPorcentajeImportada(string CodigoParametros)
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.ParametrosDeReferencia.Codigo.ToUpper().Contains(CodigoParametros.ToUpper()) && (i.Codigo.Equals("7101"))).Sum(i => i.PorcentajeParteDelCosto);
        }
        //
        public IList<MateriaPrima> BuscarTodoNacional()
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.Codigo.Equals("7102")).ToList();
        }
        public IList<MateriaPrima> BuscarTodoImportada()
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.Codigo.Equals("7101")).ToList();
        }
        public double BuscarTodoCodigoCostoTotalNacional()
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.Codigo.Equals("7102")).Sum(i => i.CostosTotal);
        }
        public double BuscarTodoCodigoCostoTotalImportada()
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.Codigo.Equals("7101")).Sum(i => i.CostosTotal);
        }
        public double BuscarTodoCodigoPorcentajeNacional()
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.Codigo.Equals("7102")).Sum(i => i.PorcentajeParteDelCosto);
        }
        public double BuscarTodoCodigoPorcentajeImportada()
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return materiaPrimas.Where(i => i.Codigo.Equals("7101")).Sum(i => i.PorcentajeParteDelCosto);
        }
        //
        public decimal BuscarSumaTotal(string Codigo)
        {
            IList<MateriaPrima> materiaPrimas = ConsultarTodos();
            return Convert.ToDecimal(materiaPrimas.Where(i => i.ParametrosDeReferencia.Codigo.Equals(Codigo)).Sum(i => i.CostosTotal));
        }

    }
}
