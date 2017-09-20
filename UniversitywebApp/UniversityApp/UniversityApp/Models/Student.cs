using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }

         [Required (ErrorMessage = "Please Provide Your Name")]
        public string Name { get; set; }
         [Required(ErrorMessage = "Please Provide Your Email")]
         [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",ErrorMessage = "Provide a Valid email")]
        public string Email { get; set; }
         [Required(ErrorMessage = "Please Provide Your Contact Number")]
         [RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        [StringLength(11,MinimumLength = 11,ErrorMessage = "Mobile No must be 11 digit")]
        public string ContactNo { get; set; }
         [Required(ErrorMessage = "Please Provide Your Year")]
        public DateTime Date { get; set; }
         [Required(ErrorMessage = "Please Provide Your Address")]
        public string Address { get; set; }
         
        public string RegistrationNo { get; set; }
        [Required(ErrorMessage = "Please select Your Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
    }
}