using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResultManagementApp.Models
{
    public class CourseMustafa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Course Name")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Please Enter Course Code")]

        [StringLength(20, MinimumLength = 5, ErrorMessage = "code length Minimum 5 characters")]

        public String Code { get; set; }
        [Required(ErrorMessage = "Please Enter Course Credit")]
        [Range(0.5, 5.0, ErrorMessage = "Invaild range! Credit range is 0.5 to 5.0")]
        public decimal Credit { get; set; }

        public decimal CreditToBeTaken { get; set; }
        public decimal RemainingCredit { get; set; }

    }
}