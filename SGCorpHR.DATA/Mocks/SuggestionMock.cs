using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGCorpHR.Models;
using SGCorpHR.Models.Interfaces;

namespace SGCorpHR.DATA.Mocks
{
    public class SuggestionMock : ISuggestionRepository
    {
        public List<Suggestion> GetAllSuggestions(string filepath)
        {
            return new List<Suggestion>()
            {
                new Suggestion() {EmployeeName = "Jake Saliga", SuggestionID = 1, SuggestionText = "Blah Blah Blah"},
                new Suggestion() {EmployeeName = "Kiley Dowling", SuggestionID = 2, SuggestionText = "Blazzy Blah Blah"},
                new Suggestion() {EmployeeName = "Darren Fluharty", SuggestionID = 3, SuggestionText = "Yipee Ki Yay"}

            };
        }
    }
}
