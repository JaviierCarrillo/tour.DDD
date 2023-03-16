using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tour.DDD.Domain.ComunDDD
{
    public class EventoDeDominio
    {
        public string Tipo;
        private string AgregadoID;
        private string Agregado;
        private decimal TipoVersion;

        public EventoDeDominio(string tipo)
        {
            Tipo = tipo;
        }

        public string ObtenerAgregadoID() => AgregadoID;
        public string ObtenerAgregado() => Agregado;
        public decimal ObtenerTipoVerion() => TipoVersion;

        public void CambiarAgregadoID(string agregadoID) => AgregadoID = agregadoID;
        public void CambiarAgregado(string agregado) => Agregado = agregado;
        public void CambiarTipoVersion(decimal tipoVersion) => TipoVersion = tipoVersion;


    }
}
