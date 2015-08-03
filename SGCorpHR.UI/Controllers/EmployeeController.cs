using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGCorpHR.BLL;
using SGCorpHR.UI.Models;

namespace SGCorpHR.UI.Controllers
{
    public class EmployeeController : Controller
    {
        public List<SelectListItem> GenerateDepartmentList()
        {
            var ops = new DepartmentOperations();
            var response = ops.ListAllDepartments();
            var listDpt = response.Data;
            var dptVM = new DepartmentsVM();
            dptVM.GenerateListOfDpts(listDpt);
            List<SelectListItem> dptSelectListItem = dptVM.DepartmentNames;
            return dptSelectListItem;
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Filter()
        {
            return View();
        }


    }
}