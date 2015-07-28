using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGCorpHR.BLL;

namespace SGCorpHR.TEST
{
    [TestFixture]
    public class EmployeeOpsTest
    {
        [Test]
        public void ListAllEmployeesTest()
        {
            var ops = new EmployeeDirectoryOperations();
            var response = ops.ListAllEmployees();
            Assert.IsTrue(response.Success);
            Assert.AreEqual(17, response.Data.Count);
        }

    }
}
