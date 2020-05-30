using System;
using System.ComponentModel.DataAnnotations;

namespace CityWasp.Models
{
    public class Discount
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Šis laukas yra privalomas")]
        [Display(Name = "Nuolaidos dydis")]
        [Range(1, 100)]
        public int percent { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Galiojimo pradžios data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime startDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Galiojimo pabaigos data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime endDate { get; set; }

        [Display(Name = "Kodas")]
        public string code { get; set; }


    }
}
