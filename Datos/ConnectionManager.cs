using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class ConnectionManager
    {

        private string ConnectionString;
        internal SqlConnection connection;
        public ConnectionManager(string connectionString)
        {
            ConnectionString = connectionString;
            connection = new SqlConnection(connectionString);
        }

        public void Open()
        {
            connection.Open();
        }
        public void Close()
        {
            connection.Close();
        }

    }
}
