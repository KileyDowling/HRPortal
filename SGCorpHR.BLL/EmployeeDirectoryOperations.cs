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

        public Response<List<Employee>> GetEmpByDptID(int departmentId)
        {
            var repo = new EmployeeDirectoryRepository();
            var response = new Response<List<Employee>>();
            List<Employee> empList = repo.GetEmpByDptID(departmentId);

            try
            {
                if (empList != null)
                {
                    response.Data = empList;
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

        public Employee GetEmpById(int id)
        {
            var repo = new EmployeeDirectoryRepository();
            var employee = repo.GetEmpById(id);
            return employee;
        }

        public void DeleteEmpById(int id)
        {
            var ops = new EmployeeDirectoryRepository();
            ops.DeleteEmp(id);
        }

        public void UpdateEmployee(Employee employee)
        {
            var repo = new EmployeeDirectoryRepository();
            repo.UpdateEmp(employee);
        }

    }
}
