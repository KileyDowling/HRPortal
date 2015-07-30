using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SGCorpHR.Models;

namespace SGCorpHR.DATA
{
    public class DepartmentRepository
    {
        public List<Departments> ListAll()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                return cn.Query<Departments>("Select * from Departments").ToList();
            }
        }

        public Departments GetSingleDpt(int departmentId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                return cn.Query<Departments>("Select * from Departments WHERE DepartmentID = @dptId", new { dptId = departmentId }).ToList().FirstOrDefault();
            }
        }

        public void CreateDepartment(string departmentName)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                cn.Query<Departments>("insert into Departments(DepartmentName) values('" + departmentName +"')");
            }
        }
    }
}
