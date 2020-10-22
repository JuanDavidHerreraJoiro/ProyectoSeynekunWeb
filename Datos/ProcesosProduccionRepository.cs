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
     public class ProcesosProduccionRepository
    {
        private string ruta = "ProcesosProduccion.txt";
        List<ProcesosProduccion> procesosProduccions = new List<ProcesosProduccion>();
        SqlConnection connection;
        public ProcesosProduccionRepository(ConnectionManager connectionManager)
        {
            connection = connectionManager.connection;
        }
        public void Guardar(ProcesosProduccion procesos)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO ProcesosProduccion (CodigoProcesosProduccion,CodigoParametroReferencia,Tipo,HorasTotalesDia,MinutosTotalesDia,HoraAlmuerzo,ParadasDescanzo,TiempoNetoDisponibleMinutos,TiempoCicloTotal,TiempoAlistamiento," +
                    "TiempoOperacion,NumeroMaquinas,NumeroOperarios,PorcentajeRechazo,NumeroTurnos,Distancia,Disponibilidad,MantenimientoCorrectivo,ParadasMenores,UptimeFactorEficienciaProceso) " +
                    "values(next value for seq_Procesos,@CodigoParametroReferencia,@Tipo,@HorasTotalesDia,@MinutosTotalesDia,@HoraAlmuerzo,@ParadasDescanzo,@TiempoNetoDisponibleMinutos,@TiempoCicloTotal,@TiempoAlistamiento," +
                    "@TiempoOperacion,@NumeroMaquinas,@NumeroOperarios,@PorcentajeRechazo,@NumeroTurnos,@Distancia,@Disponibilidad,@MantenimientoCorrectivo,@ParadasMenores,@UptimeFactorEficienciaProceso)";
                command.Parameters.AddWithValue("@CodigoProcesosProduccion", procesos.CodigoProcesosProduccionPK);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", procesos.ParametrosDeReferencia.Codigo);
                command.Parameters.AddWithValue("@Tipo", procesos.Tipo.Trim());
                command.Parameters.AddWithValue("@HorasTotalesDia", procesos.HorasTotalesDia);
                command.Parameters.AddWithValue("@MinutosTotalesDia", procesos.MinutosTotalesDia);
                command.Parameters.AddWithValue("@HoraAlmuerzo", procesos.HoraAlmuerzo);
                command.Parameters.AddWithValue("@ParadasDescanzo", procesos.ParadasDescanzo);
                command.Parameters.AddWithValue("@TiempoNetoDisponibleMinutos", procesos.TiempoNetoDisponibleMinutos);
                command.Parameters.AddWithValue("@TiempoCicloTotal", procesos.TiempoCicloTotal);
                command.Parameters.AddWithValue("@TiempoAlistamiento", procesos.TiempoAlistamiento);
                command.Parameters.AddWithValue("@TiempoOperacion", procesos.TiempoOperacion);
                command.Parameters.AddWithValue("@NumeroMaquinas", procesos.NumeroMaquinas);
                command.Parameters.AddWithValue("@NumeroOperarios", procesos.NumeroOperarios);
                command.Parameters.AddWithValue("@PorcentajeRechazo", procesos.PorcentajeRechazo);
                command.Parameters.AddWithValue("@NumeroTurnos", procesos.NumeroTurnos);
                command.Parameters.AddWithValue("@Distancia", procesos.Distancia);
                command.Parameters.AddWithValue("@Disponibilidad", procesos.Disponibilidad);
                command.Parameters.AddWithValue("@MantenimientoCorrectivo", procesos.MantenimientoCorrectivo);
                command.Parameters.AddWithValue("@ParadasMenores", procesos.ParadasMenores);
                command.Parameters.AddWithValue("@UptimeFactorEficienciaProceso", procesos.UptimeFactorEficienciaProceso);

                command.ExecuteNonQuery();
            }
        }

        public List<ProcesosProduccion> ConsultarTodo()
        {
            procesosProduccions.Clear();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT ProcesosProduccion.CodigoProcesosProduccion,ProcesosProduccion.CodigoParametroReferencia,ProcesosProduccion.Tipo,ProcesosProduccion.HorasTotalesDia,ProcesosProduccion.MinutosTotalesDia,ProcesosProduccion.HoraAlmuerzo,ProcesosProduccion.ParadasDescanzo,ProcesosProduccion.TiempoNetoDisponibleMinutos,ProcesosProduccion.TiempoCicloTotal,ProcesosProduccion.TiempoAlistamiento,ProcesosProduccion.TiempoOperacion,ProcesosProduccion.NumeroMaquinas,ProcesosProduccion.NumeroOperarios,ProcesosProduccion.PorcentajeRechazo,ProcesosProduccion.NumeroTurnos,ProcesosProduccion.Distancia,ProcesosProduccion.Disponibilidad,ProcesosProduccion.MantenimientoCorrectivo,ProcesosProduccion.ParadasMenores,ProcesosProduccion.UptimeFactorEficienciaProceso,ParametrosReferencia.ProductoExportar,  ParametrosReferencia.CantidadExportar, ParametrosReferencia.PresentacionProducto FROM ParametrosReferencia INNER JOIN ProcesosProduccion ON ParametrosReferencia.Codigo = ProcesosProduccion.CodigoParametroReferencia";
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ProcesosProduccion procesos = DataReaderMapProcesos(dataReader);
                        procesosProduccions.Add(procesos);
                    }
                }
            }
            return procesosProduccions;
        }

        private ProcesosProduccion DataReaderMapProcesos(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;

            ProcesosProduccion procesos = new ProcesosProduccion();

            procesos.CodigoProcesosProduccionPK = dataReader.GetInt32(0);
            procesos.ParametrosDeReferencia.Codigo = dataReader.GetString(1);
            procesos.Tipo = dataReader.GetString(2);
            procesos.HorasTotalesDia = dataReader.GetDouble(3);
            procesos.MinutosTotalesDia = dataReader.GetDouble(4);
            procesos.HoraAlmuerzo = dataReader.GetDouble(5);
            procesos.ParadasDescanzo = dataReader.GetDouble(6);
            procesos.TiempoNetoDisponibleMinutos = dataReader.GetDouble(7);
            procesos.TiempoCicloTotal = dataReader.GetDouble(8);
            procesos.TiempoAlistamiento = dataReader.GetDouble(9);
            procesos.TiempoOperacion = dataReader.GetDouble(10);
            procesos.NumeroMaquinas = dataReader.GetDouble(11);
            procesos.NumeroOperarios = dataReader.GetDouble(12);
            procesos.PorcentajeRechazo = dataReader.GetDouble(13);
            procesos.NumeroTurnos = dataReader.GetDouble(14);
            procesos.Distancia = dataReader.GetDouble(15);
            procesos.Disponibilidad = dataReader.GetDouble(16);
            procesos.MantenimientoCorrectivo = dataReader.GetDouble(17);
            procesos.ParadasMenores = dataReader.GetDouble(18);
            procesos.UptimeFactorEficienciaProceso = dataReader.GetDecimal(19);
            procesos.ParametrosDeReferencia.ProductoExportar = dataReader.GetString(20);
            procesos.ParametrosDeReferencia.CantidadExportar = dataReader.GetDouble(21);
            procesos.ParametrosDeReferencia.PresentacionProducto = dataReader.GetDouble(22);

            return procesos;
        }

        public void Modificar(ProcesosProduccion procesos)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"UPDATE ProcesosProduccion SET CodigoParametroReferencia=@CodigoParametroReferencia,Tipo=@Tipo,
                                      HorasTotalesDia=@HorasTotalesDia,MinutosTotalesDia=@MinutosTotalesDia,HoraAlmuerzo=@HoraAlmuerzo,
                                      ParadasDescanzo=@ParadasDescanzo,TiempoNetoDisponibleMinutos=@TiempoNetoDisponibleMinutos,
                                      TiempoCicloTotal=@TiempoCicloTotal,TiempoAlistamiento=@TiempoAlistamiento,
                                      TiempoOperacion=@TiempoOperacion,NumeroMaquinas=@NumeroMaquinas,NumeroOperarios=@NumeroOperarios,
                                      PorcentajeRechazo=@PorcentajeRechazo,NumeroTurnos=@NumeroTurnos,Distancia=@Distancia,Disponibilidad=@Disponibilidad,
                                      MantenimientoCorrectivo=@MantenimientoCorrectivo,ParadasMenores=@ParadasMenores,UptimeFactorEficienciaProceso=@UptimeFactorEficienciaProceso
                                      WHERE CodigoParametroReferencia=@CodigoParametroReferencia AND Tipo=@Tipo";

                command.Parameters.AddWithValue("@CodigoProcesosProduccion", procesos.CodigoProcesosProduccionPK);
                command.Parameters.AddWithValue("@CodigoParametroReferencia", procesos.ParametrosDeReferencia.Codigo);
                command.Parameters.AddWithValue("@Tipo", procesos.Tipo);
                command.Parameters.AddWithValue("@HorasTotalesDia", procesos.HorasTotalesDia);
                command.Parameters.AddWithValue("@MinutosTotalesDia", procesos.MinutosTotalesDia);
                command.Parameters.AddWithValue("@HoraAlmuerzo", procesos.HoraAlmuerzo);
                command.Parameters.AddWithValue("@ParadasDescanzo", procesos.ParadasDescanzo);
                command.Parameters.AddWithValue("@TiempoNetoDisponibleMinutos", procesos.TiempoNetoDisponibleMinutos);
                command.Parameters.AddWithValue("@TiempoCicloTotal", procesos.TiempoCicloTotal);
                command.Parameters.AddWithValue("@TiempoAlistamiento", procesos.TiempoAlistamiento);
                command.Parameters.AddWithValue("@TiempoOperacion", procesos.TiempoOperacion);
                command.Parameters.AddWithValue("@NumeroMaquinas", procesos.NumeroMaquinas);
                command.Parameters.AddWithValue("@NumeroOperarios", procesos.NumeroOperarios);
                command.Parameters.AddWithValue("@PorcentajeRechazo", procesos.PorcentajeRechazo);
                command.Parameters.AddWithValue("@NumeroTurnos", procesos.NumeroTurnos);
                command.Parameters.AddWithValue("@Distancia", procesos.Distancia);
                command.Parameters.AddWithValue("@Disponibilidad", procesos.Disponibilidad);
                command.Parameters.AddWithValue("@MantenimientoCorrectivo", procesos.MantenimientoCorrectivo);
                command.Parameters.AddWithValue("@ParadasMenores", procesos.ParadasMenores);
                command.Parameters.AddWithValue("@UptimeFactorEficienciaProceso", procesos.UptimeFactorEficienciaProceso);

                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(string codigoParametro, string Tipo)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE from ProcesosProduccion where CodigoParametroReferencia=@CodigoParametroReferencia and Tipo=@Tipo";
                command.Parameters.AddWithValue("@CodigoParametroReferencia", codigoParametro);
                command.Parameters.AddWithValue("@Tipo", Tipo);
                command.ExecuteNonQuery();
            }
            EliminarManoDeObra(codigoParametro, Tipo);
        }
        public void EliminarManoDeObra(string codigoParametro, string Tipo)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE from ManoDeObra where CodigoParametroReferencia=@CodigoParametroReferencia and Tipo=@Tipo";
                command.Parameters.AddWithValue("@CodigoParametroReferencia", codigoParametro);
                command.Parameters.AddWithValue("@Tipo", Tipo);
                command.ExecuteNonQuery();
            }
        }
        public int ValidarDato(string CodigoParametro, string Tipo)
        {
            procesosProduccions = ConsultarTodo();
            return procesosProduccions.Where(i => i.ParametrosDeReferencia.Codigo.Equals(CodigoParametro) && (i.Tipo.Trim().ToUpper().Equals(Tipo.ToUpper()))).Count();
        }
        public int TraerDato(string CodigoParametro)
        {
            procesosProduccions = ConsultarTodo();
            return procesosProduccions.Where(i => i.ParametrosDeReferencia.Codigo.Equals(CodigoParametro)).Count();
        }
        public List<ProcesosProduccion> LlenarDato(string CodigoParametro)
        {
            procesosProduccions = ConsultarTodo();
            return procesosProduccions.Where(i => i.ParametrosDeReferencia.Codigo.Equals(CodigoParametro)).ToList();
        }
        public List<ProcesosProduccion> LlenarCategoria(string CodigoParametro)
        {
            procesosProduccions = ConsultarTodo();
            return procesosProduccions.Where(i => i.ParametrosDeReferencia.Codigo.Equals(CodigoParametro)).ToList();
        }
        public List<ProcesosProduccion> CantidadOperarios(string CodigoParametro, string Tipo)
        {
            procesosProduccions = ConsultarTodo();
            return procesosProduccions.Where(i => i.ParametrosDeReferencia.Codigo.Equals(CodigoParametro) && (i.Tipo.Trim().ToUpper().Equals(Tipo.ToUpper()))).ToList();
        }
        public List<ProcesosProduccion> ConsultarTodos()
        {
            procesosProduccions = ConsultarTodo();
            return procesosProduccions.ToList();
        }
        public List<ProcesosProduccion> ConsultarParametro(string CodigoParametro)
        {
            procesosProduccions = ConsultarTodo();
            return procesosProduccions.Where(i => i.ParametrosDeReferencia.Codigo.ToUpper().Trim().Contains(CodigoParametro.ToUpper())).ToList();
        }

    }
}
