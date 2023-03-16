using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.Comandos;

namespace tour.DDD.Domain.CasoDeUso.GateWays
{
    public interface IClienteCasoDeUsoGateWay
    {
        Task<Cliente.Entities.Cliente> CrearCliente(CrearClienteComando crearClienteComando);
        Task<Cliente.Entities.Cliente> AgregarContactoCliente(AgregarContactoClienteComando agregarContactoClienteComando);
        Task<Cliente.Entities.Cliente> AgregarCancelacionCliente(AgregarCancelacionClienteComando agregarCancelacionClienteComando);
    }
}
