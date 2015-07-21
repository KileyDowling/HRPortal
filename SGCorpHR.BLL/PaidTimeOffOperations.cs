using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGCorpHR.DATA;
using SGCorpHR.Models;

namespace SGCorpHR.BLL
{
    public class PaidTimeOffOperations
    {
        public void SubmitPtoRequest(PaidTimeOff pto)
        {
            PaidTimeOffRepository repo = new PaidTimeOffRepository();
            repo.SubmitPtoRequest(pto);
        }

        public Response<List<PaidTimeOff>> ViewAllPtoRequests()
        {
            Response<List<PaidTimeOff>> response = new Response<List<PaidTimeOff>>();
            PaidTimeOffRepository repo = new PaidTimeOffRepository();
            List<PaidTimeOff> ptoList = repo.ViewAllPtoRequests();

            try
            {
                if (ptoList.Count > 0)
                {
                    response.Data = ptoList;
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = "There are no requests to display";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
