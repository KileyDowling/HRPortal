using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGCorpHR.Models;
using SGCorpHR.Models.Interfaces;

namespace SGCorpHR.DATA.Mocks
{
    public class PtoMock : IPaidTimeOffRepository
    {
        public List<PaidTimeOff> ViewAllPtoRequests()
        {
            return new List<PaidTimeOff>()
            {
                new PaidTimeOff() {PtoRequestID =  1, Date = new DateTime(2015,01,01), EmpID = 5, HoursRequested = 4, ManagerID = 1, ReasonRejected = "", Status = "Submitted" },
                new PaidTimeOff() {PtoRequestID =  1, Date = new DateTime(2015,04,02), EmpID = 3, HoursRequested = 8, ManagerID = 1, ReasonRejected = "", Status = "Submitted" }
                
            };
        }

        public void SubmitPtoRequest(PaidTimeOff ptoRequest)
        {
            
        }
    }
}
