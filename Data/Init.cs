using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CityWasp.Models;

namespace CityWasp.Data
{
    public class Init
    {
        public static void Initialize(CityWaspContext context)
        {
            System.Diagnostics.Debug.Write("cacaacac");
            var trips = new Trip[]
            {
                new Trip { length = 30, distance = 10000,
                    date = DateTime.Now, price = 0, state = Trip.TripState.Started, discountApplied = 0}
            };

            context.Trip.AddRange(trips);
            context.SaveChanges();
        }
    }
}
