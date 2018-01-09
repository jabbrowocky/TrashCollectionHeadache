using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCity.Models
{
    public class CustomerModel
    {
        [Key]

        public int CustomerId { get; set; }
        [Display(Name = "First Name")]
        public string CustomerFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string CustomerLastName { get; set; }
        public string CustomerAddress { get; set; }
        public int CustomerZip { get; set; }
        public double AmountOwed { get; set; }
        [Display(Name = "Update which day you'd like your trash collected")]
        public DayOfWeek CollectionDay { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        
         
    }
}