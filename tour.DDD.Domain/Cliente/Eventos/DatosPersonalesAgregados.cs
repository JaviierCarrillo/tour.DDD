using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.ValueObjects;
using tour.DDD.Domain.ComunDDD;

namespace tour.DDD.Domain.Cliente.Eventos
{
    public class DatosPersonalesAgregados : EventoDeDominio
    {
        public DatosPersonales DatosPersonales { get; set; }

        public DatosPersonalesAgregados(DatosPersonales datosPersonales) : base("Cliente.DatosPersonalesAgregados")
        {
                DatosPersonales = datosPersonales;
        }
    }
}
