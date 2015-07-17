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
            Assert.AreEqual(2, timesheets.Count);
        }

        [Test]
        public void GetSingleEmployee()
        {
            var repo = new TimeTrackerRepository();
            Employee singleEmployee = repo.GetSingleEmployee(6);
            Assert.AreEqual("Lisa", singleEmployee.FirstName);

        }

        [Test]
        public void GetAllEmployees()
        {
            var repo = new TimeTrackerRepository();
            List<Employee> allEmployees = repo.GetAllEmployees();
            Assert.AreEqual(14, allEmployees.Count);

        }
    }
}
