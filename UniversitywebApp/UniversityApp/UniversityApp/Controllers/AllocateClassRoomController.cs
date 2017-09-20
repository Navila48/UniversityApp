using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityApp.Manager;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    public class AllocateClassRoomController : Controller
    {
        private AllocateRoomManager anAllocateRoomManager = new AllocateRoomManager();

        //
        // GET: /ClassRoom/
        public ActionResult AllocateRoom()
        {
            ViewBag.Departments = anAllocateRoomManager.GetAllDepartments();
           // ViewBag.Courses = anAllocateRoomManager.GetAllCourses();
            ViewBag.Days = anAllocateRoomManager.GetAllDays();
            ViewBag.RoomNo = anAllocateRoomManager.GetAllRoomNo();
            return View();
        }

        [HttpPost]

        public ActionResult AllocateRoom(ClassRoom aClassRoom)
        {
            
            ViewBag.Departments = anAllocateRoomManager.GetAllDepartments();
            //  ViewBag.Courses = anAllocateRoomManager.GetAllCourses();
            ViewBag.Days = anAllocateRoomManager.GetAllDays();
            ViewBag.RoomNo = anAllocateRoomManager.GetAllRoomNo();

            ViewBag.Message = anAllocateRoomManager.AllocateRoom(aClassRoom);
            return View();
        }


        public JsonResult GetCourseByDepartmentId(int departmentId)
        {
            var courses = anAllocateRoomManager.GetAllCourses();
            var courseList = courses.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(courseList);

        }
    }
}