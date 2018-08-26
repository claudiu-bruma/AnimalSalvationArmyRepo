using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSalvationArmy.Services.DataTransferObjects
{
    public class AdoptionContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }
}
