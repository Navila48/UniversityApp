using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResultManagementApp.Models
{
    public class StudentMustafa
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public string Date { get; set; }
        public string RegNo { get; set; }
        public int CourseId { get; set; }
        public string Code { get; set; }
        public string Grade { get; set; }
        public List<CourseMustafa> Courses { get; set; }

    }
}