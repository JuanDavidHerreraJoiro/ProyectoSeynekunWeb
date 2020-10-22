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
    public class ManoDeObraRepository
    {
        private string ruta = "ManoDeObra.txt";
        List<ManoDeObra> manoDeObras;
        SqlConnection Connection;
        SqlCommand command;
        public ManoDeObraRepository(ConnectionManager connectionManager)
        {
            Connection = connectionManager.connection;
            command = new SqlCommand();
            manoDeObras = new List<ManoDeObra>();
        }
        public void Guardar(ManoDeObra manoDeObra)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO ManoDeObra " +
                                      "(CodigoManoDeObra,Codigo,CodigoParametroReferencia,SubCodigoManoDeObra,Tipo,Operario,SalarioNetoMensual,NominaServicio,Bonificacion,ValorTotal,Porcentaje)" +
                                      "values" +
                                      "(next value for seq_ManoDeObra,@Codigo,@CodigoParametroReferencia,@SubCodigoManoDeObra,@Tipo,@Operario,@SalarioNetoMensual,@NominaServicio,@Bonificacion,@ValorTotal,@Porcentaje)";

                
                command.Parameters.AddWithValue("@Codigo", manoDeObra.CodigoManoDeObra);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", manoDeObra.ParametrosDeReferencia.Codigo);
                command.Parameters.AddWithValue("@SubCodigoManoDeObra", manoDeObra.SubCodigoManoDeObra);
                command.Parameters.AddWithValue("@Tipo", manoDeObra.ProcesosProduccion.Tipo);
                command.Parameters.AddWithValue("@Operario", manoDeObra.Operario);
                command.Parameters.AddWithValue("@SalarioNetoMensual", manoDeObra.SalarioNetoMensual);
                command.Parameters.AddWithValue("@NominaServicio", manoDeObra.NominaServicio);
                command.Parameters.AddWithValue("@Bonificacion", manoDeObra.Bonificacion);
                command.Parameters.AddWithValue("@ValorTotal", manoDeObra.ValorTotal);
                command.Parameters.AddWithValue("@Porcentaje", manoDeObra.Porcentaje);

                command.ExecuteNonQuery();
            }

        }

        public List<ManoDeObra> ConsultarTodos()
        {
            manoDeObras.Clear();
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "SELECT MO.Codigo,MO.CodigoParametroReferencia,MO.SubCodigoManoDeObra,PR.Tipo,MO.Operario,MO.SalarioNetoMensual,MO.NominaServicio,PF.FactorPrestacionalSalarioNormal,MO.Bonificacion,MO.ValorTotal,MO.Porcentaje FROM ManoDeObra MO JOIN ProcesosProduccion PR ON MO.CodigoParametroReferencia = PR.CodigoParametroReferencia JOIN ParametrosReferencia PF ON MO.Tipo = PR.Tipo AND PF.Codigo = MO.CodigoParametroReferencia";
                    SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    ManoDeObra manoDeObra = Mapear(dataReader);
                    manoDeObras.Add(manoDeObra);
                }
            }
            return manoDeObras;
        }

        private ManoDeObra Mapear(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            ManoDeObra manoDeObra = new ManoDeObra();

            manoDeObra.CodigoManoDeObra = dataReader.GetString(0);
            manoDeObra.ParametrosDeReferencia.Codigo = dataReader.GetString(1);
            manoDeObra.SubCodigoManoDeObra = dataReader.GetString(2);
            manoDeObra.ProcesosProduccion.Tipo = dataReader.GetString(3);
            manoDeObra.Operario = dataReader.GetString(4);
            manoDeObra.SalarioNetoMensual = dataReader.GetDouble(5);
            manoDeObra.NominaServicio = dataReader.GetString(6);
            manoDeObra.ParametrosDeReferencia.FactorPrestacionalSalarioNormal = dataReader.GetDecimal(7);
            manoDeObra.Bonificacion = dataReader.GetDouble(8);
            manoDeObra.ValorTotal = dataReader.GetDouble(9);
            manoDeObra.Porcentaje = dataReader.GetDouble(10);
            
            return manoDeObra;

        }
        public void Modificar(ManoDeObra manoDeObraNuevo)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = @"UPDATE ManoDeObra SET CodigoManoDeObra = next value for seq_ManoDeObra,
                                        Codigo = @Codigo,
                                        CodigoParametroReferencia = @CodigoParametroReferencia,
                                        SubCodigoManoDeObra = @SubCodigoManoDeObra,
                                        Operario = @Operario,
                                        SalarioNetoMensual = @SalarioNetoMensual,
                                        NominaServicio = @NominaServicio,
                                        Bonificacion = @Bonificacion,
                                        ValorTotal = @ValorTotal,
                                        Porcentaje = @Porcentaje,
                                        Tipo = @Tipo WHERE CodigoParametroReferencia = @CodigoParametroReferencia AND SubCodigoManoDeObra = @SubCodigoManoDeObra AND Tipo = (select Tipo from ProcesosProduccion  where Tipo=@Tipo AND CodigoParametroReferencia = @CodigoParametroReferencia)";

                command.Parameters.AddWithValue("@CodigoManoDeObra", manoDeObraNuevo.ManoDeObraPk);
                command.Parameters.AddWithValue("@Codigo", manoDeObraNuevo.CodigoManoDeObra);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", manoDeObraNuevo.ParametrosDeReferencia.Codigo);
                command.Parameters.AddWithValue("@SubCodigoManoDeObra", manoDeObraNuevo.SubCodigoManoDeObra);
                command.Parameters.AddWithValue("@Operario", manoDeObraNuevo.Operario);
                command.Parameters.AddWithValue("@SalarioNetoMensual", manoDeObraNuevo.SalarioNetoMensual);
                command.Parameters.AddWithValue("@NominaServicio", manoDeObraNuevo.NominaServicio);
                command.Parameters.AddWithValue("@Bonificacion", manoDeObraNuevo.Bonificacion);
                command.Parameters.AddWithValue("@ValorTotal", manoDeObraNuevo.ValorTotal);
                command.Parameters.AddWithValue("@Porcentaje", manoDeObraNuevo.Porcentaje);
                command.Parameters.AddWithValue("@Tipo", manoDeObraNuevo.ProcesosProduccion.Tipo);

                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(string codigoparametro,string codigo,string tipo)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM ManoDeObra WHERE Codigo=@Codigo AND CodigoParametroReferencia=@CodigoParametroReferencia  (select Tipo from ProcesosProduccion  where Tipo=@Tipo) ";
                command.Parameters.AddWithValue("@Codigo", codigo);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", codigoparametro);
                command.Parameters.AddWithValue("@Tipo", tipo);
                command.ExecuteNonQuery();
            }
        }

        public int BuscarDato(string Codigo, String Tipo)
        {
            IList<ManoDeObra> manoDeObras = ConsultarTodos();
            return manoDeObras.Where(i => i.ProcesosProduccion.Tipo.ToUpper().Trim().Equals(Tipo.Trim().ToUpper()) && (i.ParametrosDeReferencia.Codigo.Equals(Codigo)) && (i.CodigoManoDeObra.Equals("72"))).Count();
        }
        public double TotalSalarioNetoMensualPorTipo(string Codigo,String Tipo)
        {
            IList<ManoDeObra> manoDeObras = ConsultarTodos();
            return manoDeObras.Where(i => i.ProcesosProduccion.Tipo.ToUpper().Trim().Equals(Tipo.Trim().ToUpper()) && (i.ParametrosDeReferencia.Codigo.Equals(Codigo))).Sum(i => i.SalarioNetoMensual);
        }
        public double TotalValorTotalPorTipo(string Codigo, String Tipo)
        {
            IList<ManoDeObra> manoDeObras = ConsultarTodos();
            return manoDeObras.Where(i => i.ProcesosProduccion.Tipo.ToUpper().Trim().Equals(Tipo.Trim().ToUpper()) && (i.ParametrosDeReferencia.Codigo.Equals(Codigo))).Sum(i => i.ValorTotal);
        }
        public double TotalSalarioNetoMensual(string Codigo)
        {
            IList<ManoDeObra> manoDeObras = ConsultarTodos();
            return manoDeObras.Where(i => i.ParametrosDeReferencia.Codigo.Equals(Codigo)).Sum(i => i.SalarioNetoMensual);
        }
        public double TotalValorTotal(string Codigo)
        {
            IList<ManoDeObra> manoDeObras = ConsultarTodos();
            return manoDeObras.Where(i => i.ParametrosDeReferencia.Codigo.Equals(Codigo)).Sum(i => i.ValorTotal);
        }
        public double TotalPorcentajeTotal(string Codigo)
        {
            IList<ManoDeObra> manoDeObras = ConsultarTodos();
            return manoDeObras.Where(i => i.ParametrosDeReferencia.Codigo.Equals(Codigo)).Sum(i => i.Porcentaje);
        }
        public double ValidarDato(string Codigo, String Tipo)
        {
            IList<ManoDeObra> manoDeObras = ConsultarTodos();
            return manoDeObras.Where(i => i.ProcesosProduccion.Tipo.ToUpper().Trim().Equals(Tipo.Trim().ToUpper()) && (i.ParametrosDeReferencia.Codigo.Equals(Codigo))).Count();
        }
        public IList<ManoDeObra> BuscarCodigoParametro(string CodigoParametro)
        {
            IList<ManoDeObra> manoDeObras = ConsultarTodos();
            return manoDeObras.Where(i => i.ParametrosDeReferencia.Codigo.ToUpper().Trim().Contains(CodigoParametro.ToUpper())).ToList();
        }
        public IList<ManoDeObra> BuscarCodigoManoObra(string CodigoManoObra)
        {
            IList<ManoDeObra> manoDeObras = ConsultarTodos();
            return manoDeObras.Where(i => i.CodigoManoDeObra.ToUpper().Trim().Contains(CodigoManoObra.ToUpper())).ToList();
        }
        public IList<ManoDeObra> BuscarTodo()
        {
            IList<ManoDeObra> manoDeObras = ConsultarTodos();
            return manoDeObras.ToList();
        }
    }
}
