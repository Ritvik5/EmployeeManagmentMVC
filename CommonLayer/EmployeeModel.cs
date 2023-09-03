using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Profile Image")]
        public string ProfileImage { get; set; }
        [Required]
        [DisplayName("Gender : M / F")]
        public char Gender { get; set; }
        [Required]
        [DisplayName("Department Name")]
        public string Department { get; set; }
        [Required]
        [DisplayName("Salary")]
        public Decimal Salary { get; set; }
        [Required]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayName("Add Note")]
        public string Notes { get; set; }
    }
}
