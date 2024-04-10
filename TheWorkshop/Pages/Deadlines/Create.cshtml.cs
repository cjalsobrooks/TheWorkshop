using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheWorkshop.Data;
using TheWorkshop.Models;

namespace TheWorkshop.Pages.Deadlines
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
        public Deadline Deadline { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Deadline.Add(Deadline);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
