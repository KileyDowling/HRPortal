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
    public class PolicyDocumentsController : Controller
    {
        // GET: PolicyDocuments
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult SelectPolicyDocCategory()
        {
            var fullPath = Server.MapPath(@"~/PolicyDocuments");
            var ops = new PolicyDocumentsOperations();
            var model = new CategoryVM()
            {
                PolicyDocumentToAdd = new PolicyDocument()
                {
                    Category = new Category()
                }
            };

            var response = ops.GetAllCategories(fullPath);

            model.CreateCategoryList(response.Data);

            return View(model);
        }

        [HttpPost]
        public ActionResult SelectPolicyDocCategory(CategoryVM model)
        {
            return RedirectToAction("ViewPolicyDocuments", new { nameOfCategory = model.Category.CategoryName });
        }

        public ActionResult ViewPolicyDocuments(string nameOfCategory)
        {
            var filePathToMap = string.Format(@"~/PolicyDocuments/{0}", nameOfCategory);
            var filePath = Server.MapPath(@filePathToMap);
            var ops = new PolicyDocumentsOperations();
            var model = new CategoryVM()
            {
                Response = ops.GetAllPolicyDocuments(filePath, nameOfCategory),
                Category = new Category()
                {
                    CategoryName = nameOfCategory
                }

            };


            return View(model);
        }

        [HttpPost]
        public ActionResult SavePolicyDocument(HttpPostedFileBase file, CategoryVM model)
        {
            if (file.ContentLength > 0)
            {
                var fullPath = Server.MapPath(@"~/PolicyDocuments");
                var filePathComplete = String.Format(@"{0}\{1}\{2}", fullPath, model.PolicyDocumentToAdd.Category.CategoryName, file.FileName);
                model.PolicyDocumentToAdd.FilePath = filePathComplete;

                var ops = new PolicyDocumentsOperations();

                var folderPath = fullPath + @"\" + model.PolicyDocumentToAdd.Category.CategoryName;
                ops.AddPolicyDocument(model.PolicyDocumentToAdd, folderPath);
                //file.SaveAs(filePathComplete);

            }

            return RedirectToAction("ViewPolicyDocuments", new { nameOfCategory = model.PolicyDocumentToAdd.Category.CategoryName });
        }

        public ActionResult UploadPolicyDoc()
        {
            var fullPath = Server.MapPath(@"~/PolicyDocuments");
            var ops = new PolicyDocumentsOperations();
            var model = new CategoryVM();

            var response = ops.GetAllCategories(fullPath);

            model.CreateCategoryList(response.Data);

            return View(model);
        }

        public ActionResult DownloadPolicyDoc(string filePath)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(@filePath);
            string fileName = filePath.Substring(filePath.Length - 8, 8);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public ActionResult DeletePolicyDoc(string filePath, string categoryName)
        {
            System.IO.File.Delete(@filePath);
            return RedirectToAction("ViewPolicyDocuments", new { nameOfCategory = categoryName });
        }
    }
}