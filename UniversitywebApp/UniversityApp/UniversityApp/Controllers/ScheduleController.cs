using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityApp.Manager;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    public class ScheduleController : Controller
    {
        ScheduleManager aScheduleManager=new ScheduleManager();
       

        public List<Department> GetAllDepartments()
        {
            List<Department> departments = aScheduleManager.GetAllDepartments();
            return departments;
        }
        //
        // GET: /Schedule/
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult showScheduleAndRoomAllocation()
        {
            ViewBag.Departments = GetAllDepartments();
            return View();
           // ViewBag.schedule = aScheduleManager.ShowSchedule();
        }
        [HttpPost]
        public ActionResult showScheduleAndRoomAllocation(int departmentId)
        {
            ViewBag.Departments = GetAllDepartments();
            return View();
            // ViewBag.schedule = aScheduleManager.ShowSchedule();
        }

        public JsonResult GetCourseScheduleByDepartmentId(int departmentId)
        {
            var courseSchedules = aScheduleManager.GetAllCourseSchedules(departmentId);
            return Json(courseSchedules);
        }
	}
}