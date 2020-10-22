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
    public class TRMRepository
    {
        private string ruta = "TRM.txt";
        IList<TRM> trms;
        SqlConnection Connection;
        SqlCommand command;
        public TRMRepository(ConnectionManager connectionManager)
        {
            Connection = connectionManager.connection;
            command = new SqlCommand();
            trms = new List<TRM>();
        }
        public void Guardar(TRM trm)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO TRM" +
                                      "(CodigoTRM,Fecha,ValorTrm)" +
                                      "values" +
                                      "(Next value for seq_TRM,@Fecha,@ValorTrm)";

                command.Parameters.AddWithValue("@Fecha", trm.FechaTrm);
                command.Parameters.AddWithValue("@ValorTrm", trm.ValorTrm);
                command.ExecuteNonQuery();
            }

        }

        public IList<TRM> ConsultarTodos()
        {
            trms.Clear();
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "select * from TRM";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    TRM trm = Mapear(dataReader);
                    trms.Add(trm);
                }
            }
            return trms;
        }
        

        private TRM Mapear(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            TRM tRM = new TRM();
            tRM.TrmPK = dataReader.GetInt32(0);
            tRM.FechaTrm = dataReader.GetDateTime(1);
            tRM.ValorTrm = dataReader.GetDecimal(2);
            return tRM;
        }

        public void Modificar(TRM trmNuevo)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "UPDATE TRM SET " +
                                      "ValorTrm=@ValorTrm " +
                                      "WHERE Fecha=@Fecha";

                command.Parameters.AddWithValue("@Fecha", trmNuevo.FechaTrm);
                command.Parameters.AddWithValue("@ValorTrm", trmNuevo.ValorTrm);
                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(DateTime fecha)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM TRM WHERE Fecha=@Fecha";
                command.Parameters.AddWithValue("@Fecha", fecha);
                command.ExecuteNonQuery();
            }
        }
        
        public IList<TRM> BuscarTRM()
        {
            IList<TRM> trms = ConsultarTodos();
            return trms.ToList();
        }
        public double ContarTRM()
        {
            IList<TRM> trms = ConsultarTodos();
            return trms.Count();
        }
        public Decimal SumarTRM()
        {
            IList<TRM> trms = ConsultarTodos();
            return trms.Sum(i => i.ValorTrm);
        }
        public Decimal UltimoValor()
        {
            IList<TRM> trms = ConsultarTodos();
            return trms.Last().ValorTrm;
        }
        public IList<TRM> BuscarFecha(int Mes, int Año)
        {
            IList<TRM> trms = ConsultarTodos();
            return trms.Where(i => i.FechaTrm.Year.Equals(Año) && (i.FechaTrm.Month.Equals(Mes))).ToList();
        }
        public IList<TRM> BuscarDatoFecha(int Dia,int Mes, int Año)
        {
            IList<TRM> trms = ConsultarTodos();
            return trms.Where(i => i.FechaTrm.Year.Equals(Año) && (i.FechaTrm.Month.Equals(Mes)) && (i.FechaTrm.Day.Equals(Dia))).ToList();
        }
        public int ContarDatoFecha(int Dia, int Mes, int Año)
        {
            IList<TRM> trms = ConsultarTodos();
            return trms.Where(i => i.FechaTrm.Year.Equals(Año) && (i.FechaTrm.Month.Equals(Mes)) && (i.FechaTrm.Day.Equals(Dia))).Count();
        }
    }
}
