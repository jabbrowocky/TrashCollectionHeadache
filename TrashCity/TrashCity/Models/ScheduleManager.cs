using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCity.Models
{
    public class ScheduleManager
    {
        [Key]
        public int changeId { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public CustomerModel customer { get; set; }
        public DateTime dateToChange { get; set; }
        public DayOfWeek? temporaryCollectionDay { get; set; } = null;
    }
}   