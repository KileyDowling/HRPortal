using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGCorpHR.BLL;
using SGCorpHR.Models;
using SGCorpHR.UI.Models;

namespace SGCorpHR.UI.Controllers
{
    public class TimeTrackerController : Controller
    {
        // GET: TimeTracker
        public ActionResult SelectEmpToView()
        {

            var ops = new TimeTrackerOperations();
            var model = new TimeTrackerVM();
            Response<List<Employee>> employees = ops.GetAllEmployees();

            model.DisplayEmployeeInformation(employees.Data);
              

            return View(model);
        }

        [HttpPost]
        public ActionResult SelectEmpToView(TimeTrackerVM model)
        {
            return RedirectToAction("TimeTrackerSummary", new {empId = model.SelectedEmployee.EmpID});
        }

        public ActionResult TimeTrackerSummary(int empId)
        {
            TimeTrackerOperations ops = new TimeTrackerOperations();
            Response<TimeTrackerSummary> response = new Response<TimeTrackerSummary>();
            response = ops.GetTimeTrackerSummary(empId);

            return View(response);

        }

        public ActionResult DeleteTimesheet(int TimesheetId, int EmpId )
        {
            TimeTrackerOperations ops = new TimeTrackerOperations();
            ops.DeleteSingleTimesheet(TimesheetId);

            return RedirectToAction("TimeTrackerSummary", new {empId = EmpId});
        }
    }
}