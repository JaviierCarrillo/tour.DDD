using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.ComunDDD;
using tour.DDD.Domain.Transporte.Entities;

namespace tour.DDD.Domain.Transporte.Eventos
{
    public class ConductorAgregado : EventoDeDominio
    {
        public Conductor Conductor { get; set; }

        public ConductorAgregado(Conductor conductor) : base("Transporte.ConductorAgregado")
        {
            Conductor = conductor;
        }
    }
}
