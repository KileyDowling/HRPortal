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
        public List<SelectListItem> GenerateEmployeeList()
        {

            var ops = new TimeTrackerOperations();
            List<SelectListItem> selectItemList = new List<SelectListItem>();
            Response<List<Employee>> employees = ops.GetAllEmployees();
            var model = new TimeTrackerVM();
            model.DisplayEmployeeInformation(employees.Data);
            selectItemList = model.EmployeeInfo;
            return selectItemList;
        }

        [HttpPost]
        public ActionResult SubmitTimeSheet(TimeTrackerVM model)
        {
            if (ModelState.IsValidField("NewTimesheet.TotalHoursByDay") &&
                (DateTime.Now > model.NewTimesheet.DateOfTimesheet) &&
                (model.NewTimesheet.DateOfTimesheet > new DateTime(2005, 08, 07)))
            {
                var ops = new TimeTrackerOperations();
                model.NewTimesheet.EmpId = model.SelectedEmployee.EmpID;
                ops.SubmitTimeSheet(model.NewTimesheet);


                return RedirectToAction("TimeTrackerSummary", new {empId = model.NewTimesheet.EmpId});
            }
            ModelState.AddModelError("NewTimesheet.DateOfTimesheet", "That is an invalid date");
            model.EmployeeInfo = GenerateEmployeeList();
            return View(model);
        }

        public ActionResult SubmitTimeSheet()
        {
            var model = new TimeTrackerVM();
            model.EmployeeInfo = GenerateEmployeeList();
            return View(model);
        }

        // GET: TimeTracker
        public ActionResult SelectEmpToView()
        {
            var model = new TimeTrackerVM();
            model.EmployeeInfo = GenerateEmployeeList();

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

        public ActionResult DeleteTimesheet(int TimesheetId, int EmpId)
        {
            TimeTrackerOperations ops = new TimeTrackerOperations();
            ops.DeleteSingleTimesheet(TimesheetId);

            return RedirectToAction("TimeTrackerSummary", new {empId = EmpId});
        }

        public ActionResult ViewPtoRequests()
        {
            PaidTimeOffOperations ops = OperationsFactory.CreatePaidTimeOffOperations();
            Response<List<PaidTimeOff>> response = new Response<List<PaidTimeOff>>();
            response = ops.ViewAllPtoRequests();

            return View(response);
        }

        public ActionResult SubmitPtoRequest()
        {
            List<SelectListItem> employeeList = GenerateEmployeeList();
            ViewBag.EmployeeList = employeeList;

            return View();
        }

        [HttpPost]
        public ActionResult SubmitPtoRequest(PaidTimeOffVM ptoVM)
        {
            if (ModelState.IsValidField("HoursRequested"))
            {
                var ptoRequest = new PaidTimeOff();
                ptoRequest.EmpID = ptoVM.EmpId;
                ptoRequest.Date = ptoVM.Date;
                ptoRequest.HoursRequested = ptoVM.HoursRequested;
                ptoRequest.ManagerID = ptoVM.ManagerId;

                var ops = OperationsFactory.CreatePaidTimeOffOperations();
                ops.SubmitPtoRequest(ptoRequest);
            } 
            else
            {
                return RedirectToAction("SubmitPtoRequest");
            }

           return RedirectToAction("ViewPtoRequests");
        }

        public ActionResult EditPtoRequest(int PtoRequestId)
        {
            return View();
        }

        
    }
}