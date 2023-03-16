using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.ComunDDD;
using tour.DDD.Domain.Transporte.Eventos;
using tour.DDD.Domain.Transporte.ValueObjects;

namespace tour.DDD.Domain.Transporte.Entities.Reconstruir
{
    public class ReconstruirTransporte
    {
        public Transporte CrearAgregado(List<EventoDeDominio> eventos, TransporteID transporteID)
        {
            Transporte transporte = new(transporteID);


            if (eventos.Find(e => e.GetType() == typeof(ConductorAgregado)) is ConductorAgregado conductorAgregadoEvento)
            {
                transporte.SetConductor(conductorAgregadoEvento.Conductor);
            }

            if (eventos.Find(e => e.GetType() == typeof(VehiculoAgregado)) is VehiculoAgregado vehiculoAgregadoEvento)
            {
                transporte.SetVehiculo(vehiculoAgregadoEvento.Vehiculo);
            }

            eventos.ForEach(e =>
            {
                switch (e)
                {
                    //transporte
                    case DescripcionAgregada descripcionAgregada:
                        transporte.SetDescripcion(descripcionAgregada.Descripcion);
                        break;
                    case DatosPersonalesConductorAgregados datosAgregados:
                        transporte.Conductor.setDatosPersonales(datosAgregados.DatosPersonalesConductor);
                        break;
                    case LicenciaAgregada licenciaAgregada:
                        transporte.Conductor.setLicencia(licenciaAgregada.Licencia);
                        break;
                    case CaracteristicasAgregadas caracteristicasAgregadas:
                        transporte.Vehiculo.setCaracteristicas(caracteristicasAgregadas.Caracteristicas);
                        break;
                }
            });
            return transporte;
        }
    }
}
