using AnimalSalvationArmy.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSalvationArmy.Services.Entities
{
    public class AdoptionContactEntity : BaseEntity
    {         
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }
}
