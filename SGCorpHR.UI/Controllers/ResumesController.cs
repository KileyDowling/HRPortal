using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGCorpHR.BLL;
using SGCorpHR.Models;
using SGCorpHR.DATA;
using SGCorpHR.UI.Models;

namespace SGCorpHR.UI.Controllers
{
    public class ResumesController : Controller
    {
        public ActionResult DownloadResume(string filePath)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(@filePath);
            string fileName = filePath.Substring(filePath.Length - 8, 8);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public ActionResult DeleteResume(string filePath)
        {
            System.IO.File.Delete(@filePath);
            return RedirectToAction("ViewResume");
        }
   
        
        [HttpPost]
        public ActionResult SaveFile(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fullPath = Server.MapPath(@"~/Resumes");
                file.SaveAs(String.Format(@"{0}\{1}", fullPath, file.FileName));
            }
            return RedirectToAction("ViewResume");

        }

        public ActionResult Save()
        {
            return View("Save");
        }

        public ActionResult ViewResume()
        {
            var ops = new FileOperations();
            var filePath = Server.MapPath(@"~/Resumes"); ;
            var response = ops.DisplayFiles(filePath);
            return View(response);
        }
    }
}