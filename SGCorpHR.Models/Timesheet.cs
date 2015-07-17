using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCorpHR.Models
{
    public class Timesheet
    {
        public DateTime DateOfTimesheet { get; set; }
        public decimal TotalHoursByDay { get; set; }
        public int EmpId { get; set; }
    }
}
