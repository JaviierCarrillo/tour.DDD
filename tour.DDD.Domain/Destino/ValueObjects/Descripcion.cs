using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Destino.ValueObjects
{
    public record Descripcion
    {
        public string DescripcionActividad { get; init; }

        private Descripcion(string descripcionActividad)
        {
            DescripcionActividad = descripcionActividad;
        }   

        public static Descripcion Crear(string descripcionActividad)
        {
            Validar(descripcionActividad);
            return new Descripcion(descripcionActividad);
        }


        //Validacion del value object
        public static void Validar(string descripcionActividad)
        {
            if (string.IsNullOrEmpty(descripcionActividad))
                throw new Exception("La descripcion de la actividad no puede estar vacia");
        }
    }
}
