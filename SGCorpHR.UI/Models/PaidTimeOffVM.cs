using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SGCorpHR.UI.Models.Attributes;

namespace SGCorpHR.UI.Models
{
    public class PaidTimeOffVM 
    {

        public int EmpId { get; set; }
        public int ManagerId { get; set; }

        [HoursEntered(ErrorMessage = "Can only enter 4 or 8 hours")]
        public int HoursRequested { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

    }
}