using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityApp.GateWay;
using UniversityApp.Models;

namespace UniversityApp.Manager
{
    public class CourseManager
    {
        CourseGateway aCourseGateway=new CourseGateway();
        public List<Department> GetAllDepartments()
        {
            return aCourseGateway.GetAllDepartments();
        }

        public List<Semester> GetAllSemesters()
        {
            return aCourseGateway.GetAllSemester();
        }

        public string SaveCourse(Course course)
        {
            bool uniq = aCourseGateway.IsUnique(course.Code);
           bool test =aCourseGateway.IsUniqueName(course.Name);
            if (!uniq)
            {
                if (!test)
                {
                    int rowAffected = aCourseGateway.SaveCourse(course);
                    if (rowAffected > 0)
                    {
                        return "successfully saved";
                    }
                    return "save faild";
                }
                return "Name Already exist";
            }
            
            return "Course Code Already exist";
        }
       
    }
}