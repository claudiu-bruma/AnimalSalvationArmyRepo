using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalSalvationArmyShelters.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AnimalSalvationArmy.Services.PetService;
using AnimalSalvationArmy.Services.AnimalShelterServices;
using AnimalSalvationArmy.Services.DataTransferObjects;

namespace AnimalSalvationArmyShelters.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private IPetService _petService;
        private IAnimalShelterServices _animalShelter;
        public PetController(IPetService petService, IAnimalShelterServices animalShelter)
        {
            _petService = petService;
            _animalShelter = animalShelter;
        }
        /// <summary>
        /// Get a record for a pet with available details
        /// </summary>
        /// <remarks>Get a record for a pet with available details</remarks>
        /// <param name="petId"></param>
        /// <response code="200">Status 200</response>
        /// <response code="404">Pet not found</response>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var pet = _petService.GetPetById(id);
                return Ok(pet);
            }catch(ArgumentException aex)
            {
                return NotFound(aex.Message);      
            }
        }

        /// <summary>
        /// Add a new pet to a shelter
        /// </summary>
        /// <param name="petForAdoption"></param>
        /// <response code="200">Status 200</response>
        [HttpPost]
        public ActionResult Post([FromBody] Pet value)
        {
            if (value.ShelterId <= 0)
            {
                return NotFound("Please Specify shelter");
            }
            if (string.IsNullOrWhiteSpace ( value.Name ))
            {
                return NotFound("This pet needs a name");
            }            
            _petService.AddPetToShelter(new PetDto()
            {
                MedicalCondition = value.MedicalCondition ,
                Name = value.Name,
                Photo = value.Photo,
                Race = value.Race ,
                ShelterId = value.ShelterId
            });
            return Ok(value);
        }

        /// <summary>
        /// Remove Pet From Shelter
        /// </summary>
        /// <remarks>remove an animal from the shelter list (orray! we succeeded!!!);</remarks>
        /// <param name="petId"></param>
        /// <response code="200">Status 200</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _petService.RemovePetFromShelter(id);
                return Ok(id);
            }
            catch(ArgumentException aex)
            {
                return NotFound(aex.Message);
            }

        }
        /// <summary>
        /// Pets
        /// </summary>
        /// <remarks>Get a list of All Pets for adoption </remarks>
        /// <param name="shelterId"></param>
        /// <response code="200">Status 200</response>
        [HttpGet]
        [Route("Pet/List")]
        public ActionResult List()
        {
           return Ok( GetPetList(new Nullable<int>(), new Nullable<bool>()));
        }
        /// <summary>
        /// browse the list of adoptable animals, filtering by shelter name and by already pending adoption
        /// </summary>
        /// <remarks>browse the list of adoptable animals, filtering by shelter name and by already pending adoption</remarks>
        /// <param name="shelterName">Name of shelter to filter by</param>
        /// <param name="petAlreadyPendingAdoption">Pet already pending adoption</param>
        /// <response code="200">Status 200</response>
        [HttpGet]
        [Route("Pet/CustomerList")]
        public ICollection<Pet> CustomerList(string shelterName , bool petAlreadyPendingAdoption = false )
        {
            throw new NotImplementedException();
        }
        private ICollection<Pet> GetPetList(int? shelterId, bool? petAlreadyPendingAdoption)
        {
            var pets = _petService.GetListOfPets(shelterId, petAlreadyPendingAdoption);
            if (!pets.Any())
            {
                return new List<Pet>();
            }
            return pets.Select(x => new Pet()
            {
                MedicalCondition = x.MedicalCondition,
                Name = x.Name,
                Photo = x.Photo,
                Race = x.Race,
                ShelterId = x.ShelterId,
                Id = x.Id
            }).ToList();
        }
    }
}