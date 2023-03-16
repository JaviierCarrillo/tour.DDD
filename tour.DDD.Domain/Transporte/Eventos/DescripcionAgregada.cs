using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.ComunDDD;
using tour.DDD.Domain.Transporte.ValueObjects;

namespace tour.DDD.Domain.Transporte.Eventos
{
    public class DescripcionAgregada : EventoDeDominio
    {
        public Descripcion Descripcion { get; set; }
        
        public DescripcionAgregada(Descripcion descripcion) : base("Transporte.DescripcionAgregada")
        {
            Descripcion = descripcion;
        }
    }
}
