using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Destino.ValueObjects
{
    public record ActividadID
    {
        public Guid Value { get; init; }

        private ActividadID(Guid value)
        {
            Value = value;
        }

        public static ActividadID Crear(Guid value)
        {
            return new ActividadID(value);
        }

        public static implicit operator Guid(ActividadID actividadId)
        {
            return actividadId.Value;
        }
    }
}
