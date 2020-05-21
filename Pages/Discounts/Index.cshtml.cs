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
    public class IndexModel : PageModel
    {
        private readonly CityWasp.Data.CityWaspContext _context;

        public IndexModel(CityWasp.Data.CityWaspContext context)
        {
            _context = context;
        }

        public IList<Discount> Discount { get;set; }

        public async Task OnGetAsync()
        {
            Discount = await _context.Discount.ToListAsync();
        }
    }
}
