using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CityWasp.Models;
using Microsoft.EntityFrameworkCore;

namespace CityWasp
{
    public class StartTripModel : PageModel
    {
        public int id { get; set; }
        public string error { get; set; }
        public Trip trip = new Trip();
        public Car car { get; set; }
        private readonly CityWasp.Data.CityWaspContext _context;

        public StartTripModel(CityWasp.Data.CityWaspContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(int id, string error)
        {
            if (id == null)
            {
                return NotFound();
            }
            this.error = error;
            car = await _context.Car.FirstOrDefaultAsync(m => m.id == id);

            if (car == null)
            {
                return NotFound();
            }
            return Page();
        }



        public async Task<IActionResult> OnPostStartTripAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            car = await _context.Car.FindAsync(id);
            car.changeState();
            _context.Attach(car).State = EntityState.Modified;
            trip.create(car);
            _context.Trip.Add(trip);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(car.id))
                {
                    return NotFound();
                }
                if (!TripExists(trip.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return openTripView();
        }


        private IActionResult openTripView()
        {
            return RedirectToPage("./View");
        }


        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.id == id);
        }
        private bool TripExists(int id)
        {
            return _context.Trip.Any(e => e.id == id);
        }
    }
}