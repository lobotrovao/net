using Application.Service;
using Domain.Endpoint.Enum;
using Domain.Endpoint.Model;
using Domain.Endpoint.Repository;
using Domain.Endpoint.Service;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EndpointManagerTest
{
    public class EndpointServiceTest
    {
        [Fact]
        public async Task CreateEndpointSuccess()
        {
            Mock<IEndpointRepository> mock = new Moq.Mock<IEndpointRepository>();
            mock.Setup(x => x.Add(It.IsAny<EndpointEntity>()))
                .ReturnsAsync(
                    new EndpointEntity() { 
                        Id = 1, 
                        SerialNumber = "0001",
                        ModelId = EndpointModelType.NSX1P3W.Id,
                        MeterNumber = 10,
                        FirmwareVersion = "1.3.1",
                        State = SwitchStateType.Disconnected.Id
                    });
            ////mock.Setup(x => x.GetEndpointBySerialNumber(It.IsAny<string>())).ReturnsAsync();

            IEndpointService endpointService = new EndpointService(mock.Object);

            var endpoint = new EndpointEntity()
            {
                SerialNumber = "0001",
                ModelId = EndpointModelType.NSX1P3W.Id,
                MeterNumber = 10,
                FirmwareVersion = "1.3.1",
                State = SwitchStateType.Disconnected.Id
            };

            var result = await endpointService.CreateNewEndpoint(endpoint);

            Assert.Equal(1, result.Id);
            Assert.Equal(endpoint.SerialNumber, result.SerialNumber);
            Assert.Equal(endpoint.ModelId, result.ModelId);
            Assert.Equal(endpoint.MeterNumber, result.MeterNumber);
            Assert.Equal(endpoint.FirmwareVersion, result.FirmwareVersion);
            Assert.Equal(endpoint.State, result.State);
        }

        [Fact]
        public async Task SerialNumberAlreadyExistsTest()
        {
            Mock<IEndpointRepository> mock = new Moq.Mock<IEndpointRepository>();
            mock.Setup(x => x.Add(It.IsAny<EndpointEntity>()))
                .ReturnsAsync(
                    new EndpointEntity()
                    {
                        Id = 1,
                        SerialNumber = "0001",
                        ModelId = EndpointModelType.NSX1P3W.Id,
                        MeterNumber = 10,
                        FirmwareVersion = "1.3.1",
                        State = SwitchStateType.Disconnected.Id
                    });

            mock.Setup(x => x.GetEndpointBySerialNumber(It.IsAny<string>()))
                .ReturnsAsync(
                new EndpointEntity() { 
                    Id = 1, 
                    SerialNumber = "0001" 
                });

            IEndpointService endpointService = new EndpointService(mock.Object);

            var endpoint = new EndpointEntity()
            {
                SerialNumber = "0001",
                ModelId = EndpointModelType.NSX1P3W.Id,
                MeterNumber = 10,
                FirmwareVersion = "1.3.1",
                State = SwitchStateType.Disconnected.Id
            };

            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(async () => await endpointService.CreateNewEndpoint(endpoint));
            Assert.Equal("Serial Number already exists!", exception.Message);
        }

        [Fact]
        public async Task SerialNumberEmptyOrNullTest()
        {
            Mock<IEndpointRepository> mock = new Moq.Mock<IEndpointRepository>();

            IEndpointService endpointService = new EndpointService(mock.Object);

            var endpoint = new EndpointEntity()
            {
                SerialNumber = string.Empty,
                ModelId = EndpointModelType.NSX1P3W.Id,
                MeterNumber = 10,
                FirmwareVersion = "1.3.1",
                State = SwitchStateType.Disconnected.Id
            };

            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(async () => await endpointService.CreateNewEndpoint(endpoint));
            Assert.Equal("Serial number must be informed!", exception.Message);
        }

        [Fact]
        public async Task ModelIdInvalidTest()
        {
            Mock<IEndpointRepository> mock = new Moq.Mock<IEndpointRepository>();

            IEndpointService endpointService = new EndpointService(mock.Object);

            var endpoint = new EndpointEntity()
            {
                SerialNumber = "0001",
                ModelId = 20,
                MeterNumber = 10,
                FirmwareVersion = "1.3.1",
                State = SwitchStateType.Disconnected.Id
            };

            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(async () => await endpointService.CreateNewEndpoint(endpoint));
            Assert.Equal("Inexistent model!", exception.Message);
        }

        [Fact]
        public async Task FirmwareVersionInvalidTest()
        {
            Mock<IEndpointRepository> mock = new Moq.Mock<IEndpointRepository>();

            IEndpointService endpointService = new EndpointService(mock.Object);

            var endpoint = new EndpointEntity()
            {
                SerialNumber = "0001",
                ModelId = EndpointModelType.NSX1P3W.Id,
                MeterNumber = 10,
                FirmwareVersion = string.Empty,
                State = SwitchStateType.Disconnected.Id
            };

            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(async () => await endpointService.CreateNewEndpoint(endpoint));
            Assert.Equal("Firmeware version must be informed!", exception.Message);
        }

        [Fact]
        public async Task SwitchStateInvalidTest()
        {
            Mock<IEndpointRepository> mock = new Moq.Mock<IEndpointRepository>();

            IEndpointService endpointService = new EndpointService(mock.Object);

            var endpoint = new EndpointEntity()
            {
                SerialNumber = "0001",
                ModelId = EndpointModelType.NSX1P3W.Id,
                MeterNumber = 10,
                FirmwareVersion = "1.3.1",
                State = 30
            };

            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(async () => await endpointService.CreateNewEndpoint(endpoint));
            Assert.Equal("Inexistent state!", exception.Message);
        }

        [Fact]
        public async Task UpdateTest()
        {
            Mock<IEndpointRepository> mock = new Mock<IEndpointRepository>();
            mock.Setup(x => x.GetEndpointBySerialNumber(It.IsAny<string>()))
                .ReturnsAsync(
                new EndpointEntity()
                {
                    Id = 1,
                    SerialNumber = "0001"
                });

            IEndpointService endpointService = new EndpointService(mock.Object);

            var endpoint = new EndpointEntity()
            {
                Id  = 1,
                SerialNumber = "0001",
                ModelId = EndpointModelType.NSX1P3W.Id,
                MeterNumber = 10,
                FirmwareVersion = "1.3.1",
                State = SwitchStateType.Disconnected.Id
            };

            await endpointService.UpdateEndpoint(endpoint);

            Assert.True(true);
        }

        [Fact]
        public async Task UpdateErrorSerialNotFoundTest()
        {
            Mock<IEndpointRepository> mock = new Mock<IEndpointRepository>();

            IEndpointService endpointService = new EndpointService(mock.Object);

            var endpoint = new EndpointEntity()
            {
                Id = 1,
                SerialNumber = "0001",
                ModelId = EndpointModelType.NSX1P3W.Id,
                MeterNumber = 10,
                FirmwareVersion = "1.3.1",
                State = SwitchStateType.Disconnected.Id
            };

            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(async () => await endpointService.UpdateEndpoint(endpoint));
            Assert.Equal("Serial Number not found!", exception.Message);
        }

        [Fact]
        public async Task DeleteTest()
        {
            Mock<IEndpointRepository> mock = new Mock<IEndpointRepository>();
            mock.Setup(x => x.GetEndpointBySerialNumber(It.IsAny<string>()))
                .ReturnsAsync(
                new EndpointEntity()
                {
                    Id = 1,
                    SerialNumber = "0001"
                });

            IEndpointService endpointService = new EndpointService(mock.Object);

            var endpoint = new EndpointEntity()
            {
                Id = 1,
                SerialNumber = "0001",
                ModelId = EndpointModelType.NSX1P3W.Id,
                MeterNumber = 10,
                FirmwareVersion = "1.3.1",
                State = SwitchStateType.Disconnected.Id
            };

            await endpointService.DeleteEndpoint(endpoint);

            Assert.True(true);
        }

        [Fact]
        public async Task DeleteSerialNotFoundTest()
        {
            Mock<IEndpointRepository> mock = new Mock<IEndpointRepository>();

            IEndpointService endpointService = new EndpointService(mock.Object);

            var endpoint = new EndpointEntity()
            {
                Id = 1,
                SerialNumber = "0001",
                ModelId = EndpointModelType.NSX1P3W.Id,
                MeterNumber = 10,
                FirmwareVersion = "1.3.1",
                State = SwitchStateType.Disconnected.Id
            };

            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(async () => await endpointService.DeleteEndpoint(endpoint));
            Assert.Equal("Serial Number not found!", exception.Message);
        }

        [Fact]
        public async Task GetEndpointBySerialNumberTest()
        {
            Mock<IEndpointRepository> mock = new Mock<IEndpointRepository>();
            mock.Setup(x => x.GetEndpointBySerialNumber(It.IsAny<string>()))
                .ReturnsAsync(
                new EndpointEntity()
                {
                    Id = 1,
                    SerialNumber = "0001",
                    ModelId = EndpointModelType.NSX1P3W.Id,
                    MeterNumber = 10,
                    FirmwareVersion = "1.3.1",
                    State = SwitchStateType.Disconnected.Id
                });

            IEndpointService endpointService = new EndpointService(mock.Object);

            var endpoint = new EndpointEntity()
            {
                Id = 1,
                SerialNumber = "0001",
                ModelId = EndpointModelType.NSX1P3W.Id,
                MeterNumber = 10,
                FirmwareVersion = "1.3.1",
                State = SwitchStateType.Disconnected.Id
            };

            var result = await endpointService.GetEndpointBySerialNumber(endpoint.SerialNumber);

            Assert.Equal(1, result.Id);
            Assert.Equal(endpoint.SerialNumber, result.SerialNumber);
            Assert.Equal(endpoint.ModelId, result.ModelId);
            Assert.Equal(endpoint.MeterNumber, result.MeterNumber);
            Assert.Equal(endpoint.FirmwareVersion, result.FirmwareVersion);
            Assert.Equal(endpoint.State, result.State);
        }

        [Fact]
        public async Task GetEndpointBySerialNumberNotFoundTest()
        {
            Mock<IEndpointRepository> mock = new Mock<IEndpointRepository>();

            IEndpointService endpointService = new EndpointService(mock.Object);

            var endpoint = new EndpointEntity()
            {
                Id = 1,
                SerialNumber = "0001",
                ModelId = EndpointModelType.NSX1P3W.Id,
                MeterNumber = 10,
                FirmwareVersion = "1.3.1",
                State = SwitchStateType.Disconnected.Id
            };

            ArgumentException exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await endpointService.GetEndpointBySerialNumber(endpoint.SerialNumber));
            Assert.Equal("Value cannot be null. (Parameter 'Endpoint not found')", exception.Message);
        }
    }
}