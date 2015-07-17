using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGCorpHR.DATA;
using SGCorpHR.Models;

namespace SGCorpHR.BLL
{
    public class SuggestionOperations
    {
        public Response<List<Suggestion>> DisplaySuggestions(string filePath)
        {
            var repo = new SuggestionRepository();
            var response = new Response<List<Suggestion>>();
            var suggestions = repo.GetAllSuggestions(filePath);
            try
            {
                if (suggestions.Count > 0)
                {
                    response.Success = true;
                    response.Data = suggestions;

                }
                else
                {
                    response.Success = false;
                    response.Message = "No Files were found";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public void DeleteSuggestions(int suggestionID, string filePath)
        {
            var repo = new SuggestionRepository();
            var response = new Response<List<Suggestion>>();
            repo.RemoveFile(suggestionID, filePath);
            try
            {
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            
        }

        public void AddSuggestion(Suggestion suggestion, string filePath)
        {
            var repo = new SuggestionRepository();
            repo.AddSuggestion(suggestion, filePath);
           

        }
    }
}
