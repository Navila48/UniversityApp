using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityApp.Manager;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    public class TeacherController : Controller
    {
        TeacherManager aTeacherManager=new TeacherManager();
        //
        // GET: /Teacher/
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult SaveTeacher()
        {
            ViewBag.designation = aTeacherManager.GetAllDesignation();
            ViewBag.departments = aTeacherManager.GetAllDepartments();
            return View();
        }
        [HttpPost]
        public ActionResult SaveTeacher(Teacher teacher)
        {
            ViewBag.teacher = aTeacherManager.SaveTecher(teacher);
            ViewBag.designation = aTeacherManager.GetAllDesignation();
            ViewBag.departments = aTeacherManager.GetAllDepartments();
            return View();
        }
	}
}