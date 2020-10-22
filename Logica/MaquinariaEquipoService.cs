using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Datos;

namespace Logica
{
    public class GuardarMaquinariaYEquipoResponse 
    {
        public GuardarMaquinariaYEquipoResponse (MaquinariaYEquipo maquinariaYEquipo)
        {
            Error = false;
            MaquinariaYEquipo = maquinariaYEquipo;
        }
        public GuardarMaquinariaYEquipoResponse (string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public MaquinariaYEquipo MaquinariaYEquipo { get; set; }
    }
    public class MaquinariaEquipoService
    {
        private MaquinariaEquipoRepository maquinariaEquipoRepository;
        private ConnectionManager conexion;
        public MaquinariaEquipoService(string cadenaConexion)
        {
            conexion = new ConnectionManager(cadenaConexion);
            maquinariaEquipoRepository = new MaquinariaEquipoRepository(conexion);
        }
        public GuardarMaquinariaYEquipoResponse  Guardar(MaquinariaYEquipo maquinariaYEquipo)
        {
            try
            {
                conexion.Open();
                maquinariaEquipoRepository.Guardar(maquinariaYEquipo);
                conexion.Close();
                return new GuardarMaquinariaYEquipoResponse(maquinariaYEquipo);
            }
            catch (Exception e)
            {
                return new GuardarMaquinariaYEquipoResponse("!ERROR¡ REGISTRO FALLIDO ,"+e.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
        public IList<MaquinariaYEquipo> Consultar()
        {
            try
            {
                conexion.Open();
                return maquinariaEquipoRepository.ConsultarTodo();
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
        public String Modificar(MaquinariaYEquipo maquinariaYEquipo)
        {
            try
            {
                conexion.Open();
                maquinariaEquipoRepository.Modificar(maquinariaYEquipo);

                return $" REGISTRO MODIFICADO CORECTAMENTE ";
            }
            catch (Exception e)
            {
                return $"Error,{e.Message}";
            }
            finally
            {
                conexion.Close();
            }

        }

        public string Eliminar(string codigoParametro, string codigo, string subcodigo)
        {
            try
            {
                conexion.Open();
                maquinariaEquipoRepository.Eliminar(codigoParametro, codigo, subcodigo);
                return $" EL CODIGO [ {codigoParametro} ], Y EL SUBCODIGO [{subcodigo}] HA SIDO ELIMINADO CORECTAMENTE ";
            }
            catch (Exception e)
            {
                return $"Error,{e.Message}";
            }
            finally
            {
                conexion.Close();
            }

        }
        public List<MaquinariaYEquipo> ValidarDato(string codigoParametro)
        {
            try
            {
                conexion.Open();
                return maquinariaEquipoRepository.ValidarDato(codigoParametro);
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
        public double CalcularSubtotalMaquinariaYEquipoCostoTotal(string codigoParametro)
        {
            try
            {
                conexion.Open();
                return maquinariaEquipoRepository.CalcularSubtotalMaquinariaYEquipoCostoTotal(codigoParametro);
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
                return maquinariaEquipoRepository.CalcularPorcentajeFinal(codigoParametro);
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
                return maquinariaEquipoRepository.CalcularCostoFinal(codigoParametro);
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
        public double CalcularSubTotalMaquinariaYEquipoPorcentaje(string codigoParametro)
        {
            try
            {
                conexion.Open();
                return maquinariaEquipoRepository.CalcularSubTotalMaquinariaYEquipoPorcentaje(codigoParametro);
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
                return maquinariaEquipoRepository.ValidarSubcodigo(subcodigo, codigoParametro);
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
        public List<MaquinariaYEquipo> BuscarTodo()
        {
            try
            {
                conexion.Open();
                return maquinariaEquipoRepository.BuscarTodo();
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
        public List<MaquinariaYEquipo> BuscarDato(string codigoParametro)
        {
            try
            {
                conexion.Open();
                return maquinariaEquipoRepository.BuscarDato(codigoParametro);
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
        public List<MaquinariaYEquipo> BuscarDatoMaquinaria(string subcodigo, string codigoParametro)
        {
            try
            {
                conexion.Open();
                return maquinariaEquipoRepository.BuscarDatoMaquinaria(subcodigo, codigoParametro);
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
                return maquinariaEquipoRepository.SumarCostoTotal(codigoParametro);
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
