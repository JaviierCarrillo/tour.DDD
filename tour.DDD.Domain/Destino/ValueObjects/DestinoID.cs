using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Destino.ValueObjects
{
    public record DestinoID
    {
        public Guid Value { get; init; }

        private DestinoID(Guid value)
        {
            Value = value;
        }

        public static DestinoID Crear(Guid value)
        {
            return new DestinoID(value);
        }

        public static implicit operator Guid(DestinoID destinoId)
        {
            return destinoId.Value;
        }
    }
}
