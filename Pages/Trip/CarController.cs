using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CityWasp.Models;

namespace CityWasp.Pages.Trip
{
    public class CarController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        
    }
}