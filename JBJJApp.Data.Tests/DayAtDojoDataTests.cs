using System;
using System.Collections.Generic;
using System.Linq;
using JBJJApp.Data.DataServices;
using JBJJApp.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharedKernel.Data;
using SharedKernel.Enums;

namespace JBJJApp.Data.Tests
{
    [TestClass]
    public class DayAtDojoDataTests
    {
        private List<Outcome> _outcomesInMemory;
        private List<Attendance> _attendanceInMemory;
        private List<SparringDetails> _sparringDetailsInMemory;
        private Mock<JBJJAppContext> _jbjjAppMockingContext;
        private DayAtDojoData _dayAtDojoData;

        [TestInitialize]
        public void Setup()
        {
            var now = DateTime.Now;
            var outcome1 = new Outcome() { Id = 1, Name = "Win", CreatedDate = now, UpdatedDate = now, State = ObjectState.Unchanged };
            var outcome2 = new Outcome() { Id = 2, Name = "Loose", CreatedDate = now, UpdatedDate = now, State = ObjectState.Unchanged };
            var attendance1 = new Attendance() { Id = 1, TimeTableId = 1, AttendedOn = now, TechniqueOfTheDay = "Something", CreatedDate = now, UpdatedDate = now, TimeTable = null, State = ObjectState.Unchanged };
            var sparringDetails1 = new SparringDetails() { Id = 1, AttendanceId = 1, PersonId = 1, OutcomeId = 1, TechniqueUsed = "rear naked choke", CreatedDate = now, UpdatedDate = now, Outcome = outcome1, State = ObjectState.Unchanged };
            var sparringDetails2 = new SparringDetails() { Id = 2, AttendanceId = 1, PersonId = 2, OutcomeId = 2, TechniqueUsed = "Passing the guard", CreatedDate = now, UpdatedDate = now, Outcome = outcome2, State = ObjectState.Unchanged };
            _outcomesInMemory = new List<Outcome>() { outcome1, outcome2 };
            _attendanceInMemory = new List<Attendance>() { attendance1 };
            _sparringDetailsInMemory = new List<SparringDetails>() { sparringDetails1, sparringDetails2 };

            _jbjjAppMockingContext = new Mock<JBJJAppContext>();
            _jbjjAppMockingContext.Setup(x => x.Set<Outcome>()).Returns(TestHelpers.MockDbSet(_outcomesInMemory));
            _jbjjAppMockingContext.Setup(x => x.Set<Attendance>()).Returns(TestHelpers.MockDbSet(_attendanceInMemory));
            _jbjjAppMockingContext.Setup(x => x.Set<SparringDetails>()).Returns(TestHelpers.MockDbSet(_sparringDetailsInMemory));

            _dayAtDojoData = new DayAtDojoData(new GenericRepository<Outcome>(_jbjjAppMockingContext.Object), new GenericRepository<Attendance>(_jbjjAppMockingContext.Object), new GenericRepository<SparringDetails>(_jbjjAppMockingContext.Object));
        }

        #region Outcome
        [TestMethod]
        public void Can_GetOutcome()
        {
            // Arrange
            // Act
            var result = _dayAtDojoData.GetOutcome();

            // Assert
            Assert.AreEqual(_outcomesInMemory.Count(), result.Count());
        }

        [TestMethod]
        public void Can_GetOutcomeById()
        {
            // Arrange
            // Act
            var result = _dayAtDojoData.GetOutcomeById(1);

            // Assert
            Assert.AreEqual(_outcomesInMemory.Where(x => x.Id == 1).First().Id, result.Id);
        }

        [TestMethod]
        public void Can_AddOutcome()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_UpdateOutcome()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_DeleteOutcome()
        {
            // Arrange
            // Act
            // Assert
        }
        #endregion

        #region Attendance
        [TestMethod]
        public void Can_GetAttendance()
        {
            // Arrange
            // Act
            var result = _dayAtDojoData.GetAttendance();

            // Assert
            Assert.AreEqual(_attendanceInMemory.Count(), result.Count());
        }

        [TestMethod]
        public void Can_GetAttendanceById()
        {
            // Arrange
            // Act
            var result = _dayAtDojoData.GetAttendanceById(1);

            // Assert
            Assert.AreEqual(_attendanceInMemory.Where(x => x.Id == 1).First().Id, result.Id);
        }

        [TestMethod]
        public void Can_AddAttendance()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_UpdateAttendance()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_DeleteAttendance()
        {
            // Arrange
            // Act
            // Assert
        }
        #endregion

        #region SparringDetails
        [TestMethod]
        public void Can_GetSparringDetails()
        {
            // Arrange
            // Act
            var result = _dayAtDojoData.GetSparringDetails();

            // Assert
            Assert.AreEqual(_sparringDetailsInMemory.Count(), result.Count());
        }

        [TestMethod]
        public void Can_GetSparringDetailsById()
        {
            // Arrange
            // Act
            var result = _dayAtDojoData.GetSparringDetailsById(1);

            // Assert
            Assert.AreEqual(_sparringDetailsInMemory.Where(x => x.Id == 1).First().Id, result.Id);
        }

        [TestMethod]
        public void Can_AddSparringDetails()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_UpdateSparringDetails()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_DeleteSparringDetails()
        {
            // Arrange
            // Act
            // Assert
        }
        #endregion
    }
}
