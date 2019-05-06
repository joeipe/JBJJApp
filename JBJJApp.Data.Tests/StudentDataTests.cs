using System;
using System.Collections.Generic;
using System.Linq;
using JBJJApp.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharedKernel.Data;
using SharedKernel.Enums;

namespace JBJJApp.Data.Tests
{
    [TestClass]
    public class StudentDataTests
    {
        private List<Grade> _gradesInMemory;
        private List<Person> _peopleInMemory;
        private Mock<JBJJAppContext> _jbjjAppMockingContext;
        private StudentData _studentData;

        [TestInitialize]
        public void Setup()
        {
            var now = DateTime.Now;
            var grade1 = new Grade() { Id = 1, Name = "White", CreatedDate = now, UpdatedDate = now, State = ObjectState.Unchanged };
            var grade2 = new Grade() { Id = 2, Name = "Blue", CreatedDate = now, UpdatedDate = now, State = ObjectState.Unchanged };
            var person1 = new Person() { Id = 1, FirstName = "TestFName1", LastName = "TestLName1", GradeId = 1, Stripe = 1, CreatedDate = now, UpdatedDate = now, Grade = grade1, State = ObjectState.Unchanged };
            var person2 = new Person() { Id = 2, FirstName = "TestFName2", LastName = "TestLName1", GradeId = 2, Stripe = 4, CreatedDate = now, UpdatedDate = now, Grade = grade2, State = ObjectState.Unchanged };
            _gradesInMemory = new List<Grade>() { grade1, grade2 };
            _peopleInMemory = new List<Person>() { person1, person2 };

            _jbjjAppMockingContext = new Mock<JBJJAppContext>();
            _jbjjAppMockingContext.Setup(x => x.Set<Grade>()).Returns(TestHelpers.MockDbSet(_gradesInMemory));
            _jbjjAppMockingContext.Setup(x => x.Set<Person>()).Returns(TestHelpers.MockDbSet(_peopleInMemory));

            _studentData = new StudentData(new GenericRepository<Grade>(_jbjjAppMockingContext.Object), new GenericRepository<Person>(_jbjjAppMockingContext.Object));
        }

        #region Grade
        [TestMethod]
        public void Can_GetGrade()
        {
            // Arrange
            // Act
            var result = _studentData.GetGrade();

            // Assert
            Assert.AreEqual(_gradesInMemory.Count(), result.Count());
        }

        [TestMethod]
        public void Can_GetGradeById()
        {
            // Arrange
            // Act
            var result = _studentData.GetGradeById(1);

            // Assert
            Assert.AreEqual(_gradesInMemory.Where(x => x.Id == 1).First().Id, result.Id);
        }

        [TestMethod]
        public void Can_AddGrade()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_UpdateGrade()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_DeleteGrade()
        {
            // Arrange
            // Act
            // Assert
        }
        #endregion

        #region Person
        [TestMethod]
        public void Can_GetPerson()
        {
            // Arrange
            // Act
            var result = _studentData.GetPerson();

            // Assert
            Assert.AreEqual(_peopleInMemory.Count(), result.Count());
        }

        [TestMethod]
        public void Can_GetPersonById()
        {
            // Arrange
            // Act
            var result = _studentData.GetPersonById(1);

            // Assert
            Assert.AreEqual(_peopleInMemory.Where(x => x.Id == 1).First().Id, result.Id);
        }

        [TestMethod]
        public void Can_GetPersonWithGradeById()
        {
            // Arrange
            // Act
            var result = _studentData.GetPersonWithGradeById(1);

            // Assert
            Assert.AreEqual(_peopleInMemory.Where(x => x.Id == 1).First().Id, result.Id);
            Assert.AreEqual(_peopleInMemory.Where(x => x.Id == 1).First().Grade.Id, result.Grade.Id);
        }

        [TestMethod]
        public void Can_AddPerson()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_UpdatePerson()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_DeletePerson()
        {
            // Arrange
            // Act
            // Assert
        }
        #endregion
    }
}
