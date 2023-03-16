using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Generico
{
    public class BodegaEvento
    {
        public string AlmacenadoId { get; set; }
        public string AlmacenadoNombre { get; set; }
        public string AgregadoId { get; set; }
        public string CuerpoEvento { get; set; }

        //Contructor
        public BodegaEvento(string almacenadoId, string almacenadoNombre, string agregadoId, string cuerpoEvento)
        {
            AlmacenadoId = almacenadoId;
            AlmacenadoNombre = almacenadoNombre;
            AgregadoId = agregadoId;
            CuerpoEvento = cuerpoEvento;
        }

        public BodegaEvento() { }

    }
}
