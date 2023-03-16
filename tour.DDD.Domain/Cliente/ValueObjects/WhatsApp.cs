using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Cliente.ValueObjects
{
    public record WhatsApp
    {
        public String NumeroTelefono { get; init; }

        //constructor
        public WhatsApp(String value)
        {
            NumeroTelefono = value;
        }

        public static WhatsApp Crear(string value)
        {
            Validar(value);
            return new WhatsApp(value);
        }

        //Validacion del value object
        public static void Validar(String value)
        {
            if (String.IsNullOrEmpty(value))
                throw new Exception("El numero de whatsapp no puede estar vacio");
        }
    }
}
