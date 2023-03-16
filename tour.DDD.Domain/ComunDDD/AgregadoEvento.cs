using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.ComunDDD
{
    public abstract class AgregadoEvento
    {
        private CambiarEventoSuscriptor cambiarEventoSuscriptor = new();

        public List<EventoDeDominio> ObtenerCambiosNoGuardados() => cambiarEventoSuscriptor.obtenerCambios().ToList();

        public void AgregarEvento(EventoDeDominio evento)
        {
            string nombreClase = evento.GetType().Name;
            evento.CambiarAgregado(nombreClase);
            //evento.CambiarAgregadoID(Identidad().Uuid.ToString());
            cambiarEventoSuscriptor.agregarEvento(evento);
        }
    }
}
