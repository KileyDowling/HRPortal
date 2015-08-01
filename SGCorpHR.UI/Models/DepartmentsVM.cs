using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGCorpHR.BLL;
using SGCorpHR.Models;

namespace SGCorpHR.UI.Models
{
    public class DepartmentsVM
    {
        public List<SelectListItem> DepartmentNames { get; set; }
        public DepartmentsVM SelectedDepartment { get; set; }
        public Departments NewDepartment { get; set; }

        public void GenerateListOfDpts(List<Departments> departments)
        {
            DepartmentNames = new List<SelectListItem>();
            foreach (var d in departments)
            {
                DepartmentNames.Add(new SelectListItem() { Text = d.DepartmentName, Value = d.DepartmentID .ToString()});
            }
        }
    }
}