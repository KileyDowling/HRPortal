using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGCorpHR.Models;

namespace SGCorpHR.UI.Models
{
    public class TimeTrackerVM
    {
        public List<SelectListItem> EmployeeInfo { get; set; }
        public Employee SelectedEmployee { get; set; }
        public Timesheet NewTimesheet { get; set; }

        public void DisplayEmployeeInformation(List<Employee> employees)
        {
            EmployeeInfo = new List<SelectListItem>();

            foreach (var e in employees)
            {
                EmployeeInfo.Add(new SelectListItem() {Text = e.LastName+", "+e.FirstName, Value = e.EmpID.ToString()});
            }
        }
    }
}