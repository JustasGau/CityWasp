using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CityWasp.Models
{
    public class Trip
    {
		public int id { get; set; }

		public enum TripType
		{
			paid,

			started,

			ended,

		}

		public int? length { get; set; }

		public int? distance { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Galiojimo pradžios data")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime date { get; set; }

		public double? price { get; set; }

		public Discount? assignedDiscount { get; set; }

		public Car tripCar { get; set; }

		public TripType state { get; set; }

	}
}
