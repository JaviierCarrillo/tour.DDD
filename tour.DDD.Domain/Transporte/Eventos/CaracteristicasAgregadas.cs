using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.ComunDDD;
using tour.DDD.Domain.Transporte.ValueObjects;

namespace tour.DDD.Domain.Transporte.Eventos
{
    public class CaracteristicasAgregadas : EventoDeDominio
    {
        public Caracteristicas Caracteristicas { get; set; }

        public CaracteristicasAgregadas(Caracteristicas caracteristicas) : base("Transporte.CaracteristicasAgregadas")
        {
            Caracteristicas = caracteristicas;
        }
    }
}
