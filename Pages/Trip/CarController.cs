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
        public Car Car { get; set; }
        private readonly CityWasp.Data.CityWaspContext _context;

        public CarController(CityWasp.Data.CityWaspContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async void changeState(Car.CarState state, int id)
        {
            if (id == null)
            {
                //return NotFound();
            }

            Car = await _context.Car.FindAsync(id);

            Car.state = state;

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.id))
                {
                    throw;
                }
                else
                {
                    throw;
                }
            }
            RedirectToPage("./ReservationView?id="+id);
        }
        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.id == id);
        }
    }
}