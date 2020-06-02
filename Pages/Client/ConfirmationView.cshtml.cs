using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityWasp
{
    public class TripConfirmationViewModel : PageModel
    {
        public int car_id { get; set; }
        public void OnGet(int id)
        {
            car_id = id;
        }
    }
}