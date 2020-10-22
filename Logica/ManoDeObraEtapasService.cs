using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Datos;

namespace Logica
{
    public class GuardarManoDeObraEtapasResponse 
    {
        public GuardarManoDeObraEtapasResponse (ManoDeObraEtapas manoDeObraEtapas)
        {
            Error = false;
            ManoDeObraEtapas = manoDeObraEtapas;
        }
        public GuardarManoDeObraEtapasResponse (string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public ManoDeObraEtapas ManoDeObraEtapas { get; set; }
    }
    public class ManoDeObraEtapasService
    {
        private ManoDeObraEtapasRepository manoDeObraEtapasRepository;
        private ConnectionManager connectionManager;

        public ManoDeObraEtapasService(string cadenaConexion)
        {
            connectionManager = new ConnectionManager(cadenaConexion);
            manoDeObraEtapasRepository = new ManoDeObraEtapasRepository(connectionManager);
        }
        public GuardarManoDeObraEtapasResponse Guardar(ManoDeObraEtapas manoDeObraEtapas)
        {
            try
            {
                connectionManager.Open();
                manoDeObraEtapasRepository.Guardar(manoDeObraEtapas);
                connectionManager.Close();
                return new GuardarManoDeObraEtapasResponse(manoDeObraEtapas);
            }
            catch (Exception e)
            {
                return new GuardarManoDeObraEtapasResponse("!ERROR¡ REGISTRO FALLIDO ,"+e.Message);
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public List<ManoDeObraEtapas> ConsultarTodos()
        {
            try
            {
                connectionManager.Open();
                return manoDeObraEtapasRepository.ConsultarTodos();
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

        public String Modificar(ManoDeObraEtapas manoDeObraEtapas)
        {
            try
            {
                connectionManager.Open();
                manoDeObraEtapasRepository.Modificar(manoDeObraEtapas);
                return $" REGISTRO MODIFICADO CORECTAMENTE ";
            }
            catch (Exception e)
            {
                return " !ERROR¡  MODIFICACION FALLIDA " + e.Message;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }

        public string Eliminar(string codigoParametro, string tipo, string codigoEtapas)
        {
            try
            {
                connectionManager.Open(); 
                manoDeObraEtapasRepository.Eliminar(codigoParametro,tipo, codigoEtapas);
                return $" EL DATO CON EL COGIDO 0 {codigoParametro} ],Y [{tipo}] HA SIDO ELIMINADO CORECTAMENTE ";
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

        public List<ManoDeObraEtapas> Dato(string Codigo, String Tipo)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraEtapasRepository.Dato(Codigo, Tipo);
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
        public double TotalNumeroEmpleados(string CodigoParametro)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraEtapasRepository.TotalNumeroEmpleados(CodigoParametro);
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
        public double TotalDiasHabilesAño(string CodigoParametro)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraEtapasRepository.TotalDiasHabilesAño(CodigoParametro);
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
        public double TotalDiasHabilesMes(string CodigoParametro)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraEtapasRepository.TotalDiasHabilesMes(CodigoParametro);
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
        public double TotalHorasDiaProductivas(string CodigoParametro)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraEtapasRepository.TotalHorasDiaProductivas(CodigoParametro);
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
        public double TotalHorasTrabajoEfectivos(string CodigoParametro)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraEtapasRepository.TotalHorasTrabajoEfectivos(CodigoParametro);
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
        public double TotalTotalHoraMes(string CodigoParametro)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraEtapasRepository.TotalTotalHoraMes(CodigoParametro);
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
        public double TotalCostoHora(string CodigoParametro)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraEtapasRepository.TotalCostoHora(CodigoParametro);
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
        public double TotalCostoMinuto(string CodigoParametro)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraEtapasRepository.TotalCostoMinuto(CodigoParametro);
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
        public double ValidarDato(string Codigo, String Tipo)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraEtapasRepository.ValidarDato(Codigo,Tipo);
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
        public IList<ManoDeObraEtapas> BuscarCodigoParametro(string CodigoParametro)
        {
            try
            {
                connectionManager.Open(); 
                return manoDeObraEtapasRepository.BuscarCodigoParametro(CodigoParametro);
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
        public IList<ManoDeObraEtapas> BuscarTodo()
        {
            try
            {
                connectionManager.Open();
                return manoDeObraEtapasRepository.BuscarTodo();
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
}
