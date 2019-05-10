using System;
using System.Collections.Generic;
using System.Linq;
using DayAtDojo.Data.Services;
using DayAtDojo.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharedKernel.Data;
using SharedKernel.Enums;

namespace DayAtDojo.Data.IntegrationTests
{
    [TestClass]
    public class UnitTests
    {
        private List<Outcome> _outcomesInMemory;
        private List<Attendance> _attendanceInMemory;
        private List<SparringDetails> _sparringDetailsInMemory;
        private List<TimeTableClassAttended> _timeTableClassAttendedInMemory;
        private List<PersonSparringPartner> _personSparringPartnerInMemory;
        private Mock<DayAtDojoContext> _dayAtDojoMockingContext;
        private Mock<ReferenceScheduleContext> _referenceScheduleMockingContext;
        private Mock<ReferenceStudentContext> _referenceStudentMockingContext;
        private DayAtDojoData _dayAtDojoData;

        [TestInitialize]
        public void Setup()
        {
            var now = DateTime.Now;
            var outcome1 = new Outcome() { Id = 1, Name = "Win", CreatedDate = now, UpdatedDate = now, State = ObjectState.Unchanged };
            var outcome2 = new Outcome() { Id = 2, Name = "Loss", CreatedDate = now, UpdatedDate = now, State = ObjectState.Unchanged };
            var attendance1 = new Attendance() { Id = 1, TimeTableId = 1, AttendedOn = now, TechniqueOfTheDay = "Something", CreatedDate = now, UpdatedDate = now, State = ObjectState.Unchanged }; //TimeTable = null
            var sparringDetails1 = new SparringDetails() { Id = 1, AttendanceId = 1, PersonId = 1, OutcomeId = 1, TechniqueUsed = "rear naked choke", CreatedDate = now, UpdatedDate = now, Outcome = outcome1, State = ObjectState.Unchanged };
            var sparringDetails2 = new SparringDetails() { Id = 2, AttendanceId = 1, PersonId = 2, OutcomeId = 2, TechniqueUsed = "Passing the guard", CreatedDate = now, UpdatedDate = now, Outcome = outcome2, State = ObjectState.Unchanged };
            var timeTable1 = new TimeTableClassAttended() { Id = 1, DayofWeek = "Monday", StartTimeHr = 6, StartTimeMin = 45, EndTimeHr = 7, EndTimeMin = 45, ClassType = "BJJ Gi All Levels" };
            var person1 = new PersonSparringPartner() { Id = 1, FullName = "Peppe Impala", Stripe = 0, Grade = "Purple" };
            var person2 = new PersonSparringPartner() { Id = 2, FullName = "Leonard Correa", Stripe = 2, Grade = "Purple" };
            _outcomesInMemory = new List<Outcome>() { outcome1, outcome2 };
            _attendanceInMemory = new List<Attendance>() { attendance1 };
            _sparringDetailsInMemory = new List<SparringDetails>() { sparringDetails1, sparringDetails2 };
            _timeTableClassAttendedInMemory = new List<TimeTableClassAttended>() { timeTable1 };
            _personSparringPartnerInMemory = new List<PersonSparringPartner>() { person1, person2 };

            _dayAtDojoMockingContext = new Mock<DayAtDojoContext>();
            _dayAtDojoMockingContext.Setup(x => x.Set<Outcome>()).Returns(TestHelpers.MockDbSet(_outcomesInMemory));
            _dayAtDojoMockingContext.Setup(x => x.Set<Attendance>()).Returns(TestHelpers.MockDbSet(_attendanceInMemory));
            _dayAtDojoMockingContext.Setup(x => x.Set<SparringDetails>()).Returns(TestHelpers.MockDbSet(_sparringDetailsInMemory));
            _referenceScheduleMockingContext = new Mock<ReferenceScheduleContext>();
            _referenceScheduleMockingContext.Setup(x => x.Set<TimeTableClassAttended>()).Returns(TestHelpers.MockDbSet(_timeTableClassAttendedInMemory));
            _referenceStudentMockingContext = new Mock<ReferenceStudentContext>();
            _referenceStudentMockingContext.Setup(x => x.Set<PersonSparringPartner>()).Returns(TestHelpers.MockDbSet(_personSparringPartnerInMemory));

            _dayAtDojoData = new DayAtDojoData(
                new GenericRepository<Outcome>(_dayAtDojoMockingContext.Object), 
                new GenericRepository<Attendance>(_dayAtDojoMockingContext.Object), 
                new GenericRepository<SparringDetails>(_dayAtDojoMockingContext.Object), 
                new GenericRepository<PersonSparringPartner>(_referenceStudentMockingContext.Object), 
                new GenericRepository<TimeTableClassAttended>(_referenceScheduleMockingContext.Object));
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
        public void Can_GetAttendanceWithGraphById()
        {
            // Arrange
            // Act
            var result = _dayAtDojoData.GetAttendanceWithGraphById(1);

            // Assert
            Assert.AreEqual(_attendanceInMemory.Where(x => x.Id == 1).First().Id, result.Id);
            Assert.AreEqual(_timeTableClassAttendedInMemory.Where(x => x.Id == 1).First().ClassType, result.TimeTableClassAttended.ClassType);
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
        public void Can_GetSparringDetailsWithGraph()
        {
            // Arrange
            // Act
            var result = _dayAtDojoData.GetSparringDetailsWithGraph();

            // Assert
            Assert.AreEqual(_sparringDetailsInMemory.Count(), result.Count());
            //Assert.AreEqual(_attendanceInMemory.Where(a => a.Id == 1).First().Id, result.Where(r => r.Id == 1).First().Attendance.Id);
            Assert.AreEqual(_outcomesInMemory.Where(o => o.Id == 2).First().Id, result.Where(r => r.Id == 2).First().Outcome.Id);
            Assert.AreEqual(_personSparringPartnerInMemory.Where(o => o.Id == 2).First().Id, result.Where(r => r.Id == 2).First().PersonSparringPartner.Id);
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
