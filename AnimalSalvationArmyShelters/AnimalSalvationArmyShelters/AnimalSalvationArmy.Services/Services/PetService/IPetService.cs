using AnimalSalvationArmy.Services.DataTransferObjects;
using System.Collections.Generic;

namespace AnimalSalvationArmy.Services.PetService
{
    public interface IPetService
    {
        PetDto GetPetById(int id);
        int AddPetToShelter(PetDto newPet);
        void RemovePetFromShelter(int petId);
        ICollection<PetDto> GetListOfPets(int? shelterId, bool? petAlreadyPendingAdoption);
    }
}
