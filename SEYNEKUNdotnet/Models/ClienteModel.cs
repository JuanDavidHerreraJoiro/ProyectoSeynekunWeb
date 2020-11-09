using Entity;

namespace SEYNEKUNdotnet.Model
{
    public class ClienteModel
    {
        
    }
    public class ClienteImputModel
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }

    public class ClienteViewModel : ClienteImputModel
    {
        public ClienteViewModel()
        {
        }
        public ClienteViewModel(Cliente cliente)
        {
            Identificacion = cliente.Identificacion;
            Nombre = cliente.Nombre;
            Apellido = cliente.Apellido;
            Telefono = cliente.Telefono;
            Correo = cliente.Correo;
        }
    }

    public class ClienteUpdateModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }

}