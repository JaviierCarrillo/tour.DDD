using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.Entities;
using tour.DDD.Domain.Cliente.ValueObjects;

namespace tour.DDD.Domain.Cliente.Repositories
{
    public interface IClienteRepositorio
    {
        Task<Entities.Cliente> CrearCliente(Entities.Cliente cliente);
        Task AgregarContacto(Entities.Cliente cliente, Entities.Contacto contacto);
        Task AgregarCancelaciones(Entities.Cliente cliente, Entities.Cancelacion cancelacion);
        Task EditarCancelacion(ValueObjects.CancelacionID cancelacionID, Entities.Cancelacion nuevaCancelacion);
    }
}
