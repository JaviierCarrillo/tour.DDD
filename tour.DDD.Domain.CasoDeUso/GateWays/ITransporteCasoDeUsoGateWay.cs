using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Transporte.Comandos;

namespace tour.DDD.Domain.CasoDeUso.GateWays
{
    public interface ITransporteCasoDeUsoGateWay
    {
        Task<Transporte.Entities.Transporte> CrearTransporte(CrearTransporteComando crearTransporteComando);
        Task<Transporte.Entities.Transporte> AgregarConductorTransporte(AgregarConductorTransporteComando agregarConductorTransporteComando);
        Task<Transporte.Entities.Transporte> AgregarVehiculoTransporte(AgregarVehiculoTransporteComando agregarVehiculoTransporteComando);

        //Task<Transporte.Entities.Transporte> ObtenerTransportePorID(string idTransporte);
    }
}
