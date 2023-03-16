using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.Entities;
using tour.DDD.Domain.ComunDDD;

namespace tour.DDD.Domain.Cliente.Eventos
{
    public class CancelacionAgregada : EventoDeDominio
    {
        public Cancelacion Cancelacion { get; set; }

        public CancelacionAgregada(Cancelacion cancelacion) : base("Cliente.CancelacionAgregada")
        {
            Cancelacion= cancelacion;
        }
    }
}
