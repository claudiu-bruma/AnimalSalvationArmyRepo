using AnimalSalvationArmy.DataAccessLayer;
using AnimalSalvationArmy.DataAccessLayer.DataHelpers;
using AnimalSalvationArmy.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalSalvationArmy.Services.AnimalShelterServices
{
    public class AnimalShelterServices : IAnimalShelterServices
    {
        private AnimalShelterApplicationDataStore _dataStore;
 
        public AnimalShelterServices(AnimalShelterApplicationDataStore dataStore  )
        {
            _dataStore = dataStore;
           
        }

        public int CreateAnimalShelter(string shelterName)
        {
            //check if shelter already exists 
            if( _dataStore.AnimalShelters.Any(x=>x.Name ==  shelterName ) )
            {
                throw new ArgumentException("That shelter already exists");
            }
             var newAnimalShelter =new Entities.AnimalShelterEntity()
            {
             Name =shelterName                
            };
            _dataStore.AddAnimalShelter(newAnimalShelter);
            return newAnimalShelter.Id;

            
        }
        public bool VerifyShelterId(int id)
        {
            if (id <= 0)
                return false; 
            return _dataStore.AnimalShelters.Any(x=>x.Id == id);
        }

        public void DeleteAnimalShelter(int shelterUniqueID)
        {
            if(!_dataStore.AnimalShelters.Any(x=>x.Id == shelterUniqueID ))
            {
                throw new ArgumentException("Shelter not found");
            }

            var animalShelter =  _dataStore.AnimalShelters.FirstOrDefault(x => x.Id == shelterUniqueID);
            _dataStore.AnimalShelters.Remove(animalShelter);
        }

        public int GetShelterByName(string shelterName)
        {
            if (!_dataStore.AnimalShelters.Any(x => x.Name == shelterName))
            {
                throw new ArgumentException("Shelter not found");
            }
            return _dataStore.AnimalShelters
                .Where(x => x.Name == shelterName).Select(x=>x.Id).FirstOrDefault();
            
        }
    }
}
