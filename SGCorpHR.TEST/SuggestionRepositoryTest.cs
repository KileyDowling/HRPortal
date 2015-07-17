using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGCorpHR.DATA;
using SGCorpHR.Models;

namespace SGCorpHR.TEST
{
    [TestFixture]
    public class SuggestionRepositoryTest
    {
        [Test]
        public void GetSuggestionsTest()
        {
            var repo = new SuggestionRepository();
            string filePath = @"C:\Users\Apprentice\Desktop\GitHub\KileyDowling\SGCorpHRV2\SGCorpHR\SGCorpHR.TEST\Suggestions\Suggestions.txt";
            var suggestions = repo.GetAllSuggestions(filePath);
            var suggestion = suggestions.First();
            Assert.AreEqual("Bob", suggestion.EmployeeName);

        }

        [Test]
        public void RemoveSuggestionTest()
        {
            var repo = new SuggestionRepository();
            int suggestionID = 3;
            string filePath = @"C:\Users\Apprentice\Desktop\GitHub\KileyDowling\SGCorpHRV2\SGCorpHR\SGCorpHR.TEST\Suggestions\Suggestions.txt";
            repo.RemoveFile(suggestionID, filePath);

            var suggestions = repo.GetAllSuggestions(filePath);
            Assert.IsFalse(suggestions.Exists(s => s.SuggestionID == 3));

        }
        [Test]
        public void SubmitSuggestionTest()
        {
            var repo = new SuggestionRepository();

            var suggestion = new Suggestion()
            {
                SuggestionText = "Test",
                EmployeeName = "Johnny"
            };

            string filePath =
                @"C:\Users\Apprentice\Desktop\GitHub\KileyDowling\SGCorpHRV2\SGCorpHR\SGCorpHR.TEST\Suggestions\Suggestions.txt";

            repo.AddSuggestion(suggestion, filePath);
            Assert.AreEqual("Johnny", suggestion.EmployeeName);

        }
    }
}
