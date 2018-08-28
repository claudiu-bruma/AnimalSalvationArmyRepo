using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSalvationArmyShelters.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string MedicalCondition { get; set; }
        public int ShelterId { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoUrl { get; set; }
    }
}
