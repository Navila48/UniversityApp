using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityApp.Manager;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    public class UnassignCoursesController : Controller
    {
        UnassignCourseManager anUnassignCourseManager=new UnassignCourseManager();
        //
        // GET: /UnassignCourses/
        public ActionResult UnassignCourse()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UnassignCourse(bool? isTrue)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (Convert.ToBoolean(isTrue))
            {
                ViewBag.Status = true;
            }
            else
            {
                //Your logic for cancel button
            }
            ViewBag.msg = anUnassignCourseManager.UnassignAllCourses();
            return View();
        }


       
	}
}