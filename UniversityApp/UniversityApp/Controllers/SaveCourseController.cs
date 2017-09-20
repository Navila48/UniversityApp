using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityApp.Manager;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    
    public class SaveCourseController : Controller
    {
        CourseManager aCourseManager=new CourseManager();
        //
        // GET: /SaveCourse/
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult SaveCourse()
        {
            ViewBag.departments = aCourseManager.GetAllDepartments();
            ViewBag.semesters = aCourseManager.GetAllSemesters();
            return View();
        }
        [HttpPost]
        public ActionResult SaveCourse(Course course)
        {
            ViewBag.departments = aCourseManager.GetAllDepartments();
            ViewBag.semesters = aCourseManager.GetAllSemesters();
            ViewBag.Message = aCourseManager.SaveCourse(course);
            return View();   
        }
	}
}