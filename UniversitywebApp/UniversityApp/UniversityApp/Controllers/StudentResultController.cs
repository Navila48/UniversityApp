using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityApp.Manager;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    public class StudentResultController : Controller
    {
        StudentResultManager aStudentManager = new StudentResultManager();
        public ActionResult Index()
        {
            ViewBag.Registration = aStudentManager.GetAllRegNo();
            return View();
        }

        [HttpPost]
        public ActionResult Index(StudentResult studentResult)
        {
            studentResult.DepartmentId = Convert.ToInt32(TempData["dpt"]);
            ViewBag.Save= aStudentManager.SaveResult(studentResult);
            ViewBag.Registration = aStudentManager.GetAllRegNo();

            return View();
        }

        public JsonResult GetStudentDetils(string registrationNo)
        {
            StudentTest student =   aStudentManager.GetStudentInfo(registrationNo);
            TempData["dpt"] = student.DepartmentId;
            return Json(student);
        }
        public JsonResult GetStudentCourse(string registrationNo)
        {
          
             List<CourseDetails> courses= aStudentManager.GetStudentCouses();

            var cL = courses.Where(m => m.RegNo == registrationNo).ToList();
           
            var courseNameList = aStudentManager.GetStudentCourseDetils(cL);
            return Json(courseNameList);

        }

      

      
	}
}