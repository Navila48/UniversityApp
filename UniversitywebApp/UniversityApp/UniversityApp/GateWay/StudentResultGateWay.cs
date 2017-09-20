using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApp.Models;

namespace UniversityApp.GateWay
{
    public class StudentResultGateWay: Gateway
    {
        public List<string> GetAllStudentRegNo()
        {
            Query = "Select RegistrationNo From Student ORDER BY RegistrationNo";
            Command= new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<string> registrationNo= new List<string>();
            while (Reader.Read())
            {
                string regNo = Reader["RegistrationNo"].ToString();
                registrationNo.Add(regNo);
            }
            Connection.Close();
            return registrationNo;
        }

        public StudentTest GetStudentInfo(string regisNo)
        {
            Query = "Select * From Student where RegistrationNo=@regno";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("regno", SqlDbType.VarChar);
            Command.Parameters["regno"].Value = regisNo;
            Reader = Command.ExecuteReader();
            StudentTest aStudent = new StudentTest();
         //   List<Student> students = new List<Student>();
            if (Reader.Read())
            {
                aStudent.Name = Reader["Name"].ToString();
                aStudent.Email = Reader["Email"].ToString();
                aStudent.DepartmentId = (int)Reader["DepartmentId"];
               
            }
            Connection.Close();
            return aStudent;
        }

        public List<CourseDetails> GetStudentCourses()
        {
            Query = "SELECT * FROM StudentCourse  ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            //Command.Parameters.Add("regno", SqlDbType.VarChar);
            //Command.Parameters["regno"].Value = registrationNo;
            Reader = Command.ExecuteReader();
            List<CourseDetails> courseList = new List<CourseDetails>();
           
            while (Reader.Read())
            {
                CourseDetails aCourseDetails = new CourseDetails();
              aCourseDetails.CourseId   = (int)Reader["CourseId"];
                aCourseDetails.RegNo = Reader["StudentRegNo"].ToString();
                aCourseDetails.DepartmentId = (int)Reader["DepartmentId"];
                courseList.Add(aCourseDetails);
            }
            Connection.Close();
            return courseList;
        }


        public string GetDepartmentName(int departmentId)
        {
            Query = "SELECT Name From Department Where Id=@dpid";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("dpid", SqlDbType.Int);
            Command.Parameters["dpid"].Value = departmentId;
            Reader = Command.ExecuteReader();
            string s=null;
            if (Reader.Read())
            {
                s = Reader["Name"].ToString();

            }
            Connection.Close();
            return s ;
        }

        public CourseDetails GetStudentCourseDetils(int courseId)
        {
            Query = "Select * From Course Where Id=@id";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = courseId;
            //string s = null;
            CourseDetails cdDetails = new CourseDetails();
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                cdDetails.CourseId = courseId;
                cdDetails.CourseName = Reader["Name"].ToString();

            }
            Connection.Close();
            return cdDetails;
        }

        public int Save(StudentResult studentResult)
        {
            Query = "Insert into Result Values(@regno , @deptid , @courseid , @grade)";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("regno",SqlDbType.VarChar);
            Command.Parameters["regno"].Value = studentResult.StudentRegNo;
                 Command.Parameters.Add("deptid",SqlDbType.Int);
            Command.Parameters["deptid"].Value = studentResult.DepartmentId;
            Command.Parameters.Add("courseid", SqlDbType.Int);
            Command.Parameters["courseid"].Value = studentResult.CourseId;
            Command.Parameters.Add("grade", SqlDbType.VarChar);
            Command.Parameters["grade"].Value = studentResult.Grade;
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsResultExist(int courseId)
        {
            Query = "Select * From Result where CourseId=@id";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = courseId;
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Connection.Close();
                return true;
            }
            Connection.Close();
            return false;
        }

        public int Update(StudentResult studentResult)
        {
            Query = "Update Result set StudentRegNo=@regno , DepartmentId=@deptid , CourseId=@courseid , Grade=@grade where Courseid=@cid";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("regno", SqlDbType.VarChar);
            Command.Parameters["regno"].Value = studentResult.StudentRegNo;
            Command.Parameters.Add("deptid", SqlDbType.Int);
            Command.Parameters["deptid"].Value = studentResult.DepartmentId;
            Command.Parameters.Add("courseid", SqlDbType.Int);
            Command.Parameters["courseid"].Value = studentResult.CourseId;
            Command.Parameters.Add("grade", SqlDbType.VarChar);
            Command.Parameters["grade"].Value = studentResult.Grade;
            Command.Parameters.Add("cid", SqlDbType.Int);
            Command.Parameters["cid"].Value = studentResult.CourseId;
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}