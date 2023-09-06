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
        [Required(ErrorMessage = "Employee {0} is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name Should contain minimum 3 characters and Maximum of 100")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please select {0}")]
        [DisplayName("Profile Image")]

        public string ProfileImage { get; set; }
        [Required(ErrorMessage = "Please select {0}")]
        public char Gender { get; set; }
        [Required(ErrorMessage = "Please select {0}")]
        [DisplayName("Department Name")]
        public string Department { get; set; }
        [Required]
        [DisplayName("Salary")]
        [RegularExpression("^[1-9][0-9]{4,}$", ErrorMessage = "Salary Should not be negative and Minimum should be 10000.")]
        public Decimal Salary { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Note Should contain minimum 3 Characters.")]
        [DisplayName("Add Note")]
        public string Notes { get; set; }
    }
}
