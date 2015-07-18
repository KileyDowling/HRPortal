using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGCorpHR.DATA;
using SGCorpHR.Models;

namespace SGCorpHR.BLL
{
    public class TimeTrackerOperations
    {
        public Response<TimeTrackerSummary> GetTimeTrackerSummary(int empId)
        {
            TimeTrackerRepository repo = new TimeTrackerRepository();
            var response = new Response<TimeTrackerSummary>();
            List<Timesheet> listOfTimesheets = repo.GetAllTimeSheets(empId);

            try
            {
                if (listOfTimesheets.Count > 0)
                {
                    response.Success = true;
                    response.Data = new TimeTrackerSummary()
                    {
                       SelectedEmployee = repo.GetSingleEmployee(empId),
                       TotalHoursWorked = repo.TotalHoursWorked(empId),
                        AllTimesheets = listOfTimesheets
                    };
                }

                else
                {
                    response.Data = new TimeTrackerSummary()
                    {
                        SelectedEmployee = repo.GetSingleEmployee(empId),
                    };
                    
                    response.Success = false;
                    response.Message = "There were no timesheets found for that employee";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public Response<List<Employee>> GetAllEmployees()
        {
            TimeTrackerRepository repo = new TimeTrackerRepository();
            var response = new Response<List<Employee>>();
            List<Employee> listOfEmployees = repo.GetAllEmployees();

            try
            {
                if (listOfEmployees.Count > 0)
                {
                    response.Success = true;
                    response.Data = listOfEmployees;

                }
                else
                {
                    response.Success = false;
                    response.Message = "There were no employees found";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public void DeleteSingleTimesheet(int timesheetId)
        {
            TimeTrackerRepository repo = new TimeTrackerRepository();
            repo.DeleteTimesheet(timesheetId);
        }

        public void SubmitTimeSheet(Timesheet timesheet)
        {
            TimeTrackerRepository repo = new TimeTrackerRepository();
            repo.SubmitNewTimeSheet(timesheet);
        }
    }

}
