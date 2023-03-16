using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.ValueObjects;

namespace tour.DDD.Domain.Cliente.Comandos
{
    public class AgregarCancelacionClienteComando
    {
        public string IdCliente { get; init; }
        public string Motivo { get; init; }
    }
}
