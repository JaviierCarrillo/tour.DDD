using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Transporte.ValueObjects
{
    public record DatosPersonalesConductor
    {
        public String Nombre { get; init; }
        public String Apellido { get; init; }
        public String Correo { get; init; }
        public String Telefono { get; init; }

        //constructor
        public DatosPersonalesConductor(String nombre, String apellido, String correo, String telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            Correo= correo;
            Telefono = telefono;
        }

        public static DatosPersonalesConductor Crear(String nombre, String apellido, String correo, String telefono)
        {
            Validar(nombre, apellido, correo, telefono);
            return new DatosPersonalesConductor(nombre, apellido, correo, telefono);
        }

        //Validacion del value object
        public static void Validar(String nombre, String apellido, String correo, String telefono)
        {
            if (String.IsNullOrEmpty(nombre))
                throw new Exception("El nombre no puede estar vacio");
            if (String.IsNullOrEmpty(apellido))
                throw new Exception("El apellido no puede estar vacio");
            if (String.IsNullOrEmpty(correo))
                throw new Exception("El correo no puede estar vacio");
            if (String.IsNullOrEmpty(telefono))
                throw new Exception("El telefono no puede estar vacio");
        }
    }
}
