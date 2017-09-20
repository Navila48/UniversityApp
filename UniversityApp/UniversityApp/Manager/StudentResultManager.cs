using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityApp.GateWay;
using UniversityApp.Models;

namespace UniversityApp.Manager
{
    public class StudentResultManager
    {
        StudentResultGateWay aStudentResultGateWay = new StudentResultGateWay();
        public List<string> GetAllRegNo()
        {
            return aStudentResultGateWay.GetAllStudentRegNo();
        }

        public StudentTest GetStudentInfo(string regNo)
        {
            StudentTest aStudentTest =  aStudentResultGateWay.GetStudentInfo(regNo);
            aStudentTest.DeptName = aStudentResultGateWay.GetDepartmentName(aStudentTest.DepartmentId);
            return aStudentTest;
        }

        public List<CourseDetails> GetStudentCouses()
        {
          //  List<CourseDetails> allCourses = new List<CourseDetails>();
            List<CourseDetails> courseList= aStudentResultGateWay.GetStudentCourses();
            return courseList;
            //foreach (int c in courseList)
            //{
            //    CourseDetails aCourse = aStudentResultGateWay.GetCourseDetails(c);
            //    allCourses.Add(aCourse);
            //}
            //return allCourses;
        }

        public List<CourseDetails> GetStudentCourseDetils(List<CourseDetails> cL)
        {
            List<CourseDetails> cdList = new List<CourseDetails>();
            foreach (var c in cL)
            {
               CourseDetails cD= aStudentResultGateWay.GetStudentCourseDetils(c.CourseId);
                cdList.Add(cD);
            }
            return cdList;
        }

        public object SaveResult(StudentResult studentResult)
        {
            bool check = aStudentResultGateWay.IsResultExist(studentResult.CourseId);
            if (check !=true)
            {
                int rowAffected = aStudentResultGateWay.Save(studentResult);
                if (rowAffected > 0)
                {
                    return "Grade Successfully Saved";
                }
                return "Save failed";
            }
            else
            {
                int rowAffected = aStudentResultGateWay.Update(studentResult);
                if (rowAffected > 0)
                {
                    return "Grade Successfully Updated";
                }
                return "Update failed";
            }
           
        }
    }
}