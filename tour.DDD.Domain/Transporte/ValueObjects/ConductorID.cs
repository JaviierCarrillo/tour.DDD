using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.ValueObjects;

namespace tour.DDD.Domain.Transporte.ValueObjects
{
    public record ConductorID
    {
        public Guid Value { get; set; }
        //contructor
        public ConductorID(Guid value)
        {
            Value = value;
        }

        //metodo de fabricacion: crea y devuelve una instancia usando el contructor
        public static ConductorID Of(Guid value)
        {
            return new ConductorID(value);
        }

        public static implicit operator Guid(ConductorID id) => id.Value;
    }
}
