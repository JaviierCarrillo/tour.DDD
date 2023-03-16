using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.CasoDeUso.GateWays;
using tour.DDD.Domain.CasoDeUso.GateWays.Repositorios;
using tour.DDD.Domain.Cliente.Eventos;
using tour.DDD.Domain.Cliente.ValueObjects;
using tour.DDD.Domain.ComunDDD;
using tour.DDD.Domain.Generico;
using tour.DDD.Domain.Transporte.Comandos;
using tour.DDD.Domain.Transporte.Entities;
using tour.DDD.Domain.Transporte.Entities.Reconstruir;
using tour.DDD.Domain.Transporte.Eventos;
using tour.DDD.Domain.Transporte.ValueObjects;

namespace tour.DDD.Domain.CasoDeUso.CasosDeUso
{
    public class TransporteCasoDeUso : ITransporteCasoDeUsoGateWay
    {

        private readonly IEventosAlmacenadosRepositorio<BodegaEvento> _bodegaEventosRepositorio;

        private string agregadoID;

        public TransporteCasoDeUso(IEventosAlmacenadosRepositorio<BodegaEvento> storedEventRepository)
        {
            _bodegaEventosRepositorio = storedEventRepository;
        }

        public async Task<Transporte.Entities.Transporte> CrearTransporte(CrearTransporteComando crearTransporteComando)
        {
            var transporte = new Transporte.Entities.Transporte(TransporteID.Of(Guid.NewGuid()));

            //repetir en cada funcion
            agregadoID = transporte.TransporteID.Value.ToString();

            transporte.AgregarTransporteID(transporte.TransporteID);
            var descripcion = Descripcion.Crear(crearTransporteComando.descripcion);

            transporte.AgregarDescripcion(descripcion);
            List<EventoDeDominio> eventosDeDominio = transporte.ObtenerCambiosNoGuardados();
            await GuardarEventos(eventosDeDominio);

            //mostrar transporte en response
            var transporteReconstruido = new ReconstruirTransporte();
            transporte = transporteReconstruido.CrearAgregado(eventosDeDominio, transporte.TransporteID);
            return transporte;
        }


        public async Task<Transporte.Entities.Transporte> AgregarConductorTransporte(AgregarConductorTransporteComando comando)
        {
            var contruirTransporte = new ReconstruirTransporte();
            var listaEventosDeDominio = await ObtenerEventosPorAgregadoID(comando.IdTransporte);
            var transporteID = TransporteID.Of(Guid.Parse(comando.IdTransporte));
            var reconstruirTransporte = contruirTransporte.CrearAgregado(listaEventosDeDominio, transporteID);

            //repetir en cada funcion
            agregadoID = transporteID.Value.ToString();

            #region creacion de conductor

            var Conductor = new Conductor(ConductorID.Of(Guid.NewGuid()));

            var datosPersonalesConductor = DatosPersonalesConductor.Crear(
                comando.Nombre,
                comando.Apellidos,
                comando.Correo,
                comando.Telefono);

            var licencia = Licencia.Crear(
                comando.fechaExpedicionLicencia,
                comando.fechaVencimientoLicencia,
                comando.categoriaLicencia
                );

            #endregion

            reconstruirTransporte.AgregarConductor(Conductor);
            reconstruirTransporte.AgregarDatosPersonales(datosPersonalesConductor);
            reconstruirTransporte.AgregarLicencia(licencia);

            List<EventoDeDominio> eventos = reconstruirTransporte.ObtenerCambiosNoGuardados();
            await GuardarEventos(eventos);

            //mostrar transporte en response
            
            contruirTransporte    = new ReconstruirTransporte();
            listaEventosDeDominio = await ObtenerEventosPorAgregadoID(comando.IdTransporte);
            reconstruirTransporte = contruirTransporte.CrearAgregado(listaEventosDeDominio, transporteID);
            
            return reconstruirTransporte;

        }

        public async Task<Transporte.Entities.Transporte> AgregarVehiculoTransporte(AgregarVehiculoTransporteComando comando)
        {
            var contruirTransporte = new ReconstruirTransporte();
            var listaEventosDeDominio = await ObtenerEventosPorAgregadoID(comando.IdTransporte);
            var transporteID = TransporteID.Of(Guid.Parse(comando.IdTransporte));
            var reconstruirTransporte = contruirTransporte.CrearAgregado(listaEventosDeDominio, transporteID);

            //repetir en cada funcion
            agregadoID = transporteID.Value.ToString();

            #region creacion de vehiculo

            var Vehiculo = new Vehiculo(VehiculoID.Of(Guid.NewGuid()));

            var caracteristicasVehiculo = Caracteristicas.Crear(
                comando.Marca,
                comando.Modelo,
                comando.CantidadPasajeros,
                comando.TipoCombustible
                );
            #endregion

            reconstruirTransporte.AgregarVehiculo(Vehiculo);
            reconstruirTransporte.AgregarCaracteristicasVehiculo(caracteristicasVehiculo);

            List<EventoDeDominio> eventos = reconstruirTransporte.ObtenerCambiosNoGuardados();
            await GuardarEventos(eventos);

            //mostrar transporte en response
            contruirTransporte = new ReconstruirTransporte();
            listaEventosDeDominio = await ObtenerEventosPorAgregadoID(comando.IdTransporte);
            reconstruirTransporte = contruirTransporte.CrearAgregado(listaEventosDeDominio, transporteID);

            return reconstruirTransporte;
        }

        /*
        public async Task<Transporte.Entities.Transporte> ObtenerTransportePorID(string idTransporte)
        {
            var eventosDeDominio = await _bodegaEventosRepositorio.ObtenerEventosPorAgregadoID(idTransporte);
            var transporteReconstruido = new ReconstruirTransporte();
            var transporteID = TransporteID.Of(Guid.Parse(idTransporte));
            var transporte = transporteReconstruido.CrearAgregado(eventosDeDominio, transporteID);
            return transporte;
        }
        */


        #region Eventos de dominio
        private async Task GuardarEventos(List<EventoDeDominio> lista)
        {
            var array = lista.ToArray();
            for (var i = 0; i < array.Length; i++)
            {

                array[i].CambiarAgregadoID(agregadoID);

                var bodega = new BodegaEvento();
                bodega.AlmacenadoId = Guid.NewGuid().ToString();
                bodega.AgregadoId = array[i].ObtenerAgregadoID();
                bodega.AlmacenadoNombre = array[i].ObtenerAgregado();
                switch (array[i])
                {
                    case TransporteCreado transporteCreado:
                        bodega.CuerpoEvento = JsonConvert.SerializeObject(transporteCreado);
                        break;
                    case DescripcionAgregada descripcionAgregada:
                        bodega.CuerpoEvento = JsonConvert.SerializeObject(descripcionAgregada);
                        break;
                    case ConductorAgregado conductorAgregado:
                        bodega.CuerpoEvento = JsonConvert.SerializeObject(conductorAgregado);
                        break;
                    case DatosPersonalesConductorAgregados datosPersonalesAgregados:
                        bodega.CuerpoEvento = JsonConvert.SerializeObject(datosPersonalesAgregados);
                        break;
                    case LicenciaAgregada licenciaAgregada:
                        bodega.CuerpoEvento = JsonConvert.SerializeObject(licenciaAgregada);
                        break;
                    case VehiculoAgregado vehiculoAgregado:
                        bodega.CuerpoEvento = JsonConvert.SerializeObject(vehiculoAgregado);
                        break;
                    case CaracteristicasAgregadas caracteristicasAgregadas:
                        bodega.CuerpoEvento = JsonConvert.SerializeObject(caracteristicasAgregadas);
                        break;
                }
                await _bodegaEventosRepositorio.AddAsync(bodega);
            }
            await _bodegaEventosRepositorio.SaveChangesAsync();
        }



        public async Task<List<EventoDeDominio>> ObtenerEventosPorAgregadoID(string agregadoID)
        {
            var listadoEventosGuardados = await _bodegaEventosRepositorio.ObtenerEventosPorAgregadoID(agregadoID);

            if (listadoEventosGuardados == null)
                throw new ArgumentException("No existe un agregado con ese ID");

            return listadoEventosGuardados.Select(ev =>
            {
                string nombre = $"tour.DDD.Domain.Transporte.Eventos.{ev.AlmacenadoNombre}, tour.DDD.Domain";
                Type tipo = Type.GetType(nombre);
                EventoDeDominio eventoParseado = (EventoDeDominio)JsonConvert.DeserializeObject(ev.CuerpoEvento, tipo);
                return eventoParseado;
            }).ToList();
        }
        #endregion

    }
}
