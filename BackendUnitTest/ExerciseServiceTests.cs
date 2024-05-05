
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
        private List<Exercise> _fakeExercises;

        [SetUp]
        public void Setup()
        {
            _exerciseRepositoryMock = new Mock<IExerciseRepository>();
            _mapperMock = new Mock<IMapper>();
            _serviceMock = new Mock<IService>();
            _exerciseService = new ExerciseService(_exerciseRepositoryMock.Object, _mapperMock.Object, _serviceMock.Object);

            _fakeExercises = new List<Exercise>
            {
                new Exercise {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Name = "Bench Press",
                    MuscleGroup = "Chest",
                    Description = "Lay on a bench and press the barbell up and down",
                    Reps = 10,
                    DurationRep = 2,
                    Sets = 3,
                    Weight = 60,
                    RestTime = 20,
                    TotalDuration = 100
                },
                new Exercise {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Name = "Squat",
                    MuscleGroup = "Legs",
                    Description = "Stand with the barbell on your shoulders and squat down",
                    Reps = 10,
                    DurationRep = 2,
                    Sets = 3,
                    Weight = 60,
                    RestTime = 20,
                    TotalDuration = 100
                },
                new Exercise {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Name = "Deadlift",
                    MuscleGroup = "Back",
                    Description = "Lift the barbell from the ground to your hips",
                    Reps = 10,
                    DurationRep = 2,
                    Sets = 3,
                    Weight = 60,
                    RestTime = 20,
                    TotalDuration = 100
                }
            };
        }
        [Test]
        public void GetAllExercises_ShouldReturnServiceResponseWithAllExercises()
        {
            // Arrange
            var repositoryResponse = new RepositoryResponse<dynamic> { Success = true, Data = _fakeExercises };
            var serviceResponse = new ServiceResponse<dynamic> { Success = true, Data = _fakeExercises };

            _exerciseRepositoryMock.Setup(r => r.GetAllExercises()).Returns(repositoryResponse);
            _serviceMock.Setup(s => s.HandleResponse<Exercise, ExerciseModel>(repositoryResponse)).Returns(serviceResponse);

            // Act
            var result = _exerciseService.GetAllExercises();

            // Assert
            Assert.That(result, Is.EqualTo(serviceResponse));
            Assert.That(result.Data.Count, Is.EqualTo(3));
            Assert.That(result.Data[0].Name, Is.EqualTo("Bench Press"));
            Assert.That(result.Data[1].Name, Is.EqualTo("Squat"));
            Assert.That(result.Data[2].Name, Is.EqualTo("Deadlift"));
        }
        [Test]
        public void GetAllExercises_ShouldReturnErrorResponseWhenFetchFails()
        {
            // Arrange
            var repositoryResponse = new RepositoryResponse<dynamic>
            {
                Success = false,
                Data = null,
                Message = "Failed to fetch exercises due to a database error"
            };
            var serviceResponse = new ServiceResponse<dynamic>
            {
                Success = false,
                Data = null,
                Message = "Error fetching exercises"
            };

            _exerciseRepositoryMock.Setup(r => r.GetAllExercises()).Returns(repositoryResponse);
            _serviceMock.Setup(s => s.HandleResponse<Exercise, ExerciseModel>(repositoryResponse)).Returns(serviceResponse);

            // Act
            var result = _exerciseService.GetAllExercises();

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.IsNull(result.Data);
            Assert.That(result.Message, Is.EqualTo("Error fetching exercises"));
        }
        [Test]
        public void AddExercise_ShouldReturnServiceResponseWithAddedExercise()
        {
            // Arrange
            var exerciseModel = new ExerciseModel
            {
                ID = Guid.NewGuid(),
                Name = "Bench Press",
                MuscleGroup = "Chest",
                Description = "Lay on a bench and press the barbell up and down",
                Reps = 10,
                DurationRep = 2,
                Sets = 3,
                Weight = 60,
                RestTime = 20
            };
            var exerciseEntity = new Exercise();
            var repositoryResponse = new RepositoryResponse<dynamic>
            {
                Success = true,
                Data = exerciseEntity,
                Message = "Exercise added successfully"
            };
            var serviceResponse = new ServiceResponse<dynamic>
            {
                Success = true,
                Data = exerciseEntity,
                Message = "Service handled correctly"
            };

            _mapperMock.Setup(m => m.Map<Exercise>(exerciseModel)).Returns(exerciseEntity);
            _exerciseRepositoryMock.Setup(r => r.AddExercise(exerciseEntity)).Returns(repositoryResponse);
            _serviceMock.Setup(s => s.HandleResponse<Exercise, ExerciseModel>(It.IsAny<RepositoryResponse<dynamic>>())).Returns(serviceResponse);

            // Act
            var result = _exerciseService.AddExercise(exerciseModel);

            // Assert
            Assert.That(result.Success, Is.EqualTo(true));
        }

        [Test]
        public void AddExercise_ShouldReturnErrorResponseWhenAddFails()
        {
            // Arrange
            var exerciseModel = new ExerciseModel
            {
                ID = Guid.NewGuid(),
                Name = "Bench Press",
                MuscleGroup = "Chest",
                Description = "Lay on a bench and press the barbell up and down",
                Reps = 10,
                DurationRep = 2,
                Sets = 3,
                Weight = 60,
                RestTime = 20
            };
            var exerciseEntity = new Exercise();
            var repositoryResponse = new RepositoryResponse<dynamic>
            {
                Success = false,
                Data = null,
                Message = "Failed to add exercise due to database error"
            };
            var serviceResponse = new ServiceResponse<dynamic>
            {
                Success = false,
                Data = null,
                Message = "Service handled the failure correctly"
            };

            _mapperMock.Setup(m => m.Map<Exercise>(exerciseModel)).Returns(exerciseEntity);
            _exerciseRepositoryMock.Setup(r => r.AddExercise(exerciseEntity)).Returns(repositoryResponse);
            _serviceMock.Setup(s => s.HandleResponse<Exercise, ExerciseModel>(It.IsAny<RepositoryResponse<dynamic>>())).Returns(serviceResponse);

            // Act
            var result = _exerciseService.AddExercise(exerciseModel);

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.Message, Is.EqualTo("Service handled the failure correctly"));
            Assert.IsNull(result.Data);
        }


        [Test]
        public void GetExerciseById_ShouldReturnServiceResponseWithExercise()
        {
            // Arrange
            var id = Guid.NewGuid();
            var exercise = new Exercise();
            var repositoryResponse = new RepositoryResponse<dynamic> { Success = true, Data = exercise };
            var serviceResponse = new ServiceResponse<dynamic> { Success = true, Data = exercise };

            _exerciseRepositoryMock.Setup(r => r.GetExerciseById(id)).Returns(repositoryResponse);
            _serviceMock.Setup(s => s.HandleResponse<Exercise, ExerciseModel>(repositoryResponse)).Returns(serviceResponse);

            // Act
            var result = _exerciseService.GetExerciseById(id);

            // Assert
            Assert.That(result, Is.EqualTo(serviceResponse));
        }

        [Test]
        public void GetExerciseById_ShouldReturnErrorResponseWhenExerciseNotFound()
        {
            // Arrange
            var id = Guid.NewGuid();
            var repositoryResponse = new RepositoryResponse<dynamic>
            {
                Success = false,
                Data = null,
                Message = "Exercise not found"
            };
            var serviceResponse = new ServiceResponse<dynamic>
            {
                Success = false,
                Data = null,
                Message = "Exercise not found"
            };

            _exerciseRepositoryMock.Setup(r => r.GetExerciseById(id)).Returns(repositoryResponse);
            _serviceMock.Setup(s => s.HandleResponse<Exercise, ExerciseModel>(repositoryResponse)).Returns(serviceResponse);

            // Act
            var result = _exerciseService.GetExerciseById(id);

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.IsNull(result.Data);
            Assert.That(result.Message, Is.EqualTo("Exercise not found"));
        }

        [Test]
        public void UpdateExercise_ShouldReturnServiceResponseWithUpdatedExercise()
        {
            // Arrange
            var exerciseModel = new ExerciseModel();
            var exerciseEntity = new Exercise();
            var repositoryResponse = new RepositoryResponse<dynamic> { Success = true, Data = exerciseEntity };
            var serviceResponse = new ServiceResponse<dynamic> { Success = true, Data = exerciseEntity };

            _mapperMock.Setup(m => m.Map<Exercise>(exerciseModel)).Returns(exerciseEntity);
            _exerciseRepositoryMock.Setup(r => r.UpdateExercise(exerciseEntity)).Returns(repositoryResponse);
            _serviceMock.Setup(s => s.HandleResponse<Exercise, ExerciseModel>(repositoryResponse)).Returns(serviceResponse);

            // Act
            var result = _exerciseService.UpdateExercise(exerciseModel);

            // Assert
            Assert.That(result, Is.EqualTo(serviceResponse));
        }

        [Test]
        public void UpdateExercise_ShouldReturnErrorResponseWhenUpdateFails()
        {
            // Arrange
            var exerciseModel = new ExerciseModel { ID = Guid.NewGuid() };
            var exerciseEntity = new Exercise { Id = exerciseModel.ID };
            var repositoryResponse = new RepositoryResponse<dynamic>
            {
                Success = false,
                Data = null,
                Message = "Failed to update exercise"
            };
            var serviceResponse = new ServiceResponse<dynamic>
            {
                Success = false,
                Data = null,
                Message = "Failed to update exercise"
            };

            _mapperMock.Setup(m => m.Map<Exercise>(exerciseModel)).Returns(exerciseEntity);
            _exerciseRepositoryMock.Setup(r => r.UpdateExercise(exerciseEntity)).Returns(repositoryResponse);
            _serviceMock.Setup(s => s.HandleResponse<Exercise, ExerciseModel>(It.IsAny<RepositoryResponse<dynamic>>())).Returns(serviceResponse);

            // Act
            var result = _exerciseService.UpdateExercise(exerciseModel);

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.IsNull(result.Data);
            Assert.That(result.Message, Is.EqualTo("Failed to update exercise"));
        }

        [Test]
        public void DeleteExercise_ShouldReturnServiceResponseWithDeletedExercise()
        {
            // Arrange
            var id = Guid.NewGuid();
            var repositoryResponse = new RepositoryResponse<dynamic> { Success = true, Data = id };
            var serviceResponse = new ServiceResponse<dynamic> { Success = true, Data = id };

            _exerciseRepositoryMock.Setup(r => r.DeleteExercise(id)).Returns(repositoryResponse);
            _serviceMock.Setup(s => s.HandleResponse<Exercise, ExerciseModel>(repositoryResponse)).Returns(serviceResponse);

            // Act
            var result = _exerciseService.DeleteExercise(id);

            // Assert
            Assert.That(result, Is.EqualTo(serviceResponse));
        }
        [Test]
        public void DeleteExercise_ShouldReturnErrorResponseWhenDeleteFails()
        {
            // Arrange
            var id = Guid.NewGuid();
            var repositoryResponse = new RepositoryResponse<dynamic>
            {
                Success = false,
                Data = null,
                Message = "Failed to delete exercise"
            };
            var serviceResponse = new ServiceResponse<dynamic>
            {
                Success = false,
                Data = null,
                Message = "Failed to delete exercise"
            };

            _exerciseRepositoryMock.Setup(r => r.DeleteExercise(id)).Returns(repositoryResponse);
            _serviceMock.Setup(s => s.HandleResponse<Exercise, ExerciseModel>(repositoryResponse)).Returns(serviceResponse);

            // Act
            var result = _exerciseService.DeleteExercise(id);

            // Assert
            Assert.That(result.Success, Is.False);
            Assert.IsNull(result.Data);
            Assert.That(result.Message, Is.EqualTo("Failed to delete exercise"));
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
        public void CalculateDurationInSeconds_ShouldReturnCorrectTotalDurationWithZeroRestTime()
        {
            // Arrange
            var exercise = new ExerciseModel
            {
                DurationRep = 10,
                Reps = 5,
                Sets = 3,
                RestTime = 0
            };

            // Act
            var totalDuration = _exerciseService.CalculateDurationInSeconds(exercise);

            // Assert
            Assert.That(totalDuration, Is.EqualTo(150));
        }
    }


}