using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityApp.GateWay;
using UniversityApp.Models;

namespace UniversityApp.Manager
{

    public class StudentManager
    {
        StudentGateWay aGateWay = new StudentGateWay();
        public List<Department> GetAllDepartments()
        {
            return aGateWay.GetAllDepartments();
        }

        public StudentVm Save(Student student)
        {
            StudentVm aStudentVm = new StudentVm();
            if (!aGateWay.IsEmailUnique(student.Email))
            {
                string code = aGateWay.GetStudentDepartmentCode(student.DepartmentId);
               // string date = DateTime.Today.ToString("yyyy");
                DateTime date = student.Date;
                string registerDate = date.Year.ToString();
               // string date = DateTime.
                int roll = aGateWay.GetCount(student.DepartmentId, registerDate) + 1;
                string serial = roll.ToString("000");
                string regNo = code + "-" + registerDate + "-" + serial;
                student.RegistrationNo= regNo;
              
                int rowAffected=aGateWay.SaveStudent(student);
                if (rowAffected > 0)
                {
                    aStudentVm.Name = student.Name;
                    aStudentVm.Email = student.Email;
                    aStudentVm.Date = student.Date;
                    aStudentVm.ContactNo = student.ContactNo;
                    aStudentVm.Department = aGateWay.GetDepartmentName(student.DepartmentId);
                    aStudentVm.Address = student.Address;
                    aStudentVm.RegistrationNo = regNo;
                    aStudentVm.Message = null;
                    return aStudentVm;
                }
                else
                {
                    aStudentVm.Message = "save Failed";
                    return aStudentVm;
                }
            }
            else
            {
                aStudentVm.Message = "email already exist";
                return aStudentVm;
            }
            
        }
    }
}