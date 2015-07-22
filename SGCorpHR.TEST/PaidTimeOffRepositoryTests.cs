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
    public class PaidTimeOffRepositoryTests
    {
        [Test]
        public void SubmitPtoRequestTest()
        {
            PaidTimeOff pto = new PaidTimeOff()
            {
                EmpID = 6,
                Date = new DateTime(2015, 07, 15),
                HoursRequested = 4
            };
            PaidTimeOffRepository repo = new PaidTimeOffRepository();
            repo.SubmitPtoRequest(pto);
            var ptoList = repo.ViewAllPtoRequests();
            Assert.AreEqual(7, ptoList.Count);
        }

        [Test]
        public void ViewAllptoRequestsTest()
        {
            List<PaidTimeOff>  ptoList = new List<PaidTimeOff>();
            PaidTimeOffRepository repo = new PaidTimeOffRepository();
            ptoList = repo.ViewAllPtoRequests();
            Assert.AreEqual(6, ptoList.Count);
        }
    }
}
