using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.ValueObjects;
using tour.DDD.Domain.Destino.ValueObjects;

namespace tour.DDD.Domain.Destino.Entities
{
    public class Destino
    {
        public DestinoID DestinoID { get; init; }
        public List<ClienteId> ClienteID { get; private set; }
        public Ubicacion Ubicacion { get; private set; }
        public ActividadID ActividadID { get; private set; }
        public ReservaID ReservaID { get; private set;}

        //Navegacion virtual por entidades
        [JsonIgnore]
        public virtual List<Cliente.Entities.Cliente> Clientes { get; init; }
        public virtual Actividad Actividad { get; init; }
        public virtual Reserva Reserva { get; init; }

        //Constructor
        public Destino(DestinoID destinoId)
        {
            DestinoID = destinoId;
        }

        public void SetUbicacion(Ubicacion ubicacion)
        {
            Ubicacion= ubicacion;
        }
    }
}
