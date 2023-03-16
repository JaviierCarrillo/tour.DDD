using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.ComunDDD;

namespace tour.DDD.Domain.Cliente.Eventos
{
    public class ClienteCreado : EventoDeDominio
    {
        public string ClienteId { get; set; }

        public ClienteCreado(string clienteId) : base ("Cliente.creado")
        {
            ClienteId = clienteId;
        }
    }
}
