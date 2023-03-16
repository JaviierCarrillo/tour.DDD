using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Destino.ValueObjects
{
    public record Ubicacion
    {
        public string Pais { get; init; }
        public string Ciudad { get; init; }
        public string Direccion { get; init; }

        //constructor
        private Ubicacion(string pais, string ciudad, string direccion)
        {
            Pais = pais;
            Ciudad = ciudad;
            Direccion = direccion;
        }

        public static Ubicacion Crear(string pais, string ciudad, string direccion)
        {
            Validar(pais, ciudad, direccion);
            return new Ubicacion(pais, ciudad, direccion);
        }

        //Validacion del value object
        public static void Validar(string pais, string ciudad, string direccion)
        {
            if (string.IsNullOrEmpty(pais))
                throw new Exception("El pais no puede estar vacio");
            if (string.IsNullOrEmpty(ciudad))
                throw new Exception("La ciudad no puede estar vacia");
            if (string.IsNullOrEmpty(direccion))
                throw new Exception("La direccion no puede estar vacia");
        }
    }
}
