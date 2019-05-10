using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBJJApp.Web.ViewModels
{
    public class TimeTableClassAttendedViewModel
    {
        public int Id { get; set; }
        public string DayofWeek { get; private set; }
        public int StartTimeHr { get; private set; }
        public int StartTimeMin { get; private set; }
        public int EndTimeHr { get; private set; }
        public int EndTimeMin { get; private set; }
        public string ClassType { get; private set; }
    }
}
