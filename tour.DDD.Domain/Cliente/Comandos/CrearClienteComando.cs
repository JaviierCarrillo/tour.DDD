using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Cliente.Comandos
{
    public class CrearClienteComando
    {
        public string Nombre { get; init; }
        public string Apellidos { get; init; }
        public string Nacionalidad { get; init; }
        public string IdVehiculo { get; init; }

        public CrearClienteComando(string nombre, string apellidos, string nacionalidad, string idVehiculo)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Nacionalidad = nacionalidad;
            IdVehiculo = idVehiculo;

        }
    }
}
