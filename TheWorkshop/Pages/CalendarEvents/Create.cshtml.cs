using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheWorkshop.Data;
using TheWorkshop.Models;

namespace TheWorkshop.Pages.CalendarEvents
{
    public class CreateModel : PageModel
    {
        private readonly TheWorkshop.Data.TheWorkshopContext _context;

        public CreateModel(TheWorkshop.Data.TheWorkshopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CalendarEvent CalendarEvent { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Event.Add(CalendarEvent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
