using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheWorkshop.Data;
using TheWorkshop.Models;

namespace TheWorkshop.Pages.CalendarEvents
{
    public class DeleteModel : PageModel
    {
        private readonly TheWorkshop.Data.TheWorkshopContext _context;

        public DeleteModel(TheWorkshop.Data.TheWorkshopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CalendarEvent CalendarEvent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calendarevent = await _context.Event.FirstOrDefaultAsync(m => m.Id == id);

            if (calendarevent == null)
            {
                return NotFound();
            }
            else
            {
                CalendarEvent = calendarevent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calendarevent = await _context.Event.FindAsync(id);
            if (calendarevent != null)
            {
                CalendarEvent = calendarevent;
                _context.Event.Remove(CalendarEvent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
