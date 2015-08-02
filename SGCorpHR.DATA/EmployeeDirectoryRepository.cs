using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SGCorpHR.Models;
using SGCorpHR.Models.Interfaces;

namespace SGCorpHR.DATA
{
   public class EmployeeDirectoryRepository : IEmployeeDirectoryRepository
    {
        public List<Employee> ListAllEmployees()
        {
            var emps = new List<Employee>();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {

                var cmd = new SqlCommand("select e.FirstName, e.LastName,e.HireDate, (m.FirstName + ' ' +  m.LastName) as [ManagerName], Departments.DepartmentName, Departments.DepartmentID, l.[state], e.[Status],e.EmpID from Employee e inner join Departments on e.DepartmentID = Departments.DepartmentID inner join Employee m on m.EmpID = e.ManagerID  inner join Location l on e.LocationID = l.LocationID order by e.LastName", cn);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var temp = new Employee();
                        temp.Department = new Departments();
                        temp.FirstName = dr.GetString(0);
                        temp.LastName = dr.GetString(1);
                        temp.HireDate = dr["HireDate"] is DBNull ? DateTime.Now : dr.GetDateTime(2);
                        temp.ManagerName = dr.GetString(3);
                        temp.Department.DepartmentName = dr.GetString(4);
                        temp.Department.DepartmentID = dr.GetInt32(5);
                        temp.State = dr.GetString(6);
                        temp.Status = dr["Status"] is DBNull ? String.Empty : dr.GetString(7);
                        temp.EmpID = dr.GetInt32(8);

                        emps.Add(temp);
                    }
                }
            }
            return emps;
        }

       public List<Employee> GetEmpByDptID(int id)
       {
           var emps = new List<Employee>();

           using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
           {

               var cmd = new SqlCommand("select e.FirstName, e.LastName,e.HireDate, (m.FirstName + ' ' +  m.LastName) as [ManagerName], Departments.DepartmentName, Departments.DepartmentID, l.[state], e.[Status] from Employee e inner join Departments on e.DepartmentID = Departments.DepartmentID inner join Employee m on m.EmpID = e.ManagerID  inner join Location l on e.LocationID = l.LocationID WHERE e.DepartmentID = "+ id+" order by e.LastName", cn);
               cn.Open();
               using (SqlDataReader dr = cmd.ExecuteReader())
               {
                   while (dr.Read())
                   {
                       var temp = new Employee();
                       temp.Department = new Departments();
                       temp.FirstName = dr.GetString(0);
                       temp.LastName = dr.GetString(1);
                       temp.HireDate = dr["HireDate"] is DBNull ? DateTime.Now : dr.GetDateTime(2);
                       temp.ManagerName = dr.GetString(3);
                       temp.Department.DepartmentName = dr.GetString(4);
                       temp.Department.DepartmentID = dr.GetInt32(5);
                       temp.State = dr.GetString(6);
                       temp.Status = dr["Status"] is DBNull ? String.Empty : dr.GetString(7);
                       emps.Add(temp);
                   }
               }
           }
           return emps;
           
       }

       public void DeleteEmp(int id)
       {
           using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
           {
               cn.Query("Delete Employee WHERE EmpID = @empId", new { empId = id });
           }
       }

       public void UpdateEmp(Employee updatedEmployee)
       {
           using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
           {
               var p = new DynamicParameters();
              
               p.Add("@firstName,", updatedEmployee.FirstName);
               p.Add("@lastName", updatedEmployee.LastName);
               p.Add("@locationId", updatedEmployee.LocationID);
               p.Add("@managerId", 11);
               p.Add("@status", updatedEmployee.Status);
               p.Add("@deptId", updatedEmployee.Department.DepartmentID);
               p.Add("@empId", updatedEmployee.EmpID);

               cn.Query("UpdateEmployee", p, commandType: CommandType.StoredProcedure);
           }
       }

       public Employee GetEmpById(int id)
       {
           using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
           {
               var cmd = new SqlCommand("select e.FirstName, e.LastName,e.HireDate, (m.FirstName + ' ' +  m.LastName) as [ManagerName], Departments.DepartmentName, Departments.DepartmentID, e.LocationID, e.[Status],e.EmpID from Employee e inner join Departments on e.DepartmentID = Departments.DepartmentID inner join Employee m on m.EmpID = e.ManagerID  inner join Location l on e.LocationID = l.LocationID WHERE e.EmpID = @empId order by e.LastName", cn);
               SqlParameter param = new SqlParameter();
               param.ParameterName = "@empId";
               param.Value = id;
               cmd.Parameters.Add(param);
               cn.Open();                       
               var temp = new Employee();

               using (SqlDataReader dr = cmd.ExecuteReader())
               {
                   while (dr.Read())
                   {
                       temp.Department = new Departments();
                       temp.FirstName = dr.GetString(0);
                       temp.LastName = dr.GetString(1);
                       temp.HireDate = dr["HireDate"] is DBNull ? DateTime.Now : dr.GetDateTime(2);
                       temp.ManagerName = dr.GetString(3);
                       temp.Department.DepartmentName = dr.GetString(4);
                       temp.Department.DepartmentID = dr.GetInt32(5);
                       temp.LocationID = dr.GetInt32(6);
                       temp.Status = dr["Status"] is DBNull ? String.Empty : dr.GetString(7);
                       temp.EmpID = dr.GetInt32(8);
                   }
               }
               return temp;

           }
       }
    }
}
