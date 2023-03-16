using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Cliente.ValueObjects
{
    public record AgregadosID
    {
        public string IdVehiculo { get; init; }
        public AgregadosID(string id)
        {
            IdVehiculo = id;
        }

        public static AgregadosID Crear(string id)
        {
            Validar(id);
            return new AgregadosID(id);
        }

        public static void Validar(string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new Exception("El id del vehiculo no puede estar vacio");
        }

    }
}
