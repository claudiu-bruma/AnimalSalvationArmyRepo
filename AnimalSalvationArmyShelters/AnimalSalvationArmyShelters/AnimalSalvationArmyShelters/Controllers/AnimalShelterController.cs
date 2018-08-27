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
        /// <response code="400">Status 400</response>
        ///  <response code="409">Status 409 Shelter already exists</response>
        [Route("/animalShelter")]
        public ActionResult Post([FromQuery]string shelterName)
        {
            if(string.IsNullOrEmpty (shelterName ))
            {
                return BadRequest("Shelter name cannot be empty");
            }
            try
            {
                var uniqueIdOfNewShelter = _animalShelterService.CreateAnimalShelter(shelterName);
                return Ok(uniqueIdOfNewShelter);
            }
            catch(ArgumentException aex)
            {
                return Conflict(aex.Message);
            }
            
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
            try
            {
                _animalShelterService.DeleteAnimalShelter(uniqueIdentifierForPetSelter);
                return Ok();
            }catch(ArgumentException aex)
            {
                return NotFound(aex.Message);
            }


        }
    }
}