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

        public int TotalHoursWorked(int employeeId)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("employeeID", employeeId);

                return cn.Query<int>("TotalHoursWorked", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void DeleteTimesheet(int empTimesheetId)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                cn.Query("DELETE Timesheet Where TimesheetId = @timesheetId", new {timesheetId = empTimesheetId});
            }
        }

        public void SubmitNewTimeSheet(Timesheet timesheet)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("dateOfSheet", timesheet.DateOfTimesheet);
                p.Add("totalHrsThatDay", timesheet.TotalHoursByDay);
                p.Add("empId", timesheet.EmpId);

                cn.Query("SubmitNewTimeSheet", p, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
