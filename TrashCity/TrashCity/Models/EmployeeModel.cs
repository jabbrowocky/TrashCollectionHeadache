using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCity.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [Display(Name = "First Name")]
        public string EmployeeFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string EmployeeLastName { get; set; }
        [Display(Name = "Your Address")]
        public string EmployeeAddress { get; set; }
        [Display(Name = "Which Zip Code would you prefer to cover on your routes?")]
        public int RouteZipCode { get; set; }
    }
}