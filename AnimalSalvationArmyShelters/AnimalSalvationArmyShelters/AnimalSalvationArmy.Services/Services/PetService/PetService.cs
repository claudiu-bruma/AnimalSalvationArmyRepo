using AnimalSalvationArmy.DataAccessLayer;
using AnimalSalvationArmy.DataAccessLayer.DataHelpers;
using AnimalSalvationArmy.Services.DataTransferObjects;
using AnimalSalvationArmy.Services.PetService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalSalvationArmy.Services.PetService
{
    public class PetService : IPetService
    {
        private AnimalShelterApplicationDataStore _dataStore;       
        public PetService(AnimalShelterApplicationDataStore dataStore  )
        {
            _dataStore = dataStore;
        }
        public int AddPetToShelter(PetDto newPet)
        {
            
             var newPetEntity = new Entities.PetEntity()
            {
                MedicalCondition = newPet.MedicalCondition ,
                Name = newPet.Name ,
                Photo = newPet.Photo ,
                Race = newPet.Race, 
                ShelterId = newPet.ShelterId 
               
            };
            _dataStore.AddPet(newPetEntity);
            return newPetEntity.Id;
        }

        public ICollection<PetDto> GetListOfPets(int? shelterId  , bool? petAlreadyPendingAdoption)
        {
            return _dataStore.Pets.Where(x =>
                          (
                             (
                                 shelterId.HasValue && x.ShelterId == shelterId) || !shelterId.HasValue)

                             ).Select(x => new PetDto()
                             {
                                 Id = x.Id,
                                 MedicalCondition = x.MedicalCondition,
                                 Name = x.Name,
                                 Photo = x.Photo,
                                 Race = x.Race,
                                 ShelterId = x.ShelterId
                             }).ToList();
                         
                         
        }

        public PetDto GetPetById(int id)
        {
            if (!_dataStore.Pets.Any(x => x.Id == id))
                throw new ArgumentException("No pet with this id exists");
            return _dataStore.Pets.Where(x =>x.Id == id)
                .Select(x => new PetDto()
                             {
                                 Id = x.Id,
                                 MedicalCondition = x.MedicalCondition,
                                 Name = x.Name,
                                 Photo = x.Photo,
                                 Race = x.Race,
                                 ShelterId = x.ShelterId
                             }).FirstOrDefault();
        }

        public void RemovePetFromShelter(int petId)
        {
            if (!_dataStore.Pets.Any(x => x.Id == petId))
            {
                throw new ArgumentException("Pet not found");
            }

            var pet = _dataStore.Pets.FirstOrDefault(x => x.Id == petId);
            _dataStore.Pets.Remove(pet);
        }
    }
}
