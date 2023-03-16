using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Cliente.ValueObjects
{
    public record Motivo
    {
        public String MotivoCancelacion { get; init; }

        //constructor
        public Motivo(String value)
        {
            MotivoCancelacion = value;
        }

        
        public static Motivo Crear(string value)
        {
            Validar(value);
            return new Motivo(value);
        }

        //Validacion del value object
        public static void Validar(String value)
        {
            if (String.IsNullOrEmpty(value))
                throw new Exception("El motivo de la cancelacion no puede estar vacio");
        }
    }
}
