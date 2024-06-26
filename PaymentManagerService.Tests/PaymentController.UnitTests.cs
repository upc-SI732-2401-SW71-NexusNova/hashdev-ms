using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PaymentManagerService.Controllers;
using PaymentManagerService.Data.Repositories;
using PaymentManagerService.Dtos;
using PaymentManagerService.Models;
using System.Collections.Generic;

namespace PaymentManagerService.Tests
{
    [TestFixture]
    public class PaymentControllerTests
    {
        private PaymentController _controller;
        private Mock<IMapper> _mapperMock;
        private Mock<IPaymentRepository> _repositoryMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _repositoryMock = new Mock<IPaymentRepository>();
            _controller = new PaymentController(_mapperMock.Object, _repositoryMock.Object);
        }

        [Test]
        public void GetAllPayments_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.GetAllPayments())
                .Returns(new List<Payment>()); // Mock empty list of payments

            // Act
            var result = _controller.GetAllPayments();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void GetPaymentById_ExistingId_ReturnsOkResult()
        {
            // Arrange
            int existingPaymentId = 1;
            var mockPayment = new Payment { Id = existingPaymentId };
            _repositoryMock.Setup(repo => repo.GetPaymentById(existingPaymentId))
                .Returns(mockPayment); // Mock returning a payment with ID 1

            // Act
            var result = _controller.GetPaymentById(existingPaymentId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void GetPaymentById_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            int nonExistingPaymentId = 999; // Assuming 999 doesn't exist
            _repositoryMock.Setup(repo => repo.GetPaymentById(nonExistingPaymentId))
                .Returns((Payment)null); // Mock returning null for non-existing payment

            // Act
            var result = _controller.GetPaymentById(nonExistingPaymentId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public void DeletePayment_ExistingId_ReturnsNoContentResult()
        {
            // Arrange
            int existingPaymentId = 1;
            var existingPayment = new Payment { Id = existingPaymentId };
            _repositoryMock.Setup(repo => repo.GetPaymentById(existingPaymentId))
                .Returns(existingPayment); // Mock returning an existing payment
            _repositoryMock.Setup(repo => repo.DeletePayment(existingPayment));

            // Act
            var result = _controller.DeletePayment(existingPaymentId);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public void DeletePayment_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            int nonExistingPaymentId = 999; // Assuming 999 doesn't exist
            _repositoryMock.Setup(repo => repo.GetPaymentById(nonExistingPaymentId))
                .Returns((Payment)null); // Mock returning null for non-existing payment

            // Act
            var result = _controller.DeletePayment(nonExistingPaymentId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}
