using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Datos;

namespace Logica
{
    public class GuardarCostosYGastosMensualesResponse 
    {
        public GuardarCostosYGastosMensualesResponse (CostosYGastosMensuales costosYGastosMensuales)
        {
            Error = false;
            CostosYGastosMensuales = costosYGastosMensuales;
        }
        public GuardarCostosYGastosMensualesResponse (string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public CostosYGastosMensuales CostosYGastosMensuales { get; set; }
    }
    public class CostosYGastosMensualesService
    {
        private CostosYGastosMensualesRepository costosYGastosMensualesRepository;
        private ConnectionManager conexion;
        public CostosYGastosMensualesService(string cadenaConexion)
        {
            conexion = new ConnectionManager(cadenaConexion);
            costosYGastosMensualesRepository = new CostosYGastosMensualesRepository(conexion);
        }
        public GuardarCostosYGastosMensualesResponse Guardar(CostosYGastosMensuales costosYGastosMensuales)
        {
            try
            {
                conexion.Open();
                costosYGastosMensualesRepository.Guardar(costosYGastosMensuales);
                conexion.Close();
                return new GuardarCostosYGastosMensualesResponse(costosYGastosMensuales);
            }
            catch (Exception e)
            {
                return new GuardarCostosYGastosMensualesResponse($"!ERROR¡ REGISTRO FALLIDO , {e.Message}");
            }
            finally
            {
                conexion.Close();
            }

        }
        public List<CostosYGastosMensuales> ConsultarTodos()
        {
            try
            {
                conexion.Open();
                return costosYGastosMensualesRepository.ConsultarTodos();
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
        public String Modificar(CostosYGastosMensuales costosYGastosMensuales)
        {
            try
            {
                conexion.Open();
                costosYGastosMensualesRepository.Modificar(costosYGastosMensuales);
                return $" REGISTRO MODIFICADO CORECTAMENTE ";
            }
            catch (Exception e)
            {

                return $"!ERROR¡ MODIFICACION FALLIDA, {e.Message}";
            }
            finally
            {
                conexion.Close();
            }

        }

        public string Eliminar(string codigo, String subcodigo)
        {
            try
            {
                conexion.Open();
                costosYGastosMensualesRepository.Eliminar(codigo, subcodigo);
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
        public int ValidarSubcodigo(string subcodigo, string codigo)
        {
            try
            {
                conexion.Open();
                return costosYGastosMensualesRepository.ValidarSubcodigo(subcodigo, codigo);
            }
            catch (Exception)
            {

                return 1;
            }
            finally
            {
                conexion.Close();
            }

        }

        public List<CostosYGastosMensuales> LlenarCombo(string codigo)
        {
            try
            {
                conexion.Open();
                return costosYGastosMensualesRepository.LlenarCombo(codigo);
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
        public List<CostosYGastosMensuales> BuscarTodo()
        {
            try
            {
                conexion.Open();
                return costosYGastosMensualesRepository.BuscarTodo();
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
        public List<CostosYGastosMensuales> BuscarCodigo(string Codigo)
        {
            try
            {
                conexion.Open();
                return costosYGastosMensualesRepository.BuscarCodigo(Codigo);
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
        public List<CostosYGastosMensuales> BuscarSubCodigo(string SubCodigo)
        {
            try
            {
                conexion.Open();
                return costosYGastosMensualesRepository.BuscarSubCodigo(SubCodigo);
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
        public List<CostosYGastosMensuales> BuscarTipo(string Tipo)
        {
            try
            {
                conexion.Open();
                return costosYGastosMensualesRepository.BuscarTipo(Tipo);
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

        public List<CostosYGastosMensuales> BuscarDatosMensuales(string codigo, string SubCodigo)
        {
            try
            {
                conexion.Open();
                return costosYGastosMensualesRepository.BuscarDatosMensuales(codigo, SubCodigo);
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
