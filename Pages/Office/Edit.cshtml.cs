using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using officescheduler.Data;
using officescheduler.Models;

namespace officescheduler.Pages.Office
{
    public class EditModel : PageModel
    {
        private readonly officescheduler.Data.officeschedulerContext _context;

        public EditModel(officescheduler.Data.officeschedulerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OfficeClass OfficeClass { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OfficeClass = await _context.OfficeClass.FirstOrDefaultAsync(m => m.ID == id);

            if (OfficeClass == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OfficeClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeClassExists(OfficeClass.ID))
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

        private bool OfficeClassExists(int id)
        {
            return _context.OfficeClass.Any(e => e.ID == id);
        }
    }
}
