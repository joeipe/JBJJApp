using SharedKernel.Enums;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBJJApp.Web.ViewModels
{
    public abstract class Base : IEntity, IStateObject
    {
        public int Id { get; set; }
        public ObjectState State { get; set; }
    }
}
