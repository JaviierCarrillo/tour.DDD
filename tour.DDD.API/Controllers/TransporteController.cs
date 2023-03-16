using Microsoft.AspNetCore.Mvc;
using tour.DDD.Domain.CasoDeUso.GateWays;
using tour.DDD.Domain.Transporte.Comandos;

namespace tour.DDD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransporteController : Controller
    {
        private readonly ITransporteCasoDeUsoGateWay _transporteCasoDeUsoGateWay;

        public TransporteController(ITransporteCasoDeUsoGateWay transporteCasoDeUsoGateWay)
        {
            _transporteCasoDeUsoGateWay = transporteCasoDeUsoGateWay;
        }

        [HttpPost]
        public async Task<IActionResult> CrearTransporte([FromBody] CrearTransporteComando crearTransporteComando)
        {
            var transporte = await _transporteCasoDeUsoGateWay.CrearTransporte(crearTransporteComando);
            return Ok(transporte);
        }

        [HttpPost("AgregarConductor")]
        public async Task<IActionResult> AgregarConductorTransporte([FromBody] AgregarConductorTransporteComando agregarConductorTransporteComando)
        {
            var transporteConConductor = await _transporteCasoDeUsoGateWay.AgregarConductorTransporte(agregarConductorTransporteComando);
            return Ok(transporteConConductor);
        }

        [HttpPost("AgregarVehiculo")]
        public async Task<IActionResult> AgregarVehiculoTransporte([FromBody] AgregarVehiculoTransporteComando agregarVehiculoTransporteComando)
        {
            var transporteConVehiculo = await _transporteCasoDeUsoGateWay.AgregarVehiculoTransporte(agregarVehiculoTransporteComando);
            return Ok(transporteConVehiculo);
        }

    }
}
