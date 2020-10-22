using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Datos;

namespace Logica
{
    public class GuardarManoDeObraAnalisisResponse 
    {
        public GuardarManoDeObraAnalisisResponse (ManoDeObraAnalisis manoDeObraAnalisis)
        {
            Error = false;
            ManoDeObraAnalisis = manoDeObraAnalisis;
        }
        public GuardarManoDeObraAnalisisResponse (string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public ManoDeObraAnalisis ManoDeObraAnalisis { get; set; }
    }
    public class ManoDeObraAnalisisService
    {
        private ManoDeObraAnalisisRepository manoDeObraAnalisisRepository;
        private ConnectionManager connectionManager;
        public ManoDeObraAnalisisService(string CadenaConexion)
        {
            connectionManager = new ConnectionManager(CadenaConexion);
            manoDeObraAnalisisRepository = new ManoDeObraAnalisisRepository(connectionManager);
        }
        public GuardarManoDeObraAnalisisResponse  Guardar(ManoDeObraAnalisis manoDeObraAnalisis)
        {
            try
            {
                connectionManager.Open();
                manoDeObraAnalisisRepository.Guardar(manoDeObraAnalisis);
                connectionManager.Close();
                return new GuardarManoDeObraAnalisisResponse(manoDeObraAnalisis);
            }
            catch (Exception e)
            {
                return new GuardarManoDeObraAnalisisResponse ("!ERROR¡ REGISTRO FALLIDO ,"+e.Message);
            }
            finally
            {
                connectionManager.Close();
            }
        }
        public List<ManoDeObraAnalisis> ConsultarTodos()
        {
            try
            {
                connectionManager.Open();
                return manoDeObraAnalisisRepository.ConsultarTodos();
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
        public String Modificar(ManoDeObraAnalisis manoDeObraAnalisis)
        {
            try
            {
                connectionManager.Open();
                manoDeObraAnalisisRepository.Modificar(manoDeObraAnalisis);
                return $" REGISTRO MODIFICADO CORECTAMENTE ";
            }
            catch (Exception)
            {
                return " !ERROR¡ MODIFICACION FALLIDA";
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public IList<ManoDeObraAnalisis> BuscarDato(string Codigo, String Tipo)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraAnalisisRepository.BuscarDato(Codigo, Tipo);
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
        public string Eliminar(string codigoparametro, string tipo,string codigo)
        {
            try
            {
                connectionManager.Open(); 
                manoDeObraAnalisisRepository.Eliminar(codigoparametro, tipo,codigo);
                return $" EL DATO CON EL COGIDO 0 {codigoparametro} ],Y [{tipo}] HA SIDO ELIMINADO CORECTAMENTE ";
            }
            catch (Exception e)
            {
                return "!ERROR¡ ELIMINACION FALLIDA " + e.Message;
            }
            finally
            {
                connectionManager.Close();
            }
           
        }
        public double ValidarDato(string Codigo, String Tipo)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraAnalisisRepository.ValidarDato(Codigo, Tipo);
            }
            catch (Exception)
            {
                return 1;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public RespuestaTotal TotalCoto(string Codigo)
        {
            RespuestaTotal respuesta = new RespuestaTotal();
            try
            {

                connectionManager.Open();
                respuesta.Valor = manoDeObraAnalisisRepository.TotalCoto(Codigo);
                respuesta.Mensaje = "Consulto";

                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Mensaje = $"Se espopo esta mrd, {e.Message}";
                return respuesta;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public IList<ManoDeObraAnalisis> BuscarCodigoParametro(string CodigoParametro)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraAnalisisRepository.BuscarCodigoParametro(CodigoParametro);
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
        public IList<ManoDeObraAnalisis> BuscarTodo()
        {
            try
            {
                connectionManager.Open();
                return manoDeObraAnalisisRepository.BuscarTodo();
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
    public class RespuestaTotal
    {
        public string Mensaje { get; set; }
        public decimal Valor { get; set; }
    }

}
