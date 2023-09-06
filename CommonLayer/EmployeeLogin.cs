using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class EmployeeLogin
    {
        [Required(ErrorMessage ="{0} is required.")]
        public string EmployeeId { get; set; }
        [Required(ErrorMessage ="{0} is required.")]
        public string Name { get; set; }
    }
}
