using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Drogo.Data;
using Drogo.Models;

namespace Drogo.Pages.Bicycles
{
    public class DetailsModel : PageModel
    {
        private readonly Drogo.Data.ApplicationDbContext _context;

        public DetailsModel(Drogo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Bicycle Bicycle { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bicycle = await _context.Bicycle.FirstOrDefaultAsync(m => m.Id == id);

            if (Bicycle == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
