using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.Destino.ValueObjects
{
    public record Pagado
    {
        public bool EsPagado { get; set; } = false;
        public string MedioDepago { get; set; }

        private Pagado(bool esPagado, string medioDepago)
        {
            EsPagado = esPagado;
            MedioDepago = medioDepago;
        }

        public static Pagado Crear(bool esPagado, string medioDepago)
        {

            return new Pagado(esPagado, medioDepago);
        }

        //Validaciones del Value Object
        public static void EsValido(bool esPagado, string medioDepago)
        {
            if (esPagado && medioDepago == null)
                throw new Exception("Debe ingresar un medio de pago");
        }
    }
}
