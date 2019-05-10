﻿using AutoMapper;
using JBJJApp.Web.ViewModels;
using Schedule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Data
{
    public static class ObjectMapper
    {
        static IMapper _mapper;
        public static IMapper Mapper
        {
            get
            {
                return _mapper;
            }
        }
        static ObjectMapper()
        {
            CreateMap();
        }
        private static void CreateMap()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClassType, ClassTypeViewModel>();
                cfg.CreateMap<ClassTypeViewModel, ClassType>();

                cfg.CreateMap<TimeTable, TimeTableViewModel>()
                    .ForMember(vm => vm.DayofWeek, o => o.MapFrom(a => ((DayofWeek)a.DayofWeek).ToString()));
                cfg.CreateMap<TimeTableViewModel, TimeTable>()
                    .ForMember(o => o.DayofWeek, vm => vm.MapFrom(a => (DayofWeek)Enum.Parse(typeof(DayofWeek), a.DayofWeek)));
            });

            _mapper = config.CreateMapper();
        }
    }
}