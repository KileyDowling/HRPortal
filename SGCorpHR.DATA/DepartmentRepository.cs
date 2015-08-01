using System;
using System.Collections.Generic;
using System.Data;
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

        public Departments GetSingleDptById(int departmentId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                return cn.Query<Departments>("Select * from Departments WHERE DepartmentID = @dptId", new { dptId = departmentId }).ToList().FirstOrDefault();
            }
        }

        public int GetDptIdByName (string departmentName)
        {
            var dptList = ListAll();
            var specDpt = dptList.FirstOrDefault(x => x.DepartmentName == departmentName);
            return specDpt.DepartmentID;
        }

        public bool CheckIfDptExists(string departmentName)
        {
            bool dptExists;
            var dptList = ListAll();
            var specDpt = dptList.FirstOrDefault(x => x.DepartmentName == departmentName);
            if (specDpt.DepartmentName == departmentName) 
                dptExists = true;
            else
                dptExists = false;

            return dptExists;
        }

        public void CreateDepartment(string departmentName)
        {
            var exists = CheckIfDptExists(departmentName);
            if (!exists)
            {
                using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
                {
                    var p = new DynamicParameters();
                    p.Add("dptName", departmentName);
                    cn.Query("CreateDepartment",p, commandType: CommandType.StoredProcedure);
                }
            }
        }

        public void DeleteDepartment(int departmentId)
        {

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                cn.Query("Delete Departments WHERE DepartmentID = @dptId", new { dptId = departmentId });
            }
            
        }

        public void UpdateDepartment(Departments department)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("dptName", department.DepartmentName);
                p.Add("dptId", department.DepartmentID);
                cn.Query("UpdateDepartment", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
