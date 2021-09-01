using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace officescheduler.Models
{
    public class OfficeClass
    {
        public int ID { get; set; }

        public int MaximumOcupancey { get; set; }

        [StringLength(60, MinimumLength = 3), Required]
        public string FirstName { get; set; }

        [StringLength(60, MinimumLength = 1),]          //if I ever need to add something elese
        public string Option1 { get; set; }

        [StringLength(60, MinimumLength = 1),]
        public string Option2 { get; set; }

        [StringLength(60, MinimumLength = 1),]
        public string Option3 { get; set; }
    }
}
