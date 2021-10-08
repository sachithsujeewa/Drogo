using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Drogo.Data;
using Drogo.Models;
using Microsoft.AspNetCore.Authorization;

namespace Drogo.Pages.Bicycles
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Drogo.Data.ApplicationDbContext _context;

        public DeleteModel(Drogo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bicycle = await _context.Bicycle.FindAsync(id);

            if (Bicycle != null)
            {
                _context.Bicycle.Remove(Bicycle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
