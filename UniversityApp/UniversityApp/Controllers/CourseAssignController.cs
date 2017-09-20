using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResultManagementApp.Manager;
using ResultManagementApp.Models;

namespace ResultManagementApp.Controllers
{
    public class CourseAssignController : Controller
    {
        //
        // GET: /CourseAssign/
        CourseAssignManager aCourseAssignManager=new CourseAssignManager();
        public ActionResult CourseAssignToTeacher()
        {
            ViewBag.Departments = aCourseAssignManager.GetAllDepartments();
            //ViewBag.Courses = aCourseAssignManager.GetAllCourses();
            return View();
        }

        [HttpPost]
        public ActionResult CourseAssignToTeacher(CourseAssign aCourseAssign)
        {
           
            ViewBag.Message=aCourseAssignManager.Save(aCourseAssign);
            ViewBag.Departments = aCourseAssignManager.GetAllDepartments();
            return View();
        }
        public JsonResult GetTeachersByDepartmentId(int departmentId)
        {
            //var teachers = aCourseAssignManager.GetAllTeachers();
            //var teacherList = teachers.Where(a => a.DepartmentId == departmentId).ToList();
            //return Json(teacherList);

            var teacherDetails = aCourseAssignManager.GetTeacherByDepartmentId(departmentId);
            var courseDetails = aCourseAssignManager.GetCourseByDepartmentId(departmentId);
            Departmentmustafa departmentmustafa = new Departmentmustafa();
            departmentmustafa.Courses = courseDetails;
            departmentmustafa.Teachers = teacherDetails;
            return Json(departmentmustafa);
        }

        public JsonResult GetTeacherDetails(int teacherId)
        {
           CourseAssign teacher = aCourseAssignManager.GetTeacherDetails(teacherId);
          

            return Json(teacher);
        }

        public JsonResult GetCourseDetails(int courseId)
        {
            CourseMustafa courseMustafa = aCourseAssignManager.GetCourseDetails(courseId);


            return Json(courseMustafa);
        }
	}
}