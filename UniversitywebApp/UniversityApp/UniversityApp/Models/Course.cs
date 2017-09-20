using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityApp.Models
{
    public class Course
    {
        [Required (ErrorMessage = "Please Provide Your Course Code")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Code must be at least five (5) characters long.")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
         [Required]
         [Range(0.5, 5.0)]
        public Decimal Credit { get; set; }
                [Required]
        public string Description { get; set; }
                [Required]
        public int Department  { get; set; }
                [Required]
        public int Semester { get; set; }

    }
}