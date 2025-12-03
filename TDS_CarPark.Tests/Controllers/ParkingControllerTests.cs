using System;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using TDS_CarPark.API.Controllers;
using TDS_CarPark.API.Repository;
using TDS_CarPark.API.Models.DTO;

namespace TDS_CarPark.Tests.Controllers
{
    public class ParkingControllerTests
    {
        [Fact]
        public async Task VehicleExitReturnsNotFoundWhenRepoReturnsNull()
        {
            var repoMock = new Mock<IParkingRepository>();
            repoMock.Setup(r => r.VehicleExitAsync(It.IsAny<ParkingExitRequestDto>()))
                .ReturnsAsync((ParkingExistResultDto) null);

            var controller = new Parking();
            var dto = new ParkingExitRequestDto { VehicleReg = "TEST123" };

            var result = await controller.VehicleExit(dto, repoMock.Object);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task VehicleExitReturnsOkWhenRepoReturnsDto()
        {
            var exitDto = new ParkingExistResultDto
            {
                VehicleReg = "TEST123",
                VehicleCharge = 1.0,
                TimeIn = DateTime.UtcNow.AddMinutes(-10),
                TimeOut = DateTime.UtcNow
            };

            var repoMock = new Mock<IParkingRepository>();
            repoMock.Setup(r => r.VehicleExitAsync(It.IsAny<ParkingExitRequestDto>()))
                .ReturnsAsync(exitDto);

            var controller = new Parking();
            var dto = new ParkingExitRequestDto { VehicleReg = "TEST123" };

            var result = await controller.VehicleExit(dto, repoMock.Object);

            var ok = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(exitDto, ok.Value);
        }
    }
}
