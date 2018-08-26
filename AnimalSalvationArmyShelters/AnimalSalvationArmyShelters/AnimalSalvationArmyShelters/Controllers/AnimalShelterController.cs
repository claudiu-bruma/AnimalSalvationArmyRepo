using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AnimalSalvationArmy.Services.AnimalShelterServices;

namespace AnimalSalvationArmyShelters.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnimalShelterController : ControllerBase
    {
        private IAnimalShelterServices _animalShelterService;

        public AnimalShelterController(IAnimalShelterServices animalShelterService)
        {
            _animalShelterService = animalShelterService;
        }
        /// <summary>
        /// /Create animal Shelter
        /// </summary>
        /// <param name="shelterName">Animal Shelter Name</param>
        /// <response code="200">Status 200</response>
        [Route("/animalShelter")]       
        public ActionResult Post([FromQuery]string shelterName)
        {
            var uniqueIdOfNewShelter = 0;
            return Ok(uniqueIdOfNewShelter);
        }

        /// <summary>
        /// Delete Animal Shelter
        /// </summary>
        /// <remarks>Delete Animal Shelter</remarks>
        /// <param name="uniqueIdentifierForPetSelter"></param>
        /// <response code="200">Status 200</response>
        /// <response code="404">Shelter to be deleted was not found</response>
        [HttpDelete]
        [Route("/animalShelter")]        
        public ActionResult Delete([FromQuery]int uniqueIdentifierForPetSelter)
        {
              throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/animalShelter")]
        public string Get()
        {
            return "animalShelter";
        }
    }
}