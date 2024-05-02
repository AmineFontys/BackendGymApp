
using AutoMapper;
using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using GymApp.Data.Repositories;
using GymAppTraining.Api.Interfaces;
using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;
using Moq;
using NUnit.Framework;
using System;

namespace GymAppTraining.Api.Tests.Services
{
    [TestFixture]
    public class ExerciseServiceTests
    {
        private ExerciseService _exerciseService;
        private Mock<IExerciseRepository> _exerciseRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IService> _serviceMock;

        [SetUp]
        public void Setup()
        {
            _exerciseRepositoryMock = new Mock<IExerciseRepository>();
            _mapperMock = new Mock<IMapper>();
            _serviceMock = new Mock<IService>();

            _exerciseService = new ExerciseService(_exerciseRepositoryMock.Object, _mapperMock.Object, _serviceMock.Object);
        }

        [Test]
        public void CalculateDurationInSeconds_ShouldReturnCorrectTotalDuration()
        {
            // Arrange
            var exercise = new ExerciseModel
            {
                DurationRep = 10,
                Reps = 5,
                Sets = 3,
                RestTime = 5
            };

            // Act
            var totalDuration = _exerciseService.CalculateDurationInSeconds(exercise);

            // Assert
            Assert.That(totalDuration, Is.EqualTo(160));
        }

        [Test]
        public void AddExercise_ShouldReturnServiceResponseWithAddedExercise()
        {
            // Arrange
            var exercise = new ExerciseModel();
            var exerciseEntity = new Exercise();
            var repositoryResponse = new RepositoryResponse<dynamic>
            {
                Success = true,
                Data = exerciseEntity,
                Message = "Exercise added successfully"
            };
            var serviceResponse = new ServiceResponse<dynamic>();

            _mapperMock.Setup(m => m.Map<Exercise>(exercise)).Returns(exerciseEntity);
            _exerciseRepositoryMock.Setup(r => r.AddExercise(exerciseEntity)).Returns(repositoryResponse);
            _serviceMock.Setup(s => s.HandleResponse<Exercise, ExerciseModel>(It.IsAny<RepositoryResponse<dynamic>>())).Returns(serviceResponse);

            // Act
            var result = _exerciseService.AddExercise(exercise);

            // Assert
            Assert.AreEqual(serviceResponse, result);
        }
    }
}
