using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Transporte.ValueObjects;

namespace tour.DDD.Domain.Transporte.Entities
{
    public class Vehiculo
    {
        public VehiculoID VehiculoId { get; init; }
        public Caracteristicas Caracteristicas { get; private set; }

        //constructor
        public Vehiculo(VehiculoID id)
        {
            VehiculoId = id;
        }

        public void setCaracteristicas(Caracteristicas caracteristicas)
        {
            Caracteristicas = caracteristicas;
        }

    }
}
