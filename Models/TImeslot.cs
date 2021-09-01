using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace officescheduler.Models
{
    public class TimeslotClass
    {
        public int ID { get; set; }
        public int UserID {get; set;}       //Should be validated IDK how

        public int TimelineID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]           //24 Hours clock
        public DateTime Time { get; set; }  //Populate for one year

        

        [StringLength(60, MinimumLength = 1),]          //if I ever need to add something elese
        public string Option1 { get; set; }

        [StringLength(60, MinimumLength = 1),]
        public string Option2 { get; set; }

        [StringLength(60, MinimumLength = 1),]
        public string Option3 { get; set; }
    }
}
