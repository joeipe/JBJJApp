using SharedKernel;
using SharedKernel.Enums;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBJJApp.Domain
{
    public class Grade : EntityBase
    {
        public string Name { get; set; }
        public List<Person> People { get; set; }
    }
}
