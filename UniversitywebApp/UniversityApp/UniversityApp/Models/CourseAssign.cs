using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResultManagementApp.Models
{
    public class CourseAssign
    {
        //Id changed to TeacherId
        //public int TeacherId { get; set; }

        public int Id { get; set; }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int  TeacherId { get; set; }
        public int CourseId { get; set; }
        public string Department { get; set; }
        public string DepartmentTeacher { get; set; }

        public decimal CreditToBeTaken { get; set; }
        public decimal RemainingCredit { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public decimal CourseCredit { get; set; }
       

    }
}