using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityApp.Manager;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    public class DepartmentHiraController : Controller
    {
        DepartmentHiraManager _aDepartmentHiraManager=new DepartmentHiraManager();

        
        
        public ActionResult SaveDepartment()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SaveDepartment(DepartmentHira department)
        {
            if (ModelState != null)
            {
                ViewBag.department = _aDepartmentHiraManager.SaveDepartment(department);
                return View();
            }
            //ViewBag.department = aDepartmentManager.SaveDepartment(department);
            return View();
        }
	}
}