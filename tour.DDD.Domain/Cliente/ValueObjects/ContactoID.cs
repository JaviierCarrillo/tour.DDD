using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Cliente.ValueObjects
{
    public record ContactoID
    {
        public Guid Value { get; set; }
        //contructor
        public ContactoID(Guid value)
        {
            Value = value;
        }

        //metodo de fabricacion: crea y devuelve una instancia usando el contructor
        public static ContactoID Of(Guid value)
        {
            return new ContactoID(value);
        }

        public static implicit operator Guid(ContactoID id) => id.Value;
    }
}
