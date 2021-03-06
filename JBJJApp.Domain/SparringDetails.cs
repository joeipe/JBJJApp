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
    public class SparringDetails : EntityBase
    {
        public int AttendanceId { get; set; }
        public int PersonId { get; set; }
        public int OutcomeId { get; set; }
        public string TechniqueUsed { get; set; }
        public Attendance Attendance { get; set; }
        public Person Person { get; set; }
        public Outcome Outcome { get; set; }
    }
}
