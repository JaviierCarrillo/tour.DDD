using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.Entities;
using tour.DDD.Domain.ComunDDD;

namespace tour.DDD.Domain.Cliente.Eventos
{
    public class ContactoAgregado : EventoDeDominio
    {
        public Contacto Contacto { get; set; }

        public ContactoAgregado(Contacto contacto) : base("Cliente.ContactoAgregado")
        {
            Contacto = contacto;
        }

    }
}
