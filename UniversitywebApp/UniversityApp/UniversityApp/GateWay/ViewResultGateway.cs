using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using ResultManagementApp.Models;

namespace ResultManagementApp.Gateway
{
    public class ViewResultGateway:UniversityApp.GateWay.Gateway
    {
        public List<StudentMustafa> GetAllStudentsRegistrationNo()
        {
            Query = "SELECT * FROM Student";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<StudentMustafa> students = new List<StudentMustafa>();

            while (Reader.Read())
            {

                StudentMustafa student = new StudentMustafa()
                {
                    Id = (int)Reader["id"],
                    RegNo = Reader["RegistrationNo"].ToString()
                };
                students.Add(student);
            }
            Reader.Close();
            Connection.Close();
            return students;
        }

        public StudentMustafa GetStudentDetailsWithRegistrationNo(StudentMustafa student)
        {
            Query = "SELECT * FROM StudentResult WHERE RegistrationNo=@regNo";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("regNo", SqlDbType.VarChar);
            Command.Parameters["regNo"].Value = student.RegNo;
            Reader = Command.ExecuteReader();
            StudentMustafa studentInfo = new StudentMustafa();
            while (Reader.Read())
            {

                studentInfo.Name = Reader["Name"].ToString();
                studentInfo.Email = Reader["Email"].ToString();
               // studentInfo.Code = Reader["DeptName"].ToString();
                studentInfo.Code = Reader["Code"].ToString();
              //  studentInfo.CourseName = Reader["CourseName"].ToString();
                studentInfo.Grade = Reader["Grade"].ToString();
                //studentInfo.RegNo = Reader["StudentRegNo"].ToString();
                //studentInfo.DepartmentId = Convert.ToInt32(Reader["DepartmentId"].ToString());
            }
            Reader.Close();
            Connection.Close();
            return studentInfo;
        }

        public List<ViewCourse> GetStudentAllCourseDetailsWithRegistrationNo(StudentMustafa student)
        {
            Query = "SELECT * FROM StudentCourseResult WHERE StudentRegNo=@regNo "; 

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("regNo", SqlDbType.VarChar);
            Command.Parameters["regNo"].Value = student.RegNo;
            Reader = Command.ExecuteReader();
             List<ViewCourse> studentCoursesInfo = new List<ViewCourse>();
            while (Reader.Read())
            {
                ViewCourse studentCourseInfo = new ViewCourse();
                   

                studentCourseInfo.Code = Reader["Code"].ToString();
                studentCourseInfo.CourseName = Reader["Name"].ToString();
                studentCourseInfo.Grade = Reader["Grade"].ToString();

                studentCoursesInfo.Add(studentCourseInfo);
            }
            Reader.Close();
            Connection.Close();
            return studentCoursesInfo;
        }

    }
}