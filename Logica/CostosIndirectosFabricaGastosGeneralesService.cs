using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Datos;

namespace Logica
{
    public class GuardarCostosIndirectosFabricaGastosGeneralesResponse 
    {
        public GuardarCostosIndirectosFabricaGastosGeneralesResponse (CostosIndirectosFabricaGastosGenerales  costosIndirectosFabricaGastosGenerales )
        {
            Error = false;
            CostosIndirectosFabricaGastosGenerales  = costosIndirectosFabricaGastosGenerales ;
        }
        public GuardarCostosIndirectosFabricaGastosGeneralesResponse (string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public CostosIndirectosFabricaGastosGenerales  CostosIndirectosFabricaGastosGenerales  { get; set; }
    }
    public class CostosIndirectosFabricaGastosGeneralesService
    {       
            private CostosIndirectosFabricaGastosGeneralesRepository costosIndirectosFabricacionRepository;
            private ConnectionManager conexion;
            public CostosIndirectosFabricaGastosGeneralesService(string cadenaConexion)
            {
                conexion = new ConnectionManager(cadenaConexion);
                costosIndirectosFabricacionRepository = new CostosIndirectosFabricaGastosGeneralesRepository(conexion);
            }

            public GuardarCostosIndirectosFabricaGastosGeneralesResponse  Guardar(CostosIndirectosFabricaGastosGenerales costosIndirectosFabricación)
            {
                try
                {
                    conexion.Open();
                    costosIndirectosFabricacionRepository.Guardar(costosIndirectosFabricación);
                    conexion.Close();
                    return new GuardarCostosIndirectosFabricaGastosGeneralesResponse(costosIndirectosFabricación);
                }
                catch (Exception e)
                {
                    return new GuardarCostosIndirectosFabricaGastosGeneralesResponse($"!ERROR¡ REGISTRO FALLIDO ,{e.Message}");
                }
                finally
                {
                    conexion.Close();
                }

            }

            public String Modificar(CostosIndirectosFabricaGastosGenerales costosIndirectosFabricación)
            {
                try
                {
                    conexion.Open();
                    costosIndirectosFabricacionRepository.Modificar(costosIndirectosFabricación);
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

            public string Eliminar(string codigoparametro, String subcodigo,int dia, int mes, int año)
            {
                try
                {
                    conexion.Open();
                    costosIndirectosFabricacionRepository.Eliminar(codigoparametro, subcodigo,dia, mes, año);
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
            public List<CostosIndirectosFabricaGastosGenerales> ConsultarTodos()
            {
                try
                {
                    conexion.Open();
                    return costosIndirectosFabricacionRepository.ConsultarTodos();
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

            public int ValidarSubcodigo(string subcodigo, string codigo)
            {
                try
                {
                    conexion.Open();
                    return costosIndirectosFabricacionRepository.ValidarSubcodigo(subcodigo, codigo);
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
            public int ValidarRegistro(int Mes, int Año, string SubCodigo)
            {
                try
                {
                    conexion.Open();
                    return costosIndirectosFabricacionRepository.ValidarRegistro(Mes, Año, SubCodigo);
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
            public double TotalGastosgenerales(int Mes, int Año)
            {
                try
                {
                    conexion.Open();
                    return costosIndirectosFabricacionRepository.TotalGastosgenerales(Mes, Año);
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
            public List<CostosIndirectosFabricaGastosGenerales> BuscarTodo()
            {
                try
                {
                    conexion.Open();
                    return costosIndirectosFabricacionRepository.BuscarTodo();
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
            public List<CostosIndirectosFabricaGastosGenerales> BuscarCodigo(string Codigo)
            {
                try
                {
                    conexion.Open();
                    return costosIndirectosFabricacionRepository.BuscarCodigo(Codigo);
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
            public List<CostosIndirectosFabricaGastosGenerales> BuscarSubCodigo(string SubCodigo)
            {
                try
                {
                    conexion.Open();
                    return costosIndirectosFabricacionRepository.BuscarSubCodigo(SubCodigo);
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
            public List<CostosIndirectosFabricaGastosGenerales> BuscarTipo(string Tipo)
            {
                try
                {
                    conexion.Open();
                    return costosIndirectosFabricacionRepository.BuscarTipo(Tipo);
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
            public IList<CostosIndirectosFabricaGastosGenerales> BuscarFecha(int Mes, int Año)
            {
                try
                {
                    conexion.Open();
                    return costosIndirectosFabricacionRepository.BuscarFecha(Mes, Año);
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
            public List<CostosIndirectosFabricaGastosGenerales> BuscarDatoCostoIndirectoMensuales(int mes, int año, string subcodigo, string codigo)
            {
                try
                {
                    conexion.Open();
                    return costosIndirectosFabricacionRepository.BuscarDatoCostoIndirectoMensuales(mes, año, subcodigo, codigo);
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
