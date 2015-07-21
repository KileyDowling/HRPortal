using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCorpHR.Models
{
    public class PaidTimeOff
    {
        public int PtoRequestID { get; set; }
        public string Status { get; set; }
        public int EmpID { get; set; }
        public int HoursRequested { get; set; }
        public DateTime Date { get; set; }
        public string ReasonRejected { get; set; }
        public int ManagerID { get; set; }
    }
}
