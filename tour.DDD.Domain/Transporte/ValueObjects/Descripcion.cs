using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Transporte.ValueObjects
{
    public record Descripcion
    {
        public String DescripcionTransporte { get; init; }

        //Constructor
        public Descripcion(String descripcionTransporte)
        {
            DescripcionTransporte = descripcionTransporte;
        }

        public static Descripcion Crear(String descripcionTransporte)
        {
            Validar(descripcionTransporte);
            return new Descripcion(descripcionTransporte);
        }

        //Validacion del value object
        public static void Validar(String descripcionTransporte)
        {
            if (String.IsNullOrEmpty(descripcionTransporte))
                throw new Exception("La descripcion no puede estar vacia");
        }
    }
}
