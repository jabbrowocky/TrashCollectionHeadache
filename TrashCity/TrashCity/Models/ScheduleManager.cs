using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCity.Models
{
    public class ScheduleManager
    {
        public DateTime weekToChange { get; set; }
        public DayOfWeek tempCollectionDay { get; set; }
    }
}