using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResultManagementApp.Gateway;
using ResultManagementApp.Models;

namespace ResultManagementApp.Manager
{
    public class ViewResultManager
    {
        ViewResultGateway aViewResultGateway=new ViewResultGateway();
        public List<StudentMustafa> GetAllStudentsRegistrationNo()
        {
            return aViewResultGateway.GetAllStudentsRegistrationNo();
        }

        public StudentMustafa GetStudentDetailsWithRegistrationNo(StudentMustafa student)
        {
            return aViewResultGateway.GetStudentDetailsWithRegistrationNo(student);
        }

        public List<ViewCourse> GetStudentAllCourseDetailsWithRegistrationNo(StudentMustafa student)
        {
            return aViewResultGateway.GetStudentAllCourseDetailsWithRegistrationNo(student);
        }
    }
}