using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CityWasp.Data;
using CityWasp.Models;

namespace CityWasp.Pages.Discounts
{
    public class CreateModel : PageModel
    {
        private readonly CityWasp.Data.CityWaspContext _context;

        public CreateModel(CityWasp.Data.CityWaspContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Discount Discount { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Discount.Add(Discount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
