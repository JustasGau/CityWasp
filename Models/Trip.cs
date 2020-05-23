using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CityWasp.Models
{
    public class Trip
    {
		[Key]
		int ID { get; set; }

		public enum TripType
		{
			paid,

			started,

			ended,

		}

		int length;

		int distance;

		[DataType(DataType.Date)]
		[Display(Name = "Galiojimo pradžios data")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		DateTime date;

		double price;

		Discount assignedDiscount;

		Fine fineForTheTrip;

		Car tripCar;

		Client client;

		TripType state;

		public void updateTrip()
		{

		}

		public void create(int car_id)
		{

		}
	}
}
