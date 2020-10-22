using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Datos;
//using Infraestructura;
using System.Data;

namespace Logica
{
    public class GuardarTRMResponse 
    {
        public GuardarTRMResponse (TRM tRM)
        {
            Error = false;
            TRM = tRM;
        }
        public GuardarTRMResponse (string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public TRM TRM { get; set; }
    }
    public class TRMService
    {
        private TRMRepository trmRepository;
        private ConnectionManager connectionManager;
        public TRMService(string CadenaConexion)
        {
            connectionManager = new ConnectionManager(CadenaConexion);
            trmRepository = new TRMRepository(connectionManager);
        }
        public GuardarTRMResponse  Guardar(TRM trm)
        {
            try
            {
                connectionManager.Open();
                trmRepository.Guardar(trm);
                connectionManager.Close();
                return new GuardarTRMResponse (trm);
            }
            catch (Exception e)
            {
                return new GuardarTRMResponse ("!ERROR¡ REGISTRO FALLIDO ,"+e.Message);
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
/*
        public DataView ImportarArchivoExcel(string rutaExcel)
        {
            try
            {
                DocumentoExcel documentoExcel = new DocumentoExcel();
                return documentoExcel.ImportarArchivoExcel(rutaExcel);
            }
            catch (Exception)
            {
                return null;
            }
        }*/
        public String Modificar(TRM trm)
        {
            try
            {
                connectionManager.Open();
                trmRepository.Modificar(trm);
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

        public string Eliminar(DateTime fecha)
        {
            try
            {
                connectionManager.Open();
                trmRepository.Eliminar(fecha);
                return $" EL TRM CON LA FECHA [ {fecha} ], HA SIDO ELIMINADO CORECTAMENTE ";
            }
            catch (Exception)
            {
                return "!ERROR¡ ELIMINACION FALLIDA";
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public IList<TRM> ConsultarTodos()
        {
            try
            {
                connectionManager.Open();
                return trmRepository.ConsultarTodos();
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
        public IList<TRM> BuscarTRM()
        {
            try
            {
                connectionManager.Open();
                return trmRepository.BuscarTRM();
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
        public IList<TRM> BuscarFecha(int Mes, int Año)
        {
            try
            {
                connectionManager.Open();
                return trmRepository.BuscarFecha(Mes,Año);
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
        public double ContarTRM()
        {
            try
            {
                connectionManager.Open();
                return trmRepository.ContarTRM();
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
        public Decimal SumarTRM()
        {
            try
            {
                connectionManager.Open();
                return trmRepository.SumarTRM();
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
        public Decimal UltimoValor()
        {
            try
            {
                connectionManager.Open();
                return trmRepository.UltimoValor();
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
        public IList<TRM> BuscarDatoFecha(int Dia, int Mes, int Año)
        {
            try
            {
                connectionManager.Open();
                return trmRepository.BuscarDatoFecha(Dia,Mes,Año);
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
        public int ContarDatoFecha(int Dia, int Mes, int Año)
        {

            try
            {
                connectionManager.Open();
                return trmRepository.ContarDatoFecha(Dia, Mes, Año);
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
