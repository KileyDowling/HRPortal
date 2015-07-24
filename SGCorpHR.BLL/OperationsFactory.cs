using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SGCorpHR.DATA;
using SGCorpHR.DATA.Mocks;
using SGCorpHR.Models;


namespace SGCorpHR.BLL
{
    public class OperationsFactory
    {
        private static string mode = ConfigurationManager.AppSettings["Mode"];

        public static PaidTimeOffOperations CreatePaidTimeOffOperations()
        {
            if (mode == "Test")
                return new PaidTimeOffOperations(new PtoMock());
            else
            {
                return new PaidTimeOffOperations(new PaidTimeOffRepository());
            }
        }

        public static SuggestionOperations CreateSuggestionOperations()
        {
            if (mode == "Test")
                return new SuggestionOperations(new SuggestionMock());
            else
            {
                return new SuggestionOperations(new SuggestionRepository());
            }
        }
    }
}
