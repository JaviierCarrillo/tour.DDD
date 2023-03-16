using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.ComunDDD;

namespace tour.DDD.Domain.Cliente.ValueObjects
{
    public class DatosPersonales
    {
        public String Nombre { get; init; }
        public String Apellido { get; init; }
        public String Nacionalidad { get; init; }

        //constructor
        public DatosPersonales(String nombre, String apellido, String nacionalidad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Nacionalidad = nacionalidad;
        }

        public static DatosPersonales Crear(String nombre, String apellido, String nacionalidad)
        {
            Validar(nombre, apellido, nacionalidad);
            return new DatosPersonales(nombre, apellido, nacionalidad);
        }

        //Validacion del value object
        public static void Validar(String nombre, String apellido, String nacionalidad)
        {
            if (String.IsNullOrEmpty(nombre))
                throw new Exception("El nombre no puede estar vacio");
            if (String.IsNullOrEmpty(apellido))
                throw new Exception("El apellido no puede estar vacio");
            if (String.IsNullOrEmpty(nacionalidad))
                throw new Exception("La nacionalidad no puede estar vacia");
        }

    }
}
