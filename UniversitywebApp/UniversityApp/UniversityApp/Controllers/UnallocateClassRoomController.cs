using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityApp.Manager;

namespace UniversityApp.Controllers
{
    public class UnallocateClassRoomController : Controller
    {
        ScheduleManager aScheduleManager=new ScheduleManager();
        //
        // GET: /UnallocateClassRoom/
        //public ActionResult Index()
        //{
        //    return View();
        //}
       [HttpGet]
        public ActionResult UnallocateAllClassRoom()
        {
            ViewBag.Unallocate = aScheduleManager.UnallocateRooms();
            return View();
        } [HttpPost]
        public ActionResult UnallocateAllClassRoom(string msg)
        {
            ViewBag.Unallocate = aScheduleManager.UnallocateRooms();
            return View();
        }
	}
}