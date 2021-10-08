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
    public class IndexModel : PageModel
    {
        private readonly Drogo.Data.ApplicationDbContext _context;

        public IndexModel(Drogo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Bicycle> Bicycle { get;set; }

        public async Task OnGetAsync()
        {
            Bicycle = await _context.Bicycle.ToListAsync();
        }
    }
}
