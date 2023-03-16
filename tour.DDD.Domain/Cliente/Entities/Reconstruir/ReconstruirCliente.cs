using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.Eventos;
using tour.DDD.Domain.Cliente.ValueObjects;
using tour.DDD.Domain.ComunDDD;

namespace tour.DDD.Domain.Cliente.Entities.Reconstruir
{
    public class ReconstruirCliente
    {
        
        public Cliente CrearAgregado(List<EventoDeDominio> eventos, ClienteId clienteId)
        {
            Cliente cliente = new(clienteId);

            if(eventos.Find(e => e.GetType() == typeof(ContactoAgregado)) is ContactoAgregado contactoAgregadoEvento)
            {
                cliente.SetContacto(contactoAgregadoEvento.Contacto);
            }

            if (eventos.Find(e => e.GetType() == typeof(CancelacionAgregada)) is CancelacionAgregada motivoCancelacionEvento)
            {
                cliente.SetCancelacion(motivoCancelacionEvento.Cancelacion);
            }


            eventos.ForEach(e =>
            {
                switch (e)
                {
                    //cliente
                    case DatosPersonalesAgregados datosPersonalesAgregados:
                        cliente.SetDatosPersonales(datosPersonalesAgregados.DatosPersonales);
                        break;
                    case DireccionEmailAgregada direccionEmailAgregada:
                        cliente.Contacto.SetCorreo(direccionEmailAgregada.Correo);
                        break;
                    case NumeroTelefonoAgregado numeroTelefonoAgregado:
                        cliente.Contacto.SetWhatsApp(numeroTelefonoAgregado.whatsApp);
                        break;
                    case MotivoCancelacionAgregada motivoCancelacionAgregada:
                        cliente.Cancelacion.SetMotivo(motivoCancelacionAgregada.Motivo);
                        break;
                    case AgregadosRootAgregados agregadosRootAgregados:
                        cliente.SetAgregadosRootID(agregadosRootAgregados.AgregadosID);
                        break;
                }
            });
            return cliente;
        }
        
    }
}
