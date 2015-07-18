using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGCorpHR.DATA;
using SGCorpHR.Models;

namespace SGCorpHR.TEST
{
    [TestFixture]
    public class TimeTrackerRepoTest
    {
        [Test]
        public void GetAllSheetsTest()
        {
            var repo = new TimeTrackerRepository();
            List<Timesheet> timesheets = new List<Timesheet>();
            timesheets = repo.GetAllTimeSheets(6);
            Assert.AreEqual(4, timesheets.Count);
        }

        [Test]
        public void GetSingleEmployeeTest()
        {
            var repo = new TimeTrackerRepository();
            Employee singleEmployee = repo.GetSingleEmployee(6);
            Assert.AreEqual("Lisa", singleEmployee.FirstName);

        }

        [Test]
        public void GetAllEmployeesTest()
        {
            var repo = new TimeTrackerRepository();
            List<Employee> allEmployees = repo.GetAllEmployees();
            Assert.AreEqual(14, allEmployees.Count);

        }

        [Test]
        public void TotalHoursWorkedTest()
        {
            var repo = new TimeTrackerRepository();
            int totalHoursWorked = repo.TotalHoursWorked(6);
            Assert.AreEqual(22, totalHoursWorked);
        }

        [Test]
        public void DeleteTimesheetTest()
        {
            var repo = new  TimeTrackerRepository();
            repo.DeleteTimesheet(1);
            List<Timesheet> listOfSheets = repo.GetAllTimeSheets(1); 
            Assert.IsFalse(listOfSheets.Exists(p => p.TimesheetId == 1));
        }
    }
}
