using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityWasp.Models
{
    public class Car
    {
        public enum CarState
        {
            InService,
            InUse,
            Free,
            Rezerved
        }

        public int id { get; set; }
        [Display(Name = "Modelis")]
        public string model { get; set; }
        [Display(Name = "Gamintojas")]
        public string manufacturer { get; set; }
        [Display(Name = "Koordinatės")]
        public string coordinates { get; set; }
        [Display(Name = "Kilometražas")]
        public string mileage { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Technikinė apžiūra")]
        public DateTime techincal { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Vertė")]
        public decimal value { get; set; }
        [Display(Name = "Dabartinė vertė")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal currentValue { get; set; }
        [Display(Name = "Būsena")]
        [EnumDataType(typeof(CarState))]
        public CarState state { get; set; }
    }
}
