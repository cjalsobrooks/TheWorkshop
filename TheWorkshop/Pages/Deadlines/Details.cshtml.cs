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
    public class DetailsModel : PageModel
    {
        private readonly TheWorkshop.Data.TheWorkshopContext _context;

        public DetailsModel(TheWorkshop.Data.TheWorkshopContext context)
        {
            _context = context;
        }

        public Deadline Deadline { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deadline = await _context.Deadline.FirstOrDefaultAsync(m => m.Id == id);
            if (deadline == null)
            {
                return NotFound();
            }
            else
            {
                Deadline = deadline;
            }
            return Page();
        }
    }
}
