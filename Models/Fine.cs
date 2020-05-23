using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CityWasp.Models
{
    public class Fine
    {
		public enum FineType
		{
			speeding,

			outOfBounds,

		}

		int id { get; set; }

		FineType type;

		double price;

		[DataType(DataType.Date)]
		[Display(Name = "Galiojimo pradžios data")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		DateTime date;

		Trip trip;
	}
}
