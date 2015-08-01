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
    public class DepartmentRepoTests
    {
        [Test]
        public void CheckIfDptExistsTest()
        {
            var repo = new DepartmentRepository();
            var exists = repo.CheckIfDptExists("IT");
            Assert.IsTrue(exists);
        }

        [Test]
        public void ListAllDptTest()
        {
            var repo = new DepartmentRepository();
            var dptList = repo.ListAll();
            Assert.AreEqual(5,dptList.Count);
        }

        [Test]
        public void GetSingleDptTest()
        {
            var repo = new DepartmentRepository();
            var dpt = repo.GetSingleDptById(4);
            Assert.AreEqual("Sales", dpt.DepartmentName);

        }

        [Test]
        public void CreateDepartmentTest()
        {
            var repo = new DepartmentRepository();
           // repo.CreateDepartment("Talent Development");
            var dptList = repo.ListAll();
            var newDpt = dptList.FirstOrDefault(x => x.DepartmentID == 6);
            Assert.AreEqual(6,dptList.Count);
            Assert.AreEqual("Talent Development", newDpt.DepartmentName);
        }
    }
}
