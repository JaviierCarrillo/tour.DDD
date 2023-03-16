using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.ValueObjects;
using tour.DDD.Domain.ComunDDD;

namespace tour.DDD.Domain.Cliente.Eventos
{
    public class MotivoCancelacionAgregada : EventoDeDominio
    {
        public Motivo Motivo { get; set; }

        public MotivoCancelacionAgregada(Motivo motivo) : base("Cliente.Cancelacion.MotivoCancelacionAgregada")
        {
            Motivo = motivo;
        }

    }
}
