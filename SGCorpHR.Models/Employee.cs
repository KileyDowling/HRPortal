using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCorpHR.Models
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? HireDate { get; set; }

        public string FormattedHireDate
        {
            get
            {
                string returnVal = "";
                if (HireDate != null)
                {
                    returnVal = HireDate.Value.ToShortDateString();
                }
                return returnVal;
            }
        }
    }
}
