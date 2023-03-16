using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.ComunDDD;
using tour.DDD.Domain.Transporte.Entities;

namespace tour.DDD.Domain.Transporte.Eventos
{
    public class VehiculoAgregado : EventoDeDominio
    {
        public Vehiculo Vehiculo { get; set; }

        public VehiculoAgregado(Vehiculo vehiculo) : base("Transporte.VehiculoAgregado")
        {
            Vehiculo = vehiculo;
        }
    }
}
