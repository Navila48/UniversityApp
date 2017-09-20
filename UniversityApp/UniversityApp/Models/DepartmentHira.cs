using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace UniversityApp.Models
{
    public class DepartmentHira
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Provide Department Code")]
        [StringLength(7,MinimumLength = 2, ErrorMessage = "code must be two (2) to seven (7) characters long")]
       
        public string Code { get; set; }
        [Required(ErrorMessage = "Please enter a department Name")]
        public string Name { get; set; }

    }
}