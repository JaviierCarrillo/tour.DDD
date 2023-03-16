using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.ComunDDD;
using tour.DDD.Domain.Transporte.ValueObjects;

namespace tour.DDD.Domain.Transporte.Eventos
{
    public class DatosPersonalesConductorAgregados : EventoDeDominio
    {
        public DatosPersonalesConductor DatosPersonalesConductor { get; set; }

        public DatosPersonalesConductorAgregados(DatosPersonalesConductor datosPersonalesConductor) : base("Transporte.DatosPersonalesConductorAgregados")
        {
            DatosPersonalesConductor = datosPersonalesConductor;
        }
    }
}
