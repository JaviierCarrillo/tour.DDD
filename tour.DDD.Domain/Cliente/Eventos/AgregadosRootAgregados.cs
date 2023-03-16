using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.ValueObjects;
using tour.DDD.Domain.ComunDDD;

namespace tour.DDD.Domain.Cliente.Eventos
{
    public class AgregadosRootAgregados : EventoDeDominio
    {
        public AgregadosID AgregadosID { get; set; }

        public AgregadosRootAgregados(AgregadosID agregadosID) : base("Cliente.AgregadosRootAgregados")
        {
            AgregadosID = agregadosID;
        }
    }
}
