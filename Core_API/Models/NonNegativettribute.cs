using System.ComponentModel.DataAnnotations;

namespace Core_API.Models
{
    public class NonNegativeAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (Convert.ToInt32(value) < 0) return false; return true;
        }
    }
}
