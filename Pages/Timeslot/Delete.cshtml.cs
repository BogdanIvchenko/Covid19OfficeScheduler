using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using officescheduler.Data;
using officescheduler.Models;

namespace officescheduler.Pages.Timeslot
{
    public class DeleteModel : PageModel
    {
        private readonly officescheduler.Data.officeschedulerContext _context;

        public DeleteModel(officescheduler.Data.officeschedulerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TimeslotClass TimeslotClass { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TimeslotClass = await _context.Timeslot.FirstOrDefaultAsync(m => m.ID == id);

            if (TimeslotClass == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TimeslotClass = await _context.Timeslot.FindAsync(id);

            if (TimeslotClass != null)
            {
                _context.Timeslot.Remove(TimeslotClass);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
