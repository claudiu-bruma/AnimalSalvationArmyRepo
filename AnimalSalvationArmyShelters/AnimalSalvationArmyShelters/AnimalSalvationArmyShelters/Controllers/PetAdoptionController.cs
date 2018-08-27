using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AnimalSalvationArmyShelters.Models;
using AnimalSalvationArmy.Services.PetService;
using AnimalSalvationArmy.Web.Models;

namespace AnimalSalvationArmyShelters.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class PetAdoptionController : ControllerBase
    {
        private IPetService _petService;
        public PetAdoptionController(IPetService petService)
        {
            _petService = petService;
        }
        /// <summary>
        /// PetAdoption
        /// </summary>
        /// <remarks>query pet adoption status </remarks>
        /// <param name="petId"></param>
        /// <response code="200">Status 200</response>
        [HttpGet("{id}")]
        public ActionResult  Get(int id)
        {
            var pet = _petService.GetPetById(id);
            if(pet == null )
            {
                return NotFound("Pet not found");
            }
            return Ok(
                new AdoptionStatus()
                {
                    PetAdoptionPending = pet.AdoptionContact != null,
                    AdoptionContact = pet.AdoptionContact != null ? 
                                new AdoptionContact() {
                                    Address = pet.AdoptionContact.Address,
                                    Email = pet.AdoptionContact.Email,
                                    Name = pet.AdoptionContact.Name,
                                    PhoneNo = pet.AdoptionContact.PhoneNo 
                                } :null
                }
            );
             
        }

        /// <summary>
        /// Post Adoption request for pet
        /// </summary>
        /// <remarks>Post Adoption request for pet</remarks>
        /// <param name="petId">Unique id for the pet you want to adopt</param>
        /// <param name="contactDetails">Contact details for pet lover who wants to apopt</param>
        /// <response code="200">Status 200</response>
        /// <response code="301">Pet already adopted or pending adoption</response>
        /// <response code="404">No such pet found</response>
        [HttpPost]
        public void Post([FromBody] AdoptionContact value)
        {
        }
        /// <summary>
        /// Mark Pet as adoptable ( ready for adoption )
        /// </summary>
        /// <param name="petId">unique id of pet to be markedAsAdoptable</param>
        /// <response code="200">Status 200</response>
        [HttpPut]
        public void Put([FromBody] int id)
        {
        }

    }
}