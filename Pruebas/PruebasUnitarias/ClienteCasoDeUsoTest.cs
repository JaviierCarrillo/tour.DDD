using Moq;
using Pruebas.Builder;
using Pruebas.Builder.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.CasoDeUso.CasosDeUso;
using tour.DDD.Domain.CasoDeUso.GateWays.Repositorios;
using tour.DDD.Domain.Cliente.Comandos;
using tour.DDD.Domain.Generico;

namespace Pruebas.PruebasUnitarias
{
    public class ClienteCasoDeUsoTest
    {
        private readonly Mock<IEventosAlmacenadosRepositorio<BodegaEvento>> _mockRepository;

        public ClienteCasoDeUsoTest()
        {
            _mockRepository = new();
        }

        [Fact]
        public async Task CrearCliente()
        {
            //Arrange
            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<BodegaEvento>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GetStoredEvent);

            _mockRepository.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<int>(200));

            //Act
            var casoDeUso = new ClienteCasoDeUso(_mockRepository.Object);
            await casoDeUso.CrearCliente(GetClienteComando());

            //Assert
            _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<BodegaEvento>(), It.IsAny<CancellationToken>()), Times.Exactly(3));

            _mockRepository.Verify(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(1));
        }

        private CrearClienteComando GetClienteComando() =>
            new CrearClienteComandoBuilder()
            .WithNombre("nombre cliente prueba")
            .WithApellidos("apellidos cliente prueba")
            .WithNacionalidad("Nacionalidad cliente prueba")
            .WithIdVehiculo("d8696ea4-3b36-41c0-abfb-ae00df024d5f")
            .Build();


        private BodegaEvento GetStoredEvent() =>
            new BodegaDeEventosBuilder()
                .WithStoredId("d8696ea4-3b36-41c0-abfb-ae00df024d5f")
                .WithStoredName("ClienteCreado")
                .WithAggregateId("Aggregate1")
                .WithEventBody("{\"Tipo\":\"Cliente.creado\",\"ClienteId\":\"tour.DDD.Domain.Cliente.ValueObjects.ClienteId\"}")
                .Build();

    }
}
