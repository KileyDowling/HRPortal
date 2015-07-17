using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGCorpHR.BLL;
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
            Assert.AreEqual(2, response.Data.AllTimesheets.Count);
        }
    }
}
