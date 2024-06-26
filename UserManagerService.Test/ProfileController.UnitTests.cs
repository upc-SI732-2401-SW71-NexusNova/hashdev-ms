using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using UserManagerService.Controllers;
using UserManagerService.Data.Repositories;
using UserManagerService.Dtos;
using UserManagerService.Models;

namespace UserManagerService.Tests.UnitTests
{
    [TestFixture]
    public class ProfileControllerTests
    {
        private ProfileController _controller;
        private Mock<IProfileRepository> _mockProfileRepository;
        private Mock<AutoMapper.IMapper> _mockMapper;

        [SetUp]
        public void Setup()
        {
            _mockProfileRepository = new Mock<IProfileRepository>();
            _mockMapper = new Mock<AutoMapper.IMapper>();
            _controller = new ProfileController(_mockMapper.Object, _mockProfileRepository.Object);
        }

        [Test]
        public void CreateProfile_ValidProfile_ReturnsCreatedAtRoute()
        {
            // Arrange
            var profileCreateDto = new ProfileCreateDto
            {
                FullName = "John Doe",
                Bio = "Sample bio",
                ProfilePictureUrl = "url",
                Location = "City",
                UserId = 1
            };
            var profileModel = new Profile
            {
                Id = 1,
                FullName = profileCreateDto.FullName,
                Bio = profileCreateDto.Bio,
                ProfilePictureUrl = profileCreateDto.ProfilePictureUrl,
                Location = profileCreateDto.Location,
                UserId = profileCreateDto.UserId
            };
            var profileReadDto = new ProfileReadDto
            {
                Id = profileModel.Id,
                FullName = profileModel.FullName,
                Bio = profileModel.Bio,
                ProfilePictureUrl = profileModel.ProfilePictureUrl,
                Location = profileModel.Location,
                UserId = profileModel.UserId
            };

            _mockMapper.Setup(mapper => mapper.Map<Profile>(profileCreateDto)).Returns(profileModel);
            _mockMapper.Setup(mapper => mapper.Map<ProfileReadDto>(profileModel)).Returns(profileReadDto);

            _mockProfileRepository.Setup(repo => repo.CreateProfile(profileModel)).Returns(profileModel);
            _mockProfileRepository.Setup(repo => repo.SaveChanges()).Returns(true);

            // Act
            var actionResult = _controller.CreateProfile(profileCreateDto);

            // Assert
            Assert.IsInstanceOf<ActionResult<ProfileReadDto>>(actionResult);
            var createdAtRouteResult = actionResult.Result as CreatedAtRouteResult;
            Assert.IsNotNull(createdAtRouteResult);
            Assert.AreEqual(nameof(ProfileController.GetProfileById), createdAtRouteResult.RouteName);
            Assert.AreEqual(profileModel.Id, createdAtRouteResult.RouteValues["id"]);

            var createdProfile = createdAtRouteResult.Value as ProfileReadDto;
            Assert.IsNotNull(createdProfile);
            Assert.AreEqual(profileReadDto.Id, createdProfile.Id);
            Assert.AreEqual(profileReadDto.FullName, createdProfile.FullName);
            // Add more assertions for other properties if needed

            _mockProfileRepository.Verify(repo => repo.CreateProfile(profileModel), Times.Once);
            _mockProfileRepository.Verify(repo => repo.SaveChanges(), Times.Once);
        }

        [Test]
        public void GetProfileById_ValidId_ReturnsProfile()
        {
            // Arrange
            int profileId = 1;
            var profileModel = new Profile
            {
                Id = profileId,
                FullName = "John Doe",
                Bio = "Sample bio",
                ProfilePictureUrl = "url",
                Location = "City",
                UserId = 1
            };
            var profileReadDto = new ProfileReadDto
            {
                Id = profileModel.Id,
                FullName = profileModel.FullName,
                Bio = profileModel.Bio,
                ProfilePictureUrl = profileModel.ProfilePictureUrl,
                Location = profileModel.Location,
                UserId = profileModel.UserId
            };

            _mockProfileRepository.Setup(repo => repo.GetProfileById(profileId)).Returns(profileModel);
            _mockMapper.Setup(mapper => mapper.Map<ProfileReadDto>(profileModel)).Returns(profileReadDto);

            // Act
            var actionResult = _controller.GetProfileById(profileId);

            // Assert
            Assert.IsInstanceOf<ActionResult<ProfileReadDto>>(actionResult);
            var okResult = actionResult.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var returnedProfile = okResult.Value as ProfileReadDto;
            Assert.IsNotNull(returnedProfile);
            Assert.AreEqual(profileReadDto.Id, returnedProfile.Id);
            Assert.AreEqual(profileReadDto.FullName, returnedProfile.FullName);
            // Add more assertions for other properties if needed

            _mockProfileRepository.Verify(repo => repo.GetProfileById(profileId), Times.Once);
        }

        [Test]
        public void GetProfileById_InvalidId_ReturnsNotFound()
        {
            // Arrange
            int profileId = 100; // Assuming an invalid ID

            _mockProfileRepository.Setup(repo => repo.GetProfileById(profileId)).Returns((Profile)null);

            // Act
            var actionResult = _controller.GetProfileById(profileId);

            // Assert
            Assert.IsInstanceOf<ActionResult<ProfileReadDto>>(actionResult);
            var notFoundResult = actionResult.Result as NotFoundResult;
            Assert.IsNotNull(notFoundResult);

            _mockProfileRepository.Verify(repo => repo.GetProfileById(profileId), Times.Once);
        }

        [Test]
        public void UpdateProfile_ValidId_ReturnsNoContent()
        {
            // Arrange
            int profileId = 1;
            var profileUpdateDto = new ProfileCreateDto
            {
                FullName = "John Doe",
                Bio = "Sample bio",
                ProfilePictureUrl = "url",
                Location = "City",
                UserId = 1
            };
            var profileModel = new Profile
            {
                Id = profileId,
                FullName = profileUpdateDto.FullName,
                Bio = profileUpdateDto.Bio,
                ProfilePictureUrl = profileUpdateDto.ProfilePictureUrl,
                Location = profileUpdateDto.Location,
                UserId = profileUpdateDto.UserId
            };

            _mockProfileRepository.Setup(repo => repo.GetProfileById(profileId)).Returns(profileModel);

            // Act
            var actionResult = _controller.UpdateProfile(profileId, profileUpdateDto);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(actionResult);
            _mockProfileRepository.Verify(repo => repo.UpdateProfile(profileId, profileModel), Times.Once);
            _mockProfileRepository.Verify(repo => repo.SaveChanges(), Times.Once);
        }
    }
}
