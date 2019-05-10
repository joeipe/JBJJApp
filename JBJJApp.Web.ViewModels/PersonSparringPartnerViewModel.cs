using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBJJApp.Web.ViewModels
{
    public class PersonSparringPartnerViewModel
    {
        public int Id { get; set; }
        public string FullName { get; private set; }
        public int Stripe { get; private set; }
        public string Grade { get; private set; }
    }
}
