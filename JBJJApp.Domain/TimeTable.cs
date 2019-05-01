﻿using SharedKernel;
using SharedKernel.Enums;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBJJApp.Domain
{
    public class TimeTable : EntityBase
    {
        public DayofWeek DayofWeek { get; set; }
        public int StartTimeHr { get; set; }
        public int StartTimeMin { get; set; }
        public int EndTimeHr { get; set; }
        public int EndTimeMin { get; set; }
        public int ClassTypeId { get; set; }
        public ClassType ClassType { get; set; }
        public List<Attendance> Attendances { get; set; }
    }
}
