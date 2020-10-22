using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Datos;

namespace Logica
{
    public class GuardarManoDeObraResponse 
    {
        public GuardarManoDeObraResponse (ManoDeObra manoDeObra)
        {
            Error = false;
            ManoDeObra = manoDeObra;
        }
        public GuardarManoDeObraResponse (string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public ManoDeObra ManoDeObra { get; set; }
    }
    public class ManoDeObraService
    {

        private ManoDeObraRepository manoDeObraRepository;
        private ConnectionManager connectionManager;

        public ManoDeObraService(string cadenaConexion)
        {
            connectionManager = new ConnectionManager(cadenaConexion);
            manoDeObraRepository = new ManoDeObraRepository(connectionManager);
        }
        public GuardarManoDeObraResponse Guardar(ManoDeObra manoDeObra)
        {
            try
            {
                connectionManager.Open();
                manoDeObraRepository.Guardar(manoDeObra);
                connectionManager.Close();
                return new GuardarManoDeObraResponse (manoDeObra);
            }
            catch (Exception e)
            {
                return new GuardarManoDeObraResponse ("!ERROR¡ REGISTRO FALLIDO ,"+e.Message);
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public String Modificar(ManoDeObra manoDeObra )
        {
            try
            {
                connectionManager.Open();
                manoDeObraRepository.Modificar(manoDeObra);
                return $" REGISTRO MODIFICADO CORECTAMENTE ";
            }
            catch (Exception e)
            {
                return $" MODIFICACION FALLIDA " + e.Message;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }

        public string Eliminar(string codigoparametro, string codigo, string tipo)
        {
            try
            {
                connectionManager.Open();
                manoDeObraRepository.Eliminar(codigoparametro, codigo,tipo);
                return $" EL DATO CON EL COGIDO 0 {codigoparametro} ],Y [{codigo}] HA SIDO ELIMINADO CORECTAMENTE ";
            }
            catch (Exception e)
            {
                return $" ELIMINACION FALLIDO " + e.Message;
                
            }
            finally
            {
                connectionManager.Close();
            }
            
        }

        public List<ManoDeObra> ConsultarTodos()
        {
            try
            {
                connectionManager.Open();
                return manoDeObraRepository.ConsultarTodos();
            }
            catch (Exception e)
            {
                return null;
                
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public double TotalSalarioNetoMensualPorTipo(string Codigo, String Tipo)
        {
            try
            {
                connectionManager.Open(); 
                return manoDeObraRepository.TotalSalarioNetoMensualPorTipo(Codigo,Tipo);
            }
            catch (Exception e)
            {
                return 0;

            }
            finally
            {
                connectionManager.Close();
            }
           
        }
        public double TotalValorTotalPorTipo(string Codigo, String Tipo)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraRepository.TotalValorTotalPorTipo(Codigo, Tipo);
            }
            catch (Exception e)
            {
                return 0;

            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public double TotalSalarioNetoMensual(string Codigo)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraRepository.TotalSalarioNetoMensual(Codigo);
            }
            catch (Exception e)
            {
                return 0;

            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public double TotalValorTotal(string Codigo)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraRepository.TotalValorTotal(Codigo);
            }
            catch (Exception e)
            {
                return 0;

            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public double TotalPorcentajeTotal(string Codigo)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraRepository.TotalPorcentajeTotal(Codigo);
            }
            catch (Exception e)
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
                return manoDeObraRepository.ValidarDato(Codigo, Tipo);
            }
            catch (Exception e)
            {
                return 0;

            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public IList<ManoDeObra> BuscarCodigoParametro(string CodigoParametro)
        {
            try
            {
                connectionManager.Open(); 
                return manoDeObraRepository.BuscarCodigoParametro(CodigoParametro);
            }
            catch (Exception e)
            {
                return null;

            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public IList<ManoDeObra> BuscarCodigoManoObra(string CodigoManoObra)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraRepository.BuscarCodigoManoObra(CodigoManoObra);
            }
            catch (Exception e)
            {
                return null;

            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public IList<ManoDeObra> BuscarTodo()
        {
            try
            {
                connectionManager.Open();
                return manoDeObraRepository.BuscarTodo();
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public int BuscarDato(string Codigo, String Tipo)
        {
            try
            {
                connectionManager.Open();
                return manoDeObraRepository.BuscarDato(Codigo,Tipo);

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
