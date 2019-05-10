using SharedKernel;
using SharedKernel.Enums;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayAtDojo.Domain
{
    public class TimeTableClassAttended : IEntity
    {
        public int Id { get; set; }
        public string DayofWeek { get; set; }
        public int StartTimeHr { get; set; }
        public int StartTimeMin { get; set; }
        public int EndTimeHr { get; set; }
        public int EndTimeMin { get; set; }
        public string ClassType { get; set; }
    }
}
