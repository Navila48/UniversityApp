using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityApp.GateWay;
using UniversityApp.Models;

namespace UniversityApp.Manager
{
    public class DepartmentHiraManager
    {
        private DepartmentHiraGateway _aDepartmentHiraGateway = new DepartmentHiraGateway();

        public string SaveDepartment(DepartmentHira department)
        {
           // int rowAffected = aDepartmentGateway.SaveDepartment(department);

            if (_aDepartmentHiraGateway.IsCodeExist(department.Code) == false)
            {
                if(_aDepartmentHiraGateway.IsDepartmentExist(department.Name)==false)
                {
                    int rowAffected = _aDepartmentHiraGateway.SaveDepartment(department);
                    if (rowAffected > 0)
                    {
                        return "Saved Succesfully";
                    }
                    {
                        return "Saved Failed";
                    }
                }
                return "Department Name already exist";

            }
            return "Code Already Exist";
        }
    }
}