using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Destino.ValueObjects
{
    public record Precio
    {
        public decimal PrecioPorPersona { get; init; }

        //constructor
        private Precio(decimal value)
        {
            PrecioPorPersona = value;
        }

        public static Precio Crear(decimal value)
        {
            Validar(value);
            return new Precio(value);
        }

        //Validacion del value object
        public static void Validar(decimal value)
        {
            if (value <= 0)
                throw new Exception("El precio no puede ser menor o igual a 0");
        }
    }
}
