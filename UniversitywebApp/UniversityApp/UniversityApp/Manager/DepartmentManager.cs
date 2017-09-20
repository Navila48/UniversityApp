using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityApp.GateWay;
using UniversityApp.Models;

namespace UniversityApp.Manager
{
    public class DepartmentManager
    {
        DepartmentGateway aDepartmentGateway=new DepartmentGateway();
        public string SaveDepartment(Department department)
        {
            int rowEffected = aDepartmentGateway.SaveDepartment(department);
            if (rowEffected > 0)
            {
                return "Saved Succesfully";
            }
            {
                return "Saved Failed";
            }
        }

        public List<Department> GetAllDepartments()
        {
            return aDepartmentGateway.GetAllDepartments();
        }
    }
}