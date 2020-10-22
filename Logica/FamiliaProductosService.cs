using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Datos;

namespace Logica
{
    public class GuardarFamiliaProductosResponse 
    {
        public GuardarFamiliaProductosResponse (FamiliaProductos familiaProductos)
        {
            Error = false;
            FamiliaProductos = familiaProductos;
        }
        public GuardarFamiliaProductosResponse (string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public FamiliaProductos FamiliaProductos { get; set; }
    }
    public class FamiliaProductosService
    {
        private FamiliaProductosRepository familiaProductosRepository;
        private ConnectionManager conexion;
        public FamiliaProductosService(string cadenaConexion)
        {
            conexion = new ConnectionManager(cadenaConexion);
            familiaProductosRepository = new FamiliaProductosRepository(conexion);
        }
        public GuardarFamiliaProductosResponse  Guardar(FamiliaProductos familiaProducto)
        {
            try
            {
                conexion.Open();
                familiaProductosRepository.Guardar(familiaProducto);
                conexion.Close();
                return new GuardarFamiliaProductosResponse (familiaProducto);
            }
            catch (Exception e)
            {
                return new GuardarFamiliaProductosResponse ($"!ERROR¡ REGISTRO FALLIDO ,{e.Message}");
            }
            finally
            {
                conexion.Close();
            }

        }
        public List<FamiliaProductos> ConsultarTodos()
        {
            try
            {
                conexion.Open();
                return familiaProductosRepository.ConsultarTodos();
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
        public String Modificar(FamiliaProductos familiaProducto)
        {
            try
            {
                conexion.Open();
                familiaProductosRepository.Modificar(familiaProducto);
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

        public string Eliminar(int codigoparametro)
        {
            try
            {
                conexion.Open();
                familiaProductosRepository.Eliminar(codigoparametro);
                return $" EL DATO CON EL COGIDO 0 {codigoparametro} ] HA SIDO ELIMINADO CORECTAMENTE ";
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
        public List<FamiliaProductos> ConsultaIndividual(string Codigo)
        {
            try
            {
                conexion.Open();
                return familiaProductosRepository.ConsultaIndividual(Codigo);
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
        public double TotalSumaUnidadesVendidasMes(string Codigo)
        {
            try
            {
                conexion.Open();
                return familiaProductosRepository.TotalSumaUnidadesVendidasMes(Codigo);
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
        public double TotalSumaVolumenVentas(string Codigo)
        {
            try
            {
                conexion.Open();
                return familiaProductosRepository.TotalSumaVolumenVentas(Codigo);
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
        public double TotalSumaPorcentajeUnidadVendidas(string Codigo)
        {
            try
            {
                conexion.Open();
                return familiaProductosRepository.TotalSumaPorcentajeUnidadVendidas(Codigo);
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
        public double TotalSumaPorcentajeVolumenVentas(string Codigo)
        {
            try
            {
                conexion.Open();
                return familiaProductosRepository.TotalSumaPorcentajeVolumenVentas(Codigo);
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
        public double TotalSumaPorcentajeUnidadVolumen(string Codigo)
        {
            try
            {
                conexion.Open();
                return familiaProductosRepository.TotalSumaPorcentajeUnidadVolumen(Codigo);
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
        public double TotalSumaCostosYGastosFamilia(string Codigo)
        {
            try
            {
                conexion.Open();
                return familiaProductosRepository.TotalSumaCostosYGastosFamilia(Codigo);
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
        public double TotalSumaGastoAsignable(string Codigo)
        {
            try
            {
                conexion.Open();
                return familiaProductosRepository.TotalSumaGastoAsignable(Codigo);
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
        public List<FamiliaProductos> BuscarTodo()
        {
            try
            {
                conexion.Open();
                return familiaProductosRepository.BuscarTodo();
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
        public List<FamiliaProductos> BuscarCodigoPK(int CodigoPk)
        {
            try
            {
                conexion.Open();
                return familiaProductosRepository.BuscarCodigoPK(CodigoPk);
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
