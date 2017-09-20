using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityApp.GateWay;
using UniversityApp.Models;

namespace UniversityApp.Manager
{
    public class TeacherManager
    {
        TeacherGateway aTeacherGateway=new TeacherGateway();
        public List<Designation> GetAllDesignation()
        {
            return aTeacherGateway.GetAllDesignation();
        }

        public List<Department> GetAllDepartments()
        {
            return aTeacherGateway.GetAllDepartments();
        }

        public string SaveTecher(Teacher teacher)
        {
            bool isEmailUnique = aTeacherGateway.IsUnique(teacher.Email);
            if (!isEmailUnique)
            {
                int rowAffected = aTeacherGateway.Saveteacher(teacher);
                if (rowAffected > 0)
                {
                    return "Saved Successfully";
                }
                else
                {
                    return "Save failed";
                }
            }
            else
            {
                return "Email Must Be Unique";
            }
        }
    }
}