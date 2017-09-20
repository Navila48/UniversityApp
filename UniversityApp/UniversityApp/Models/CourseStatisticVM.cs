using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityApp.Models
{
    public class CourseStatisticVM
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string AssignTo { get; set; }
        public string Status { get; set; }
    }
}