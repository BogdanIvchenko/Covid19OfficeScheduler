using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using officescheduler.Data;
using officescheduler.Models;
namespace officescheduler.Pages.Login
{
    public class InvalidCredentialsLoginModel : PageModel
    {
        
        private readonly officescheduler.Data.officeschedulerContext _context;

        public InvalidCredentialsLoginModel(officescheduler.Data.officeschedulerContext context)
        {
            _context = context;


        }

        Boolean CredentialsDontMatch = false;

        public IActionResult OnGet()
        {

            return Page();
        }

        [BindProperty]
        public UserClass UserClass { get; set; }



        public async Task<IActionResult> OnPost()
        {

            Console.WriteLine("Entered OnPost");


            ///! make sure you can't register two users with the same email!!!
            UserClass RealUser = _context.UserAccount.SingleOrDefault(user => user.Email == UserClass.Email);


            if (RealUser == null)
            {
                //make it redirect to the new page for csHTML
                Console.WriteLine("User does not exist");

                return Page();

            }
            else
            {
                if (String.Equals(RealUser.Password, UserClass.Password))
                {
                    //User exists and the passwords are the same, redirect to the callendar
                    System.Diagnostics.Debug.WriteLine("Password Matches");

                    string dayOfWeek = DateTime.Today.DayOfWeek.ToString().ToLower();

                    int offSet = 0;

                    switch (dayOfWeek)
                    {
                        case "sunday":
                            offSet = 0;
                            break;
                        case "monday":
                            offSet = 1;
                            break;
                        case "tuesday":
                            offSet = 2;
                            break;
                        case "wednesday":
                            offSet = 3;
                            break;
                        case "thursday":
                            offSet = 4;
                            break;
                        case "friday":
                            offSet = 5;
                            break;
                        case "saturday":
                            offSet = 6;
                            break;
                    }

                    DateTime startWeek = DateTime.Now.AddDays(-offSet);
                    DateTime endWeek = startWeek.AddDays(6);

                    string startWeekString = startWeek.ToLongDateString();
                    string defaultOffice = RealUser.DefaultOffice;


                    Response.Redirect("../Timeslot/Index?UserIDpassed=" + RealUser.ID + "&TestVariable2=12345" + "&defaultOffice=" + defaultOffice + "&weekStart=" + startWeekString);

                }
                //Passwords are not the same
                //Add Alert
                Console.WriteLine("Password does not match, but User is not null");
                return Page();
            }
        }
    }
}