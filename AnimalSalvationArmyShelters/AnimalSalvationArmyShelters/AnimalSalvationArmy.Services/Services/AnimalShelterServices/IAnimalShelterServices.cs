using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSalvationArmy.Services.AnimalShelterServices
{
    public interface IAnimalShelterServices
    {
        int CreateAnimalShelter(string shelterName);
        void DeleteAnimalShelter(int shelterUniqueID);
        
    }
}
