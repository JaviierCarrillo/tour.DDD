using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Transporte.ValueObjects;

namespace tour.DDD.Domain.Transporte.Entities
{
    public class Conductor
    {
        public ConductorID ConductorID { get; init; }
        public DatosPersonalesConductor DatosPersonales { get; private set; }
        public Licencia Licencia { get; private set; }

        public Conductor(ConductorID id)
        {
            ConductorID = id;
        }

        public void setDatosPersonales(DatosPersonalesConductor datosPersonales)
        {
            DatosPersonales = datosPersonales;
        }

        public void setLicencia(Licencia licencia)
        {
            Licencia = licencia;
        }

    }
}
