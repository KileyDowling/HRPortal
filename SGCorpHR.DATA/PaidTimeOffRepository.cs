﻿using System;
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

        public void EditPtoRequest(PaidTimeOff paidTimeOff)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand("UPDATE [dbo].[PaidTimeOff] "
                    + "SET [PtoStatus] = @PtoStatus, "
                    + "[EmpID] = @EmpId, "
                    + "[HoursRequested] = @HoursRequested, "
                    + "[Date] = @Date, "
                    + "[ReasonRejected] = @ReasonReject, "
                    + "[ManagerID] = @ManagerId "
                    + "WHERE PtoRequestID = @PtoRequestId", cn);
                cmd.Parameters.AddWithValue("@PtoRequestId", paidTimeOff.PtoRequestID);
                cmd.Parameters.AddWithValue("@PtoStatus", paidTimeOff.PtoStatus);
                cmd.Parameters.AddWithValue("@EmpID", paidTimeOff.EmpID);
                cmd.Parameters.AddWithValue("@HoursRequested", paidTimeOff.HoursRequested);
                cmd.Parameters.AddWithValue("@Date", paidTimeOff.Date);
                cmd.Parameters.AddWithValue("@ReasonReject", paidTimeOff.ReasonRejected);
                cmd.Parameters.AddWithValue("@ManagerID", paidTimeOff.ManagerID);


                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
