using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Web;
using System.Net;
using officescheduler.Models;
using System.Globalization;


namespace officescheduler.Pages.Timeslot
{
    public class IndexModel : PageModel
    {

        private readonly officescheduler.Data.officeschedulerContext _context;
        // int UserIDpassed;

        public IndexModel(officescheduler.Data.officeschedulerContext context)
        {
            _context = context;

        }


        public IList<TimeslotClass> TimeslotClass { get; set; }
        public IList<OfficeClass> OfficeClass { get; set; }

        [BindProperty] public string UID { get; set; }
        [BindProperty] public string DefaultOffice { get; set; }
        [BindProperty] public string StartWeek { get; set; }
        [BindProperty] public int Year { get; set; }
        [BindProperty] public string Month { get; set; }
        [BindProperty] public int DayInt { get; set; }
        [BindProperty] public int MonthInt { get; set; }
        [BindProperty] public TimeslotClass[,,] TimeslotsBackend3DArray {get; set;}
        [BindProperty] public DateTime WeekStartDT { get; set; }
        [BindProperty] public DateTime WeekEndDT { get; set; }
        [BindProperty] public OfficeClass OfficeClassOffice { get; set; }

       

        public async Task OnGetAsync()
        {
            //PassedParameters = HttpContext.Request.PathBase;
            //UserIDpassed = 
            var UserIDpassed = HttpContext.Request.Query["UserIDpassed"].ToString();
            var TestVariable2 = HttpContext.Request.Query["TestVariable2"].ToString();
            var OfficePassedVar = HttpContext.Request.Query["defaultOffice"].ToString();
            var weekStart = HttpContext.Request.Query["weekStart"].ToString();

            UID = UserIDpassed;
            DefaultOffice = OfficePassedVar;
            StartWeek = weekStart;
            var weekStartDate = DateTime.Parse(StartWeek);
            Year = weekStartDate.Year;
            Month = weekStartDate.Month.ToString();
            DayInt = weekStartDate.Day;

            MonthInt = weekStartDate.Month;
            //MonthInt = DateTime.ParseExact(Month, "MMMM", CultureInfo.CurrentCulture).Month;

            string test = "Entered OnGet Assync asdfsdafasdfsd!" + UserIDpassed + " Testvar2: " + TestVariable2;
            Console.WriteLine(test);

            WeekStartDT = new DateTime(Year, MonthInt, DayInt, 0 , 0 , 0);

            WeekEndDT = WeekStartDT;

            if (WeekEndDT.Day <= DateTime.DaysInMonth(WeekEndDT.Year, WeekEndDT.Month) - 4)
            {
                WeekEndDT = WeekStartDT.AddDays(4);

            }
            else
            {
                WeekEndDT = new DateTime(WeekEndDT.Year, WeekEndDT.Month, DateTime.DaysInMonth(WeekEndDT.Year, WeekEndDT.Month));

            }


            //UserClass RealUser = _context.UserAccount.SingleOrDefault(user => user.Email == UserClass.Email);
            
            OfficeClassOffice = _context.OfficeClass.SingleOrDefault(office => office.FirstName == DefaultOffice);

            //For every date from the timeline [1]

            //For every timelineID in the office [2]

            //For every for every hour in the office starting at 8 am
            /*

            TimeSpan difference = WeekEndDT - WeekStartDT;

            int differenceInDays = (int)difference.TotalDays + 1;

            
            TimeslotsBackend3DArray = new TimeslotClass[differenceInDays, OfficeClassOffice.MaximumOcupancey, 9];
            
            int dailyIteratorCounter=0;
            for (DateTime DailyIterator = WeekStartDT; DailyIterator<= WeekEndDT; DailyIterator = DailyIterator.AddDays(1))
            {
                for (int timeline = 1; timeline <= OfficeClassOffice.MaximumOcupancey; timeline++)
                {

                    int hourIteratorCounter = 0;
                    for (DateTime HourIterator = DailyIterator.AddHours(8); HourIterator<= DailyIterator.AddHours(9); HourIterator = HourIterator.AddHours(1))
                    {
                        
                        var results =  _context.Timeslot
                                     .Where(Thetimeslot => Thetimeslot.Date == DailyIterator)
                                     .Where(Thetimeslot => Thetimeslot.Time == HourIterator)
                                     .Where(Thetimeslot => Thetimeslot.TimelineID == timeline)
                                      .ToList();



                        if (results.Count != 0)
                        {
                            Console.WriteLine("The size of count is not 0");
                            TimeslotsBackend3DArray[dailyIteratorCounter, timeline-1, hourIteratorCounter] = results[0];
                        }
                        else
                        {
                            TimeslotsBackend3DArray[dailyIteratorCounter, timeline - 1, hourIteratorCounter] = null;
                            Console.WriteLine("Console is zero");
                        }
                       



                            //SingleOrDefault(timeslot => timeslot.Time == HourIterator, timeslot => timeslot.TimelineID == timeline);




                        hourIteratorCounter++;
                    }
                    
                }
                dailyIteratorCounter++;
            }
            */



            TimeslotClass = await _context.Timeslot.ToListAsync();
            OfficeClass = await _context.OfficeClass.ToListAsync();
        }
    }
}
