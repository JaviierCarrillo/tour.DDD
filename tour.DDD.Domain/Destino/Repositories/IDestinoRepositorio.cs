using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Destino.Entities;
using tour.DDD.Domain.Destino.ValueObjects;

namespace tour.DDD.Domain.Destino.Repositories
{
    public interface IDestinoRepositorio
    {
        Task<Destino.Entities.Destino> CrearDestino(Destino.Entities.Destino destino);
        Task AgregarActividad(Destino.Entities.Destino destino, Destino.Entities.Actividad actividad);
        Task AgregarReserva(Destino.Entities.Destino destino, Destino.Entities.Reserva reserva);
        Task PagarReserva(DestinoID destinoId, Pagado pagado);
    }
}
