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
    public class DeleteModel : PageModel
    {
        private readonly TheWorkshop.Data.TheWorkshopContext _context;

        public DeleteModel(TheWorkshop.Data.TheWorkshopContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deadline = await _context.Deadline.FindAsync(id);
            if (deadline != null)
            {
                Deadline = deadline;
                _context.Deadline.Remove(Deadline);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
