using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Datos;

namespace Logica
{
    public class GuardarFichaTecnicaResponse 
    {
        public GuardarFichaTecnicaResponse (FichaTecnica fichaTecnica)
        {
            Error = false;
            FichaTecnica = fichaTecnica;
        }
        public GuardarFichaTecnicaResponse (string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public FichaTecnica FichaTecnica { get; set; }
    }
    public class FichaTecnicaService
    {
        private FichaTecnicaRepository fichaTecnicaRepository;
        private ConnectionManager connectionManager;

        public FichaTecnicaService(string CadenaConexion)
        {
            connectionManager = new ConnectionManager(CadenaConexion);
            fichaTecnicaRepository = new FichaTecnicaRepository(connectionManager);
        }

        public  GuardarFichaTecnicaResponse Guardar(FichaTecnica fichaTecnica)
        {
            try
            {
                connectionManager.Open();
                fichaTecnicaRepository.Guardar(fichaTecnica);
                connectionManager.Close();
                return new  GuardarFichaTecnicaResponse(fichaTecnica);
            }
            catch (Exception e)
            {
                return new  GuardarFichaTecnicaResponse($"!ERROR¡ REGISTRO FALLIDO ,{e.Message} ");
            }
            finally
            {
                connectionManager.Close();
            }
            
        }

        public bool Buscar(string codigo)
        {
            try
            {
                connectionManager.Open();
                return fichaTecnicaRepository.Buscar(codigo);
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

        public List<FichaTecnica> BuscarDatosCodigo(string codigo)
        {
            try
            {
                connectionManager.Open();
                return fichaTecnicaRepository.BuscarDatosCodigo(codigo);
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

        public List<FichaTecnica> BuscarDatosIdentificacion(string identificacion)
        {
            try
            {
                connectionManager.Open();
                return fichaTecnicaRepository.BuscarDatosIdentificacion(identificacion);
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

        public FichaTecnica Consultar(string codigo)
        {
            try
            {
                connectionManager.Open();
                FichaTecnica fichaTecnica = fichaTecnicaRepository.Consultar(codigo);
                return fichaTecnica;
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

        public List<FichaTecnica> ConsultarTodos()
        {
            try
            {
                connectionManager.Open();
                return fichaTecnicaRepository.ConsultarTodos();
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

        public String Modificar(FichaTecnica fichaTecnicaNuevo)
        {
            try
            {
                connectionManager.Open();
                fichaTecnicaRepository.Modificar(fichaTecnicaNuevo);
                return $" REGISTRO MODIFICADO CORECTAMENTE ";
            }
            catch (Exception e)
            {
                return $" REGISTRO NO MODIFICADO CORECTAMENTE,{e.Message} ";
            }
            finally
            {
                connectionManager.Close();
            }
            
        }

        public string Eliminar(string codigo)
        {
            try
            {
                connectionManager.Open();
                fichaTecnicaRepository.Eliminar(codigo);
                return $" EL CLIENTE CON LA IDENTIFICACION [ {codigo} ], HA SIDO ELIMINADO CORECTAMENTE ";
            }
            catch (Exception)
            {
                return "ERROR, FALLO AL TRATAR DE ELIMINAR";
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public IList<FichaTecnica> BuscarCodigoFichaTecnica(string CodigoFichaTecnica)
        {
            try
            {
                connectionManager.Open();
                return fichaTecnicaRepository.BuscarCodigoFichaTecnica(CodigoFichaTecnica);
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
        public IList<FichaTecnica> BuscarIdentificacion(string Identificacion)
        {
            try
            {
                connectionManager.Open();
                return fichaTecnicaRepository.BuscarIdentificacion(Identificacion);
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
        public IList<FichaTecnica> BuscarPaisObjetivo(string PaisObjetivo)
        {
            try
            {
                connectionManager.Open();
                return fichaTecnicaRepository.BuscarPaisObjetivo(PaisObjetivo);
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
        public IList<FichaTecnica> BuscarTodo()
        {
            try
            {
                connectionManager.Open();
                return fichaTecnicaRepository.BuscarTodo();
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

    }
}
