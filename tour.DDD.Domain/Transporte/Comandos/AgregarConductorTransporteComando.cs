using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Transporte.Comandos
{
    public class AgregarConductorTransporteComando
    {
        public string IdTransporte { get; init; }
        public string Nombre { get; init; }
        public string Apellidos { get; init; }
        public string Correo { get; init; }
        public string Telefono { get; init; }
        public string fechaExpedicionLicencia { get; init; }
        public string fechaVencimientoLicencia { get; init; }
        public string categoriaLicencia { get; init;}


    }
}
