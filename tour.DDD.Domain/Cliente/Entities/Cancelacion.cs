using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.ValueObjects;

namespace tour.DDD.Domain.Cliente.Entities
{
    public class Cancelacion
    {
        public CancelacionID CancelacionID { get; init; }
        public Motivo Motivo { get; private set; }

        public Cancelacion(CancelacionID id)
        {
            CancelacionID = id;
        }

        public void SetMotivo(Motivo motivo)
        {
            Motivo= motivo;
        }
    }
}
