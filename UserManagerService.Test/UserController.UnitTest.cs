using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagerService.Controllers;
using UserManagerService.Data.Repositories;
using UserManagerService.Dtos;
using UserManagerService.Models;

namespace UserManagerService.Tests
{
    [TestFixture]
    public class UserControllerTests
    {
        private UserController _controller;
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<IMapper> _mockMapper;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMapper = new Mock<IMapper>();
            _controller = new UserController(_mockUserRepository.Object, _mockMapper.Object);
        }

        [Test]
        public void Login_ValidCredentials_ReturnsOk()
        {
            // Arrange
            string email = "test@example.com";
            string password = "password123";

            // Simula el retorno del método Login del repositorio
            _mockUserRepository.Setup(repo => repo.Login(email, password));

            // Act
            var result = _controller.Login(email, password);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            _mockUserRepository.Verify(repo => repo.Login(email, password), Times.Once);
        }


        [Test]
        public void Register_ValidUser_ReturnsCreatedAtRoute()
        {
            // Arrange
            var userCreateDto = new UserCreateDto { Username = "Test User", Email = "test@example.com", Password = "password123" };
            var userModel = new User { Id = 1, Username = "Test User", Email = "test@example.com" };
            var userReadDto = new UserReadDto { Id = 1, Username = "Test User", Email = "test@example.com" };

            _mockMapper.Setup(m => m.Map<User>(It.IsAny<UserCreateDto>())).Returns(userModel);
            _mockMapper.Setup(m => m.Map<UserReadDto>(It.IsAny<User>())).Returns(userReadDto);

            // Act
            var result = _controller.Register(userCreateDto) as ActionResult<UserReadDto>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<CreatedAtRouteResult>(result.Result);
            var createdAtRouteResult = result.Result as CreatedAtRouteResult;
            Assert.AreEqual(nameof(UserController.GetUserById), createdAtRouteResult.RouteName);
            Assert.AreEqual(userReadDto.Id, createdAtRouteResult.RouteValues["Id"]);
            Assert.AreEqual(userReadDto, createdAtRouteResult.Value);
            _mockUserRepository.Verify(repo => repo.Register(userModel), Times.Once);
            _mockUserRepository.Verify(repo => repo.SaveChanges(), Times.Once);
        }


        [Test]
        public void GetAllUsers_ReturnsOkWithUsers()
        {
            // Arrange
            var users = new List<User> {
                new User { Id = 1, Username = "User 1", Email = "user1@example.com" },
                new User { Id = 2, Username = "User 2", Email = "user2@example.com" }
            };
            _mockUserRepository.Setup(repo => repo.GetAllUsers()).Returns(users);
            _mockMapper.Setup(m => m.Map<IEnumerable<UserReadDto>>(users))
                       .Returns(users.Select(u => new UserReadDto { Id = u.Id, Username = u.Username, Email = u.Email }));

            // Act
            var result = _controller.GetAllUsers();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            var returnedUsers = okResult.Value as IEnumerable<UserReadDto>;
            Assert.IsNotNull(returnedUsers);
            Assert.AreEqual(users.Count, returnedUsers.Count());
        }

        [Test]
        public void GetUserById_ValidId_ReturnsOkWithUser()
        {
            // Arrange
            int userId = 1;
            var user = new User { Id = userId, Username = "Test User", Email = "test@example.com" };
            _mockUserRepository.Setup(repo => repo.GetUserById(userId)).Returns(user);
            var expectedUserDto = new UserReadDto { Id = userId, Username = "Test User", Email = "test@example.com" };
            _mockMapper.Setup(m => m.Map<UserReadDto>(user)).Returns(expectedUserDto);

            // Act
            var result = _controller.GetUserById(userId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            var returnedUser = okResult.Value as UserReadDto;
            Assert.IsNotNull(returnedUser);
            Assert.AreEqual(expectedUserDto.Id, returnedUser.Id);
            Assert.AreEqual(expectedUserDto.Username, returnedUser.Username);
            Assert.AreEqual(expectedUserDto.Email, returnedUser.Email);
        }

        [Test]
        public void DeleteUser_ValidId_ReturnsNoContent()
        {
            // Arrange
            int userId = 1;
            var user = new User { Id = userId, Username = "Test User", Email = "test@example.com" };
            _mockUserRepository.Setup(repo => repo.GetUserById(userId)).Returns(user);

            // Act
            var result = _controller.DeleteUser(userId);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
            _mockUserRepository.Verify(repo => repo.DeleteUser(user), Times.Once);
            _mockUserRepository.Verify(repo => repo.SaveChanges(), Times.Once);
        }




    }
}
