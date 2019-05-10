using SharedKernel;
using SharedKernel.Enums;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Domain
{
    public class ClassType : EntityBase
    {
        public string Name { get; set; }
        public List<TimeTable> TimeTables { get; set; }
    }
}
