using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGCorpHR.BLL;
using SGCorpHR.Models;

namespace SGCorpHR.TEST
{[TestFixture]
    public class FileOperationsTest
    {
        [Test]
        public void DisplayFiles()
        {
            var ops = new FileOperations();
            string filePath = @"C:\Users\Apprentice\Desktop\GitHub\KileyDowling\SGCorpHRV2\SGCorpHR\SGCorpHR.TEST\Resumes";
    ;        var response = ops.DisplayFiles(filePath);
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Data);
        }
    }
}
