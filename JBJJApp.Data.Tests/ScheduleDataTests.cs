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
    public class ScheduleDataTests
    {
        private List<ClassType> _classTypesInMemory;
        private List<TimeTable> _timeTablesInMemory;
        private Mock<JBJJAppContext> _jbjjAppMockingContext;
        private ScheduleData _scheduleData;

        [TestInitialize]
        public void Setup()
        {
            var now = DateTime.Now;
            var classType1 = new ClassType() { Id = 1, Name = "Test1", CreatedDate = now, UpdatedDate = now, State = ObjectState.Unchanged };
            var classType2 = new ClassType() { Id = 2, Name = "Test2", CreatedDate = now, UpdatedDate = now, State = ObjectState.Unchanged };
            var timeTable1 = new TimeTable() { Id = 1, DayofWeek = DayofWeek.Monday, StartTimeHr = 18, StartTimeMin = 30, EndTimeHr = 19, EndTimeMin = 30, ClassTypeId = 1, CreatedDate = now, UpdatedDate = now, ClassType = classType1, State = ObjectState.Unchanged };
            var timeTable2 = new TimeTable() { Id = 1, DayofWeek = DayofWeek.Monday, StartTimeHr = 19, StartTimeMin = 30, EndTimeHr = 20, EndTimeMin = 30, ClassTypeId = 2, CreatedDate = now, UpdatedDate = now, ClassType = classType2, State = ObjectState.Unchanged };
            _classTypesInMemory = new List<ClassType>() { classType1, classType2 };
            _timeTablesInMemory = new List<TimeTable>() { timeTable1, timeTable2 };

            _jbjjAppMockingContext = new Mock<JBJJAppContext>();
            //_jbjjAppMockingContext.Setup(x => x.FixState()).Callback<ClassType>((entity) => _classTypesInMemory.Remove(entity));
            _jbjjAppMockingContext.Setup(x => x.Set<ClassType>()).Returns(TestHelpers.MockDbSet(_classTypesInMemory));
            _jbjjAppMockingContext.Setup(x => x.Set<TimeTable>()).Returns(TestHelpers.MockDbSet(_timeTablesInMemory));

            _scheduleData = new ScheduleData(new GenericRepository<ClassType>(_jbjjAppMockingContext.Object), new GenericRepository<TimeTable>(_jbjjAppMockingContext.Object));
        }

        #region ClassType
        [TestMethod]
        public void Can_GetClassType()
        {
            // Arrange
            // Act
            var result = _scheduleData.GetClassType();

            // Assert
            Assert.AreEqual(_classTypesInMemory.Count(), result.Count());
        }

        [TestMethod]
        public void Can_GetClassTypeById()
        {
            // Arrange
            // Act
            var result = _scheduleData.GetClassTypeById(1);

            // Assert
            Assert.AreEqual(_classTypesInMemory.Where(x => x.Id == 1).First().Id, result.Id);
        }

        [TestMethod]
        public void Can_AddClassType()
        {
            /*
            // Arrange
            var testObject = new ClassType() { Id = 1, Name = "Test1", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, State = ObjectState.Unchanged, TimeTables = null };
            testObject.State = ObjectState.Added;

            var context = new Mock<DbContext>();
            var dbSetMock = new Mock<DbSet<ClassType>>();
            context.Setup(x => x.Set<ClassType>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Add(It.IsAny<ClassType>())).Returns(testObject);

            // Act
            var repository = new GenericRepository<ClassType>(context.Object);
            repository.Add(testObject);

            //Assert
            context.Verify(x => x.Set<ClassType>());
            dbSetMock.Verify(x => x.Add(It.Is<ClassType>(y => y == testObject)));
            */
        }

        [TestMethod]
        public void Can_UpdateClassType()
        {

        }

        [TestMethod]
        public void Can_DeleteClassType()
        {
            /*
            // Arrange
            var testObject = new ClassType();

            var context = new Mock<JBJJAppContext>();
            var dbSetMock = new Mock<DbSet<ClassType>>();
            context.Setup(x => x.Set<ClassType>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Remove(It.IsAny<ClassType>())).Returns(testObject);

            // Act
            var repository = new GenericRepository<ClassType>(context.Object);
            repository.Delete(testObject);

            //Assert
            context.Verify(x => x.Set<ClassType>());
            dbSetMock.Verify(x => x.Remove(It.Is<ClassType>(y => y == testObject)));
            */
        }
        #endregion

        #region TimeTable
        [TestMethod]
        public void Can_GetTimeTable()
        {
            // Arrange
            // Act
            var result = _scheduleData.GetTimeTable();

            // Assert
            Assert.AreEqual(_timeTablesInMemory.Count(), result.Count());
        }

        [TestMethod]
        public void Can_GetTimeTableById()
        {
            // Arrange
            // Act
            var result = _scheduleData.GetClassTypeById(1);

            // Assert
            Assert.AreEqual(_timeTablesInMemory.Where(x => x.Id == 1).First().Id, result.Id);
        }

        [TestMethod]
        public void Can_GetTimeTableWithClassTypeById()
        {
            // Arrange
            // Act
            var result = _scheduleData.GetTimeTableWithClassTypeById(1);

            // Assert
            Assert.AreEqual(_timeTablesInMemory.Where(x => x.Id == 1).First().Id, result.Id);
            Assert.AreEqual(_timeTablesInMemory.Where(x => x.Id == 1).First().ClassType.Id, result.ClassType.Id);
        }

        [TestMethod]
        public void Can_AddTimeTable()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_UpdateTimeTable()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_DeleteTimeTable()
        {
            // Arrange
            // Act
            // Assert
        }
        #endregion
    }
}
