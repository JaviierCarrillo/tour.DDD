using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using tour.DDD.Domain.Cliente.Entities;
using tour.DDD.Domain.Cliente.ValueObjects;
using tour.DDD.Domain.ComunDDD;
using tour.DDD.Domain.Transporte.Eventos;
using tour.DDD.Domain.Transporte.ValueObjects;

namespace tour.DDD.Domain.Transporte.Entities
{
    public class Transporte : AgregadoEvento
    {
        public TransporteID TransporteID { get; init; }
        public List<ClienteId> ClienteID { get; private set; }
        public Descripcion Descripcion { get; private set; }
        public ConductorID ConductorID { get; private set; }
        public VehiculoID VehiculoID { get; private set; }

        //navegacion virtual por entidades
        public virtual List<Cliente.Entities.Cliente> Clientes { get; init; }
        public virtual Conductor Conductor { get; private set; }
        public virtual Vehiculo Vehiculo { get; private set; }

        #region metodos del agregado como manejador de eventos
        public Transporte(TransporteID id)
        {
            TransporteID = id;
        }

        public void AgregarTransporteID(TransporteID transporteID)
        {
            AgregarEvento(new TransporteCreado(transporteID.ToString()));
        }

        public void AgregarDescripcion(Descripcion descripcion)
        {
            AgregarEvento(new DescripcionAgregada(descripcion));
        }

        public void AgregarDatosPersonales(DatosPersonalesConductor datosPersonales)
        {
            AgregarEvento(new DatosPersonalesConductorAgregados(datosPersonales));
        }

        public void AgregarConductor(Conductor conductor)
        {
            AgregarEvento(new ConductorAgregado(conductor));
        }

        public void AgregarLicencia(Licencia licencia)
        {
            AgregarEvento(new LicenciaAgregada(licencia));
        }

        public void AgregarCaracteristicasVehiculo(Caracteristicas caracteristicas)
        {
            AgregarEvento(new CaracteristicasAgregadas(caracteristicas));
        }

        public void AgregarVehiculo(Vehiculo vehiculo)
        {
            AgregarEvento(new VehiculoAgregado(vehiculo));
        }

        #endregion


        public void SetConductor(Conductor conductor)
        {
            Conductor = conductor;
        }
        public void SetDescripcion(Descripcion descripcion)
        {
            Descripcion = descripcion;
        }

        public void SetVehiculo(Vehiculo vehiculo)
        {
            Vehiculo = vehiculo;
        }

    }
}
