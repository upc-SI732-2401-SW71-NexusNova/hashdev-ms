using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using UserManagerService.Data.Repositories;
using UserManagerService.Models;
using UserManagerService.Data;

namespace UserManagerService.Tests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private UserManagerDbContext _context;
        private IUserRepository _userRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<UserManagerDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new UserManagerDbContext(options);
            SeedDatabase();
            _userRepository = new UserRepository(_context);
        }

        private void SeedDatabase()
        {
            var users = new List<User>
            {
                new User { Id = 1, Username = "User1", Email = "user1@example.com", Password = "password1" },
                new User { Id = 2, Username = "User2", Email = "user2@example.com", Password = "password2" }
            };
            _context.Users.AddRange(users);
            _context.SaveChanges();
        }

        [Test]
        public void GetAllUsers_ReturnsAllUsers()
        {
            // Act
            var result = _userRepository.GetAllUsers();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void GetUserById_ValidId_ReturnsUser()
        {
            // Arrange
            int userId = 1;

            // Act
            var result = _userRepository.GetUserById(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userId, result.Id);
        }

        [Test]
        public void GetUserById_InvalidId_ThrowsException()
        {
            // Arrange
            int userId = 100; // Assuming an invalid ID

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _userRepository.GetUserById(userId));
        }

        [Test]
        public void ExistUserByEmail_ExistingEmail_ReturnsTrue()
        {
            // Arrange
            string email = "user1@example.com";

            // Act
            var result = _userRepository.ExistUserByEmail(email);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ExistUserByEmail_NonExistingEmail_ReturnsFalse()
        {
            // Arrange
            string email = "nonexisting@example.com";

            // Act
            var result = _userRepository.ExistUserByEmail(email);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Register_NewUser_SuccessfullyRegisters()
        {
            // Arrange
            var newUser = new User { Username = "NewUser", Email = "newuser@example.com", Password = "newpassword" };

            // Act
            var result = _userRepository.Register(newUser);
            _userRepository.SaveChanges();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newUser.Email, result.Email);
        }

        [Test]
        public void Register_ExistingEmail_ThrowsException()
        {
            // Arrange
            var existingUser = new User { Username = "User1", Email = "user1@example.com", Password = "password1" };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _userRepository.Register(existingUser));
        }

        [Test]
        public void UpdateUser_ValidId_SuccessfullyUpdatesUser()
        {
            // Arrange
            int userId = 1;
            var updatedUser = new User { Id = userId, Username = "UpdatedUser", Email = "updateduser@example.com", Password = "updatedpassword" };

            // Act
            _userRepository.UpdateUser(userId, updatedUser);
            _userRepository.SaveChanges();
            var result = _userRepository.GetUserById(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedUser.Username, result.Username);
            Assert.AreEqual(updatedUser.Email, result.Email);
            Assert.AreEqual(updatedUser.Password, result.Password);
        }

        [Test]
        public void DeleteUser_ValidUser_SuccessfullyDeletesUser()
        {
            // Arrange
            int userId = 1;
            var userToDelete = _userRepository.GetUserById(userId);

            // Act
            _userRepository.DeleteUser(userToDelete);
            _userRepository.SaveChanges();
            Assert.Throws<ArgumentNullException>(() => _userRepository.GetUserById(userId));
        }

        [TearDown]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
