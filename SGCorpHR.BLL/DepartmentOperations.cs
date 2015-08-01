using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGCorpHR.DATA;

namespace SGCorpHR.BLL
{
    public class DepartmentOperations
    {

        public void DeleteDepartment(int departmentId)
        {
            var repo = new DepartmentRepository();
            repo.DeleteDepartment(departmentId);
        }
    }
}
