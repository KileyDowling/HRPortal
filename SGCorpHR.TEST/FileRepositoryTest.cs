using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGCorpHR.DATA;
using SGCorpHR.Models;


namespace SGCorpHR.TEST
{[TestFixture]
   public class FileRepositoryTest
   {
       [Test]
       public void GetResumesTest()
       {
           var repo = new FileRepository();
           var filePath = @"C:\Users\Apprentice\Desktop\GitHub\KileyDowling\SGCorpHRV2\SGCorpHR\SGCorpHR.TEST\Resumes";
           var resumes = repo.GetFiles(filePath);
           var resume = resumes.First();
           Assert.AreEqual("TestResume.pdf", resume.FileName);
       }

    }
}
