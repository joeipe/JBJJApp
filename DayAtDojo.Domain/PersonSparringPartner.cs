﻿using SharedKernel;
using SharedKernel.Enums;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayAtDojo.Domain
{
    public class PersonSparringPartner : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Stripe { get; set; }
        public string Grade { get; set; }
    }
}