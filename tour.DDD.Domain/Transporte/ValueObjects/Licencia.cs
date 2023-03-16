using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Transporte.ValueObjects
{
    public record Licencia
    {
        public DateTime FechaExpedicion { get; init; }
        public DateTime FechaVencimiento { get; init; }
        public string Categoria { get; init; }

        //constructor
        public Licencia(DateTime fechaExpedicion, DateTime fechaVencimiento, string categoria)
        {
            
            FechaExpedicion = fechaExpedicion;
            FechaVencimiento = fechaVencimiento;
            Categoria = categoria;
        }

        public static Licencia Crear(string fechaExpedicion, string fechaVencimiento, string categoria)
        {
            Validar(fechaExpedicion, fechaVencimiento, categoria);
            return new Licencia(DateTime.Parse(fechaExpedicion),DateTime.Parse(fechaVencimiento), categoria);
        }

        //Validacion del value object
        public static void Validar(string fechaExpedicion, string fechaVencimiento, string categoria)
        {
            DateTime fecha;

            if (!DateTime.TryParse(fechaExpedicion, out fecha))
                throw new Exception("El formato de fecha de expedición es inválido");
            if (!DateTime.TryParse(fechaVencimiento, out fecha))
                throw new Exception("El formato de fecha de vencimiento es inválido");
            if (String.IsNullOrEmpty(categoria))
                throw new Exception("La categoria no puede estar vacia");
        }
    }
}
