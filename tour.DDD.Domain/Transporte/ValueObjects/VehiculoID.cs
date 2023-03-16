using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.ValueObjects;

namespace tour.DDD.Domain.Transporte.ValueObjects
{
    public record VehiculoID
    {
        public Guid Value { get; set; }
        //contructor
        public VehiculoID(Guid value)
        {
            Value = value;
        }

        //metodo de fabricacion: crea y devuelve una instancia usando el contructor
        public static VehiculoID Of(Guid value)
        {
            return new VehiculoID(value);
        }

        public static implicit operator Guid(VehiculoID id) => id.Value;
    }
}
