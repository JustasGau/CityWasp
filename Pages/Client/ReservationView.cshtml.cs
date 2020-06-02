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
    public class ReservationViewModel : PageModel
    {
        private readonly CityWasp.Data.CityWaspContext _context;

        public ReservationViewModel(CityWasp.Data.CityWaspContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car.FirstOrDefaultAsync(m => m.id == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostCancelAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car.FindAsync(id);

            Car.state = CityWasp.Models.Car.CarState.Free;

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
            return RedirectToPage("./View");
        }

        public async Task<IActionResult> OnPostRenewAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car.FindAsync(id);

            Car.state = CityWasp.Models.Car.CarState.Rezerved;

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

