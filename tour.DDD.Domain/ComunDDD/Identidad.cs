using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.ComunDDD
{
    public class Identidad
    {
        public Guid Uuid { get; set; }

        public Identidad(Guid uuid)
        {
            if(uuid == null)
            
                throw new ArgumentNullException("La identiicacion no puede estar vacía");
            Uuid = uuid;
            
        }
    }
}
