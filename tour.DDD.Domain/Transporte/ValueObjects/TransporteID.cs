using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.ValueObjects;

namespace tour.DDD.Domain.Transporte.ValueObjects
{
    public class TransporteID
    {
        public Guid Value { get; set; }
        //contructor
        public TransporteID(Guid value)
        {
            Value = value;
        }

        //metodo de fabricacion: crea y devuelve una instancia usando el contructor
        public static TransporteID Of(Guid value)
        {
            return new TransporteID(value);
        }

        public static implicit operator Guid(TransporteID id) => id.Value;
    }
}
