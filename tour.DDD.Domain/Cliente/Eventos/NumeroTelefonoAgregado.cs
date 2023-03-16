using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.ValueObjects;
using tour.DDD.Domain.ComunDDD;

namespace tour.DDD.Domain.Cliente.Eventos
{
    public class NumeroTelefonoAgregado : EventoDeDominio
    {
        public WhatsApp whatsApp { get; set; }

        public NumeroTelefonoAgregado(WhatsApp whatsApp) : base("Cliente.Contacto.NumeroTelefonoAgregado")
        {
            this.whatsApp = whatsApp;
        }
    }
}
