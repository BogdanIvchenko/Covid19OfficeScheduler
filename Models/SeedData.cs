using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using officescheduler.Data;

namespace officescheduler.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new officeschedulerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<officeschedulerContext>>()))
            {
                if (!context.OfficeClass.Any())
                {
                    context.OfficeClass.AddRange(
                        new OfficeClass
                        {
                            MaximumOcupancey = 7,
                            FirstName =  "Vancouver APS"
                        },
                        new OfficeClass
                        {
                            MaximumOcupancey = 3,
                            FirstName = "Vancouver DDA"
                        },
                        new OfficeClass
                        {
                            MaximumOcupancey = 1,
                            FirstName = "Kelso DDA"
                        },
                        new OfficeClass
                        {
                            MaximumOcupancey = 5,
                            FirstName = "Auberdeen APS"
                        },
                        new OfficeClass
                        {
                            MaximumOcupancey = 2,
                            FirstName = "Centralia HCS"

                        },
                        new OfficeClass
                        {
                            MaximumOcupancey = 7,
                            FirstName = "Liberty City DDA"
                        },
                        new OfficeClass
                        {
                            MaximumOcupancey = 3,
                            FirstName = "Los Santos APS"
                        },

                       new OfficeClass
                       {
                           MaximumOcupancey = 22,
                           FirstName = "Seattle"
                       }

                        );

                   
                }
                if (!context.UserAccount.Any())
                {
                    context.UserAccount.AddRange(
                            new UserClass
                            {
                                FirstName = "Admin",
                                LastName = "Admin",
                                Email = "admin@dshs.wa.gov",
                                Title = "Admin",
                                Password = "AdminAdmin",
                                DefaultOffice = "Vancouver APS",
                                ADuser = "Admin",
                                IsManager = 1,
                            },
                            new UserClass
                            {
                                FirstName = "Bohdan",
                                LastName = "Ivchenko",
                                Email = "bogdan.ivchenko@hotmail.com",
                                Title = "IT intern",
                                Password = "Qwertasdf",
                                DefaultOffice = "Vancouver APS",
                                ADuser = "BohdanIvchenko",
                                IsManager = 1,
                            }, 
                            new UserClass
                            {
                                FirstName = "Jennifer",
                                LastName = "LastName",
                                Email = "Jennifer.Lastname@dshs.wa.gov",
                                Title = "Social Services Worker",
                                Password = "Qwertasdf",
                                DefaultOffice = "Vancouver APS",
                                ADuser = "Admin",
                                IsManager = 1,
                            },
                            new UserClass
                            {
                                FirstName = "Jesdfsfer",
                                LastName = "LasgsfdName",
                                Email = "Jennifesfdggr.Lastname@dshs.wa.gov",
                                Title = "Social Servdfgices Worker",
                                Password = "Qwerfsddf",
                                DefaultOffice = "Vancouver APS",
                                ADuser = "Admin",
                                IsManager = 1,
                            }
                        );

                    
                }
                if (!context.Timeslot.Any())
                {
                    

                    DateTime StartDate = new DateTime(2021,1,1,0,0,0);
                    DateTime EndDate = new DateTime(2021, 11, 30, 0, 0, 0);

                    for (DateTime date = StartDate; date.Date <= EndDate.Date; date = date.AddDays(1))
                    {
                        DayOfWeek dayOfWeek = date.DayOfWeek;

                        if ((dayOfWeek == DayOfWeek.Saturday) || (dayOfWeek == DayOfWeek.Sunday))
                        {
                            continue;
                        }
                        
                        foreach (OfficeClass OfficeClassForEachLoop in context.OfficeClass)
                        {

                            for (int timeline = 1; timeline <= OfficeClassForEachLoop.MaximumOcupancey; timeline++)
                            {
                                DateTime StartTime = new DateTime(date.Year, date.Month, date.Day, 8, 0, 0); // Form 8 am 
                                DateTime EndTime = new DateTime(date.Year, date.Month, date.Day, 17, 0, 0);  // To 5 pm

                                for (DateTime time = StartTime; time.TimeOfDay <= EndTime.TimeOfDay; time = time.AddHours(1))
                                {
                                    context.Timeslot.AddRange(
                                            new TimeslotClass
                                            {
                                                UserID = 0,
                                                Date = date,
                                                Time = time,
                                                TimelineID = timeline
                                            }
                                        );
                                    Console.WriteLine("Timeslot should be creatred");
                                    
                                }
                            }
                        }
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
//= new officeschedulerContext(
//              serviceProvider.GetRequiredService<
//                 DbContextOptions<officeschedulerContext>>())) 


//NullReferenceException: Object reference not set to an instance of an object.