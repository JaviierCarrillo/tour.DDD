using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Destino.ValueObjects
{
    public record Horario
    {
        public DateTime HoraInicio { get; init; }
        public DateTime HoraFin { get; init; }

        //constructor
        private Horario(DateTime horaInicio, DateTime horaFin)
        {
            HoraInicio = horaInicio;
            HoraFin = horaFin;
        }

        public static Horario Crear(DateTime horaInicio, DateTime horaFin)
        {
            Validar(horaInicio, horaFin);
            return new Horario(horaInicio, horaFin);
        }

        //Validacion del value object
        public static void Validar(DateTime horaInicio, DateTime horaFin)
        {
            if (horaInicio > horaFin)
                throw new Exception("La hora de inicio no puede ser mayor a la hora de fin");
        }
    }
}
