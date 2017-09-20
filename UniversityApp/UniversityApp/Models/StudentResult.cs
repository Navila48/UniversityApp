using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityApp.Models
{
    public class StudentResult
    {
        public string StudentRegNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public string Grade { get; set; }
        public string DeptName { get; set; }
    }
}