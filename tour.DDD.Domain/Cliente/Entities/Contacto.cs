using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.ValueObjects;
using tour.DDD.Domain.ComunDDD;

namespace tour.DDD.Domain.Cliente.Entities
{
    public class Contacto
    {
        public ContactoID Id { get; init; }
        public WhatsApp WhatsApp { get; private set; }
        public Correo Correo { get; private set; }

        public Contacto(ContactoID id)
        {
           this.Id = id;
        }

        public void SetWhatsApp(WhatsApp whatsApp)
        {
            WhatsApp = whatsApp;
        }

        public void SetCorreo(Correo correo)
        {
            Correo = correo;
        }
    }
}
