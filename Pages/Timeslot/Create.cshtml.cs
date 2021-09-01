using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using officescheduler.Data;
using officescheduler.Models;

namespace officescheduler.Pages.Timeslot
{
    public class CreateModel : PageModel
    {
        private readonly officescheduler.Data.officeschedulerContext _context;

        public CreateModel(officescheduler.Data.officeschedulerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TimeslotClass TimeslotClass { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Timeslot.Add(TimeslotClass);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}