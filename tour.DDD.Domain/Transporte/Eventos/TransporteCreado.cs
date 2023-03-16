using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.ComunDDD;

namespace tour.DDD.Domain.Transporte.Eventos
{
    public class TransporteCreado : EventoDeDominio
    {

        public string TransporteId { get; set; }

        public TransporteCreado(string transporteId) : base ("Transporte.creado")
        {
            TransporteId = transporteId;
        }

    }
}
