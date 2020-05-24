using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CityWasp.Data;
using CityWasp.Models;
using Microsoft.EntityFrameworkCore;

namespace CityWasp
{
    public class ViewModel : PageModel
    {
        private readonly CityWasp.Data.CityWaspContext _context;

        public ViewModel(CityWasp.Data.CityWaspContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get; set; }
        public IList<Car> CarUsed { get; set; }
        public IList<Car> CarRez { get; set; }
        public int CarUsedCount { get; set; }
        public int CarRezCount { get; set; }
        public int CarCount { get; set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Car.ToListAsync();
            CarUsed = new List<Car>();
            CarRez = new List<Car>();
            foreach (var it in Car)
            {
                if (it.state.Equals(CityWasp.Models.Car.CarState.InUse))
                {
                    CarUsed.Add(it);
                    CarUsedCount++;
                }
                if (it.state.Equals(CityWasp.Models.Car.CarState.Rezerved))
                {
                    CarRez.Add(it);
                    CarRezCount++;
                }
            }
            CarCount = Car.Count;
        }
    }
}
