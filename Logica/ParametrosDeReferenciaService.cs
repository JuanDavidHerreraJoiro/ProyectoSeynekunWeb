using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;
using Datos;

namespace Logica
{
    public class GuardarParametrosDeReferenciaResponse 
    {
        public GuardarParametrosDeReferenciaResponse (ParametrosDeReferencia parametrosDeReferencia)
        {
            Error = false;
            ParametrosDeReferencia = parametrosDeReferencia;
        }
        public GuardarParametrosDeReferenciaResponse (string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public ParametrosDeReferencia ParametrosDeReferencia{ get; set; }
    }
    public class ParametrosDeReferenciaService
    {
        private ConnectionManager connectionManager;
        private ParametrosDeReferenciaRepository parametrosDeReferenciaRepository;
        public ParametrosDeReferenciaService(string CadenaConexion)
        {
            connectionManager = new ConnectionManager(CadenaConexion);
            parametrosDeReferenciaRepository = new ParametrosDeReferenciaRepository(connectionManager);
        }
        
        public GuardarParametrosDeReferenciaResponse  Guardar(ParametrosDeReferencia parametrosDeReferencia)
        {
            try
            {
                connectionManager.Open();
                parametrosDeReferenciaRepository.Guardar(parametrosDeReferencia);
                connectionManager.Close();
                return new GuardarParametrosDeReferenciaResponse (parametrosDeReferencia);
            }
            catch (Exception e)
            {
                return new GuardarParametrosDeReferenciaResponse ($"!ERROR¡ REGISTRO FALLIDO ,"+e.Message);
            }
            finally
            {
                connectionManager.Close();
            }
            
        }

        public bool Buscar(string codigo)
        {
            try
            {
                connectionManager.Open();
                return parametrosDeReferenciaRepository.Buscar(codigo);   
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }

        public List<ParametrosDeReferencia> BuscarDatos(string codigo)
        {
            try
            {
                connectionManager.Open();
                return parametrosDeReferenciaRepository.BuscarDatos(codigo);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public ParametrosDeReferencia Consultar(string codigo)
        {
            try
            {
                connectionManager.Open();
                ParametrosDeReferencia parametrosDeReferencia = parametrosDeReferenciaRepository.Consultar(codigo);
                return parametrosDeReferencia;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }

        public List<ParametrosDeReferencia> ConsultarTodos()
        {
            try
            {
                connectionManager.Open();
                return parametrosDeReferenciaRepository.ConsultarTodos();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }

        public String Modificar(ParametrosDeReferencia parametrosDeReferenciaNuevo)
        {
            try
            {
                connectionManager.Open();
                parametrosDeReferenciaRepository.Modificar(parametrosDeReferenciaNuevo);
                return $" REGISTRO MODIFICADO CORECTAMENTE ";
            }
            catch (Exception)
            {
                return " !ERROR¡ MODIFICACION FALLIDA ";
            }
            finally
            {
                connectionManager.Close();
            }
            
        }

        public string Eliminar(string codigo)
        {
            try
            {
                connectionManager.Open();
                parametrosDeReferenciaRepository.Eliminar(codigo);
                return $" EL CODIGO [ {codigo} ], HA SIDO ELIMINADO CORECTAMENTE ";
            }
            catch (Exception)
            {
                return " !ERROR¡ ELIMINACION FALLIDA ";
            }
            finally
            {
                connectionManager.Close();
            }
            
        }

        public IList<ParametrosDeReferencia> BuscarFecha(int Mes, int Año)
        {
            try
            {
                connectionManager.Open();
                return parametrosDeReferenciaRepository.BuscarFecha(Mes,Año);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public double BuscarFechaContar(int Mes, int Año)
        {
            try
            {
                connectionManager.Open();
                return parametrosDeReferenciaRepository.BuscarFechaContar(Mes, Año);
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public IList<ParametrosDeReferencia> BuscarParametroReferencia(string CodigoParametroReferencia)
        {
            try
            {
                connectionManager.Open();
                return parametrosDeReferenciaRepository.BuscarParametroReferencia(CodigoParametroReferencia);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public double BuscarParametroReferenciaContar(string CodigoParametroReferencia)
        {
            try
            {
                connectionManager.Open();
                return parametrosDeReferenciaRepository.BuscarParametroReferenciaContar(CodigoParametroReferencia);
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public IList<ParametrosDeReferencia> BuscarProducto(string Producto)
        {
            try
            {
                connectionManager.Open();
                return parametrosDeReferenciaRepository.BuscarProducto(Producto);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public double BuscarProductoContar(string Producto)
        {
            try
            {
                connectionManager.Open();
                return parametrosDeReferenciaRepository.BuscarProductoContar(Producto);
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public IList<ParametrosDeReferencia> BuscarCodigoFichaTecnica(string CodigoFichaTecnica)
        {
            try
            {
                connectionManager.Open(); 
                return parametrosDeReferenciaRepository.BuscarCodigoFichaTecnica(CodigoFichaTecnica);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connectionManager.Close();
            }
           
        }
        public double BuscarCodigoFichaTecnicaContar(string CodigoFichaTecnica)
        {
            try
            {
                connectionManager.Open();
                return parametrosDeReferenciaRepository.BuscarCodigoFichaTecnicaContar(CodigoFichaTecnica);
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                connectionManager.Close();
            }
           
        }
        public IList<ParametrosDeReferencia> BuscarTodo()
        {
            try
            {
                connectionManager.Open();
                return parametrosDeReferenciaRepository.BuscarTodo();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public double BuscarTodoContar()
        {
            try
            {
                connectionManager.Open();
                return parametrosDeReferenciaRepository.BuscarTodoContar();
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }

    }
}
