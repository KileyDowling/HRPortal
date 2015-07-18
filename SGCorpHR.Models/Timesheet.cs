﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace SGCorpHR.Models
{
    public class Timesheet
    {
        public int TimesheetId { get; set; }

        [Required(ErrorMessage = "You must enter a date for this timesheet")]
        [DataType(DataType.Date)]
        public DateTime DateOfTimesheet { get; set; }

        [Range(typeof(decimal), "1","16", ErrorMessage = "You can only submit a maximum of 16 hours")]
        public decimal TotalHoursByDay { get; set; }

        public int EmpId { get; set; }

        public string FormattedDateOfTimesheet
        {
            get
            {
                string returnVal = "";
                if (DateOfTimesheet != null)
                {
                    returnVal = DateOfTimesheet.ToShortDateString();
                }
                return returnVal;
            }
        }
    }
}
