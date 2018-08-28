using AnimalSalvationArmy.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSalvationArmy.Services.Entities
{
    public class PetEntity: BaseEntity
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string MedicalCondition { get; set; }
        public int ShelterId { get; set; }
        public byte[] Photo { get; set; }
        public AdoptionContactEntity AdoptionContact { get; set; }

    }
}
