using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Destino.ValueObjects
{
    public record ReservaID
    {
        public Guid Value { get; init; }

        //constructor
        private ReservaID(Guid value)
        {
            Value = value;
        }

        public static ReservaID Crear(Guid value)
        {
            return new ReservaID(value);
        }

        public static implicit operator Guid(ReservaID reservaId)
        {
            return reservaId.Value;
        }
    }
}
