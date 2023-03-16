using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Cliente.ValueObjects
{
    public record Correo
    {
        public String DireccionEmail { get; init; }

        //constructor
        public Correo(String value)
        {
            DireccionEmail = value;
        }

        public static Correo crear(string value)
        {
            Validar(value);
            return new Correo(value);
        }


        //Validacion del value object
        public static void Validar(String value)
        {
            if (String.IsNullOrEmpty(value))
                throw new Exception("El correo no puede estar vacio");
        }
    }
}
