using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGCorpHR.DATA;
using SGCorpHR.Models;

namespace SGCorpHR.TEST
{[TestFixture]
    public class PolicyDocumentsRepoTest
    {
    [Test]
    public void GetAllCategoriesTest()
    {
        var repo = new PolicyDocumentRepository();
        var folderPath =
            @"C:\Users\Apprentice\Desktop\GitHub\KileyDowling\SGCorpHRV2\SGCorpHR\SGCorpHR.TEST\PolicyDocuments";
        var allCategories = repo.GetAllPolicyDocCategories(folderPath);
        Assert.AreEqual("DressCode", allCategories.First());
    }

//********CANNOT BE TESTED AT THIS TIME
    
    //[Test]
        //public void GetPolicyDocsTest()
        //{
        //    var repo = new PolicyDocumentRepository();
        //    var policyDocuments = repo.GetAllPolicyDocuments();
        //    var policyDoc = policyDocuments.First();
        //    Assert.AreEqual("Female Professional", policyDoc.Name);

        //}

        //[Test]
        //public void AddPolicyDocTest()
        //{
        //    string folderPath =
        //        @"C:\Users\Apprentice\Desktop\GitHub\KileyDowling\SGCorpHRV2\SGCorpHR\SGCorpHR.TEST\PolicyDocuments";
        //    var policyDocument = new PolicyDocument()
        //    {
        //        Category = "MaleDressCode",
        //        FilePath = @"C:\Users\Apprentice\Desktop\GitHub\KileyDowling\SGCorpHRV2\SGCorpHR\SGCorpHR.TEST\PolicyDocuments\Business-Casual-Guide-Male.jpg",
        //        Name = "MaleDress"
        //    };
        //    var repo = new PolicyDocumentRepository();
        //    repo.AddNewPolicyDocument(policyDocument, folderPath);
        //    Assert.IsTrue(Directory.Exists("MaleDressCode"));
        //}
    }
}
