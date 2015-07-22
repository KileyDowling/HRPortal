using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SGCorpHR.DATA;
using SGCorpHR.DATA.Mocks;


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
    }
}
