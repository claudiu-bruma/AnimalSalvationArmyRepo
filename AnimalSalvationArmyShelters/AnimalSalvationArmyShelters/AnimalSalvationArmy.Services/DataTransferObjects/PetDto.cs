using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSalvationArmy.Services.DataTransferObjects
{
    public class PetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string MedicalCondition { get; set; }
        public int ShelterId { get; set; }
        public byte[] Photo { get; set; }
        public AdoptionContactDto AdoptionContact { get; set; }

    }
}
