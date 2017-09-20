using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityApp.GateWay;

namespace UniversityApp.Manager
{
    
    public class UnassignCourseManager
    {
        UnassignCourseGateway anUnassignCourseGateway=new UnassignCourseGateway();

         public string UnassignAllCourses()
        {
              int rowAffected= anUnassignCourseGateway.UnassignStudentCourse();
             int rowAffected2=anUnassignCourseGateway.UnassignTeacherCourse();

             if (rowAffected > 0 && rowAffected2 > 0)
             {
                 return "Successfully Unassign All Courses";
             }

             return "Failed Unassign All Courses";

        }

             

       
    }
}

