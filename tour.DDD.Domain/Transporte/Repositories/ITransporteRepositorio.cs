using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Transporte.Entities;

namespace tour.DDD.Domain.Transporte.Repositories
{
    public interface ITransporteRepositorio
    {
        Task<Transporte.Entities.Transporte> CrearTransporte(Transporte.Entities.Transporte transporte);
        Task AgregarConductor(Transporte.Entities.Transporte transporte, Transporte.Entities.Conductor conductor);
        Task AgregarVehiculo(Transporte.Entities.Transporte transporte, Transporte.Entities.Vehiculo vehiculo);
        Task EditarConductor(ValueObjects.ConductorID conductorID, Transporte.Entities.Conductor nuevoConductor);
    }
}
