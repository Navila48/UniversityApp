using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResultManagementApp.Gateway;
using ResultManagementApp.Models;

namespace ResultManagementApp.Manager
{
    public class CourseAssignManager
    {
        CourseAssignGateway aCourseAssignGateway=new CourseAssignGateway();
        public List<Departmentmustafa> GetAllDepartments()
        {
            return aCourseAssignGateway.GetAllDepartments();
        }

        //public List<TeacherForCourseAssign> GetAllTeachers()
        //{
        //    return aCourseAssignGateway.GetAllTeachers();
        //}

        public CourseAssign GetTeacherDetails(int teacherId)
        {
            return aCourseAssignGateway.GetTeacherDetails(teacherId);
        }

        //public List<Course> GetAllCourses()
        //{
        //    return aCourseAssignGateway.GetAllCourses();
        //}

        public CourseMustafa GetCourseDetails(int courseId)
        {
            return aCourseAssignGateway.GetCourseDetails(courseId);
        }

        public string Save(CourseAssign aCourseAssign)
        {
           bool check= aCourseAssignGateway.IsCourseAssigned(aCourseAssign.CourseId);
            if (check !=true)
            {
                aCourseAssign.RemainingCredit = aCourseAssign.RemainingCredit - aCourseAssign.CourseCredit;
                int rowAffected = aCourseAssignGateway.Save(aCourseAssign);
                if (rowAffected > 0)
                {
                    return "Successfully Saved";

                }
                else
                {
                    return "Saving failed";
                }
            }
            return "Course Already Assigned";

        }

        public List<CourseAssign> GetTeacherByDepartmentId(int departmentId)
        {
            return aCourseAssignGateway.GetTeacherByDepartmentId(departmentId);
        }

        public List<CourseMustafa> GetCourseByDepartmentId(int departmentId)
        {
            return aCourseAssignGateway.GetCourseByDepartmentId(departmentId);
        }
    }
}