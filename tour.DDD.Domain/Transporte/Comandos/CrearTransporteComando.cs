using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Transporte.Comandos
{
    public class CrearTransporteComando
    {
        public string descripcion { get; init; }

        public CrearTransporteComando(string descripcion)
        {
            this.descripcion = descripcion;
        }
    }
}
