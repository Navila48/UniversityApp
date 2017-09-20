using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApp.Models;

namespace UniversityApp.GateWay
{
    public class CourseStatGateway: Gateway
    {
        public List<DepartmentHira> GetAllDepartments()
        {
            Query = "SELECT * From Department";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<DepartmentHira> departments=new List<DepartmentHira>();
            while (Reader.Read())
            {
                DepartmentHira aDepartment=new DepartmentHira();
                aDepartment.Id = (int)Reader["id"];
                aDepartment.Name = Reader["Name"].ToString();
                departments.Add(aDepartment);
  
            }
            Connection.Close();
            return departments;
            
        }


        public List<CourseStatisticVM> GetCourseStat(int departmentId)
        {
            Query = "Select * from CourseStat where DepartmentId=@deptId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("deptId", SqlDbType.Int);
            Command.Parameters["deptId"].Value = departmentId;
            Reader = Command.ExecuteReader();
            
            List<CourseStatisticVM> departments = new List<CourseStatisticVM>();

            while (Reader.Read())
            {
                CourseStatisticVM aDepartment = new CourseStatisticVM();
                aDepartment.Code = Reader["Code"].ToString();
                aDepartment.Name = Reader["CourseName"].ToString();
                aDepartment.Semester = Reader["Semister"].ToString();
                aDepartment.AssignTo = Reader["AssignTo"].ToString();
                aDepartment.Status = Reader["Status"].ToString();
                departments.Add(aDepartment);

            }
            Connection.Close();
            return departments;

        }
    }
}