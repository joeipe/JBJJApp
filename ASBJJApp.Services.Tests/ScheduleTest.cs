using System;
using System.Collections.Generic;
using System.Data.Entity;
using JBJJApp.Data;
using JBJJApp.Domain;
using JBJJApp.Web.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharedKernel.Data;

namespace ASBJJApp.Services.Tests
{
    [TestClass]
    public class ScheduleTest
    {
        [TestMethod]
        public void CanAddClassType()
        {   
            //var mockNewClassTypeDbSet = MockNewDbSet<ClassType>();
            //var mockNewTimeTableDbSet = MockNewDbSet<TimeTable>();
            //var jbjjAppContext = new JBJJAppContext() { ClassTypes = mockNewClassTypeDbSet, TimeTables = mockNewTimeTableDbSet };
           
            //var scheduleData = new ScheduleData(new GenericRepository<ClassType>(jbjjAppContext), new GenericRepository<TimeTable>(jbjjAppContext));
            //scheduleData.AddClassType(new ClassTypeViewModel() { Id = 1, Name = "test" });
            ////act
            ////assert
            //Assert.AreEqual("test", jbjjAppContext.ClassTypes.Find(1).Name);
        }

        private DbSet<T> MockNewDbSet<T>() where T :class
        {
            var newEntityInMemory = new List<T>();
            var mockNewEntityDbSet = new Mock<DbSet<T>>();
            mockNewEntityDbSet.Setup(m => m.Add(It.IsAny<T>()))
               .Callback<T>(newEntityInMemory.Add);
            return mockNewEntityDbSet.Object;
        }
    }
}
