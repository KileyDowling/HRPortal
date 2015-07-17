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
        public ActionResult TimeTracker()
        {
        //    var ops = new PolicyDocumentsOperations();
        //    var model = new CategoryVM();

        //    var response = ops.GetAllCategories(fullPath);

        //    model.CreateCategoryList(response.Data);

        //    return View(model);

            var ops = new TimeTrackerOperations();
            //var model = new TimeTrackerVM();
            //List<Employee> employees = ops.
            //model.EmployeeInfo

            return View();
        }
    }
}