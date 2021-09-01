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
    public class DetailsModel : PageModel
    {
        private readonly officescheduler.Data.officeschedulerContext _context;

        public DetailsModel(officescheduler.Data.officeschedulerContext context)
        {
            _context = context;
        }

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
    }
}
