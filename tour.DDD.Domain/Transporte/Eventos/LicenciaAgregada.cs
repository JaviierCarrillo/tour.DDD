using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.ComunDDD;
using tour.DDD.Domain.Transporte.ValueObjects;

namespace tour.DDD.Domain.Transporte.Eventos
{
    public class LicenciaAgregada : EventoDeDominio
    {
        public Licencia Licencia { get; set; }

        public LicenciaAgregada(Licencia licencia) : base("Transporte.Conductor.LicenciaAgregada")
        {
            Licencia = licencia;
        }
    }
}
