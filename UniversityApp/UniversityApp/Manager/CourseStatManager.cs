using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityApp.GateWay;
using UniversityApp.Models;

namespace UniversityApp.Manager
{
    public class CourseStatManager
    {
        CourseStatGateway aCourseStatGateway=new CourseStatGateway();

        public List<DepartmentHira> GetAllDepartments()
        {
            return aCourseStatGateway.GetAllDepartments();
        }

        public List<CourseStatisticVM> GetCourseStat(int departmentId)
        {
            return aCourseStatGateway.GetCourseStat(departmentId);
        }

    }
}