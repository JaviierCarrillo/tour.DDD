using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Destino.ValueObjects;

namespace tour.DDD.Domain.Destino.Entities
{
    public class Reserva
    {
        public ReservaID ReservaID { get; init; }
        public Horario Horario { get; private set; }
        public Entradas Entradas { get; private set;}
        public Pagado Pagado { get; private set; }

        public Reserva(ReservaID id)
        {
            ReservaID = id;
        }

        public void SetHorario(Horario horario)
        {
            Horario= horario;
        }

        public void SetEntradas(Entradas entradas)
        {
            Entradas= entradas;
        }

        public void SetPagado(Pagado pagado)
        {
            Pagado= pagado;
        }

    }
}
