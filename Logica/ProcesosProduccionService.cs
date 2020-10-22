using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Datos;

namespace Logica
{
    public class GuardarProcesosProduccionResponse 
    {
        public GuardarProcesosProduccionResponse (ProcesosProduccion procesosProduccion)
        {
            Error = false;
            ProcesosProduccion = procesosProduccion;
        }
        public GuardarProcesosProduccionResponse (string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public ProcesosProduccion ProcesosProduccion { get; set; }
    }
    public class ProcesosProduccionService
    {

        private ProcesosProduccionRepository procesosProduccionRepository;
        private ConnectionManager conexion;
        public ProcesosProduccionService(string cadenaConexion)
        {
            conexion = new ConnectionManager(cadenaConexion);
            procesosProduccionRepository = new ProcesosProduccionRepository(conexion);
        }
        public GuardarProcesosProduccionResponse Guardar(ProcesosProduccion procesosProduccion)
        {
            try
            {
                conexion.Open();
                procesosProduccionRepository.Guardar(procesosProduccion);
                conexion.Close();
                return new GuardarProcesosProduccionResponse (procesosProduccion);
            }
            catch (Exception e)
            {
                return new GuardarProcesosProduccionResponse ($"!ERROR¡ REGISTRO FALLIDO ,"+e.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
        public String Modificar(ProcesosProduccion procesosProduccion)
        {
            try
            {
                conexion.Open();
                procesosProduccionRepository.Modificar(procesosProduccion);
                return $" REGISTRO MODIFICADO CORECTAMENTE ";
            }
            catch (Exception e)
            {

                return $"MODIFICACION FALLIDA{e.Message}";
            }
            finally
            {
                conexion.Close();
            }

        }

        public string Eliminar(string codigoParametro, string Tipo)
        {
            try
            {
                conexion.Open();
                procesosProduccionRepository.Eliminar(codigoParametro,Tipo);
                return $" REGISTRO ELIMINADO CORRECTAMENTE";
            }
            catch (Exception e)
            {
                return $" !ERROR¡ ELIMINACION FALLIDA, [ {e.Message} ]";
            }
            finally
            {
                conexion.Close();
            }

        }
        public int ValidarDato(string CodigoParametro, string Tipo)
        {
            try
            {
                conexion.Open();
                return procesosProduccionRepository.ValidarDato(CodigoParametro, Tipo);
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                conexion.Close();
            }


        }
        public int TraerDato(string CodigoParametro)
        {
            try
            {
                conexion.Open();
                return procesosProduccionRepository.TraerDato(CodigoParametro);
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                conexion.Close();
            }

        }
        public List<ProcesosProduccion> LlenarDato(string CodigoParametro)
        {
            try
            {
                conexion.Open();
                return procesosProduccionRepository.LlenarDato(CodigoParametro);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }


        }
        public List<ProcesosProduccion> LlenarCategoria(string CodigoParametro)
        {
            try
            {
                conexion.Open();
                return procesosProduccionRepository.LlenarCategoria(CodigoParametro);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }

        }
        public List<ProcesosProduccion> CantidadOperarios(string CodigoParametro, string Tipo)
        {
            try
            {
                conexion.Open();
                return procesosProduccionRepository.CantidadOperarios(CodigoParametro, Tipo);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }

        }
        public List<ProcesosProduccion> ConsultarTodos()
        {
            try
            {
                conexion.Open();
                return procesosProduccionRepository.ConsultarTodos();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }

        }
        public List<ProcesosProduccion> ConsultarParametro(string CodigoParametro)
        {
            try
            {
                conexion.Open();
                return procesosProduccionRepository.ConsultarParametro(CodigoParametro);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }


        }
    }
}
