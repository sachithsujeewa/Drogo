using Drogo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drogo.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Drogo.Data.ApplicationDbContext _context;

        public IndexModel(Drogo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Bicycle> Bicycles { get; set; }
        public async Task OnGetAsync()
        {
            Bicycles = await _context.Bicycle.ToListAsync();
        }
    }
}
