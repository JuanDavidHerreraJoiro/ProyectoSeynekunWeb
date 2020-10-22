using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Datos;

namespace Logica
{
    public class GuardarMateriaPrimaResponse 
    {
        public GuardarMateriaPrimaResponse (MateriaPrima materiaPrima)
        {
            Error = false;
           MateriaPrima = materiaPrima;
        }
        public GuardarMateriaPrimaResponse (string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public MateriaPrima MateriaPrima { get; set; }
    }
    public class MateriaPrimaService
    {
        private MateriaPrimaRepository materiaPrimaRepository;
        private ConnectionManager connectionManager;
         
        public MateriaPrimaService(string CadenaConexion)
        {
            connectionManager = new ConnectionManager(CadenaConexion);
            materiaPrimaRepository = new MateriaPrimaRepository(connectionManager);
        }

        public GuardarMateriaPrimaResponse Guardar(MateriaPrima materiaPrima)
        {
            try
            {
                connectionManager.Open();
                materiaPrimaRepository.Guardar(materiaPrima);
                connectionManager.Close();
                return new GuardarMateriaPrimaResponse (materiaPrima);
            }
            catch (Exception e)
            {
                return new GuardarMateriaPrimaResponse("!ERROR¡ REGISTRO FALLIDO ,"+e.Message);
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public bool BuscarImportados(string subcodigo, string codigoParametro)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarImportados(subcodigo, codigoParametro);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public bool BuscarNacionales(string subcodigo, string codigoParametro)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarNacionales(subcodigo, codigoParametro);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connectionManager.Close();
            }
            
        }

        public List<MateriaPrima> BuscarDatosSubcodigo(string subcodigo)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarDatosSubcodigo(subcodigo);
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
        public List<MateriaPrima> BuscarDatosCodigoParametro(string subcodigo)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarDatosCodigoParametro(subcodigo);
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
        public List<MateriaPrima> BuscarLista(string codigoParametro, string codigoMateria)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarLista(codigoParametro, codigoMateria);
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
        public MateriaPrima BuscarMateriaPrima(string codigoParametro/*, string codigoMateria*/)
        {
            try
            {
                connectionManager.Open();
                MateriaPrima materiaPrima = materiaPrimaRepository.BuscarMateriaPrima(codigoParametro/*, codigoMateria*/);
                return materiaPrima;
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
        public MateriaPrima Consultar(string subcodigo)
        {
            try
            {
                connectionManager.Open();
                MateriaPrima materiaPrima = materiaPrimaRepository.Consultar(subcodigo);
                return materiaPrima;
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

        public List<MateriaPrima> ConsultarTodos()
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.ConsultarTodos();
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

        public String Modificar(MateriaPrima materiaPrimaNueva)
        {
            try
            {
                connectionManager.Open();materiaPrimaRepository.Modificar(materiaPrimaNueva);
                return $" REGISTRO MODIFICADO CORECTAMENTE ";
            }
            catch (Exception)
            {
                return " !ERROR¡ MODIFICACION FALLIDA ";
            }
            finally
            {
                connectionManager.Close();
            }
            
        }

        public string Eliminar(string Codigo, string SubCodigo, string CodigoParametro)
        {
            try
            {
                connectionManager.Open();
                materiaPrimaRepository.Eliminar(Codigo,SubCodigo,CodigoParametro);
                return $" EL REGISTRO HA SIDO ELIMINADO CORECTAMENTE ";
            }
            catch (Exception)
            {
                return " !ERROR¡ ELIMINACION FALLIDA ";
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        //Sentencia

        public double BuscarDato(string CodigoParametro, string SubCodigo, string CodigoMateriaPrima)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarDato(CodigoParametro,SubCodigo,CodigoMateriaPrima);
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
        public IList<MateriaPrima> ListaDato(string CodigoParametro, string SubCodigo, string CodigoMateriaPrima)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.ListaDato(CodigoParametro, SubCodigo, CodigoMateriaPrima);
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
        public IList<MateriaPrima> LlenarCostoNacional(double CostoTotal)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.LlenarCostoNacional(CostoTotal);
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
        public IList<MateriaPrima> LlenarCostoImportada(double CostoTotal)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.LlenarCostoImportada(CostoTotal);
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
        public double BuscarSubcostoTotalNacional(double CostoTotal)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarSubcostoTotalNacional(CostoTotal);
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
        public double BuscarSubcostoTotalImportada(double CostoTotal)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarSubcostoTotalImportada(CostoTotal);
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
        public double BuscarSubporcentajeNacional(double CostoTotal)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarSubporcentajeNacional(CostoTotal);
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
        public double BuscarSubporcentajeImportada(double CostoTotal)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarSubporcentajeImportada(CostoTotal);
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
        //
        public IList<MateriaPrima> LlenarCodigoNacional(string CodigoParametros)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.LlenarCodigoNacional(CodigoParametros);
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
        public IList<MateriaPrima> LlenarCodigoImportada(string CodigoParametros)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.LlenarCodigoImportada(CodigoParametros);
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
        public double BuscarCodigoCostoTotalNacional(string CodigoParametros)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarCodigoCostoTotalNacional(CodigoParametros);
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
        public double BuscarCodigoCostoTotalImportada(string CodigoParametros)
        {
            try
            {
                connectionManager.Open(); 
                return materiaPrimaRepository.BuscarCodigoCostoTotalImportada(CodigoParametros);
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
        public double BuscarCodigoPorcentajeNacional(string CodigoParametros)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarCodigoPorcentajeNacional(CodigoParametros);
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
        public double BuscarCodigoPorcentajeImportada(string CodigoParametros)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarCodigoPorcentajeImportada(CodigoParametros);
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
        //
        public IList<MateriaPrima> BuscarTodoNacional()
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarTodoNacional();
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
        public IList<MateriaPrima> BuscarTodoImportada()
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarTodoImportada();
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
        public double BuscarTodoCodigoCostoTotalNacional()
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarTodoCodigoCostoTotalNacional();
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
        public double BuscarTodoCodigoCostoTotalImportada()
        {
            try
            {
                connectionManager.Open(); 
                return materiaPrimaRepository.BuscarTodoCodigoCostoTotalImportada();
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
        public double BuscarTodoCodigoPorcentajeNacional()
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarTodoCodigoPorcentajeNacional();
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
        public double BuscarTodoCodigoPorcentajeImportada()
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarTodoCodigoPorcentajeImportada();
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
        //
        public decimal BuscarSumaTotal(string Codigo)
        {
            try
            {
                connectionManager.Open();
                return materiaPrimaRepository.BuscarSumaTotal(Codigo);
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
