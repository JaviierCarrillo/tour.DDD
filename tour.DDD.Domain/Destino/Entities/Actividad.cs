using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Destino.ValueObjects;

namespace tour.DDD.Domain.Destino.Entities
{
    public class Actividad
    {
        public ActividadID ActividadID { get; init; }
        public Descripcion Descripcion { get; private set; }
        public Precio Precio { get; private set; }

        public Actividad(ActividadID actividadID)
        {
            ActividadID = actividadID;
        }

        public void SetDescripcion(Descripcion descripcion)
        {
            Descripcion= descripcion;
        }

        public void SetPrecio(Precio precio)
        {
            Precio= precio;
        }
    }
}
