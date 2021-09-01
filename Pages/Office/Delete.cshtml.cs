using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using officescheduler.Data;
using officescheduler.Models;

namespace officescheduler.Pages.Office
{
    public class DeleteModel : PageModel
    {
        private readonly officescheduler.Data.officeschedulerContext _context;

        public DeleteModel(officescheduler.Data.officeschedulerContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OfficeClass = await _context.OfficeClass.FindAsync(id);

            if (OfficeClass != null)
            {
                _context.OfficeClass.Remove(OfficeClass);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
