using AnimalSalvationArmy.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSalvationArmy.Services.Entities
{
    public class ShelterWorkerEntity: BaseEntity
    {
        public int ShelterId { get; set; }
        public string Name { get; set; }     
    }

}
