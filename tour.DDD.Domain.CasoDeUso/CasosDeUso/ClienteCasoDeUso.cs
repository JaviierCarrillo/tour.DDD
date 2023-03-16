using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.CasoDeUso.GateWays;
using tour.DDD.Domain.CasoDeUso.GateWays.Repositorios;
using tour.DDD.Domain.Cliente.Comandos;
using tour.DDD.Domain.Cliente.Entities;
using tour.DDD.Domain.Cliente.Entities.Reconstruir;
using tour.DDD.Domain.Cliente.Eventos;
using tour.DDD.Domain.Cliente.ValueObjects;
using tour.DDD.Domain.ComunDDD;
using tour.DDD.Domain.Generico;
using static System.Formats.Asn1.AsnWriter;

namespace tour.DDD.Domain.CasoDeUso.CasosDeUso
{
    public class ClienteCasoDeUso : IClienteCasoDeUsoGateWay
    {
        private readonly IEventosAlmacenadosRepositorio<BodegaEvento> _bodegaEventosRepositorio;

        private string agregadoID;

        public ClienteCasoDeUso(IEventosAlmacenadosRepositorio<BodegaEvento> storedEventRepository)
        {
            _bodegaEventosRepositorio = storedEventRepository;
        }

        public async Task<Cliente.Entities.Cliente> CrearCliente(CrearClienteComando comando)
        {
            var cliente = new Cliente.Entities.Cliente(ClienteId.Of(Guid.NewGuid()));

            //repetir en cada funcion
            agregadoID = cliente.ClienteId.Value.ToString();

            cliente.CambiarClienteID(cliente.ClienteId);
            var datosPersonales = DatosPersonales.Crear(
                comando.Nombre,
                comando.Apellidos,
                comando.Nacionalidad
                );
            var agregadosRoot = AgregadosID.Crear(comando.IdVehiculo);


            cliente.CambiarDatosPersonales( datosPersonales );
            cliente.AgregarAgregadosRoot(agregadosRoot);
            List<EventoDeDominio> eventosDeDominio = cliente.ObtenerCambiosNoGuardados();
            await GuardarEventos(eventosDeDominio);

            //mostrar estudiante en response

            var clienteRecosntruido = new ReconstruirCliente();
            cliente = clienteRecosntruido.CrearAgregado(eventosDeDominio, cliente.ClienteId);

            return cliente;
        }

        public async Task<Cliente.Entities.Cliente> AgregarContactoCliente(AgregarContactoClienteComando comando)
        {
            var construirCliente = new ReconstruirCliente();
            var listaEventosDeDominio = await ObtenerEventosPorAgregadoID(comando.IdCliente);
            var clienteID = ClienteId.Of(Guid.Parse(comando.IdCliente));
            var reconstruirCliente = construirCliente.CrearAgregado(listaEventosDeDominio, clienteID);

            //repetir en cada funcion
            agregadoID = clienteID.Value.ToString();

            #region creacion de contacto
            var contacto = new Contacto(ContactoID.Of(Guid.NewGuid()));

            var numeroTelefono = WhatsApp.Crear(comando.NumeroTelefono);

            var correo = Correo.crear(comando.DireccionEmail);

            #endregion

            reconstruirCliente.AgregarContacto(contacto);
            reconstruirCliente.AgregarNumeroTelefono(numeroTelefono);
            reconstruirCliente.AgregarCorreo(correo);
            List<EventoDeDominio> eventos = reconstruirCliente.ObtenerCambiosNoGuardados();
            await GuardarEventos(eventos);

            //Mostrar Cliente en Response
            construirCliente = new ReconstruirCliente();
            listaEventosDeDominio = await ObtenerEventosPorAgregadoID(comando.IdCliente);
            reconstruirCliente = construirCliente.CrearAgregado(listaEventosDeDominio, clienteID);

            return reconstruirCliente;

        }

        public async Task<Cliente.Entities.Cliente> AgregarCancelacionCliente(AgregarCancelacionClienteComando comando)
        {
            var construirCliente = new ReconstruirCliente();
            var listaEventosDeDominio = await ObtenerEventosPorAgregadoID(comando.IdCliente);
            var clienteID = ClienteId.Of(Guid.Parse(comando.IdCliente));
            var reconstruirCliente = construirCliente.CrearAgregado(listaEventosDeDominio, clienteID);

            //repetir en cada funcion
            agregadoID = clienteID.Value.ToString();

            #region creacion de cancelacion
            var cancelacion = new Cancelacion(CancelacionID.Of(Guid.NewGuid()));
            var motivoCancelacion = Motivo.Crear(comando.Motivo);
            #endregion

            reconstruirCliente.AgregarCancelacion(cancelacion);
            reconstruirCliente.AgregarMotivoCancelacion(motivoCancelacion);

            List<EventoDeDominio> eventos = reconstruirCliente.ObtenerCambiosNoGuardados();
            await GuardarEventos(eventos);

            //Mostrar Cliente en Response
            construirCliente = new ReconstruirCliente();
            listaEventosDeDominio = await ObtenerEventosPorAgregadoID(comando.IdCliente);
            reconstruirCliente = construirCliente.CrearAgregado(listaEventosDeDominio, clienteID);

            return reconstruirCliente;

        }

        #region Eventos de dominio
        private async Task GuardarEventos(List<EventoDeDominio> lista)
        {
            var array = lista.ToArray();
            for(var i = 0; i<array.Length; i++)
            {

                array[i].CambiarAgregadoID(agregadoID);

                var bodega = new BodegaEvento();
                bodega.AlmacenadoId = Guid.NewGuid().ToString();
                bodega.AgregadoId = array[i].ObtenerAgregadoID();
                bodega.AlmacenadoNombre = array[i].ObtenerAgregado();
                switch(array[i])
                {
                    case ClienteCreado clienteCreado:
                        bodega.CuerpoEvento = JsonConvert.SerializeObject( clienteCreado );
                        break;
                    case DatosPersonalesAgregados datosPersonalesCambiados:
                        bodega.CuerpoEvento = JsonConvert.SerializeObject( datosPersonalesCambiados );
                        break;
                    case ContactoAgregado contactoAgregado:
                        bodega.CuerpoEvento = JsonConvert.SerializeObject(contactoAgregado );
                        break;
                    case DireccionEmailAgregada direccionEmailAgregada:
                        bodega.CuerpoEvento = JsonConvert.SerializeObject(direccionEmailAgregada);
                        break;
                    case NumeroTelefonoAgregado numeroTelefonoAgregado:
                        bodega.CuerpoEvento = JsonConvert.SerializeObject(numeroTelefonoAgregado);
                        break;
                    case CancelacionAgregada cancelacionAgregada:
                        bodega.CuerpoEvento = JsonConvert.SerializeObject(cancelacionAgregada);
                        break;
                    case MotivoCancelacionAgregada motivoCancelacionAgregada:
                        bodega.CuerpoEvento = JsonConvert.SerializeObject(motivoCancelacionAgregada);
                        break;
                    case AgregadosRootAgregados agregadosRootAgregados:
                        bodega.CuerpoEvento = JsonConvert.SerializeObject(agregadosRootAgregados);
                        break;
                }
                await _bodegaEventosRepositorio.AddAsync( bodega );
            }
            await _bodegaEventosRepositorio.SaveChangesAsync();
        }



        public async Task<List<EventoDeDominio>> ObtenerEventosPorAgregadoID(string agregadoID)
        {
            var listadoEventosGuardados = await _bodegaEventosRepositorio.ObtenerEventosPorAgregadoID( agregadoID );

            if (listadoEventosGuardados == null)
                throw new ArgumentException("No existe un agregado con ese ID");

            return listadoEventosGuardados.Select(ev =>
            {
                string nombre = $"tour.DDD.Domain.Cliente.Eventos.{ev.AlmacenadoNombre}, tour.DDD.Domain";
                Type tipo = Type.GetType(nombre);
                EventoDeDominio eventoParseado = (EventoDeDominio)JsonConvert.DeserializeObject(ev.CuerpoEvento, tipo);
                return eventoParseado;
            }).ToList();
        }
        #endregion

    }
}
