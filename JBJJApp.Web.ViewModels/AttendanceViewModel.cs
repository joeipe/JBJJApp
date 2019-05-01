using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBJJApp.Web.ViewModels
{
    public class AttendanceViewModel : Base
    {
        public int TimeTableId { get; set; }
        public DateTime AttendedOn { get; set; }
        public string TechniqueOfTheDay { get; set; }
        public TimeTableViewModel TimeTable { get; set; }
        public List<SparringDetailsViewModel> SparringDetails { get; set; }
    }
}
