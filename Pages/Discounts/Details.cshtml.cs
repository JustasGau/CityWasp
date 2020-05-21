using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CityWasp.Data;
using CityWasp.Models;

namespace CityWasp.Pages.Discounts
{
    public class DetailsModel : PageModel
    {
        private readonly CityWasp.Data.CityWaspContext _context;

        public DetailsModel(CityWasp.Data.CityWaspContext context)
        {
            _context = context;
        }

        public Discount Discount { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Discount = await _context.Discount.FirstOrDefaultAsync(m => m.id == id);

            if (Discount == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
