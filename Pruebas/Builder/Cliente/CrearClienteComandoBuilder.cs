using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.Comandos;

namespace Pruebas.Builder.Cliente
{
    public class CrearClienteComandoBuilder
    {
        public string _nombre;
        public string _apellidos;
        public string _nacionalidad;
        public string _idVehiculo;

        public CrearClienteComandoBuilder WithNombre(string nombre)
        {
            _nombre = nombre;
            return this;
        }

        public CrearClienteComandoBuilder WithApellidos(string apellidos)
        {
            _apellidos = apellidos;
            return this;
        }

        public CrearClienteComandoBuilder WithNacionalidad(string nacionalidad)
        {
            _nacionalidad = nacionalidad;
            return this;
        }

        public CrearClienteComandoBuilder WithIdVehiculo(string idVehiculo)
        {
            _idVehiculo = idVehiculo;
            return this;
        }

        public CrearClienteComando Build()
        {
            return new CrearClienteComando(_nombre, _apellidos, _nacionalidad, _idVehiculo);
        }
    }
}
