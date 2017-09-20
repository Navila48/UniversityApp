using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityApp.Models
{
    public class CourseDetails
    {
        public int CourseId { get; set; }
      //  public string CourseName { get; set; }
        public string RegNo { get; set; }
        public int DepartmentId { get; set; }
        public string CourseName { get; set; }
    }
}