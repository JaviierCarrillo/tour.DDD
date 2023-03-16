using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.ValueObjects;
using tour.DDD.Domain.ComunDDD;

namespace tour.DDD.Domain.Cliente.Eventos
{
    public class DireccionEmailAgregada : EventoDeDominio
    {
        public Correo Correo { get; set; }

        public DireccionEmailAgregada(Correo correo) : base("Cliente.Contacto.DireccionEmailAgregada")
        {
            Correo = correo;
        }     
    }
}
