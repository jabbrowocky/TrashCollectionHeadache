﻿using System;
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
        [Display(Name = "Date to reschedule pickup.")]
        public DateTime? dateToChange { get; set; } = null;
        
        public DayOfWeek temporaryCollectionDay { get; set; }
    }
}   