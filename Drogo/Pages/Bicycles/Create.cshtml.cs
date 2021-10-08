using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Drogo.Data;
using Drogo.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Drogo.Pages.Bicycles
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Drogo.Data.ApplicationDbContext _context;

        public CreateModel(Drogo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Bicycle Bicycle { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ImageFile != null)

            {
                if (ImageFile.Length > 0)

                //Convert Image to byte and save to database

                {

                    byte[] p1 = null;
                    using (var fs1 = ImageFile.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                    Bicycle.Image = p1;

                }
            }

            _context.Bicycle.Add(Bicycle);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
