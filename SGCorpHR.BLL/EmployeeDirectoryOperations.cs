using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGCorpHR.DATA;
using SGCorpHR.Models;

namespace SGCorpHR.BLL
{
    public class EmployeeDirectoryOperations
    {
        public Response<List<Employee>> ListAllEmployees()
        {
            var repo = new EmployeeDirectoryRepository();
            List<Employee> empList = repo.ListAllEmployees();
            var response = new Response<List<Employee>>();

            try
            { 
                if (empList.Count > 0)
                {
                    response.Data = empList;
                    response.Success = true;

                }
                else
                {
                    response.Success = false;
                    response.Message = "There  are no employees to display";
                }
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<List<Departments>> ListAllDepartments()
        {
            var repo = new DepartmentRepository();
            var response = new Response<List<Departments>>();
            List<Departments> dptList = repo.ListAll();

            try
            {
                if (dptList.Count > 0)
                {
                    response.Data = dptList;
                    response.Success = true;

                }
                else
                {
                    response.Success = false;
                    response.Message = "There  are no employees to display";
                }
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
            }
            return response;


        }

        public Response<Departments> GetSingleDpt(int departmentId)
        {
            var repo = new DepartmentRepository();
            var response = new Response <Departments>();
            Departments dpt = repo.GetSingleDpt(departmentId);

            try
            {
                if (dpt != null)
                {
                    response.Data = dpt;
                    response.Success = true;

                }
                else
                {
                    response.Success = false;
                    response.Message = "That department doesn't exist";
                }
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public void CreateDepartment(string dptName)
        {
            var repo = new DepartmentRepository();
            repo.CreateDepartment(dptName);
        }

    }
}
