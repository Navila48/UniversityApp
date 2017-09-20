using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResultManagementApp.Gateway;
using ResultManagementApp.Models;

namespace ResultManagementApp.Manager
{
    public class EnrollCourseManager
    {
    
        EnrollCourseGateway anEnrollCourseGateway=new EnrollCourseGateway();
        public List<StudentMustafa> GetAllStudentsRegistrationNo()
        {
            return anEnrollCourseGateway.GetAllStudentsRegistrationNo();
        }

        public StudentMustafa GetStudentDetailsWithRegistrationNo(StudentMustafa student)
        {
            return anEnrollCourseGateway.GetStudentDetailsWithRegistrationNo(student);

        }

        public List<CourseMustafa> GetAllCoursesByDeptId(int departmentId)
        {
            return anEnrollCourseGateway.GetAllCoursesByDeptId(departmentId);
        }

        public string Enroll(StudentMustafa student)
        {
            if (anEnrollCourseGateway.IsCourseExists(student))
            {
                return "This Course has been enrolled already";
            }
            else
            {
                int isRowAffected = anEnrollCourseGateway.Enroll(student);
                if (isRowAffected > 0)
                {
                    return "Enrolled successfully";
                }
                else
                {
                    return "course enrolled failed";

                }
            }
        }
    }
}