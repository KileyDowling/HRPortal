using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SGCorpHR.Models
{
    public class TimeTrackerSummary
    {
        public Employee SelectedEmployee { get; set; }
        public List<Timesheet> AllTimesheets { get; set; }
        public Timesheet SelectedTimesheet { get; set; }
        public int TotalHoursWorked { get; set; }
        
    }
}
