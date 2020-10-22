using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Datos;

namespace Logica
{
    public class GuardarMaquilasYServicioResponse 
    {
        public GuardarMaquilasYServicioResponse (MaquilasYServicio maquilasYServicio)
        {
            Error = false;
            MaquilasYServicio = maquilasYServicio;
        }
        public GuardarMaquilasYServicioResponse (string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public MaquilasYServicio MaquilasYServicio { get; set; }
    }
    public class MaquilasServiciosService
    {
        MaquilasServiciosRepository maquilasServiciosRepository;
        private ConnectionManager conexion;
        public MaquilasServiciosService(string cadenaConexion)
        {
            conexion = new ConnectionManager(cadenaConexion);
            maquilasServiciosRepository = new MaquilasServiciosRepository(conexion);
        }
        public GuardarMaquilasYServicioResponse  Guardar(MaquilasYServicio maquilasYServicio)
        {
            try
            {
                conexion.Open();
                maquilasServiciosRepository.Guardar(maquilasYServicio);
                conexion.Close();
                return new GuardarMaquilasYServicioResponse (maquilasYServicio);
            }
            catch (Exception e)
            {
                return new GuardarMaquilasYServicioResponse ("!ERROR¡ REGISTRO FALLIDO ,"+e.Message);
            }
            finally
            {
                conexion.Close();
            }

        }
        public IList<MaquilasYServicio> Consultar()
        {
            try
            {
                conexion.Open();
                return maquilasServiciosRepository.ConsultarTodo();
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
        public String Modificar(MaquilasYServicio maquilasYServicio)
        {
            try
            {
                conexion.Open();
                maquilasServiciosRepository.Modificar(maquilasYServicio);
                return $" REGISTRO MODIFICADO CORECTAMENTE ";
            }
            catch (Exception e)
            {

                return $"Error,{e.Message} ";
            }
            finally
            {
                conexion.Close();
            }
        }

        public string Eliminar(string codigoparametro, string codigo, string subCodigo)
        {
            try
            {
                conexion.Open();
                maquilasServiciosRepository.Eliminar(codigoparametro, codigo, subCodigo);
                return $" EL DATO CON EL COGIDO 0 {codigoparametro} ],Y [{subCodigo}] HA SIDO ELIMINADO CORECTAMENTE ";
            }
            catch (Exception e)
            {

                return $"Error,{e.Message} ";
            }
            finally
            {
                conexion.Close();
            }

        }
        public List<MaquilasYServicio> ValidarDato(string codigoParametro)
        {
            try
            {
                conexion.Open();
                return maquilasServiciosRepository.ValidarDato(codigoParametro);
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
        public double CalcularSubtotalMaquilasYServicioCostoTotal(string codigoParametro)
        {
            try
            {
                conexion.Open();
                return maquilasServiciosRepository.CalcularSubtotalMaquilasYServicioCostoTotal(codigoParametro);
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
        public double CalcularPorcentajeFinal(string codigoParametro)
        {
            try
            {
                conexion.Open();
                return maquilasServiciosRepository.CalcularPorcentajeFinal(codigoParametro);
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
        public double CalcularCostoFinal(string codigoParametro)
        {
            try
            {
                conexion.Open();
                return maquilasServiciosRepository.CalcularCostoFinal(codigoParametro);
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
        public double CalcularSubTotalMaquilasYServicioPorcentaje(string codigoParametro)
        {
            try
            {
                conexion.Open();
                return maquilasServiciosRepository.CalcularSubTotalMaquilasYServicioPorcentaje(codigoParametro);
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
        public int ValidarSubcodigo(string subcodigo, string codigoParametro)
        {
            try
            {
                conexion.Open();
                return maquilasServiciosRepository.ValidarSubcodigo(subcodigo, codigoParametro);
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
        public List<MaquilasYServicio> BuscarTodo()
        {
            try
            {
                conexion.Open();
                return maquilasServiciosRepository.BuscarTodo();
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
        public List<MaquilasYServicio> BuscarDato(string codigoParametro)
        {
            try
            {
                conexion.Open();
                return maquilasServiciosRepository.BuscarDato(codigoParametro);
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
        public List<MaquilasYServicio> BuscarDatoMaquilas(string subcodigo, string codigoParametro)
        {
            try
            {
                conexion.Open();
                return maquilasServiciosRepository.BuscarDatoMaquilas(subcodigo, codigoParametro);
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
        public double SumarCostoTotal(string codigoParametro)
        {
            try
            {
                conexion.Open();
                return maquilasServiciosRepository.SumarCostoTotal(codigoParametro);
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

    }
}
