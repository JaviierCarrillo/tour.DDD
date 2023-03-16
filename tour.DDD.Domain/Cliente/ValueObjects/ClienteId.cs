using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.ComunDDD;
using tour.DDD.Domain.Transporte.ValueObjects;

namespace tour.DDD.Domain.Cliente.ValueObjects
{
    public class ClienteId
    {
        public Guid Value { get; set; }
        //contructor
        public ClienteId(Guid value)
        {
            Value = value;
        }

        //metodo de fabricacion: crea y devuelve una instancia usando el contructor
        public static ClienteId Of(Guid value)
        {
            return new ClienteId(value);
        }

        public static implicit operator Guid(ClienteId id) => id.Value;

    }
}
