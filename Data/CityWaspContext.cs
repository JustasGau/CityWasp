using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CityWasp.Models;

namespace CityWasp.Data
{
    public class CityWaspContext : DbContext
    {
        public CityWaspContext (DbContextOptions<CityWaspContext> options)
            : base(options)
        {
        }

        public DbSet<CityWasp.Models.Car> Car { get; set; }

        public DbSet<CityWasp.Models.Discount> Discount { get; set; }

        public DbSet<CityWasp.Models.Trip> Trip { get; set; }

    }
}
