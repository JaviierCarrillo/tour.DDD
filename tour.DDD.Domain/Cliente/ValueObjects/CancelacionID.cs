using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Cliente.ValueObjects
{
    public record CancelacionID
    {
        public Guid Value { get; set; }
        //contructor
        public CancelacionID(Guid value)
        {
            Value = value;
        }

        //metodo de fabricacion: crea y devuelve una instancia usando el contructor
        public static CancelacionID Of(Guid value)
        {
            return new CancelacionID(value);
        }

        public static implicit operator Guid(CancelacionID id) => id.Value;
    }
}
