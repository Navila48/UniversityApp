using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityApp.Manager;

namespace UniversityApp.Controllers
{
    public class CourseStaticticsController : Controller
    {
        CourseStatManager aCourseStatManager = new CourseStatManager();
        public ActionResult CourseStat()
        {
            ViewBag.Departments = aCourseStatManager.GetAllDepartments();
            return View();
        }
        [HttpPost]
        public ActionResult CourseStat(int departmentId)
        {
            ViewBag.Departments = aCourseStatManager.GetAllDepartments();
            return View();
        }

        public JsonResult GetCourseStatByDepartmentId(int departmentId)
        {
            var students = aCourseStatManager.GetCourseStat(departmentId);
            //var studentList = students.Where(a => a == departmentId).ToList();
            return Json(students);
        }


        public ActionResult UrlAsPDF()
        {
           // var model = new GeneratePDFModel();
            //Code to get content
            return new Rotativa.ActionAsPdf("CourseStat") { FileName = "TestActionAsPdf.pdf" };

          

        }

        public ActionResult Sample()
        {
            return View();
        }
    }
}