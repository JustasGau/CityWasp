using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CityWasp.Data;
using CityWasp.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CityWasp
{
    public class ClosestCarViewModel : PageModel
    {
        public IList<Car> Car { get; set; }
        private readonly CityWasp.Data.CityWaspContext _context;

        public ClosestCarViewModel(CityWasp.Data.CityWaspContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(string cars)
        {
            Car = JsonConvert.DeserializeObject<IList<Car>>(cars);
            return Page();
        }
    }
}