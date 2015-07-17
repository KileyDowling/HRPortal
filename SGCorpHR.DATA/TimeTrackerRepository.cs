using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGCorpHR.Models;
using Dapper;

namespace SGCorpHR.DATA
{
    public class TimeTrackerRepository
    {
        public List<Timesheet> GetAllTimeSheets(int employeeId)
        {
           using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
           {
               var p = new DynamicParameters();
               p.Add("EmpId", employeeId);
               
               return 
                   cn.Query<Timesheet>("TimeTrackerSummary", p, commandType: CommandType.StoredProcedure).ToList();
           }
        }

        public Employee GetSingleEmployee(int employeeId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                return cn.Query<Employee>("SELECT * FROM Employee WHERE EmpId = @empId", new {empId = employeeId}).ToList().FirstOrDefault();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                 return
                    cn.Query<Employee>("SELECT * FROM Employee").ToList();
            }
        } 
    }
}
