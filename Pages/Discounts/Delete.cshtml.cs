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
    public class DeleteModel : PageModel
    {
        private readonly CityWasp.Data.CityWaspContext _context;

        public DeleteModel(CityWasp.Data.CityWaspContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Discount = await _context.Discount.FindAsync(id);

            if (Discount != null)
            {
                _context.Discount.Remove(Discount);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
