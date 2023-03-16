using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Destino.ValueObjects
{
    public record Entradas
    {
        public int Cantidad { get; init; }
        public decimal Precio { get; init; }

        private Entradas(int cantidad, decimal precio)
        {
            Cantidad = cantidad;
            Precio = precio;
        }

        public static Entradas Crear(int cantidad, decimal precio)
        {
            ValidarEntradas(cantidad, precio);
            return new Entradas(cantidad, precio);
        }

        //validacion de los value Objects
        public static void ValidarEntradas(int cantidad, decimal precio)
        {
            if(cantidad < 0)
                throw new Exception("La cantidad de entradas no puede ser negativa");
            if (precio < 0)
                throw new Exception("El precio de las entradas no puede ser negativo");
        }
    }
}
