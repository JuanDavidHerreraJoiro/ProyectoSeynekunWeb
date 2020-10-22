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
    public class ManoDeObraEtapasRepository
    {
        private string ruta = "ManoDeObraEtapas.txt";
        List<ManoDeObraEtapas> manoDeObraEtapas;
        SqlConnection Connection;
        SqlCommand command;
        public ManoDeObraEtapasRepository(ConnectionManager connectionManager)
        {
            Connection = connectionManager.connection;
            command = new SqlCommand();
            manoDeObraEtapas = new List<ManoDeObraEtapas>();
        }

        public void Guardar(ManoDeObraEtapas manoDeObraEtapas)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO ManoDeObraEtapas" +
                                      "(CodigoManoDeObraEtapas,Codigo,CodigoParametroReferencia,Tipo,NumeroEmpleado,DiasHabilesAño,DiasHabilesMes,HorasDiaProductivas,HorasTrabajoEfectivo,TotalHorasMes,CostoHora,CostoMinuto)" +
                                      "values" +
                                      "(NexT value for seq_ManoDeObraEtapas,@Codigo,@CodigoParametroReferencia,@Tipo,@NumeroEmpleado,@DiasHabilesAño,@DiasHabilesMes,@HorasDiaProductivas,@HorasTrabajoEfectivo,@TotalHorasMes,@CostoHora,@CostoMinuto)";

                command.Parameters.AddWithValue("@Codigo", manoDeObraEtapas.CodigoManoDeObra);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", manoDeObraEtapas.ParametrosDeReferencia.Codigo);
                command.Parameters.AddWithValue("@Tipo", manoDeObraEtapas.ProcesosProduccion.Tipo);
                command.Parameters.AddWithValue("@NumeroEmpleado", manoDeObraEtapas.NumeroEmpleado);
                command.Parameters.AddWithValue("@DiasHabilesAño", manoDeObraEtapas.DiasHabilesAño);
                command.Parameters.AddWithValue("@DiasHabilesMes", manoDeObraEtapas.DiasHabilesMes);
                command.Parameters.AddWithValue("@HorasDiaProductivas", manoDeObraEtapas.HorasDiaProductivas);
                command.Parameters.AddWithValue("@HorasTrabajoEfectivo", manoDeObraEtapas.HorasTrabajoEfectivo);
                command.Parameters.AddWithValue("@TotalHorasMes", manoDeObraEtapas.TotalHorasMes);
                command.Parameters.AddWithValue("@CostoHora", manoDeObraEtapas.CostoHora);
                command.Parameters.AddWithValue("@CostoMinuto", manoDeObraEtapas.CostoMinuto);
               
                command.ExecuteNonQuery();
            }
        }

        public List<ManoDeObraEtapas> ConsultarTodos()
        {
            manoDeObraEtapas.Clear();
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "SELECT MA.Codigo,MA.CodigoParametroReferencia,PR.Tipo,PR.NumeroOperarios,MA.DiasHabilesAño,MA.DiasHabilesMes,MA.HorasDiaProductivas,MA.HorasTrabajoEfectivo,MA.TotalHorasMes,MA.CostoHora,MA.CostoMinuto FROM ManoDeObraEtapas MA  JOIN ProcesosProduccion PR ON MA.CodigoParametroReferencia = PR.CodigoParametroReferencia AND MA.Tipo = PR.Tipo";
                    SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    ManoDeObraEtapas manoDeObraEtapa = Mapear(dataReader);
                    manoDeObraEtapas.Add(manoDeObraEtapa);
                }
            }
            return manoDeObraEtapas;
        }

        private ManoDeObraEtapas Mapear(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            ManoDeObraEtapas ManoDeObraEtapa = new ManoDeObraEtapas();

            ManoDeObraEtapa.CodigoManoDeObra = dataReader.GetString(0);
            ManoDeObraEtapa.ParametrosDeReferencia.Codigo = dataReader.GetString(1);
            ManoDeObraEtapa.ProcesosProduccion.Tipo = dataReader.GetString(2);
            ManoDeObraEtapa.NumeroEmpleado = dataReader.GetDouble(3);
            ManoDeObraEtapa.DiasHabilesAño = dataReader.GetDouble(4);
            ManoDeObraEtapa.DiasHabilesMes = dataReader.GetDouble(5);
            ManoDeObraEtapa.HorasDiaProductivas = dataReader.GetDouble(6);
            ManoDeObraEtapa.HorasTrabajoEfectivo = dataReader.GetDouble(7);
            ManoDeObraEtapa.TotalHorasMes = dataReader.GetDouble(8);
            ManoDeObraEtapa.CostoHora = dataReader.GetDouble(9);
            ManoDeObraEtapa.CostoMinuto = dataReader.GetDouble(10);

            return ManoDeObraEtapa;
        }

        public void Modificar(ManoDeObraEtapas manoDeObraEtapasNuevo)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "UPDATE ManoDeObraEtapas SET Codigo=@Codigo," +
                                      "CodigoParametroReferencia=@CodigoParametroReferencia," +
                                      "Tipo=@Tipo," +
                                      "NumeroEmpleado=@NumeroEmpleado," +
                                      "DiasHabilesAño=@DiasHabilesAño," +
                                      "DiasHabilesMes=@DiasHabilesMes," +
                                      "HorasDiaProductivas=@HorasDiaProductivas," +
                                      "HorasTrabajoEfectivo=@HorasTrabajoEfectivo," +
                                      "TotalHorasMes=@TotalHorasMes," +
                                      "CostoHora=@CostoHora," +
                                      "CostoMinuto=@CostoMinuto WHERE CodigoParametroReferencia=@CodigoParametroReferencia AND Tipo= (select Tipo from ProcesosProduccion where Tipo=@Tipo AND CodigoParametroReferencia=@CodigoParametroReferencia)";

                command.Parameters.AddWithValue("@Codigo", manoDeObraEtapasNuevo.CodigoManoDeObra);
                command.Parameters.AddWithValue("@NumeroEmpleado", manoDeObraEtapasNuevo.NumeroEmpleado);
                command.Parameters.AddWithValue("@DiasHabilesAño", manoDeObraEtapasNuevo.DiasHabilesAño);
                command.Parameters.AddWithValue("@DiasHabilesMes", manoDeObraEtapasNuevo.DiasHabilesMes);
                command.Parameters.AddWithValue("@HorasDiaProductivas", manoDeObraEtapasNuevo.HorasDiaProductivas);
                command.Parameters.AddWithValue("@HorasTrabajoEfectivo", manoDeObraEtapasNuevo.HorasTrabajoEfectivo);
                command.Parameters.AddWithValue("@TotalHorasMes", manoDeObraEtapasNuevo.TotalHorasMes);
                command.Parameters.AddWithValue("@CostoHora", manoDeObraEtapasNuevo.CostoHora);
                command.Parameters.AddWithValue("@CostoMinuto", manoDeObraEtapasNuevo.CostoMinuto);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", manoDeObraEtapasNuevo.ParametrosDeReferencia.Codigo);
                command.Parameters.AddWithValue("@Tipo", manoDeObraEtapasNuevo.ProcesosProduccion.Tipo);

                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(string codigoParametro,string tipo, string codigoEtapas)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM ManoDeObraEtapas WHERE Codigo=@Codigo AND CodigoParametroReferencia=@CodigoParametroReferencia  (select Tipo from ProcesosProduccion  where Tipo=@Tipo)";
                command.Parameters.AddWithValue("@Codigo", codigoEtapas);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", codigoParametro);
                command.Parameters.AddWithValue("@Tipo", tipo);
                command.ExecuteNonQuery();
            }
        }
        public double ValidarDato(string Codigo, String Tipo)
        {
            manoDeObraEtapas = ConsultarTodos();
            return manoDeObraEtapas.Where(i => i.ProcesosProduccion.Tipo.ToUpper().Trim().Equals(Tipo.Trim().ToUpper()) && (i.ParametrosDeReferencia.Codigo.Equals(Codigo))).Count();
        }
        public List<ManoDeObraEtapas> Dato(string Codigo, String Tipo)
        {
            manoDeObraEtapas = ConsultarTodos();
            return manoDeObraEtapas.Where(i => i.ProcesosProduccion.Tipo.ToUpper().Trim().Equals(Tipo.Trim().ToUpper()) && (i.ParametrosDeReferencia.Codigo.Equals(Codigo))).ToList();
        }

        public double TotalNumeroEmpleados(string CodigoParametro)
        {
            manoDeObraEtapas = ConsultarTodos();
            return manoDeObraEtapas.Where(i => i.ParametrosDeReferencia.Codigo.Equals(CodigoParametro)).Sum(i => i.NumeroEmpleado); ;
        }
        public double TotalDiasHabilesAño(string CodigoParametro)
        {
            manoDeObraEtapas = ConsultarTodos();
            return manoDeObraEtapas.Where(i => i.ParametrosDeReferencia.Codigo.Equals(CodigoParametro)).Sum(i => i.DiasHabilesAño); ;
        }
        public double TotalDiasHabilesMes(string CodigoParametro)
        {
            manoDeObraEtapas = ConsultarTodos();
            return manoDeObraEtapas.Where(i => i.ParametrosDeReferencia.Codigo.Equals(CodigoParametro)).Sum(i => i.DiasHabilesMes); ;
        }
        public double TotalHorasDiaProductivas(string CodigoParametro)
        {
            manoDeObraEtapas = ConsultarTodos();
            return manoDeObraEtapas.Where(i => i.ParametrosDeReferencia.Codigo.Equals(CodigoParametro)).Sum(i => i.HorasDiaProductivas); ;
        }
        public double TotalHorasTrabajoEfectivos(string CodigoParametro)
        {
            manoDeObraEtapas = ConsultarTodos();
            return manoDeObraEtapas.Where(i => i.ParametrosDeReferencia.Codigo.Equals(CodigoParametro)).Sum(i => i.HorasTrabajoEfectivo); ;
        }
        public double TotalTotalHoraMes(string CodigoParametro)
        {
            manoDeObraEtapas = ConsultarTodos();
            return manoDeObraEtapas.Where(i => i.ParametrosDeReferencia.Codigo.Equals(CodigoParametro)).Sum(i => i.TotalHorasMes); ;
        }
        public double TotalCostoHora(string CodigoParametro)
        {
            manoDeObraEtapas = ConsultarTodos();
            return manoDeObraEtapas.Where(i => i.ParametrosDeReferencia.Codigo.Equals(CodigoParametro)).Sum(i => i.CostoHora); ;
        }
        public double TotalCostoMinuto(string CodigoParametro)
        {
            manoDeObraEtapas = ConsultarTodos();
            return manoDeObraEtapas.Where(i => i.ParametrosDeReferencia.Codigo.Equals(CodigoParametro)).Sum(i => i.CostoMinuto); ;
        }
        public IList<ManoDeObraEtapas> BuscarCodigoParametro(string CodigoParametro)
        {
            IList<ManoDeObraEtapas> manoDeObraEtapas = ConsultarTodos();
            return manoDeObraEtapas.Where(i => i.ParametrosDeReferencia.Codigo.ToUpper().Trim().Contains(CodigoParametro.ToUpper())).ToList();
        }
        public IList<ManoDeObraEtapas> BuscarTodo()
        {
            IList<ManoDeObraEtapas> manoDeObraEtapas  = ConsultarTodos();
            return manoDeObraEtapas.ToList();
        }
    }
}
