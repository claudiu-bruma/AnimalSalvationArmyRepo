using AnimalSalvationArmyShelters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSalvationArmy.Web.Models
{
    public class AdoptionStatus
    {
        public bool PetAdoptionPending { get; set; }
        public AdoptionContact AdoptionContact { get; set; }
    }
}
