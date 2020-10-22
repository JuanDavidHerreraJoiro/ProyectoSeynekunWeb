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
    public class ManoDeObraAnalisisRepository
    {
        private string ruta = "ManoDeObraAnalisis.txt";
        List<ManoDeObraAnalisis> ManoDeObraAnalisis;
        SqlConnection Connection;
        SqlCommand command;

        public ManoDeObraAnalisisRepository(ConnectionManager connectionManager)
        {
            Connection = connectionManager.connection;
            command = new SqlCommand();
            ManoDeObraAnalisis = new List<ManoDeObraAnalisis>();
        }

        public void Guardar(ManoDeObraAnalisis manoDeObraAnalisis)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO AnalisisManoDeObra " +
                                      "(CodigoManoDeObraAnalisis,Codigo,CodigoParametroReferencia,Tipo,Costo)" +
                                      "values" +
                                      "(Next value for seq_AnalisisManoDeObra,@Codigo,@CodigoParametroReferencia,@Tipo,@Costo)";
                
                command.Parameters.AddWithValue("@Codigo", manoDeObraAnalisis.CodigoManoDeObra);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", manoDeObraAnalisis.ParametrosDeReferencia.Codigo);
                command.Parameters.AddWithValue("@Tipo", manoDeObraAnalisis.procesosProduccion.Tipo);
                command.Parameters.AddWithValue("@Costo", manoDeObraAnalisis.Costo);
                command.ExecuteNonQuery();
            }
        }

        public List<ManoDeObraAnalisis> ConsultarTodos()
        {
            ManoDeObraAnalisis.Clear();
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "SELECT A.Codigo,A.CodigoParametroReferencia,PR.Tipo,PR.TiempoCicloTotal,A.Costo  FROM AnalisisManoDeObra A  JOIN ProcesosProduccion PR ON A.CodigoParametroReferencia=PR.CodigoParametroReferencia AND  A.Tipo=PR.Tipo";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    ManoDeObraAnalisis manoDeObraAnalisis = Mapear(dataReader);
                    ManoDeObraAnalisis.Add(manoDeObraAnalisis);
                }
            }
            return ManoDeObraAnalisis;
        }

        private ManoDeObraAnalisis Mapear(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;

            ManoDeObraAnalisis manoDeObraAnalisis = new ManoDeObraAnalisis();
            manoDeObraAnalisis.CodigoManoDeObra = dataReader.GetString(0);
            manoDeObraAnalisis.ParametrosDeReferencia.Codigo = dataReader.GetString(1);
            manoDeObraAnalisis.procesosProduccion.Tipo = dataReader.GetString(2);
            manoDeObraAnalisis.procesosProduccion.TiempoCicloTotal = dataReader.GetDouble(3);
            manoDeObraAnalisis.Costo = dataReader.GetDouble(4);
            return manoDeObraAnalisis;
        }


        public void Modificar(ManoDeObraAnalisis manoDeObraAnalisisNuevo)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "UPDATE AnalisisManoDeObra SET " +
                                      "Codigo=@Codigo," +
                                      "CodigoParametroReferencia=@CodigoParametroReferencia," +
                                      "Tipo=@Tipo," +
                                      "Costo=@Costo " +
                                      "WHERE CodigoParametroReferencia=@CodigoParametroReferencia AND Tipo=(select Tipo from ProcesosProduccion where Tipo=@Tipo AND CodigoParametroReferencia=@CodigoParametroReferencia) ";

                command.Parameters.AddWithValue("@Codigo", manoDeObraAnalisisNuevo.CodigoManoDeObra);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", manoDeObraAnalisisNuevo.ParametrosDeReferencia.Codigo);
                command.Parameters.AddWithValue("@Tipo", manoDeObraAnalisisNuevo.procesosProduccion.Tipo);
                command.Parameters.AddWithValue("@Costo", manoDeObraAnalisisNuevo.Costo);
                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(string codigoParametro,string tipo,string codigo)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM AnalisisManoDeObra WHERE Codigo=@Codigo AND CodigoParametroReferencia=@CodigoParametroReferencia AND Tipo=@Tipo";
                command.Parameters.AddWithValue("@Codigo",codigo);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", codigoParametro);
                command.Parameters.AddWithValue("@Tipo",tipo);
                command.ExecuteNonQuery();
            }
        }
        public IList<ManoDeObraAnalisis>  BuscarDato(string Codigo, String Tipo)
        {
            ManoDeObraAnalisis = ConsultarTodos();
            return ManoDeObraAnalisis.Where(i => i.procesosProduccion.Tipo.ToUpper().Trim().Equals(Tipo.Trim().ToUpper()) && (i.ParametrosDeReferencia.Codigo.Equals(Codigo))).ToList();
        }

        public double ValidarDato(string Codigo, String Tipo)
        {
            ManoDeObraAnalisis = ConsultarTodos();
            return ManoDeObraAnalisis.Where(i => i.procesosProduccion.Tipo.ToUpper().Trim().Equals(Tipo.Trim().ToUpper()) && (i.ParametrosDeReferencia.Codigo.Equals(Codigo))).Count();
        }
        public decimal TotalCoto(string Codigo)
        {
            ManoDeObraAnalisis = ConsultarTodos();
            return Convert.ToDecimal(ManoDeObraAnalisis.Where(i => i.ParametrosDeReferencia.Codigo.Equals(Codigo)).Sum(i => i.Costo));
        }
        
        public IList<ManoDeObraAnalisis> BuscarCodigoParametro(string CodigoParametro)
        {
            IList<ManoDeObraAnalisis> manoDeObraAnalisis = ConsultarTodos();
            return manoDeObraAnalisis.Where(i => i.ParametrosDeReferencia.Codigo.ToUpper().Trim().Contains(CodigoParametro.ToUpper())).ToList();
        }
        public IList<ManoDeObraAnalisis> BuscarTodo()
        {
            IList<ManoDeObraAnalisis> manoDeObraAnalisis = ConsultarTodos();
            return manoDeObraAnalisis.ToList();
        }
    }
}
