using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ResultManagementApp.Models;

namespace ResultManagementApp.Gateway
{
    public class EnrollCourseGateway:UniversityApp.GateWay.Gateway
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
            Query = "SELECT s.Name, s.Email, s.DepartmentId,s.RegistrationNo,d.Code from Student s INNER JOIN Department d on d.id = s.DepartmentId where s.id = @id";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = student.Id;
            Reader = Command.ExecuteReader();
            StudentMustafa studentInfo = new StudentMustafa();
            while (Reader.Read())
            {

                studentInfo.Name = Reader["Name"].ToString();
                studentInfo.Email = Reader["Email"].ToString();
                studentInfo.Code = Reader["Code"].ToString();
                studentInfo.RegNo = Reader["RegistrationNo"].ToString();
                studentInfo.DepartmentId = Convert.ToInt32(Reader["DepartmentId"].ToString());
            }
            Reader.Close();
            Connection.Close();
            return studentInfo;
        }

        public List<CourseMustafa> GetAllCoursesByDeptId(int departmentId)
        {
            Query = "SELECT * FROM Course Where DepartmentId = @id";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = departmentId;
            Reader = Command.ExecuteReader();
            List<CourseMustafa> courses = new List<CourseMustafa>();
            while (Reader.Read())
            {
                CourseMustafa courseMustafa = new CourseMustafa()
                {
                    Id = (int)Reader["id"],
                    Name = Reader["Name"].ToString()
                };

                courses.Add(courseMustafa);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        public int Enroll(StudentMustafa student)
        {
            Query = "INSERT INTO StudentCourse VALUES(@courseId, @studentRegNo, @date, @departmentId)";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();

            Command.Parameters.Add("courseId", SqlDbType.Int);
            Command.Parameters["courseId"].Value = student.CourseId;
            Command.Parameters.Add("studentRegNo", SqlDbType.VarChar);
            Command.Parameters["studentRegNo"].Value = student.RegNo;

            Command.Parameters.Add("date", SqlDbType.Date);
            Command.Parameters["date"].Value = student.Date;

            Command.Parameters.Add("departmentId", SqlDbType.VarChar);
            Command.Parameters["departmentId"].Value = student.DepartmentId;
            int isRowEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return isRowEffected;
        }

        public bool IsCourseExists(StudentMustafa student)
        {
            Query = "SELECT * FROM StudentCourse Where StudentRegNo = @str AND CourseId = @courseId ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("str", SqlDbType.VarChar);
            Command.Parameters["str"].Value = student.RegNo;
            Command.Parameters.Add("courseId", SqlDbType.Int);
            Command.Parameters["courseId"].Value = student.CourseId;
            Reader= Command.ExecuteReader();


            bool isExist = false;
            if (Reader.HasRows)
            {
                isExist = true;
            }
            Reader.Close();
            Connection.Close();
            return isExist;
        }
    }
}