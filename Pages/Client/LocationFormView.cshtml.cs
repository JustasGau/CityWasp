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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CityWasp
{
    public class LocationFormViewModel : PageModel
    {
        private readonly CityWasp.Data.CityWaspContext _context;

        public LocationFormViewModel(CityWasp.Data.CityWaspContext context)
        {
            _context = context;
        }


        public IList<Car> Car { get; set; }
        public IList<Trip> Trip { get; set; }
        public IList<Car> CarCoordinates { get; set; }
        public IList<Car> filtered { get; set; }
        public IList<Car> searched { get; set; }

        public List<SelectListItem> Options { get; set; }
        public int CarCoordinatesCount { get; set; }
        public int CarRezCount { get; set; }
        public int CarCount { get; set; }
        [BindProperty]
        public string SelectedOptionsIds { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Car = await _context.Car.ToListAsync();
            Trip = await _context.Trip.ToListAsync();
            CarCoordinates = new List<Car>();
            foreach (var it in Car)
            {
                if (!CarCoordinates.Contains(it))
                {
                    CarCoordinates.Add(it);
                    CarCoordinatesCount++;
                }
            }
            CarCount = Car.Count;
            Options = _context.Car.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.coordinates.ToString(),
                                      Text = a.coordinates
                                  }).Distinct().ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostFindLocationAsync(string location)
        {
            Car = await _context.Car.ToListAsync();
            var cor = Request.Form["coordinates"];
            var searched = getCarsList(cor, Car);
            return openClosestCarView(searched);
        }

        public IList<Car> getCarsList(string location, IList<Car> Car)
        {
            searched = new List<Car>();
            foreach (var it in Car)
            {
                if (it.coordinates.Equals(location))
                {
                    searched.Add(it);
                }
            }
            return searched;
        }

        private IActionResult openClosestCarView(IList<Car> location)
        {
            return RedirectToPage("./ClosestCarView", new
            {
                cars = JsonConvert.SerializeObject(location),
            }); ;
        }
    }
}