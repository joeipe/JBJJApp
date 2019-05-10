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
    public class Outcome : EntityBase
    {
        public string Name { get; set; }
        public List<SparringDetails> SparringDetails { get; set; }
    }
}
