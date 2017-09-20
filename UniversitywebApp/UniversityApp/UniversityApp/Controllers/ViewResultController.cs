using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResultManagementApp.Manager;
using ResultManagementApp.Models;

namespace ResultManagementApp.Controllers
{
    public class ViewResultController : Controller
    {
        //
        // GET: /ViewResult/
        public ActionResult Index()
        {
            return View();
        }
        ViewResultManager aViewResultManager=new ViewResultManager();
        public ActionResult ViewResult()
        {
            ViewBag.Students = aViewResultManager.GetAllStudentsRegistrationNo();
            return View();
        }
        [HttpPost]
        public ActionResult ViewResult(StudentMustafa student)
        {
            ViewBag.Students = aViewResultManager.GetAllStudentsRegistrationNo();

            return View();
        }

        public JsonResult GetStudentDetails(StudentMustafa student)
        {
            var studentDetails = aViewResultManager.GetStudentDetailsWithRegistrationNo(student);
           
            
            return Json(studentDetails);
        }

        public JsonResult GetStudentAllCoursesDetailsWithRegNo(StudentMustafa student)
        {
            var studentCourseDetails = aViewResultManager.GetStudentAllCourseDetailsWithRegistrationNo(student);


            return Json(studentCourseDetails);
        }
    }
}