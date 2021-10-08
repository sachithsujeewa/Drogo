using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Drogo.Data;
using Drogo.Models;
using Microsoft.AspNetCore.Authorization;

namespace Drogo.Pages.Bicycles
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Drogo.Data.ApplicationDbContext _context;

        public EditModel(Drogo.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var bike = await _context.Bicycle.FirstOrDefaultAsync(m => m.Id == Bicycle.Id);
            bike.Name = Bicycle.Name;
            bike.HourlyRate = Bicycle.HourlyRate;
            bike.IsActive = Bicycle.IsActive;
            bike.IsInUse = Bicycle.IsInUse;

            _context.Attach(bike).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BicycleExists(Bicycle.Id))
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

        private bool BicycleExists(int id)
        {
            return _context.Bicycle.Any(e => e.Id == id);
        }
    }
}
