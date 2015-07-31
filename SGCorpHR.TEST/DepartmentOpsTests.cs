using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGCorpHR.BLL;
using SGCorpHR.DATA;

namespace SGCorpHR.TEST
{
    [TestFixture]
    public class DepartmentOpsTests
    {
        [Test]
        public void CreateDptTest()
        {
            var ops = new EmployeeDirectoryOperations();
            ops.CreateDepartment("Customer Service");
            var ptoList = ops.ListAllDepartments();
            var newDpt = ptoList.Data.FirstOrDefault(x => x.DepartmentID == 8);
            Assert.AreEqual("Customer Service", newDpt.DepartmentName);
        }

        [Test]
        public void ListAllDptTest()
        {
            var ops = new EmployeeDirectoryOperations();
            var response = ops.ListAllDepartments();
            Assert.IsTrue(response.Success);
            Assert.AreEqual(8,response.Data.Count);
        }

        [Test]
        public void GetSingleDptTest()
        {
            var ops = new EmployeeDirectoryOperations();
            var response = ops.GetSingleDpt(5);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("Human Resources", response.Data.DepartmentName);
        }
    }
}
