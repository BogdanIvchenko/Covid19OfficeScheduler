using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using officescheduler.Data;
using officescheduler.Models;

namespace officescheduler.Pages.User
{
    public class DeleteModel : PageModel
    {
        private readonly officescheduler.Data.officeschedulerContext _context;

        public DeleteModel(officescheduler.Data.officeschedulerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserClass UserClass { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserClass = await _context.UserAccount.FirstOrDefaultAsync(m => m.ID == id);

            if (UserClass == null)
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

            UserClass = await _context.UserAccount.FindAsync(id);

            if (UserClass != null)
            {
                _context.UserAccount.Remove(UserClass);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
