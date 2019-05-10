﻿using AutoMapper;
using JBJJApp.Web.ViewModels;
using DayAtDojo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayAtDojo.Data
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
                cfg.CreateMap<Outcome, OutcomeViewModel>();
                cfg.CreateMap<OutcomeViewModel, Outcome>();

                cfg.CreateMap<Attendance, AttendanceViewModel>();
                cfg.CreateMap<AttendanceViewModel, Attendance>();

                cfg.CreateMap<Attendance, AttendanceDetailedViewModel>();

                cfg.CreateMap<SparringDetails, SparringDetailsViewModel>();
                cfg.CreateMap<SparringDetailsViewModel, SparringDetails>();

                cfg.CreateMap<TimeTableClassAttended, TimeTableClassAttendedViewModel>();

                cfg.CreateMap<PersonSparringPartner, PersonSparringPartnerViewModel>();
            });

            _mapper = config.CreateMapper();
        }
    }
}