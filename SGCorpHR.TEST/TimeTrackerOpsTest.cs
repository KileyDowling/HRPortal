using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGCorpHR.BLL;
using SGCorpHR.DATA;
using SGCorpHR.Models;

namespace SGCorpHR.TEST
{
    [TestFixture]
    public class TimeTrackerOpsTest
    {
        [Test]
        public void TimesheetOperationsTest()
        {
            TimeTrackerOperations ops = new TimeTrackerOperations();
          var response = ops.GetTimeTrackerSummary(6);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(4, response.Data.AllTimesheets.Count);
            Assert.AreEqual(22, response.Data.TotalHoursWorked);
        }

        [Test]
        public void GetAllEmployeesTest()
        {
            TimeTrackerOperations ops = new TimeTrackerOperations();
            var response = ops.GetAllEmployees();
            Assert.AreEqual(14, response.Data.Count);
        }

        [Test]
        public void DeleteEmpTimesheetTest()
        {
            TimeTrackerOperations ops = new TimeTrackerOperations();
            ops.DeleteSingleTimesheet(14);
            var repo = new TimeTrackerRepository();
            List<Timesheet> listOfSheets = repo.GetAllTimeSheets(5);
            Assert.IsFalse(listOfSheets.Exists(p => p.TimesheetId == 15));
        }
    }
}
