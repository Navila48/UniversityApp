using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityApp.Models
{
    public class Teacher
    {
        [Required(ErrorMessage = "Please Provide Teacher's Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Provide an address")]
        public string Address { get; set; }

        [StringLength(50)]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter a valid email")]
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please provide Contact Number")]
        public string ContactNo { get; set; }
           [Required(ErrorMessage = "Please provide Designation")]
        public string Designation { get; set; }
           [Required(ErrorMessage = "Please provide Department Name")]
        public string Department { get; set; }
           [Required(ErrorMessage = "Please provide Credit to be taken")]
           [Range(1, double.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        public decimal CreditToBeTaken { get; set; }

    }
}