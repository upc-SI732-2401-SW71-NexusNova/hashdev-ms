using AutoMapper;
using ConferenceManagerService.Controllers;
using ConferenceManagerService.Data.Repositories;
using ConferenceManagerService.Dtos;
using ConferenceManagerService.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceManagerService.Tests
{
    [TestFixture]
    public class ConferenceControllerTests
    {
        private ConferenceController _controller;
        private Mock<IConferenceRepository> _repositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IConferenceRepository>();
            _mapperMock = new Mock<IMapper>();
            _controller = new ConferenceController(_repositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public void GetAllConferences_ShouldReturnAllConferences()
        {
            // Arrange
            var conferences = new List<Conference>
            {
                new Conference { Id = 1, Name = "Conference 1" },
                new Conference { Id = 2, Name = "Conference 2" }
            };
            _repositoryMock.Setup(repo => repo.GetAllConferences())
                .Returns(conferences);
            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<ConferenceReadDto>>(conferences))
                .Returns(conferences.Select(c => new ConferenceReadDto { Id = c.Id, Name = c.Name }));

            // Act
            var result = _controller.GetAllConferences() as OkObjectResult;
            var conferenceDtos = result.Value as IEnumerable<ConferenceReadDto>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(conferenceDtos);
            Assert.AreEqual(conferences.Count, conferenceDtos.Count());
        }

        [Test]
        public void GetConferenceById_ExistingId_ShouldReturnConference()
        {
            // Arrange
            int conferenceId = 1;
            var conference = new Conference { Id = conferenceId, Name = "Conference 1" };
            _repositoryMock.Setup(repo => repo.GetConferenceById(conferenceId))
                .Returns(conference);
            _mapperMock.Setup(mapper => mapper.Map<ConferenceReadDto>(conference))
                .Returns(new ConferenceReadDto { Id = conference.Id, Name = conference.Name });

            // Act
            var result = _controller.GetConferenceById(conferenceId) as OkObjectResult;
            var conferenceDto = result.Value as ConferenceReadDto;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(conferenceDto);
            Assert.AreEqual(conference.Id, conferenceDto.Id);
            Assert.AreEqual(conference.Name, conferenceDto.Name);
        }

        [Test]
        public void GetConferenceById_NonExistingId_ShouldReturnNotFound()
        {
            // Arrange
            int conferenceId = 999;
            _repositoryMock.Setup(repo => repo.GetConferenceById(conferenceId))
                .Returns((Conference)null);

            // Act
            var result = _controller.GetConferenceById(conferenceId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void CreateConference_ValidConferenceCreateDto_ReturnsCreatedAtRouteResult()
        {
            // Arrange
            var conferenceCreateDto = new ConferenceCreateDto
            {
                Name = "New Conference",
                Image = "conference.jpg",
                Description = "Conference Description",
                Price = "Free",
                Date = "2024-07-01",
                Time = "09:00 AM",
                Location = "Conference Hall",
                UserId = 1
            };

            var createdConference = new Conference { Id = 1 };
            var conferenceReadDto = new ConferenceReadDto { Id = 1, Name = "New Conference" };

            _mapperMock.Setup(mapper => mapper.Map<Conference>(conferenceCreateDto))
                       .Returns(createdConference);
            _mapperMock.Setup(mapper => mapper.Map<ConferenceReadDto>(It.IsAny<Conference>()))
                       .Returns(conferenceReadDto);

            _repositoryMock.Setup(repo => repo.CreateConference(It.IsAny<Conference>()));
            _repositoryMock.Setup(repo => repo.SaveChanges()).Verifiable();

            // Act
            var result = _controller.CreateConference(conferenceCreateDto);

            // Assert
            Assert.IsInstanceOf<CreatedAtRouteResult>(result);
        }




        [Test]
        public void DeleteConference_ExistingId_ShouldReturnNoContent()
        {
            // Arrange
            int conferenceId = 1;
            var conference = new Conference { Id = conferenceId, Name = "Conference 1" };
            _repositoryMock.Setup(repo => repo.GetConferenceById(conferenceId))
                .Returns(conference);

            // Act
            var result = _controller.DeleteConference(conferenceId);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public void DeleteConference_NonExistingId_ShouldReturnNotFound()
        {
            // Arrange
            int conferenceId = 999; // Assuming a non-existing ID
            _repositoryMock.Setup(repo => repo.GetConferenceById(conferenceId))
                .Returns((Conference)null);

            // Act
            var result = _controller.DeleteConference(conferenceId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}
