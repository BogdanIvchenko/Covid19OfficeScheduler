using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using System.Net;

namespace officescheduler.Pages.Calendar
{
    public class CalendarModel : PageModel
    {

        private readonly officescheduler.Data.officeschedulerContext _context;
        // int UserIDpassed;

        public CalendarModel(officescheduler.Data.officeschedulerContext context)
        {
            _context = context;

        }
        public System.Collections.Specialized.NameValueCollection QueryString { get; }


        public async Task OnGetAsync()
        {
            //PassedParameters = HttpContext.Request.PathBase;
            //UserIDpassed = 
            // Uri MyUrl = Request.Url;
            var UserIDpassed = HttpContext.Request.Query["UserIDpassed"].ToString();
            var TestVariable2 = HttpContext.Request.Query["TestVariable2"].ToString();

            string test = "Entered OnGet Assync asdfsdafasdfsd!" + UserIDpassed+" Testvar2: "+TestVariable2;
            Console.WriteLine(test);
            // TimeslotClass = await _context.Timeslot.ToListAsync();
        }
    }
}