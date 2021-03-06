﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CityWasp.Data;
using CityWasp.Models;

namespace CityWasp.Pages.Discounts
{
    public class EditModel : PageModel
    {
        private readonly CityWasp.Data.CityWaspContext _context;

        public EditModel(CityWasp.Data.CityWaspContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Discount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscountExists(Discount.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DiscountExists(int id)
        {
            return _context.Discount.Any(e => e.id == id);
        }
    }
}
