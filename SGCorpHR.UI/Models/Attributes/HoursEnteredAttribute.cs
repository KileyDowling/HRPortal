using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SGCorpHR.UI.Models.Attributes
{
    public class HoursEnteredAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return ((int)value == 4 || (int)value == 8);
        }
    }
}