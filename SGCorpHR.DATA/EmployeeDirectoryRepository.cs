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

                var cmd = new SqlCommand("select e.FirstName, e.LastName,e.HireDate, (m.FirstName + ' ' +  m.LastName) as [ManagerName], Departments.DepartmentName, Departments.DepartmentID, l.[state], e.[Status] from Employee e inner join Departments on e.DepartmentID = Departments.DepartmentID inner join Employee m on m.EmpID = e.ManagerID  inner join Location l on e.LocationID = l.LocationID order by e.LastName", cn);
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
    }
}
