using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Datos;

namespace Logica
{
    public class GuardarCosteoGeneralResponse 
    {
        public GuardarCosteoGeneralResponse (CosteoGeneral costeoGeneral)
        {
            Error = false;
            CosteoGeneral = costeoGeneral;
        }
        public GuardarCosteoGeneralResponse (string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public CosteoGeneral CosteoGeneral { get; set; }
    }
    public class CosteoGeneralService
    {
        private CosteoGeneralRepository costeoGeneralRepository;
        private ConnectionManager connectionManager;
        public CosteoGeneralService(string CadenaConexion)
        {
            connectionManager = new ConnectionManager(CadenaConexion);
            costeoGeneralRepository = new CosteoGeneralRepository(connectionManager);
        }
        public GuardarCosteoGeneralResponse Guardar(CosteoGeneral costeoGeneral)
        {
            try
            {
                connectionManager.Open();
                costeoGeneralRepository.Guardar(costeoGeneral);
                connectionManager.Close();

                return new GuardarCosteoGeneralResponse(costeoGeneral);
            }
            catch (Exception e)
            {
                return new GuardarCosteoGeneralResponse("!ERROR¡ REGISTRO FALLIDO "+e.Message);
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public String Modificar(CosteoGeneral costeoGeneral)
        {
            try
            {
                connectionManager.Open();
                costeoGeneralRepository.Modificar(costeoGeneral);
                return $" REGISTRO MODIFICADO CORECTAMENTE ";
            }
            catch (Exception e)
            {
                return "!ERROR¡ MODIFICACION FALLIDA "+e.Message;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }

        public string Eliminar(string codigoparametro)
        {
            try
            {
                connectionManager.Open();
                costeoGeneralRepository.Eliminar(codigoparametro);
                return $" EL DATO CON EL COGIDO {codigoparametro} ] HA SIDO ELIMINADO CORECTAMENTE ";
            }
            catch (Exception e)
            {
                return "!ERROR¡ ELIMINACION FALLIDA "+e.Message;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public RespuestaConsultar Consultar()
        {
            RespuestaConsultar respuesta = new RespuestaConsultar();
            try
            {
                connectionManager.Open();
                respuesta.Lista = costeoGeneralRepository.ConsultarTodos();
                respuesta.Mensaje = "Consultado correctamente";
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Lista = null;
                respuesta.Mensaje = $"Se toteo esta mrd,{e.Message}";
                return respuesta;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public double Contar(string codigo)
        {
            try
            {
                connectionManager.Open();
                return costeoGeneralRepository.Contar(codigo);
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
        public double ContarCosteo(string codigo)
        {
            try
            {
                connectionManager.Open();
                return costeoGeneralRepository.ContarCosteo(codigo);
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
        public RespuestaConsultar ConsultarTodo()
        {
            RespuestaConsultar respuesta = new RespuestaConsultar();
            try
            {
                connectionManager.Open();
                respuesta.Lista = costeoGeneralRepository.ConsultarTodo();
                respuesta.Mensaje = "Consultado correctamente";
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Lista = null;
                respuesta.Mensaje = $"Se toteo esta mrd,{e.Message}";
                return respuesta;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public List<CosteoGeneral> ConsultarCodigo(string filtro)
        {
            try
            {
                connectionManager.Open(); 
                return costeoGeneralRepository.ConsultarCodigo(filtro);
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
        public List<CosteoGeneral> ConsultaIndividual(string codigo)
        {
            try
            {
                connectionManager.Open();
                return costeoGeneralRepository.ConsultaIndividual(codigo);
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

    }
    public class RespuestaConsultar
    {
        public IList<CosteoGeneral> Lista { get; set; }
        public string Mensaje { get; set; }
    }

}
