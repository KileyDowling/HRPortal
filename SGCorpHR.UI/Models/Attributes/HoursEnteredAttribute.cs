using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SGCorpHR.UI.Models.Attributes
{
    public class HoursEnteredAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value) && ((int)value == 4 || (int)value == 8);
        }
    }
}