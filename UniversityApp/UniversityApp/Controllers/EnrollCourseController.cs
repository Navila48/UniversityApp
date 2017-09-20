using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResultManagementApp.Manager;
using ResultManagementApp.Models;

namespace ResultManagementApp.Controllers
{
    public class EnrollCourseController : Controller
    {
        //
        // GET: /EnrollCourse/
        //public ActionResult Index()
        //{
        //    return View();
        //}
        EnrollCourseManager anEnrollCourseManager=new EnrollCourseManager();
        public ActionResult EnrollStudentCourse()
        {
            ViewBag.Students = anEnrollCourseManager.GetAllStudentsRegistrationNo();
            return View();
        }
        [HttpPost]
        public ActionResult EnrollStudentCourse(StudentMustafa student)
        {
            ViewBag.Students = anEnrollCourseManager.GetAllStudentsRegistrationNo();
            StudentMustafa aStudent = (StudentMustafa) TempData["std"];
            aStudent.CourseId = student.CourseId;
            aStudent.Date = student.Date;
            ViewBag.Message = anEnrollCourseManager.Enroll(aStudent);
            return View();
        }

        public JsonResult GetStudentDetails(StudentMustafa student)
        {
            var studentDetails = anEnrollCourseManager.GetStudentDetailsWithRegistrationNo(student);
            TempData["std"] = studentDetails;
            var courses = anEnrollCourseManager.GetAllCoursesByDeptId(studentDetails.DepartmentId);
            studentDetails.Courses = courses;
            return Json(studentDetails);
        }
	}
}