using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace officescheduler.Models
{
    public class UserClass
    {

        public int ID { get; set; }             //Should be automatically assigned

        [StringLength(60, MinimumLength = 3), Required]
        public string FirstName { get; set; }

        [StringLength(60, MinimumLength = 3), Required]
        public string LastName { get; set; }

        [StringLength(60, MinimumLength = 3), Required]
        public string Email { get; set; }

        [StringLength(60, MinimumLength = 3), Required]
        public string Title { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(60, MinimumLength = 8)]
        public string Password { get; set; }

        [StringLength(60, MinimumLength = 3), Required]
        public string DefaultOffice { get; set; }           //Change to object office

        [StringLength(60, MinimumLength = 3), Required]
        public string ADuser { get; set; }


        public int IsManager { get; set;}               //Fix later to boolean

        [StringLength(60, MinimumLength = 1),]          //if I ever need to add something elese
        public string Option1 { get; set; } 

        [StringLength(60, MinimumLength = 1),]
        public string Option2 { get; set; }

        [StringLength(60, MinimumLength = 1),]
        public string Option3 { get; set; }
    }
}
