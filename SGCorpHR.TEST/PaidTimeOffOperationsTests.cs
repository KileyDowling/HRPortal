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
