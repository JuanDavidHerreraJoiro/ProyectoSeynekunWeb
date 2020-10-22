using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Datos;

namespace Logica
{
    public class GuardarMargenDeContribucionResponse 
    {
        public GuardarMargenDeContribucionResponse (MargenDeContribucion margenDeContribucion)
        {
            Error = false;
            MargenDeContribucion = margenDeContribucion;
        }
        public GuardarMargenDeContribucionResponse (string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public MargenDeContribucion MargenDeContribucion { get; set; }
    }
    public class MargenContribucionService
    {
        private MargenContribucionRepository margenContribucionRepository;
        private ConnectionManager conexion;
        public MargenContribucionService(string cadenaConexion)
        {
            conexion = new ConnectionManager(cadenaConexion);
            margenContribucionRepository = new MargenContribucionRepository(conexion);
        }

        public GuardarMargenDeContribucionResponse Guardar(MargenDeContribucion margenDeContribucion)
        {
            try
            {
                conexion.Open();
                margenContribucionRepository.Guardar(margenDeContribucion);
                conexion.Close();
                return new GuardarMargenDeContribucionResponse(margenDeContribucion);
            }
            catch (Exception e)
            {
                return new GuardarMargenDeContribucionResponse("!ERROR¡ REGISTRO FALLIDO ,"+e.Message);
            }
            finally
            {
                conexion.Close();
            }

        }
        public String Modificar(MargenDeContribucion margenDeContribucion)
        {
            try
            {
                conexion.Open();
                margenContribucionRepository.Modificar(margenDeContribucion);
                return $" REGISTRO MODIFICADO CORECTAMENTE ";
            }
            catch (Exception)
            {
                return "!ERROR¡ MODIFICACION FALLIDA ";
            }
            finally
            {
                conexion.Close();
            }
            
        }

        public string Eliminar(string codigo)
        {
            try
            {
                conexion.Open();
                margenContribucionRepository.Eliminar(codigo);
                return $" EL CODIGO [ {codigo} ], HA SIDO ELIMINADO CORECTAMENTE ";
            }
            catch (Exception)
            {
                return "!ERROR¡ ELIMINACION FALLIDA ";
            }
            finally
            {
                conexion.Close();
            }
            
        }
        public List<MargenDeContribucion> ConsultarTodos()
        {
            try
            {
                conexion.Open();
                return margenContribucionRepository.ConsultarTodos();
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
        public double ValidarRepetido(string codigo)
        {
            try
            {
                conexion.Open();
                return margenContribucionRepository.ValidarRepetido(codigo);
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
        public RespuestaConsulta BuscarTodo()
        {
            RespuestaConsulta respuesta = new RespuestaConsulta();
            try
            {
                conexion.Open();
                respuesta.Lista = margenContribucionRepository.BuscarTodo();
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
                conexion.Close();
            }
        }
        public IList<MargenDeContribucion> BuscarCodigoParametro(string CodigoParametro)
        {
            try
            {
                conexion.Open();
                return margenContribucionRepository.BuscarCodigoParametro(CodigoParametro);
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
        public IList<MargenDeContribucion> DatoRepetido(string codigo)
        {
            try
            {
                conexion.Open();
                return margenContribucionRepository.DatoRepetido(codigo);
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
    public class RespuestaConsulta
    {
        public IList<MargenDeContribucion> Lista { get; set; }
        public string Mensaje { get; set; }
    }
}
