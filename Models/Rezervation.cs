using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CityWasp.Models
{
    public class Rezervation
    {
		int id { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Galiojimo sukūrimo data")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		DateTime created;

		[DataType(DataType.Date)]
		[Display(Name = "Rezervuota iki data")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		DateTime reserved;

		Client reservingClient;

		Car reservedCar;
	}
}
