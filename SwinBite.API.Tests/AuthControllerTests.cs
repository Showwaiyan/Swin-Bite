using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SwinBite.Controller;
using SwinBite.DTO;
using SwinBite.Interface;
using SwinBite.Mappings;
using SwinBite.Models;
using Xunit;

namespace SwinBite.API.Tests
{
    public class AuthControllerTests
    {
        private readonly AuthController _controller;
        private readonly Mock<IUserServices> _mockUserServices;
        private readonly Mock<ICustomerServices> _mockCustomerServices;
        private readonly IMapper _mapper;

        public AuthControllerTests()
        {
            _mockUserServices = new Mock<IUserServices>();
            _mockCustomerServices = new Mock<ICustomerServices>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = config.CreateMapper();
            _controller = new AuthController(
                _mockUserServices.Object,
                _mockCustomerServices.Object,
                _mapper
            );
        }

        [Fact]
        public async void CustomerRegister_WithValidCredentials_ReturnsOkResult()
        {
            CreateCustomerDto registerCustomer = new CreateCustomerDto
            {
                Username = "John",
                Email = "johnsnow@gmail.com",
                Password = "12345",
                PasswordConfirmed = "12345",
                Address = "Fake",
            };

            Customer exceptedUser = new Customer
            {
                UserId = 1,
                Username = registerCustomer.Username,
                Password = registerCustomer.Password,
                IsAuthenticated = true,
                UserType = UserType.Customer,
                Address = "Fake",
            };

            _mockUserServices
                .Setup(userService =>
                    userService.Login(It.IsAny<string>(), It.IsAny<string>()).Result
                )
                .Returns(exceptedUser);

            // 4. Create a fake login request model with valid credentials
            // (e.g., a DTO like LoginRequest with Email and Password)
            // var loginRequest = new LoginRequest { Email = "test@example.com", Password = "password123" };

            // Act
            // 5. Call the controller's Login action
            // var result = controller.Login(loginRequest);
            var result = await _controller.Register(registerCustomer);
            Assert.IsType<OkObjectResult>(result);

            var oKResult = result as OkObjectResult;
            Assert.NotNull(oKResult);

            var respondValue = oKResult.Value as UserDto;
            Assert.Equivalent(exceptedUser, respondValue);

            // Assert
            // 6. Check that the result is of type OkObjectResult or whatever is expected

            // 7. Optionally, verify that the service's Login method was called once
            // mockUserService.Verify(s => s.Login(loginRequest.Email, loginRequest.Password), Times.Once);
        }
    }
}
