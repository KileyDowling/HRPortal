using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGCorpHR.DATA;

namespace SGCorpHR.TEST
{
    [TestFixture]
    public class EmployeeDirectoryRepositoryTests
    {
        [Test]
        public void GetAllEmployeesTest()
        {
            var repo = new EmployeeDirectoryRepository();
            var allEmps = repo.ListAllEmployees();
            var empDpt = allEmps.FirstOrDefault(x=>x.EmpID==1);
            Assert.AreEqual(17,allEmps.Count);
            Assert.AreEqual("Marketing", empDpt.DepartmentName);
        }
     }
}
