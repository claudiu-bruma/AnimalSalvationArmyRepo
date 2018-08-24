using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalSalvationArmyShelters.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalSalvationArmyShelters.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        /// <summary>
        /// Get a record for a pet with available details
        /// </summary>
        /// <remarks>Get a record for a pet with available details</remarks>
        /// <param name="petId"></param>
        /// <response code="200">Status 200</response>
        /// <response code="404">Pet not found</response>
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return new Pet();
        }

        /// <summary>
        /// Add a new pet to a shelter
        /// </summary>

        /// <param name="petForAdoption"></param>
        /// <response code="200">Status 200</response>
        [HttpPost]
        public void Post([FromBody] Pet value)
        {
        }

        /// <summary>
        /// Remove Pet From Shelter
        /// </summary>
        /// <remarks>remove an animal from the shelter list (orray! we succeeded!!!);</remarks>
        /// <param name="petId"></param>
        /// <response code="200">Status 200</response>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        /// <summary>
        /// Pets
        /// </summary>
        /// <remarks>Get a list of All Pets for adoption </remarks>
        /// <param name="shelterId"></param>
        /// <response code="200">Status 200</response>
        [HttpGet]
        [Route("Pet/List")]
        public ICollection<Pet> List()
        {
            return new List<Pet>();
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
            return new List<Pet>();
        }
    }
}