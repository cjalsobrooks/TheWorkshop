using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheWorkshop.Data;
using TheWorkshop.Models;

namespace TheWorkshop.Pages.CalendarEvents
{
    public class EditModel : PageModel
    {
        private readonly TheWorkshop.Data.TheWorkshopContext _context;

        public EditModel(TheWorkshop.Data.TheWorkshopContext context)
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

            var calendarevent =  await _context.Event.FirstOrDefaultAsync(m => m.Id == id);
            if (calendarevent == null)
            {
                return NotFound();
            }
            CalendarEvent = calendarevent;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CalendarEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalendarEventExists(CalendarEvent.Id))
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

        private bool CalendarEventExists(int id)
        {
            return _context.Event.Any(e => e.Id == id);
        }
    }
}
