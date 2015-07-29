using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SGCorpHR.BLL;
using SGCorpHR.Models;

namespace SGCorpHR.UI.Controllers
{
    public class EmployeeDirectoryController : ApiController
    {
        public List<Employee> Get()
        {
            var ops = new EmployeeDirectoryOperations();
            var response = ops.ListAllEmployees();
            var list = response.Data;
            return list;
        }
 
    }
}
