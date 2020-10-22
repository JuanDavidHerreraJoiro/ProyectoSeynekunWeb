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
    public class ParametrosDeReferenciaRepository
    {
        private string ruta = "ParametrosDeReferencia.txt";
        List<ParametrosDeReferencia> parametrosDeReferencias;
        SqlConnection Connection;
        SqlCommand command;
        public ParametrosDeReferenciaRepository(ConnectionManager connectionManager)
        {
            Connection = connectionManager.connection;
            command = new SqlCommand();
            parametrosDeReferencias = new List<ParametrosDeReferencia>();
        }
        public void Guardar(ParametrosDeReferencia parametros)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO ParametrosReferencia (Codigo,CodigoFichaTecnica,Empresa,FechaCosteo,ProductoExportar," +
                                      "CantidadExportar,PresentacionProducto,Cliente,FactorPrestacionalSalarioNormal,FactorAplicableContratistas," +
                                      "DiaAlMes,HoraDeTrabajoPorDia,ComisionPorVenta,MargenDeRentabilidadEsperado)" +
                                      "values(@Codigo,@CodigoFichaTecnica,@Empresa,@FechaDeCosteo,@ProductoExportar," +
                                      "@CantidadExportar,@PresentacionProducto,@Cliente,@FactorPrestacionalSalarioNormal,@FactorAplicableContratistas," +
                                      "@DiaAlMes,@HoraDeTrabajoPorDia,@ComisionPorVenta,@MargenDeRentabilidadEsperado)";
                
                command.Parameters.AddWithValue("@Codigo", parametros.Codigo);
                command.Parameters.AddWithValue("@CodigoFichaTecnica", parametros.FichaTecnica.Codigo);
                command.Parameters.AddWithValue("@Empresa", parametros.Empresa);
                command.Parameters.AddWithValue("@FechaDeCosteo", parametros.FechaDeCosteo);
                command.Parameters.AddWithValue("@ProductoExportar", parametros.ProductoExportar);
                command.Parameters.AddWithValue("@CantidadExportar", parametros.CantidadExportar);
                command.Parameters.AddWithValue("@PresentacionProducto", parametros.PresentacionProducto);
                command.Parameters.AddWithValue("@Cliente", parametros.Cliente);
                command.Parameters.AddWithValue("@FactorPrestacionalSalarioNormal", parametros.FactorPrestacionalSalarioNormal);
                command.Parameters.AddWithValue("@FactorAplicableContratistas", parametros.FactorAplicableALosContratistas);
                command.Parameters.AddWithValue("@DiaAlMes", parametros.DiaAlMes);
                command.Parameters.AddWithValue("@HoraDeTrabajoPorDia", parametros.HoraDeTrabajoPorDia);
                command.Parameters.AddWithValue("@ComisionPorVenta", parametros.ComisionPorVenta);
                command.Parameters.AddWithValue("@MargenDeRentabilidadEsperado", parametros.MargenDeRentabilidadEsperado);

                command.ExecuteNonQuery();
            }

        }

        public List<ParametrosDeReferencia> ConsultarTodos()
        {
            parametrosDeReferencias.Clear();
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "select * from ParametrosReferencia";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    
                    ParametrosDeReferencia parametros = DataReaderMapLiquidacion(dataReader);
                    parametrosDeReferencias.Add(parametros);

                }
            }
            return parametrosDeReferencias;
        }

        private ParametrosDeReferencia DataReaderMapLiquidacion(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            ParametrosDeReferencia parametros = new ParametrosDeReferencia();
            parametros.Codigo = dataReader.GetString(0);
            parametros.FichaTecnica.Codigo = dataReader.GetString(1);
            parametros.Empresa = dataReader.GetString(2);
            parametros.FechaDeCosteo = dataReader.GetDateTime(3);
            parametros.ProductoExportar = dataReader.GetString(4);
            parametros.CantidadExportar = dataReader.GetDouble(5);
            parametros.PresentacionProducto = dataReader.GetDouble(6);
            parametros.Cliente = dataReader.GetString(7);
            parametros.FactorPrestacionalSalarioNormal = dataReader.GetDecimal(8);
            parametros.FactorAplicableALosContratistas = dataReader.GetDecimal(9);
            parametros.DiaAlMes = dataReader.GetInt32(10);
            parametros.HoraDeTrabajoPorDia = dataReader.GetInt32(11);
            parametros.ComisionPorVenta = dataReader.GetDouble(12);
            parametros.MargenDeRentabilidadEsperado = dataReader.GetDouble(13);
            return parametros;
        }
        public void Modificar(ParametrosDeReferencia parametros)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "UPDATE ParametrosReferencia set CodigoFichaTecnica=@CodigoFichaTecnica,Empresa=@Empresa,FechaCosteo=@FechaDeCosteo," +
                                       "ProductoExportar=@ProductoExportar,CantidadExportar=@CantidadExportar,PresentacionProducto=@PresentacionProducto,Cliente=@Cliente,FactorPrestacionalSalarioNormal=@FactorPrestacionalSalarioNormal,FactorAplicableContratistas=@FactorAplicableContratistas," +
                                       "DiaAlMes=@DiaAlMes,HoraDeTrabajoPorDia=@HoraDeTrabajoPorDia,ComisionPorVenta=@ComisionPorVenta,MargenDeRentabilidadEsperado=@MargenDeRentabilidadEsperado WHERE Codigo = @Codigo and CodigoFichaTecnica = @CodigoFichaTecnica";
                
                
                command.Parameters.AddWithValue("@Codigo", parametros.Codigo);
                command.Parameters.AddWithValue("@CodigoFichaTecnica", parametros.FichaTecnica.Codigo);
                command.Parameters.AddWithValue("@Empresa", parametros.Empresa);
                command.Parameters.AddWithValue("@FechaDeCosteo", parametros.FechaDeCosteo);
                command.Parameters.AddWithValue("@ProductoExportar", parametros.ProductoExportar);
                command.Parameters.AddWithValue("@CantidadExportar", parametros.CantidadExportar);
                command.Parameters.AddWithValue("@PresentacionProducto", parametros.PresentacionProducto);
                command.Parameters.AddWithValue("@Cliente", parametros.Cliente);
                command.Parameters.AddWithValue("@FactorPrestacionalSalarioNormal", parametros.FactorPrestacionalSalarioNormal);
                command.Parameters.AddWithValue("@FactorAplicableContratistas", parametros.FactorAplicableALosContratistas);
                command.Parameters.AddWithValue("@DiaAlMes", parametros.DiaAlMes);
                command.Parameters.AddWithValue("@HoraDeTrabajoPorDia", parametros.HoraDeTrabajoPorDia);
                command.Parameters.AddWithValue("@ComisionPorVenta", parametros.ComisionPorVenta);
                command.Parameters.AddWithValue("@MargenDeRentabilidadEsperado", parametros.MargenDeRentabilidadEsperado);

                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(string codigo)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "DELETE from ParametrosReferencia where Codigo = @Codigo";
                command.Parameters.AddWithValue("@Codigo", codigo);

                command.ExecuteNonQuery();
            }
        }
        public bool Buscar(string codigo)
        {
            List<ParametrosDeReferencia> parametrosDeReferencias = ConsultarTodos();

            foreach (var item in parametrosDeReferencias)
            {
                if (item.Codigo.Equals(codigo))
                {
                    return true;
                }
            }
            return false;
        }

        public List<ParametrosDeReferencia> BuscarDatos(string codigo)
        {
            List<ParametrosDeReferencia> parametrosDeReferencias = ConsultarTodos();

            foreach (var item in parametrosDeReferencias)
            {
                if (item.Codigo.Equals(codigo))
                {
                    return parametrosDeReferencias;
                }
            }
            return null;
        }
        
        public ParametrosDeReferencia Consultar(string codigo)
        {
            List<ParametrosDeReferencia> parametrosDeReferenciaspersonas = ConsultarTodos();

            foreach (var item in parametrosDeReferencias)
            {
                if (item.Codigo.Equals(codigo))
                {
                    return item;
                }
            }
            return null;
        }



        //sentencia

        public IList<ParametrosDeReferencia> BuscarFecha(int Mes, int Año)
        {
            IList<ParametrosDeReferencia> parametrosDeReferencias = ConsultarTodos();
            return parametrosDeReferencias.Where(i => i.FechaDeCosteo.Year.Equals(Año) && (i.FechaDeCosteo.Month.Equals(Mes))).ToList();
        }
        public double BuscarFechaContar(int Mes, int Año)
        {
            IList<ParametrosDeReferencia> parametrosDeReferencias = ConsultarTodos();
            return parametrosDeReferencias.Where(i => i.FechaDeCosteo.Year.Equals(Año) && (i.FechaDeCosteo.Month.Equals(Mes))).Count();
        }
        public IList<ParametrosDeReferencia> BuscarParametroReferencia(string CodigoParametroReferencia)
        {
            IList<ParametrosDeReferencia> parametrosDeReferencias = ConsultarTodos();
            return parametrosDeReferencias.Where(i => i.Codigo.ToUpper().Trim().Contains(CodigoParametroReferencia.ToUpper())).ToList();
        }
        public double BuscarParametroReferenciaContar(string CodigoParametroReferencia)
        {
            IList<ParametrosDeReferencia> parametrosDeReferencias = ConsultarTodos();
            return parametrosDeReferencias.Where(i => i.Codigo.ToUpper().Trim().Contains(CodigoParametroReferencia.ToUpper())).Count();
        }
        public IList<ParametrosDeReferencia> BuscarProducto(string Producto)
        {
            IList<ParametrosDeReferencia> parametrosDeReferencias = ConsultarTodos();
            return parametrosDeReferencias.Where(i => i.ProductoExportar.ToUpper().Trim().Contains(Producto.ToUpper())).ToList();
        }
        public double BuscarProductoContar(string Producto)
        {
            IList<ParametrosDeReferencia> parametrosDeReferencias = ConsultarTodos();
            return parametrosDeReferencias.Where(i => i.ProductoExportar.ToUpper().Trim().Contains(Producto.ToUpper())).Count();
        }
        public IList<ParametrosDeReferencia> BuscarCodigoFichaTecnica(string CodigoFichaTecnica)
        {
            IList<ParametrosDeReferencia> parametrosDeReferencias = ConsultarTodos();
            return parametrosDeReferencias.Where(i => i.FichaTecnica.Codigo.ToUpper().Trim().Contains(CodigoFichaTecnica.ToUpper())).ToList();
        }
        public double BuscarCodigoFichaTecnicaContar(string CodigoFichaTecnica)
        {
            IList<ParametrosDeReferencia> parametrosDeReferencias = ConsultarTodos();
            return parametrosDeReferencias.Where(i => i.FichaTecnica.Codigo.ToUpper().Trim().Contains(CodigoFichaTecnica.ToUpper())).Count();
        }
        public IList<ParametrosDeReferencia> BuscarTodo()
        {
            IList<ParametrosDeReferencia> parametrosDeReferencias = ConsultarTodos();
            return parametrosDeReferencias.ToList();
        }
        public double BuscarTodoContar()
        {
            IList<ParametrosDeReferencia> parametrosDeReferencias = ConsultarTodos();
            return parametrosDeReferencias.Count();
        }
    }
}
