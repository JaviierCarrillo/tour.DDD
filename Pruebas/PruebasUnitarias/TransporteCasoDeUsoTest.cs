using Moq;
using Pruebas.Builder;
using Pruebas.Builder.Transporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.CasoDeUso.CasosDeUso;
using tour.DDD.Domain.CasoDeUso.GateWays.Repositorios;
using tour.DDD.Domain.Cliente.Comandos;
using tour.DDD.Domain.Generico;
using tour.DDD.Domain.Transporte.Comandos;
using tour.DDD.Domain.Transporte.Entities;

namespace Pruebas.PruebasUnitarias
{
    public class TransporteCasoDeUsoTest
    {
        private readonly Mock<IEventosAlmacenadosRepositorio<BodegaEvento>> _mockRepository;

        public TransporteCasoDeUsoTest()
        {
            _mockRepository = new();
        }

        [Fact]
        public async Task CrearTransporte()
        {
            //Arrange
            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<BodegaEvento>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GetStoredEvent);

            _mockRepository.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<int>(200));

            //Act
            var casoDeUso = new TransporteCasoDeUso(_mockRepository.Object);
            await casoDeUso.CrearTransporte(GetTransporteComando());

            //Assert
            _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<BodegaEvento>(), It.IsAny<CancellationToken>()), Times.Exactly(2));

            _mockRepository.Verify(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(1));
        }


        private CrearTransporteComando GetTransporteComando()=>
            new CrearTransporteComandoBuilder()
            .WithDescription("Descripcion prueba")
            .Build();


        private BodegaEvento GetStoredEvent() =>
            new BodegaDeEventosBuilder()
                .WithStoredId("d8696ea4-3b36-41c0-abfb-ae00df024d5f")
                .WithStoredName("TransporteCreado")
                .WithAggregateId("Aggregate1")
                .WithEventBody("{\"Tipo\":\"Transporte.creado\",\"TransporteId\":\"tour.DDD.Domain.Transporte.ValueObjects.TransporteID\"}")
                .Build();
    }
}
