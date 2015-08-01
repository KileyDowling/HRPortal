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
    public class DepartmentController : ApiController
    {
        // GET api/<controller>
        public List<Departments> Get()
        {
            var ops = new DepartmentOperations();
            var response = ops.ListAllDepartments();
            var list = response.Data;
            return list;

        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>

        public HttpResponseMessage Post(string departmentName)
        {
            var ops = new DepartmentOperations();
            ops.CreateDepartment(departmentName);
            var opsResponse = ops.GetDptIdByName(departmentName);
            int dptId = opsResponse.Data;

            var response = Request.CreateResponse(HttpStatusCode.Created, departmentName);

            string uri = Url.Link("DefaultApi", new { id = dptId });
            response.Headers.Location = new Uri(uri);

            return response;


        }

        // PUT api/<controller>/5
        public void Put(Departments department)
        {
            var ops = new DepartmentOperations();
            ops.UpdateDepartment(department);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var ops = new DepartmentOperations();
            ops.DeleteDepartment(id);
        }
    }
}