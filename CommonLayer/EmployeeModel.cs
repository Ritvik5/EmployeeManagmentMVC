using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ProfileImage { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public Decimal Salary { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public string Notes { get; set; }
    }
}
