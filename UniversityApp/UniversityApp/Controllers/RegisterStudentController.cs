using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using UniversityApp.Manager;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    public class RegisterStudentController : Controller
    {
        StudentManager aStudentManager = new StudentManager();
        StudentVm students = new StudentVm();
        public ActionResult RegisterStudent()
        {
            ViewBag.departments = aStudentManager.GetAllDepartments();
            return View();
        }
        [HttpPost]
        public ActionResult RegisterStudent(Student student)
        {
            ViewBag.departments = aStudentManager.GetAllDepartments();

            students = aStudentManager.Save(student);

            if (students.Message!=null)
            {
                ViewBag.message = students.Message;
                return View();
            }
           
            else
            {
                
                TempData["student"] = students; 
                return RedirectToAction("Save");
            }
        }

        public ActionResult Save()
        {
            StudentVm aStudentVm = (StudentVm)TempData["student"];
            return View(aStudentVm);
        }
        public ActionResult PrintIndex(StudentVm aStudentVm)
        {
           // StudentVm aStudentVm = (StudentVm)TempData["student"];
            return new Rotativa.ViewAsPdf("Save", aStudentVm)
            {
                FileName = Server.MapPath("~/Content/Student.pdf")
            };

            
        }
	}
}