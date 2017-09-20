using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ResultManagementApp.Models;

namespace ResultManagementApp.Gateway
{
    public class CourseAssignGateway:UniversityApp.GateWay.Gateway
    {
        public List<Departmentmustafa> GetAllDepartments()
        {
            Query = "SELECT * FROM Department";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Departmentmustafa>departments=new List<Departmentmustafa>();
            while (Reader.Read())
            {
                Departmentmustafa aDepartmentmustafa=new Departmentmustafa();
                aDepartmentmustafa.Id = (int)Reader["Id"];
                aDepartmentmustafa.Name = Reader["Name"].ToString();
                departments.Add(aDepartmentmustafa);
            }
            Reader.Close();
            Connection.Close();
            return departments;
        
        }

        //public List<TeacherForCourseAssign> GetAllTeachers()
        //{
        //    Query = "SELECT * FROM Teacher";
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    List<TeacherForCourseAssign> teachers = new List<TeacherForCourseAssign>();
        //    while (Reader.Read())
        //    {
        //      TeacherForCourseAssign aTeacherForCourseAssign = new TeacherForCourseAssign();
        //        aTeacherForCourseAssign.Id = (int)Reader["id"];
        //        aTeacherForCourseAssign.DepartmentId = (int)Reader["DepartmentId"];
        //        aTeacherForCourseAssign.Name = Reader["Name"].ToString();
        //        teachers.Add(aTeacherForCourseAssign);
        //    }
        //    Reader.Close();
        //    Connection.Close();
        //    return teachers;
        //}

        public CourseAssign GetTeacherDetails(int teacherId)
        {
            Query = "SELECT Teacher.CreditToBeTaken,ISNULL(AssignCourse.RemainingCredit,CreditToBeTaken) as RemainingCredit FROM Teacher FULL JOIN AssignCourse ON Teacher.id=AssignCourse.TeacherId WHERE Teacher.id=@TeacherId ORDER BY AssignCourse.RemainingCredit";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("TeacherId", SqlDbType.Int);
            Command.Parameters["TeacherId"].Value = teacherId;
            Reader = Command.ExecuteReader();

            CourseAssign aCourseAssign = new CourseAssign();
            if (Reader.Read())
            {
                aCourseAssign.Id = teacherId;
                aCourseAssign.CreditToBeTaken = (decimal)Reader["CreditToBeTaken"];
                aCourseAssign.RemainingCredit = (decimal)Reader["RemainingCredit"];
               
                    

                //teacher = new Teacher()
                //{
                //    CreditTake = Convert.ToDouble(Reader["CreditToBeTaken"].ToString()),
                //    CreditLeft = Convert.ToDouble(Reader["RemainingCredit"].ToString())
                //};
              
            }
            Reader.Close();
            Connection.Close();
            return aCourseAssign;
        }

        //public List<CourseMustafa> GetAllCourses()
        //{
        //    Query = "SELECT * FROM Course";
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    List<CourseMustafa> courses = new List<CourseMustafa>();
        //    while (Reader.Read())
        //    {
        //        CourseMustafa aCourse = new CourseMustafa();
        //        aCourse.Id = (int)Reader["id"];
        //        aCourse.Name = Reader["Code"].ToString();
        //        courses.Add(aCourse);
        //    }
        //    Reader.Close();
        //    Connection.Close();
        //    return courses;
        //}

        public CourseMustafa GetCourseDetails(int courseId)
        {
            //Query = "SELECT * FROM Course";
            //Command = new SqlCommand(Query, Connection);
            //Connection.Open();
            //Reader = Command.ExecuteReader();
            
            //CourseMustafa aCourse = new CourseMustafa();
            //if (Reader.Read())
            //{
            //    aCourse.CourseId =courseId;
            //    aCourse.CourseName = Reader["Name"].ToString();
            //    aCourse.Credit = (decimal)Reader["Credit"];

            //}
            //Reader.Close();
            //Connection.Close();
            //return aCourse;

            Query = "SELECT * FROM Course Where id = @courseId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("courseId", SqlDbType.Int);
            Command.Parameters["courseId"].Value = courseId;
            Reader = Command.ExecuteReader();
            CourseMustafa courseMustafa = null;

            while (Reader.Read())
            {
                courseMustafa = new CourseMustafa()
                {
                    Name = Reader["Name"].ToString(),
                    Credit = (decimal)Reader["Credit"]
                };
            }
            Reader.Close();
            Connection.Close();
            return courseMustafa;
        }

        public int Save(CourseAssign aCourseAssign)
        {
            Query = "Insert into AssignCourse Values('" + aCourseAssign.Id + "','" + aCourseAssign.CourseId + "','" + aCourseAssign.RemainingCredit + "','Assign') ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<CourseAssign> GetTeacherByDepartmentId(int departmentId)
        {
            Query = "SELECT * FROM Teacher Where DepartmentId = @departmentid";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("departmentId", SqlDbType.Int);
            Command.Parameters["departmentId"].Value = departmentId;
            Reader = Command.ExecuteReader();
            List<CourseAssign> teachers = new List<CourseAssign>();
            while (Reader.Read())
            {
                CourseAssign teacher = new CourseAssign()
                {
                    Id = (int) Reader["Id"],
                    Name = Reader["Name"].ToString()
                };

                teachers.Add(teacher);
            }
            Reader.Close();
            Connection.Close();
            return teachers;
        }

        public List<CourseMustafa> GetCourseByDepartmentId(int departmentId)
        {
            Query = "SELECT * FROM Course Where DepartmentId = @departmentId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("departmentId", SqlDbType.Int);
            Command.Parameters["departmentId"].Value = departmentId;
            Reader = Command.ExecuteReader();
            List<CourseMustafa> courses = new List<CourseMustafa>();
            while (Reader.Read())
            {
                CourseMustafa courseMustafa = new CourseMustafa()
                {
                    Id = (int)Reader["id"],
                    Code = Reader["Code"].ToString()
                };

                courses.Add(courseMustafa);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        public bool IsCourseAssigned(int courseId)
        {
            Query = "select * From AssignCourse Where CourseId= '" + courseId + "' AND Status='Assign'";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Connection.Close();
                return true;
            }
            Connection.Close();
            return false;
        }
    }
}