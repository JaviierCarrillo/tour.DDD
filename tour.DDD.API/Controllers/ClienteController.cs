using Microsoft.AspNetCore.Mvc;
using tour.DDD.Domain.CasoDeUso.GateWays;
using tour.DDD.Domain.Cliente.Comandos;

namespace tour.DDD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteCasoDeUsoGateWay _clienteCasoDeUsoGateWay;

        public ClienteController(IClienteCasoDeUsoGateWay clienteCasoDeUsoGateWay)
        {
            _clienteCasoDeUsoGateWay = clienteCasoDeUsoGateWay;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCliente([FromBody] CrearClienteComando crearClienteComando)
        {
            var cliente = await _clienteCasoDeUsoGateWay.CrearCliente(crearClienteComando);
            return Ok(cliente);
        }

        [HttpPost("Agregarcontacto")]
        public async Task<IActionResult> AgregarContactoCliente([FromBody] AgregarContactoClienteComando agregarContactoClienteComando)
        {
            var clienteConContacto = await _clienteCasoDeUsoGateWay.AgregarContactoCliente(agregarContactoClienteComando);
            return Ok(clienteConContacto);
        }

        [HttpPost("AgregarCancelacion")]
        public async Task<IActionResult> AgregarCancelacionCliente([FromBody] AgregarCancelacionClienteComando agregarCancelacionClienteComando)
        {
            var clienteConCancelacion = await _clienteCasoDeUsoGateWay.AgregarCancelacionCliente(agregarCancelacionClienteComando);
            return Ok(clienteConCancelacion);
        }
        
    }
}
