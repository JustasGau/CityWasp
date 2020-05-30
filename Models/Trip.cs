using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityWasp.Models
{
    public class Trip
    {
        public enum TripState
        {
            Started,
            Ended,
            Payed
        }
        public int id { get; set; }
        public int length { get; set; }
        public int distance { get; set; }
        public DateTime date { get; set; }

        public double price { get; set; }

        public TripState state { get; set; }
        public int discountApplied { get; set; }
    }
}
