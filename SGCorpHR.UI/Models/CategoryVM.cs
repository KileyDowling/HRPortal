using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGCorpHR.Models;

namespace SGCorpHR.UI.Models
{
    public class CategoryVM
    {
        public PolicyDocument PolicyDocumentToAdd { get; set; }
        public Category Category { get; set; }
        public Response<List<PolicyDocument>> Response { get; set; }
        public List<SelectListItem> Categories { get; set; }

        public void CreateCategoryList(List<Category> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var c in categories)
            {
                Categories.Add(new SelectListItem() {Text = c.CategoryName, Value = c.CategoryName});
            }
        }
    }
}