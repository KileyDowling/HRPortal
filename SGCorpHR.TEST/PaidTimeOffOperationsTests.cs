using System;
using System.Collections.Generic;
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
    public class PaidTimeOffOperationsTests
    {
        [Test]
        public void EditPtoRequestTest()
        {
            //tests against DB; altered test app config setting
            var ops = OperationsFactory.CreatePaidTimeOffOperations();
            PaidTimeOff ptoRequest = new PaidTimeOff()
            {
                PtoRequestID = 1,
                PtoStatus = "Approved",
                EmpID = 5,
                Date = new DateTime(2015, 07, 15),
                HoursRequested = 4,
                ManagerID = 2,
                ReasonRejected = "N/A"

            };
            PaidTimeOffRepository repo = new PaidTimeOffRepository();
            repo.EditPtoRequest(ptoRequest);
            var response = new Response<List<PaidTimeOff>>();
            response = ops.ViewAllPtoRequests();
            PaidTimeOff updatedPto = response.Data.FirstOrDefault(p => p.PtoRequestID == 1);
            Assert.AreEqual("Approved", updatedPto.PtoStatus);

        }
        [Test]
        public void ViewAllPtoRequests()
        {
            Response<List<PaidTimeOff>> response = new Response<List<PaidTimeOff>>();
            var ops = OperationsFactory.CreatePaidTimeOffOperations();
            response = ops.ViewAllPtoRequests();
            Assert.IsTrue(response.Success);
            Assert.AreEqual(2, response.Data.Count);
            
        }
    }
}
