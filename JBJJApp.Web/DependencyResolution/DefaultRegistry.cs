// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace JBJJApp.Web.DependencyResolution {
    using DayAtDojo.Data;
    using DayAtDojo.Data.Services;
    using JBJJApp.Web.Controllers;
    using Schedule.Data;
    using Schedule.Data.Services;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using StructureMap.Web.Pipeline;
    using Student.Data;
    using Student.Data.Services;
    using System.Data.Entity;

    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            //For<IExample>().Use<Example>();
            /*
            var scheduleContext = For<DbContext>().Use<ScheduleContext>().Transient();
            For<ScheduleController>().Use<ScheduleController>()
                .Ctor<ScheduleData>().Is(scheduleContext)
                .LifecycleIs<HttpContextLifecycle>();

            var StudentContext = For<DbContext>().Use<StudentContext>().Transient();
            For<StudentController>().Use<StudentController>()
                .Ctor<StudentData>().Is(StudentContext)
                .LifecycleIs<HttpContextLifecycle>();

            var DayAtDojoContext = For<DbContext>().Use<DayAtDojoContext>().Transient();
            For<DayAtDojoController>().Use<DayAtDojoController>()
                .Ctor<DayAtDojoData>().Is(DayAtDojoContext)
                .LifecycleIs<HttpContextLifecycle>();
                */

        }

        #endregion
    }
}