using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace ResultManagementApp.Models
{
    public class TeacherForCourseAssign
    {
        public int TeacherId { get; set; }

        public int DepartmentId { get; set; }
        public string TeacherName { get; set; }

    }
}