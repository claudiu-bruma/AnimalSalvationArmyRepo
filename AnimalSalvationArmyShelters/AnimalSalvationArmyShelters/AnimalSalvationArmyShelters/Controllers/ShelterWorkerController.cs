using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AnimalSalvationArmyShelters.Controllers
{
    public class ShelterWorkerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}