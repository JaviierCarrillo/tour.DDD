using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.Eventos;
using tour.DDD.Domain.Cliente.ValueObjects;
using tour.DDD.Domain.ComunDDD;
using tour.DDD.Domain.Destino.ValueObjects;
using tour.DDD.Domain.Transporte.ValueObjects;

namespace tour.DDD.Domain.Cliente.Entities
{
    public class Cliente : AgregadoEvento
    {
        //variables
        public ClienteId ClienteId { get; init; }
        public ContactoID ContactoID { get; private set; }

        public AgregadosID AgregadosID { get; private set; }
        public DatosPersonales DatosPersonales { get; private set; }

        //navegacion virtual por entidades

        public virtual Contacto Contacto { get; private set; }
        public virtual Cancelacion Cancelacion { get; private set; }



        #region Metodos del agregado como manejador de eventos
        public Cliente(ClienteId clienteId)
        {
            ClienteId = clienteId;
        }

        public void CambiarClienteID(ClienteId clienteId)
        {
            AgregarEvento(new ClienteCreado(clienteId.ToString()));
        }

        public void CambiarDatosPersonales(DatosPersonales datosPersonales)
        {
            AgregarEvento(new DatosPersonalesAgregados(datosPersonales));
        }

        //Referencia a los agregados root
        public void AgregarAgregadosRoot(AgregadosID agregadosID)
        {
            AgregarEvento(new AgregadosRootAgregados(agregadosID));
        }

        public void AgregarContacto(Contacto contacto)
        {
            AgregarEvento(new ContactoAgregado(contacto));
        }

        public void AgregarCancelacion(Cancelacion cancelacion)
        {
            AgregarEvento(new CancelacionAgregada(cancelacion));
        }

        public void AgregarMotivoCancelacion(Motivo motivo)
        {
            AgregarEvento(new MotivoCancelacionAgregada(motivo));
        }

        public void AgregarNumeroTelefono(WhatsApp whatsApp)
        {
            AgregarEvento(new NumeroTelefonoAgregado(whatsApp));
        }

        public void AgregarCorreo(Correo correo)
        {
            AgregarEvento(new DireccionEmailAgregada(correo));
        }

        #endregion

        public void SetDatosPersonales(DatosPersonales datosPersonales)
        {
            DatosPersonales = datosPersonales;
        }

        public void SetContacto(Contacto contacto)
        {
            Contacto = contacto;
        }

        public void SetCancelacion(Cancelacion cancelacion)
        {
            Cancelacion = cancelacion;
        }

        public void SetAgregadosRootID(AgregadosID agregadosID)
        {
            AgregadosID = agregadosID;
        }

    }
}
