using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using Infraestructura;
using Entity;
using Datos;

namespace Logica
{
    public class GuardarClienteResponse 
    {
        public GuardarClienteResponse (Cliente cliente)
        {
            Error = false;
            Cliente = cliente;
        }
        public GuardarClienteResponse (string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Cliente Cliente { get; set; }
    }
    public class ClienteService
    {
        private ClienteRepository clienteRepository;
        private ConnectionManager connectionManager;

        public ClienteService(string CadenaConexion)
        {
            connectionManager = new ConnectionManager(CadenaConexion);
            clienteRepository = new ClienteRepository(connectionManager);
        }
        public GuardarClienteResponse Guardar(Cliente cliente)
        {
            try
            {
                connectionManager.Open();
                clienteRepository.Guardar(cliente);
                connectionManager.Close();
/*
                Email email = new Email();
                string mensajeEmail = string.Empty;
                mensajeEmail = email.EnviarEmail(cliente);*/
                return new GuardarClienteResponse(cliente);
            }
            catch (Exception e)
            {
                return new  GuardarClienteResponse("!ERROR¡ REGISTRO FALLIDO "+e.Message );
            }
            finally
            {
                connectionManager.Close();
            }
        }
        public bool Buscar(string identificacion)
        {
            try
            {
                connectionManager.Open();
                return clienteRepository.Buscar(identificacion);
            }
            catch (Exception e)
            {
                return true;
            }
            finally
            {
                connectionManager.Close();
            }       
        }
        public List<Cliente> BuscarDatos(string identificacion)
        {
            try
            {
                connectionManager.Open();
                return clienteRepository.BuscarDatos(identificacion);
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
        public Cliente Consultar(string identificacion)
        {
            try
            {
                connectionManager.Open();
                Cliente cliente = clienteRepository.Consultar(identificacion);
                return cliente;
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
        public List<Cliente> ConsultarTodos()
        {
            try
            {
                connectionManager.Open();
                return clienteRepository.ConsultarTodos();
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
        public String Modificar(Cliente clienteNuevo)
        {
            try
            {
                connectionManager.Open();
                clienteRepository.Modificar(clienteNuevo);
                return $"REGISTRO MODIFICADO CORECTAMENTE";
            }
            catch (Exception)
            {
                return " !ERROR! MODIFICACION FALLIDA ";
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        public string Eliminar(string identificacion)
        {
            try
            {
                connectionManager.Open();
                clienteRepository.Eliminar(identificacion);
                return $" EL CLIENTE CON LA IDENTIFICACION [ {identificacion} ], HA SIDO ELIMINADO CORECTAMENTE ";
            }
            catch (Exception)
            {
                return " !ERROR¡ ELIMINACION FALLIDA";
            }
            finally
            {
                connectionManager.Close();
            }
            
        }
        //SENTENCIA LINQ
        public IList<Cliente> BuscarTodo()
        {
            try
            {
                connectionManager.Open();
                return clienteRepository.BuscarTodo();
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
        public double ContarTodo()
        {
            try
            {
                connectionManager.Open();
                return clienteRepository.ContarTodo();
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
        public IList<Cliente> BuscarIdentificacion(string Identificacion)
        {
            try
            {
                connectionManager.Open();
                return clienteRepository.BuscarIdentificacion(Identificacion);
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
        public double ContarIdentificacion(string Identificacion)
        {
            try
            {
                connectionManager.Open();
                return clienteRepository.ContarIdentificacion(Identificacion);
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
        public IList<Cliente> BuscarNombre(string Nombre)
        {
            try
            {
                connectionManager.Open();
                return clienteRepository.BuscarNombre(Nombre);
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
        public double ContarNombre(string Nombre)
        {
            try
            {
                connectionManager.Open();
                return clienteRepository.ContarNombre(Nombre);
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
        public IList<Cliente> BuscarApellido(string Apellido)
        {
            try
            {
                connectionManager.Open();
                return clienteRepository.BuscarApellido(Apellido);
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
        public double ContarApellido(string Apellido)
        {
            try
            {
                connectionManager.Open();
                return clienteRepository.ContarApellido(Apellido);
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
        public IList<Cliente> BuscarCorreo(string Correo)
        {
            try
            {
                connectionManager.Open();
                return clienteRepository.BuscarCorreo(Correo);
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
        public double ContarCorreo(string Correo)
        {
            try
            {
                connectionManager.Open();
                return clienteRepository.ContarCorreo(Correo);
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
        /*
        public string GenerarPdf(IList<Cliente> clientes, string filename)
        {
            DocumentoPdf documentoPdf = new DocumentoPdf();
            try
            {
                connectionManager.Open();
                documentoPdf.GuardarPdf(clientes, filename);
                return " PDF GENERADO CORRECTAMENTE ";
            }
            catch (Exception e)
            {
                return " !ERROR¡ PDF FALLIDO, NO GENERADO " + e.Message;
            }
            finally
            {
                connectionManager.Close();
            }
        }*/

    }
}
