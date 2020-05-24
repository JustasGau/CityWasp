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
    public class ReserveCarModel : PageModel
    {
        public Car Car { get; set; }
        private readonly CityWasp.Data.CityWaspContext _context;

        public ReserveCarModel(CityWasp.Data.CityWaspContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnPostAsync(Car.CarState state, int id)
        {
            if (id == null)
            {
                return NotFound();
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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Redirect("./ReservationView?id=" + id);
        }
        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.id == id);
        }
    }
}