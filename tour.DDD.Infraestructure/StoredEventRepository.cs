using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.CasoDeUso.GateWays.Repositorios;
using tour.DDD.Domain.Generico;

namespace tour.DDD.Infraestructure
{
    public class StoredEventRepository<T> : RepositoryBase<T>, IEventosAlmacenadosRepositorio<T> where T : class
    {
        private readonly DataBaseContext dataBaseContext;
        public StoredEventRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public async Task<List<BodegaEvento>> ObtenerEventosPorAgregadoID(string agregadoID)
        {
            return dataBaseContext.EventosAlmacenados.Where(evento => evento.AgregadoId == agregadoID).ToList();
        }
    }
}
