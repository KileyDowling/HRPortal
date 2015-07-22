using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGCorpHR.UI.Models
{
    public class PaidTimeOffVM
    {
        public int EmpId { get; set; }
        public int ManagerId { get; set; }
        public int HoursRequested { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

    }
}