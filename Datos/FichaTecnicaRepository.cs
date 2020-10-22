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
    public class FichaTecnicaRepository
    {
        private string ruta = "FichaTecnica.txt";
        List<FichaTecnica> fichaTecnicas;
        SqlConnection Connection;
        SqlCommand command;
        public FichaTecnicaRepository(ConnectionManager connectionManager)
        {
            Connection = connectionManager.connection;
            fichaTecnicas = new List<FichaTecnica>();
            command = new SqlCommand();
        }
        public void Guardar(FichaTecnica fichaTecnica)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO FichaTecnica " +
                                      "(Codigo,RazonSocial,NombreGerente,Telefono,Celular,Correo,ConsultorExportacion,CelularConsultor,Objetivo,CorreoConsultor,PaisObjetivo,PaisAlterno,PaisContingente,TipoCanalDeDistribucion,SegmentoObjetivo,Identificacion)" +
                                      "values" +
                                      "(@Codigo,@RazonSocial,@NombreGerente,@Telefono,@Celular,@Correo,@ConsultorExportacion,@CelularConsultor,@Objetivo,@CorreoConsultor,@PaisObjetivo,@PaisAlterno,@PaisContingente,@TipoCanalDeDistribucion,@SegmentoObjetivo,@Identificacion)";

                command.Parameters.AddWithValue("@Codigo", fichaTecnica.Codigo);
                command.Parameters.AddWithValue("@RazonSocial", fichaTecnica.RazonSocial);
                command.Parameters.AddWithValue("@NombreGerente", fichaTecnica.NombreDelGerente);
                command.Parameters.AddWithValue("@Telefono", fichaTecnica.Telefono);
                command.Parameters.AddWithValue("@Celular", fichaTecnica.Celular);
                command.Parameters.AddWithValue("@Correo", fichaTecnica.Correo);
                command.Parameters.AddWithValue("@ConsultorExportacion", fichaTecnica.ConsultorDeExportacion);
                command.Parameters.AddWithValue("@CelularConsultor", fichaTecnica.CelularConsultor);
                command.Parameters.AddWithValue("@Objetivo", fichaTecnica.Objetivo);
                command.Parameters.AddWithValue("@CorreoConsultor", fichaTecnica.CorreoConsultor);
                command.Parameters.AddWithValue("@PaisObjetivo", fichaTecnica.PaisObjetivo);
                command.Parameters.AddWithValue("@PaisAlterno", fichaTecnica.PaisAlterno);
                command.Parameters.AddWithValue("@PaisContingente", fichaTecnica.PaisContingente);
                command.Parameters.AddWithValue("@TipoCanalDeDistribucion", fichaTecnica.TipoCanalDeDistribucion);
                command.Parameters.AddWithValue("@SegmentoObjetivo", fichaTecnica.SegmentoObjetivo);
                command.Parameters.AddWithValue("@Identificacion", fichaTecnica.Cliente.Identificacion);
                command.ExecuteNonQuery();
            }
        }
        public List<FichaTecnica> ConsultarTodos()
        {
            fichaTecnicas.Clear();
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = $"Select * from FichaTecnica";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    FichaTecnica fichaTecnica = Mapear(dataReader);
                    fichaTecnicas.Add(fichaTecnica);
                }
            }
            return fichaTecnicas;
        }

        private FichaTecnica Mapear(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            FichaTecnica fichaTecnica = new FichaTecnica();
            fichaTecnica.Codigo = dataReader.GetString(0);
            fichaTecnica.RazonSocial = dataReader.GetString(1);
            fichaTecnica.NombreDelGerente = dataReader.GetString(2);
            fichaTecnica.Telefono = dataReader.GetString(3);
            fichaTecnica.Celular = dataReader.GetString(4);
            fichaTecnica.Correo = dataReader.GetString(5);
            fichaTecnica.ConsultorDeExportacion = dataReader.GetString(6);
            fichaTecnica.CelularConsultor = dataReader.GetString(7);
            fichaTecnica.Objetivo = dataReader.GetString(8);
            fichaTecnica.CorreoConsultor = dataReader.GetString(9);
            fichaTecnica.PaisObjetivo = dataReader.GetString(10);
            fichaTecnica.PaisAlterno = dataReader.GetString(11);
            fichaTecnica.PaisContingente = dataReader.GetString(12);
            fichaTecnica.TipoCanalDeDistribucion = dataReader.GetString(13);
            fichaTecnica.SegmentoObjetivo = dataReader.GetString(14);
            fichaTecnica.Cliente.Identificacion = dataReader.GetString(15);
            return fichaTecnica;
        }

        public bool Buscar(string codigo)
        {
            List<FichaTecnica> fichaTecnicas = ConsultarTodos();

            foreach (var item in fichaTecnicas)
            {
                if (item.Codigo.Equals(codigo))
                {
                    return true;
                }
            }
            return false;
        }
        public List<FichaTecnica> BuscarDatosCodigo(string codigo)
        {
            List<FichaTecnica> fichaTecnicas = ConsultarTodos();

            foreach (var item in fichaTecnicas)
            {
                if (item.Codigo.Equals(codigo))
                {
                    return fichaTecnicas;
                }
            }
            return null;
        }
        public List<FichaTecnica> BuscarDatosIdentificacion(string identificacion)
        {
            List<FichaTecnica> fichaTecnicas = ConsultarTodos();

            foreach (var item in fichaTecnicas)
            {
                if (item.Cliente.Identificacion.Equals(identificacion))
                {
                    return fichaTecnicas;
                }
            }
            return null;
        }
        public FichaTecnica Consultar(string codigo)
        {
            List<FichaTecnica> fichaTecnicas = ConsultarTodos();

            foreach (var item in fichaTecnicas)
            {
                if (item.Codigo.Equals(codigo))
                {
                    return item;
                }
            }
            return null;
        }
        public void Modificar(FichaTecnica fichaTecnicaNuevo)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "UPDATE FichaTecnica SET " +
                                      "RazonSocial=@RazonSocial," +
                                      "NombreGerente=@NombreGerente," +
                                      "Telefono=@Telefono," +
                                      "Celular=@Celular," +
                                      "Correo=@Correo," +
                                      "ConsultorExportacion=@ConsultorExportacion," +
                                      "CelularConsultor=@CelularConsultor," +
                                      "Objetivo=@Objetivo," +
                                      "CorreoConsultor=@CorreoConsultor," +
                                      "PaisObjetivo=@PaisObjetivo," +
                                      "PaisAlterno=@PaisAlterno," +
                                      "PaisContingente=@PaisContingente," +
                                      "TipoCanalDeDistribucion=@TipoCanalDeDistribucion," +
                                      "SegmentoObjetivo=@SegmentoObjetivo," +
                                      "Identificacion=@Identificacion" +
                                      " WHERE Codigo=@Codigo";

                command.Parameters.AddWithValue("@Codigo", fichaTecnicaNuevo.Codigo);
                command.Parameters.AddWithValue("@RazonSocial", fichaTecnicaNuevo.RazonSocial);
                command.Parameters.AddWithValue("@NombreGerente", fichaTecnicaNuevo.NombreDelGerente);
                command.Parameters.AddWithValue("@Telefono", fichaTecnicaNuevo.Telefono);
                command.Parameters.AddWithValue("@Celular", fichaTecnicaNuevo.Celular);
                command.Parameters.AddWithValue("@Correo", fichaTecnicaNuevo.Correo);
                command.Parameters.AddWithValue("@ConsultorExportacion", fichaTecnicaNuevo.ConsultorDeExportacion);
                command.Parameters.AddWithValue("@CelularConsultor", fichaTecnicaNuevo.CelularConsultor);
                command.Parameters.AddWithValue("@Objetivo", fichaTecnicaNuevo.Objetivo);
                command.Parameters.AddWithValue("@CorreoConsultor", fichaTecnicaNuevo.CorreoConsultor);
                command.Parameters.AddWithValue("@PaisObjetivo", fichaTecnicaNuevo.PaisObjetivo);
                command.Parameters.AddWithValue("@PaisAlterno", fichaTecnicaNuevo.PaisAlterno);
                command.Parameters.AddWithValue("@PaisContingente", fichaTecnicaNuevo.PaisContingente);
                command.Parameters.AddWithValue("@TipoCanalDeDistribucion", fichaTecnicaNuevo.TipoCanalDeDistribucion);
                command.Parameters.AddWithValue("@SegmentoObjetivo", fichaTecnicaNuevo.SegmentoObjetivo);
                command.Parameters.AddWithValue("@Identificacion", fichaTecnicaNuevo.Cliente.Identificacion);
                command.ExecuteNonQuery();
            }
        }
        public void Eliminar(string codigo)
        {
            using (var command = Connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM FichaTecnica WHERE Codigo=@Codigo";
                command.Parameters.AddWithValue("@Codigo", codigo);
                command.ExecuteNonQuery();
            }
        }
        //SENTENCIA
        public IList<FichaTecnica> BuscarCodigoFichaTecnica(string CodigoFichaTecnica)
        {
            IList<FichaTecnica> fichaTecnicas = ConsultarTodos();
            return fichaTecnicas.Where(i => i.Codigo.ToUpper().Trim().Contains(CodigoFichaTecnica.ToUpper())).ToList();
        }
        public IList<FichaTecnica> BuscarIdentificacion(string Identificacion)
        {
            IList<FichaTecnica> fichaTecnicas = ConsultarTodos();
            return fichaTecnicas.Where(i => i.Cliente.Identificacion.ToUpper().Trim().Contains(Identificacion.ToUpper())).ToList();
        }
        public IList<FichaTecnica> BuscarPaisObjetivo(string PaisObjetivo)
        {
            IList<FichaTecnica> fichaTecnicas = ConsultarTodos();
            return fichaTecnicas.Where(i => i.PaisObjetivo.ToUpper().Trim().Contains(PaisObjetivo.ToUpper())).ToList();
        }
        public IList<FichaTecnica> BuscarTodo()
        {
            IList<FichaTecnica> fichaTecnicas = ConsultarTodos();
            return fichaTecnicas.ToList();
        }
    }
}
