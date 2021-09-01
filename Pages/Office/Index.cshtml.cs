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
    public class IndexModel : PageModel
    {
        private readonly officescheduler.Data.officeschedulerContext _context;

        public IndexModel(officescheduler.Data.officeschedulerContext context)
        {
            _context = context;
        }

        public IList<OfficeClass> OfficeClass { get;set; }

        public async Task OnGetAsync()
        {
            OfficeClass = await _context.OfficeClass.ToListAsync();
        }
    }
}
