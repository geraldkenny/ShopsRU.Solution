using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ShopsRU.API.Controllers;
using ShopsRU.API.Repositories.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ShopsRU.Tests
{
    public class CustomersControllerTest
    {
        private readonly CustomersController customersController;
        private readonly Mock<IMapper> mockMapperService;
        private readonly Mock<IUnitOfWork> mockUoWService;
        private readonly Mock<ICustomerRepository> mockCustomerRepo;
        private readonly Mock<ILogger<CustomersController>> mockLoggerService;

        public CustomersControllerTest()
        {
            mockLoggerService = new Mock<ILogger<CustomersController>>();

            mockMapperService = new Mock<IMapper>();
            mockUoWService = new Mock<IUnitOfWork>();
            mockCustomerRepo = new Mock<ICustomerRepository>();
            mockUoWService.Setup(uow => uow.CustomerRepository).Returns(mockCustomerRepo.Object);
            customersController = new CustomersController(mockMapperService.Object,
                                                          mockUoWService.Object, mockLoggerService.Object);
        }

        [Fact]
        public async Task GetCustomerByIdEndpoint_ReturnsNotFound_GivenInvaildId()
        {
            //Arrange
            int customerId = 90;

            //Act
            var actionResult = await customersController.Get(customerId).ConfigureAwait(false);

            //Assert
            Assert.IsType<NotFoundObjectResult>(actionResult);
        }
    }
}