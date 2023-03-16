using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.ComunDDD
{
    public class Entidad<T> where T : Identidad
    {
        protected T entidadID;

        public Entidad(T entidadID)
        {
            this.entidadID = entidadID;
        }

        public T Identidad() => entidadID;
    }
}
