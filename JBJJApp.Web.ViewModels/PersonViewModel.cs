using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBJJApp.Web.ViewModels
{
    public class PersonViewModel : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GradeId { get; set; }
        public int Stripe { get; set; }
        public GradeViewModel Grade { get; set; }
        public List<SparringDetailsViewModel> SparringDetails { get; set; }
    }
}
