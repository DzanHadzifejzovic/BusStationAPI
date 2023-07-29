using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CustomDataAnnotation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class YearRangeAttribute : RangeAttribute
    {
        public YearRangeAttribute(double minimum) : base(minimum, DateTime.Now.Year-1)
        {
        }
    }
}
