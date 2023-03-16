using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Transporte.ValueObjects
{
    public record Caracteristicas
    {
        //Caracteristicas de un vehiculo
        public string Marca { get; init; }
        public string Modelo { get; init; }
        public int CantidadPasajeros { get; init; }
        public string Tipo { get; init; }

        //constructor
        public Caracteristicas(string marca, string modelo, int cantidadPasajeros, string tipo)
        {
            Marca = marca;
            Modelo = modelo;
            CantidadPasajeros = cantidadPasajeros;
            Tipo = tipo;
        }

        public static Caracteristicas Crear(string marca, string modelo, int cantidadPasajeros, string tipo)
        {
            Validar(marca, modelo, cantidadPasajeros, tipo);
            return new Caracteristicas(marca, modelo, cantidadPasajeros, tipo);
        }

        //Validacion del value object
        public static void Validar(string marca, string modelo, int cantidadPasajeros, string tipo)
        {
            if (String.IsNullOrEmpty(marca))
                throw new Exception("La marca no puede estar vacia");
            if (String.IsNullOrEmpty(modelo))
                throw new Exception("El modelo no puede estar vacio");
            if (cantidadPasajeros <= 0)
                throw new Exception("La cantidad de pasajeros debe ser mayor a 0");
            if (String.IsNullOrEmpty(tipo))
                throw new Exception("El tipo no puede estar vacio");
        }
    }
}
