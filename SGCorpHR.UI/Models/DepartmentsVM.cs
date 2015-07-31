using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SGCorpHR.BLL;

namespace SGCorpHR.UI.Models
{
    public class DepartmentsVM
    {
        public List<string> DepartmentNames { get; set; }

        public void ListAllNames()
        {
            var ops = new EmployeeDirectoryOperations();
            var resposne = ops.ListAllDepartments();
            foreach (var d in resposne.Data)
            {
                DepartmentNames.Add(d.DepartmentName);
            }
        }  
    }
}