using System.ComponentModel.DataAnnotations;

namespace Domain.CustomDataAnnotation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class YearRangeAttribute : RangeAttribute
    {
        public YearRangeAttribute(double minimum) : base(minimum, DateTime.Now.Year-1)
        {
        }
    }
}
