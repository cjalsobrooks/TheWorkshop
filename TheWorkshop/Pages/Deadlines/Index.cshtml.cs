using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheWorkshop.Data;
using TheWorkshop.Models;

namespace TheWorkshop.Pages.Deadlines
{
    public class IndexModel : PageModel
    {
        private readonly TheWorkshop.Data.TheWorkshopContext _context;

        public IndexModel(TheWorkshop.Data.TheWorkshopContext context)
        {
            _context = context;
        }

        public IList<Deadline> Deadline { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Deadline = await _context.Deadline.ToListAsync();
        }
    }
}
