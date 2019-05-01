using AutoMapper;
using JBJJApp.Domain;
using JBJJApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBJJApp.Data
{
    public static class ObjectMapper
    {
        public static IMapper Mapper
        {
            get
            {
                return AutoMapper.Mapper.Instance;
            }
        }
        static ObjectMapper()
        {
            CreateMap();
        }
        private static void CreateMap()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ClassType, ClassTypeViewModel>();
                cfg.CreateMap<ClassTypeViewModel, ClassType>();

                cfg.CreateMap<TimeTable, TimeTableViewModel>()
                    .ForMember(vm => vm.DayofWeek, o => o.MapFrom(a => ((DayofWeek)a.DayofWeek).ToString()));
                cfg.CreateMap<TimeTableViewModel, TimeTable>()
                    .ForMember(o => o.DayofWeek, vm => vm.MapFrom(a => (DayofWeek)Enum.Parse(typeof(DayofWeek), a.DayofWeek)));

                cfg.CreateMap<Grade, GradeViewModel>();
                cfg.CreateMap<GradeViewModel, Grade>();

                cfg.CreateMap<Person, PersonViewModel>();
                cfg.CreateMap<PersonViewModel, Person>();

                cfg.CreateMap<Outcome, OutcomeViewModel>();
                cfg.CreateMap<OutcomeViewModel, Outcome>();

                cfg.CreateMap<Attendance, AttendanceViewModel>();
                cfg.CreateMap<AttendanceViewModel, Attendance>();

                cfg.CreateMap<SparringDetails, SparringDetailsViewModel>()
                    .ForMember(vm => vm.Attendance, o => o.Ignore());
                cfg.CreateMap<SparringDetailsViewModel, SparringDetails>();
            });
        }
    }
}
