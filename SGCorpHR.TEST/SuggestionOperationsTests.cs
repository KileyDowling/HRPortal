using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGCorpHR.BLL;
using SGCorpHR.Models;

namespace SGCorpHR.TEST
{
    [TestFixture]
    public class SuggestionOperationsTests
    {
        [Test]
        public void DisplaySuggestionsTest()
        {
            Response<List<Suggestion>> response = new Response<List<Suggestion>>();
            var ops = OperationsFactory.CreateSuggestionOperations();
            response = ops.DisplaySuggestions("filepath");
            Assert.IsTrue(response.Success);
            Assert.AreEqual(3, response.Data.Count);
        }
    }
}
