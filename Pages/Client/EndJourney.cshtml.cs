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
    [BindProperties]
    public class EndJourneyModel : PageModel
    {
        private readonly CityWasp.Data.CityWaspContext _context;

        public EndJourneyModel(CityWasp.Data.CityWaspContext context)
        {
            _context = context;
        }
        public int Status { get; set; }
        public int dicountIs { get; set; }
        public Trip Trip { get; set; }
        public Discount Discount { get; set; }

        public void a()
        {
            Trip newt = new Trip();
            newt.date = DateTime.Now;
            newt.price = 0;
            newt.state = Trip.TripState.Started;
            newt.length = 30;
            newt.distance = 10000;
            newt.discountApplied = 0;
            _context.Trip.Add(newt);
            _context.SaveChanges();
        }
        public void OnGet(int id)
        {
            Trip = _context.Trip.Find(id);
            Status = (int)Trip.state;
            if (Trip.discountApplied != 0)
            {
                Discount = _context.Discount.Find(Trip.discountApplied);
                dicountIs = Discount.percent;
            }
            else
                dicountIs = 0;

        }
        double calculatePrice(Trip t)
        {
            return t.length * 0.05 + t.distance * 0.001;
        }
        public IActionResult OnPostEndTrip()
        {
            var TripFromDb = _context.Trip.Find(Trip.id);
            double price = calculatePrice(TripFromDb);
            TripFromDb.price = price;
            TripFromDb.state = Trip.TripState.Ended;
            TripFromDb.date = DateTime.Now;
            _context.SaveChanges();
            return RedirectToPage();
        }

        IActionResult checkDiscount(IQueryable<Discount> dicount)
        {
            if (dicount.Count() != 0)
            {
                Discount = dicount.First();
                if (Discount.startDate <= DateTime.Now && Discount.endDate >= DateTime.Now)
                {
                    var TripFromDb = _context.Trip.Find(Trip.id);
                    TripFromDb.discountApplied = Discount.id;
                    updatePrice(TripFromDb, Discount.percent);
                    _context.SaveChanges();
                    TempData["success"] = "Pritaikyta nuolaida";
                }
                else
                {
                    TempData["error"] = "Nuolaida nebegalioja";
                }
            }
            else
            {
                TempData["error"] = "Nuolaida neegzistuoja";
            }

            return RedirectToPage();
        }
        public IActionResult OnPostApplyDiscount()
        {
            string dicountCode = Request.Form["discount"];
            var dicount = from d in _context.Discount
                          where d.code == dicountCode
                          select d;

            return checkDiscount(dicount);
        }

        public IActionResult OnPostPayForTrip()
        {
            var TripFromDb = _context.Trip.Find(Trip.id);
            TripFromDb.state = Trip.TripState.Payed;
            _context.SaveChanges();
            TempData["success"] = "Sėkmingas apmokėjimas";
            return RedirectToPage();

        }

        void updatePrice(Trip a, int percent)
        {
            double price = (a.length * 0.05 + a.distance * 0.001) *(100-percent)/100;
            a.price = price;
        }
    }
}