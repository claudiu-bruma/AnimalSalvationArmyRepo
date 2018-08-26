using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalSalvationArmyShelters.Models;
using Microsoft.AspNetCore.Mvc; 
using AnimalSalvationArmy.Services.ShelterWorker;

namespace AnimalSalvationArmyShelters.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShelterWorkerController : Controller
    {
        private IShelterWorkerService _shelterWorkerService;
        public ShelterWorkerController(IShelterWorkerService shelterWorkerService)
        {
            _shelterWorkerService = shelterWorkerService;
        }
        
        /// <summary>
        /// remove worker from system
        /// </summary>
        /// <param name="shelterWorkerID"></param>
        /// <response code="200">Status 200</response>
        [HttpDelete]
        [Route("/animalShelter/worker")]
        public IActionResult Delete([FromQuery]int shelterWorkerID)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Add worker to shelter
        /// </summary>
        /// <remarks>Add worker to shelter</remarks>
        /// <param name="body"></param>
        /// <response code="200">Status 200</response>
        [HttpPost]
        [Route("/animalShelter/worker")]
        public virtual IActionResult Post([FromBody]ShelterWorker body)
        {
            
            int id = 0;
            return Ok(id);
        }
    }
}