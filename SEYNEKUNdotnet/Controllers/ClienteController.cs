using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SEYNEKUNdotnet.Model;
using Logica;
using Entity;

namespace SEYNEKUNdotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        public IConfiguration Configuration { get; }

        public ClienteController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _clienteService = new ClienteService(connectionString);
        }
        // GET: api/cliente
        [HttpGet]
        public IEnumerable<ClienteViewModel> Gets()
        {
            var clientes = _clienteService.ConsultarTodos().Select(p=> new ClienteViewModel(p));
            return clientes;
        }

        // GET: api/cliente/5
        [HttpGet("{identificacion}")]
        public ActionResult<ClienteViewModel> Get(string identificacion)
        {
            var cliente = _clienteService.Consultar(identificacion);
            if (cliente == null) return NotFound();
            var clienteViewModel = new ClienteViewModel(cliente);
            return clienteViewModel;
        }

        // POST: api/Cliente
        [HttpPost]
        public ActionResult<ClienteViewModel> Post(ClienteImputModel ClienteInput)
        {
            Cliente cliente = MapearCliente(ClienteInput);
            var response = _clienteService.Guardar(cliente);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Cliente);
        }
        // DELETE: api/cliente/5
        [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(string identificacion)
        {
            string mensaje = _clienteService.Eliminar(identificacion);
            return Ok(mensaje);
        }

        private Cliente MapearCliente(ClienteImputModel clienteInput)
        {
            var cliente = new Cliente
            {
                Identificacion = clienteInput.Identificacion,
                Nombre = clienteInput.Nombre,
                Apellido = clienteInput.Apellido,
                Telefono = clienteInput.Telefono,
                Correo = clienteInput.Correo 
            };
            return cliente;
        }
    }
}