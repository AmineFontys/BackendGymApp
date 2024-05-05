using GymApp.Data.DAL;
using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using GymApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendUnitTest
{
    [TestFixture]
    public class ExerciseRepositoryTests
    {
        private ITrainingContext _context;
        private ExerciseRepository _exerciseRepository;
        private Mock<IRepository> _repositoryMock;

        [SetUp]
        public void Setup()
        {
            

            var options = new DbContextOptionsBuilder<TrainingContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new TrainingContext(options);
            _repositoryMock = new Mock<IRepository>();           
            _exerciseRepository = new ExerciseRepository(_context, _repositoryMock.Object);
            

            _repositoryMock.Setup(r => r.HandleException(It.IsAny<Exception>()))
                           .Returns((Exception ex) => new RepositoryResponse<dynamic>
                           {
                               Success = false,
                               Data = null,
                               Message = ex.Message
                           });


            SeedDatabase();
        }
        private void SeedDatabase()
        {
            _context.Exercises.AddRange(new List<Exercise>
            {
                new Exercise {
                    Id = Guid.NewGuid(),
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
                    Id = Guid.NewGuid(),
                    Name = "Squat",
                    MuscleGroup = "Legs",
                    Description = "Stand with the barbell on your shoulders and squat down",
                    Reps = 10,
                    DurationRep = 2,
                    Sets = 3,
                    Weight = 80,
                    RestTime = 30,
                    TotalDuration = 120
                }
            });

            _context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose(); 
        }
    

        [Test]
        public void GetAllExercises_ReturnsAllExercises()
        {

            // Arrange
            _repositoryMock.Setup(r => r.CreateResponse(It.IsAny<bool>(), It.IsAny<List<Exercise>>(), It.IsAny<string>()))
                .Returns((bool success, List<Exercise> data, string message) => new RepositoryResponse<dynamic>
                {
                    Success = success,
                    Data = data,
                    Message = message
                });
            // Act
            var result = _exerciseRepository.GetAllExercises();

            // Assert
            Assert.IsNotNull(result.Data);
            Assert.AreEqual("Bench Press", result.Data[0].Name);
            Assert.AreEqual("Squat", result.Data[1].Name);
            Assert.AreEqual("Chest", result.Data[0].MuscleGroup);
            Assert.AreEqual("Legs", result.Data[1].MuscleGroup);
            Assert.AreEqual(60, result.Data[0].Weight);
            Assert.AreEqual(80, result.Data[1].Weight);
        }
        [Test]
        public void GetAllExercises_ReturnsEmptyWhenNoExercisesExist()
        {
            // Arrange
            _context.Exercises.RemoveRange(_context.Exercises);
            _context.SaveChanges();

            _repositoryMock.Setup(r => r.CreateResponse(It.IsAny<bool>(), It.IsAny<List<Exercise>>(), It.IsAny<string>()))
                .Returns((bool success, List<Exercise> data, string message) => new RepositoryResponse<dynamic>
                {
                    Success = success,
                    Data = data,
                    Message = message
                });

            // Act
            var result = _exerciseRepository.GetAllExercises();

            // Assert
            Assert.IsNull(result.Data);
            Assert.That(result.Message, Is.EqualTo("No exercises found"));
        }

        [Test]
        public void GetExerciseById_ReturnsExerciseById()
        {
            // Arrange
            var id = _context.Exercises.First().Id;

            _repositoryMock.Setup(r => r.CreateResponse(It.IsAny<bool>(), It.IsAny<Exercise>(), It.IsAny<string>()))
                .Returns((bool success, Exercise data, string message) => new RepositoryResponse<dynamic>
                {
                    Success = success,
                    Data = data,
                    Message = message
                });

            // Act
            var result = _exerciseRepository.GetExerciseById(id);

            // Assert
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(id, result.Data.Id);
        }
        [Test]
        public void GetExerciseById_ReturnsNullWhenExerciseNotFound()
        {
            // Arrange
            var id = Guid.NewGuid();

            _repositoryMock.Setup(r => r.CreateResponse(It.IsAny<bool>(), It.IsAny<Exercise>(), It.IsAny<string>()))
                .Returns((bool success, Exercise data, string message) => new RepositoryResponse<dynamic>
                {
                    Success = success,
                    Data = data,
                    Message = message
                });

            // Act
            var result = _exerciseRepository.GetExerciseById(id);

            // Assert
            Assert.IsNull(result.Data);
            Assert.That(result.Message, Is.EqualTo("Exercise not found"));
        }
        [Test]
        public void AddExercise_GetSameExerciseById()
        {
            // Arrange
            var exercise = new Exercise
            {
                Id = Guid.Parse("9765720e-07e6-438e-97fd-a47ca42285ba"),
                Name = "Deadlift",
                MuscleGroup = "Back",
                Description = "Lift the barbell from the ground to your hips",
                Reps = 10,
                DurationRep = 2,
                Sets = 3,
                Weight = 60,
                RestTime = 20,
                TotalDuration = 100
            };

            _repositoryMock.Setup(r => r.CreateResponse(It.IsAny<bool>(), It.IsAny<Exercise>(), It.IsAny<string>()))
                .Returns((bool success, Exercise data, string message) => new RepositoryResponse<dynamic>
                {
                    Success = success,
                    Data = data,
                    Message = message
                });

            // Act
             _exerciseRepository.AddExercise(exercise);
            var result = _exerciseRepository.GetExerciseById(exercise.Id);

            // Assert
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(exercise.Id, result.Data.Id);
        }
        [Test]
        public void DeleteExercise_ReturnsExerciseDeleted()
        {
            // Arrange
            var exercise = _context.Exercises.First();

            _repositoryMock.Setup(r => r.CreateResponse(It.IsAny<bool>(), It.IsAny<Exercise>(), It.IsAny<string>()))
                .Returns((bool success, Exercise data, string message) => new RepositoryResponse<dynamic>
                {
                    Success = success,
                    Data = data,
                    Message = message
                });

            // Act
            var result = _exerciseRepository.DeleteExercise(exercise.Id);
            var deletedExercise = _exerciseRepository.GetExerciseById(exercise.Id);

            // Assert
            Assert.IsNull(deletedExercise.Data);
            Assert.That(result.Message, Is.EqualTo("Exercise deleted successfully"));
        }
        [Test]
        public void DeleteExercise_ReturnsExerciseNotFound()
        {
            // Arrange
            var id = Guid.NewGuid();

            _repositoryMock.Setup(r => r.CreateResponse(It.IsAny<bool>(), It.IsAny<Exercise>(), It.IsAny<string>()))
                .Returns((bool success, Exercise data, string message) => new RepositoryResponse<dynamic>
                {
                    Success = success,
                    Data = data,
                    Message = message
                });

            // Act
            var result = _exerciseRepository.DeleteExercise(id);

            // Assert
            Assert.IsNull(result.Data);
            Assert.That(result.Message, Is.EqualTo("Exercise not found"));
        }

        [Test]
        public void UpdateExercise_GetUpdatedExercise()
        {
            // Arrange
            var exercise = _context.Exercises.First();
            exercise.Name = "Updated Name";

            _repositoryMock.Setup(r => r.CreateResponse(It.IsAny<bool>(), It.IsAny<Exercise>(), It.IsAny<string>()))
                .Returns((bool success, Exercise data, string message) => new RepositoryResponse<dynamic>
                {
                    Success = success,
                    Data = data,
                    Message = message
                });

            // Act
            _exerciseRepository.UpdateExercise(exercise);
            var result = _exerciseRepository.GetExerciseById(exercise.Id);

            // Assert
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(exercise.Name, result.Data.Name);
            
        }
        [Test]
        public void UpdateExercise_ReturnsExerciseNotFound()
        {
            // Arrange
            var exercise = new Exercise
            {
                Id = Guid.NewGuid(),
                Name = "Updated Name",
                MuscleGroup = "Back",
                Description = "Lift the barbell from the ground to your hips",
                Reps = 10,
                DurationRep = 2,
                Sets = 3,
                Weight = 60,
                RestTime = 20,
                TotalDuration = 100
            };

            _repositoryMock.Setup(r => r.CreateResponse(It.IsAny<bool>(), It.IsAny<Exercise>(), It.IsAny<string>()))
                .Returns((bool success, Exercise data, string message) => new RepositoryResponse<dynamic>
                {
                    Success = success,
                    Data = data,
                    Message = message
                });

            // Act
            var result = _exerciseRepository.UpdateExercise(exercise);

            // Assert
            Assert.IsNull(result.Data);
            Assert.That(result.Message, Is.EqualTo("Exercise not found"));
            Assert.That(result.Success, Is.False);
        }



    }

}
