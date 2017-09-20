using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityApp.Manager;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //public ActionResult SaveDepartment()
        //{

        //    return View();
        //}
        //[HttpPost]
        //public ActionResult SaveDepartment(Department department)
        //{
        //    ViewBag.department = aDepartmentManager.SaveDepartment(department);
        //    return View();
        //}
        public ActionResult ShowDepartment()
        {
            ViewBag.departments = aDepartmentManager.GetAllDepartments();
            return View();
        }
	}
}