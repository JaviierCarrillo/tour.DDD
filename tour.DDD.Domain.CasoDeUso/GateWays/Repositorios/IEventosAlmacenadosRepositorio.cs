using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Generico;

namespace tour.DDD.Domain.CasoDeUso.GateWays.Repositorios
{
    public interface IEventosAlmacenadosRepositorio<T> : IRepositoryBase<T> where T : class
    {
        Task<List<BodegaEvento>> ObtenerEventosPorAgregadoID(string agregadoID);
    }
}
