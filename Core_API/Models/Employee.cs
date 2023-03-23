using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core_API.Models
{
    public partial class Employee : EntityBase
    {
        [Required(ErrorMessage ="EmpNo is required")]
        [NonNegative(ErrorMessage = "This value cannot be -ve")]
        public int EmpNo { get; set; }
        [Required(ErrorMessage = "EmpName is required")]
        public string EmpName { get; set; } = null!;
        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; } = null!;
        [Required(ErrorMessage = "Salary is required")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "DeptNo is required")]
        public int? DeptNo { get; set; }
        // The DeptNoNAvigation can be null
        public virtual Department? DeptNoNavigation { get; set; } = null!;
    }
}
