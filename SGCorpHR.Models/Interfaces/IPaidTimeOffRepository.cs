using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCorpHR.Models.Interfaces
{
    public interface IPaidTimeOffRepository
    {

        void SubmitPtoRequest(PaidTimeOff ptoRequest);


        List<PaidTimeOff> ViewAllPtoRequests();

    }
}
