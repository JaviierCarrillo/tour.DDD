using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Transporte.Comandos
{
    public class AgregarVehiculoTransporteComando
    {
        public string IdTransporte { get; init; }
        public string Modelo { get; init; }
        public string Marca { get; init; }
        public int CantidadPasajeros { get; init; }
        public string TipoCombustible { get; init; }
    }
}
