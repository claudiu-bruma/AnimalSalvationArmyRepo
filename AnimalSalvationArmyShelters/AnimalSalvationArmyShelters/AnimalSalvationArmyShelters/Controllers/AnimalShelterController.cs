using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AnimalSalvationArmyShelters.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnimalShelterController : ControllerBase
    {
        /// <summary>
        /// /Create animal Shelter
        /// </summary>
        /// <param name="shelterName">Animal Shelter Name</param>
        /// <response code="200">Status 200</response>
        [Route("/animalShelter")]       
        public ActionResult Post([FromQuery]string shelterName)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(int?));

            string exampleJson = null;
            exampleJson = "0";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<int?>(exampleJson)
            : default(int?);
            //TODO: Change the data returned
            return new ObjectResult(example);
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
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);


            throw new NotImplementedException();
        }
    }
}