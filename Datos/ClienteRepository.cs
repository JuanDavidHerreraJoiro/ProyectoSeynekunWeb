using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class ClienteRepository
    {
        private string ruta = "Cliente.txt";
        List<Cliente> clientes;
        SqlConnection Connection;
        SqlCommand command;

        public ClienteRepository(ConnectionManager connectionManager)
        {
            Connection = connectionManager.connection;
            command = new SqlCommand();
            clientes = new List<Cliente>();
        }

        public void Guardar(Cliente cliente)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Cliente " +
                                      "(Identificacion,Nombre,Apellido,Telefono,Correo)" +
                                      "values" +
                                      "(@Identificacion,@Nombre,@Apellido,@Telefono,@Correo)";

                command.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                command.Parameters.AddWithValue("@Correo", cliente.Correo);
                command.ExecuteNonQuery();
            }
        }

        public List<Cliente> ConsultarTodos()
        {
            clientes.Clear();
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "select * from Cliente";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Cliente cliente = Mapear(dataReader);
                    clientes.Add(cliente);
                }
            }
            return clientes;
        }

        private Cliente Mapear(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Cliente cliente = new Cliente();
            cliente.Identificacion = dataReader.GetString(0);
            cliente.Nombre = dataReader.GetString(1);
            cliente.Apellido = dataReader.GetString(2);
            cliente.Telefono = dataReader.GetString(3);
            cliente.Correo = dataReader.GetString(4);
            return cliente;
        }

        public bool Buscar(string identificacion)
        {
            List<Cliente> clientes = ConsultarTodos();
            foreach (var item in clientes)
            {
                if (item.Identificacion.Equals(identificacion))
                {  
                    return true;
                }
            }
            return false;
        }

        public List<Cliente> BuscarDatos(string identificacion)
        {
            List<Cliente> clientes = ConsultarTodos();
            foreach (var item in clientes)
            {
                if (item.Identificacion.Equals(identificacion))
                {
                    return clientes;
                }
            }
            return null;
        }
        
        public Cliente Consultar(string identificacion)
        {
            List<Cliente> clientes = ConsultarTodos();
            foreach (var item in clientes)
            {
                if (item.Identificacion.Equals(identificacion))
                {
                    return item;
                }
            }
            return null;
        }

        public void Modificar(Cliente clienteNuevo)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "UPDATE Cliente SET " +
                                      "Nombre=@Nombre," +
                                      "Apellido=@Apellido," +
                                      "Telefono=@Telefono," +
                                      "Correo=@Correo" +
                                      " WHERE Identificacion=@Identificacion";

                command.Parameters.AddWithValue("@Identificacion", clienteNuevo.Identificacion);
                command.Parameters.AddWithValue("@Nombre", clienteNuevo.Nombre);
                command.Parameters.AddWithValue("@Apellido", clienteNuevo.Apellido);
                command.Parameters.AddWithValue("@Telefono", clienteNuevo.Telefono);
                command.Parameters.AddWithValue("@Correo", clienteNuevo.Correo);
                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(string identificacion)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM Cliente WHERE Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                command.ExecuteNonQuery();
            }
        }

        //SENTENCIA LINQ
        public IList<Cliente> BuscarTodo()
        {
            IList<Cliente> clientes = ConsultarTodos();
            return clientes.ToList();
        }
        public double ContarTodo()
        {
            IList<Cliente> clientes = ConsultarTodos();
            return clientes.Count();
        }
        public IList<Cliente> BuscarIdentificacion(string Identificacion)
        {
            IList<Cliente> clientes = ConsultarTodos();
            return clientes.Where(i => i.Identificacion.ToUpper().Trim().Contains(Identificacion.ToUpper())).ToList();
        }
        public double ContarIdentificacion(string Identificacion)
        {
            IList<Cliente> clientes = ConsultarTodos();
            return clientes.Where(i => i.Identificacion.ToUpper().Trim().Contains(Identificacion.ToUpper())).Count();
        }
        public IList<Cliente> BuscarNombre(string Nombre)
        {
            IList<Cliente> clientes = ConsultarTodos();
            return clientes.Where(i => i.Nombre.ToUpper().Trim().Contains(Nombre.ToUpper())).ToList();
        }
        public double ContarNombre(string Nombre)
        {
            IList<Cliente> clientes = ConsultarTodos();
            return clientes.Where(i => i.Nombre.ToUpper().Trim().Contains(Nombre.ToUpper())).Count();
        }
        public IList<Cliente> BuscarApellido(string Apellido)
        {
            IList<Cliente> clientes = ConsultarTodos();
            return clientes.Where(i => i.Apellido.ToUpper().Trim().Contains(Apellido.ToUpper())).ToList();
        }
        public double ContarApellido(string Apellido)
        {
            IList<Cliente> clientes = ConsultarTodos();
            return clientes.Where(i => i.Apellido.ToUpper().Trim().Contains(Apellido.ToUpper())).Count();
        }
        public IList<Cliente> BuscarCorreo(string Correo)
        {
            IList<Cliente> clientes = ConsultarTodos();
            return clientes.Where(i => i.Correo.ToUpper().Trim().Contains(Correo.ToUpper())).ToList();
        }
        public double ContarCorreo(string Correo)
        {
            IList<Cliente> clientes = ConsultarTodos();
            return clientes.Where(i => i.Correo.ToUpper().Trim().Contains(Correo.ToUpper())).Count();
        }

    }
}
