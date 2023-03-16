using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Transporte.Comandos;

namespace Pruebas.Builder.Transporte
{
    public class CrearTransporteComandoBuilder
    {
        private string _descripcion;

        public CrearTransporteComandoBuilder WithDescription(string descripcion)
        {
            _descripcion = descripcion;
            return this;
        }
        public CrearTransporteComando Build()
        {
            return new CrearTransporteComando(_descripcion);
        }
    }
}
