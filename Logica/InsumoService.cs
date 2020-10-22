using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Datos;

namespace Logica
{
    public class GuardarInsumoResponse 
    {
        public GuardarInsumoResponse (Insumo insumo)
        {
            Error = false;
            Insumo = insumo;
        }
        public GuardarInsumoResponse (string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Insumo Insumo { get; set; }
    }
    public class InsumoService
    {
        InsumoRepository insumoRepository;
        private ConnectionManager conexion;
        public InsumoService(string cadenaConexion)
        {
            conexion = new ConnectionManager(cadenaConexion);
            insumoRepository = new InsumoRepository(conexion);
        }
        public  GuardarInsumoResponse Guardar(Insumo insumo)
        {
            try
            {
                conexion.Open();
                insumoRepository.Guardar(insumo);
                conexion.Close();
                return new GuardarInsumoResponse(insumo);
            }
            catch (Exception e)
            {
                return new GuardarInsumoResponse($"!ERROR¡ REGISTRO FALLIDO ,{e.Message}");
            }
            finally
            {
                conexion.Close();
            }
        }
        public String Modificar(Insumo insumo)
        {
            try
            {
                conexion.Open();
                insumoRepository.Modificar(insumo);
                return $" REGISTRO MODIFICADO CORECTAMENTE ";
            }
            catch (Exception e)
            {

                return $"Error, {e.Message}";
            }
            finally
            {
                conexion.Close();
            }

        }
        public string Eliminar(string codigoParametro, string subCodigo, string codigo)
        {
            try
            {
                conexion.Open();
                insumoRepository.Eliminar(codigoParametro, subCodigo, codigo);
                return $" EL DATO HA SIDO ELIMINADO CORECTAMENTE ";
            }
            catch (Exception e)
            {

                return $"Error, {e.Message}";
            }
            finally
            {
                conexion.Close();
            }

        }
        public IList<Insumo> Consultar()
        {
            try
            {
                conexion.Open();
                return insumoRepository.ConsultarTodo();
            }
            catch (Exception e)
            {

                return null;
            }
            finally
            {
                conexion.Close();
            }

        }
        public List<Insumo> ValidarDato(string codigoParametro)
        {
            try
            {
                conexion.Open();
                return insumoRepository.ValidarDato(codigoParametro);
            }
            catch (Exception e)
            {

                return null;
            }
            finally
            {
                conexion.Close();
            }

        }
        public double CalcularSubtotalInsumoCostoTotal(string codigoParametro)
        {
            try
            {
                conexion.Open();
                return insumoRepository.CalcularSubtotalInsumoCostoTotal(codigoParametro);
            }
            catch (Exception e)
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
                return insumoRepository.CalcularPorcentajeFinal(codigoParametro);
            }
            catch (Exception e)
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
                return insumoRepository.CalcularCostoFinal(codigoParametro);
            }
            catch (Exception e)
            {

                return 0;
            }
            finally
            {
                conexion.Close();
            }

        }
        public double CalcularSubTotalInsumoPorcentaje(string codigoParametro)
        {
            try
            {
                conexion.Open();
                return insumoRepository.CalcularSubTotalInsumoPorcentaje(codigoParametro);
            }
            catch (Exception e)
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
                return insumoRepository.ValidarSubcodigo(subcodigo, codigoParametro);
            }
            catch (Exception e)
            {

                return 0;
            }
            finally
            {
                conexion.Close();
            }

        }
        public List<Insumo> BuscarTodo()
        {
            try
            {
                conexion.Open();
                return insumoRepository.BuscarTodo();
            }
            catch (Exception e)
            {

                return null;
            }
            finally
            {
                conexion.Close();
            }

        }
        public List<Insumo> BuscarDato(string codigoParametro)
        {
            try
            {
                conexion.Open();
                return insumoRepository.BuscarDato(codigoParametro);
            }
            catch (Exception e)
            {

                return null;
            }
            finally
            {
                conexion.Close();
            }

        }
        public List<Insumo> BuscarDatoInsumo(string subcodigo, string codigoParametro)
        {
            try
            {
                conexion.Open();
                return insumoRepository.BuscarDatoInsumo(subcodigo, codigoParametro);
            }
            catch (Exception e)
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
                return insumoRepository.SumarCostoTotal(codigoParametro);
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
