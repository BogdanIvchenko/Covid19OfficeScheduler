using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using officescheduler.Data;
using officescheduler.Models;
using DateTimeExtensions;


namespace officescheduler.Pages.Login
{
    public class LoginModel : PageModel
    {

        private readonly officescheduler.Data.officeschedulerContext _context;

        public LoginModel(officescheduler.Data.officeschedulerContext context)
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

        public static DateTime StartOfWeek( DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public async Task<IActionResult> OnPost()
        {

            Console.WriteLine("Entered OnPost");


            ///! make sure you can't register two users with the same email!!!
            UserClass RealUser = _context.UserAccount.SingleOrDefault(user => user.Email == UserClass.Email);


            if (RealUser == null)
            {
                //make it redirect to the new page for csHTML
                Console.WriteLine("User does not exist");
                Response.Redirect("../Login/InvalidCredentialsLogin");
        
                return Page();

            }
            else
            {
                if (String.Equals(RealUser.Password, UserClass.Password))
                {
                    //User exists and the passwords are the same, redirect to the callendar
                    System.Diagnostics.Debug.WriteLine("Password Matches");
                    //Need to extract a homeoffice
                    //Need to extract a current day and the start of current week
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


                    Response.Redirect("../Timeslot/Index?UserIDpassed=" + RealUser.ID + "&TestVariable2=12345"+"&defaultOffice="+defaultOffice+ "&weekStart="+startWeekString);

                }
                //Passwords are not the same
                //Add Alert
                Console.WriteLine("Password does not match, but User is not null");
                Response.Redirect("../Login/InvalidCredentialsLogin");
                return Page();
            }
        }
        //Ask for login information

        // You can Create new user usin User/Create for now

        //If validated, then redirect to callendar



        // Othervice 
        // Alert(Incorrect login information)
        // reload the page.

    }
}