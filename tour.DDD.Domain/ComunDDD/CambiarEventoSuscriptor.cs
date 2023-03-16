using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.ComunDDD
{
    public class CambiarEventoSuscriptor
    {
        private List<EventoDeDominio> cambios = new List<EventoDeDominio>();

        public List<EventoDeDominio> obtenerCambios() => cambios;

        public void agregarEvento(EventoDeDominio eventoDeDominio)
        {
            this.cambios.Add(eventoDeDominio);
        }
    }
}
