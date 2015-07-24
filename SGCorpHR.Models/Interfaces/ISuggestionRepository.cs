using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCorpHR.Models.Interfaces
{
    public interface ISuggestionRepository
    {
        List<Suggestion> GetAllSuggestions(string filePath);
    }
}
