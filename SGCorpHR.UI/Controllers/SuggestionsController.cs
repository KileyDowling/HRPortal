using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SGCorpHR.BLL;
using SGCorpHR.Models;

namespace SGCorpHR.UI.Controllers
{
    public class SuggestionsController : Controller
    {
        public ActionResult AddSuggestion()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult AddSuggestionForm(Suggestion suggestion)
        {
            var filePath = Server.MapPath(@"~/Suggestions/Suggestions.txt");
            var ops = new SuggestionOperations();
            ops.AddSuggestion(suggestion, filePath);

            return View("ConfirmationPage");
        }

        public ActionResult ViewSuggestions()
        {
            var filePath = Server.MapPath(@"~/Suggestions/Suggestions.txt"); ;
            var ops = new SuggestionOperations();
            var response = ops.DisplaySuggestions(filePath);
            return View(response);
        }

        public ActionResult DeleteSuggestion(int suggestionID)
        {
            var filePath = Server.MapPath(@"~/Suggestions/Suggestions.txt"); ;
            var ops = new SuggestionOperations();
            ops.DeleteSuggestions(suggestionID, filePath);
            return RedirectToAction("ViewSuggestions");

        }
    }
}
