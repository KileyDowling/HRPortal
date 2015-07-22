using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SGCorpHR.Models;
using SGCorpHR.Models.Interfaces;

namespace SGCorpHR.DATA
{
    public class PaidTimeOffRepository : IPaidTimeOffRepository
    {
        public void SubmitPtoRequest(PaidTimeOff ptoRequest)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                
                p.Add("EmpId", ptoRequest.EmpID);
                p.Add("HoursRequested", ptoRequest.HoursRequested);
                p.Add("Date", ptoRequest.Date);
                

                    cn.Query<PaidTimeOff>("SubmitPtoRequest", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<PaidTimeOff> ViewAllPtoRequests()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                
                 return cn.Query<PaidTimeOff>("Select * from PaidTimeOff Order by EmpID ASC, [Date] DESC").ToList();
            }
        } 
    }
}
