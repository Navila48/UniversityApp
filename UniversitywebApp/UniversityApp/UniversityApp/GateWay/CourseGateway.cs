using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApp.Models;

namespace UniversityApp.GateWay
{
    public class CourseGateway:Gateway
    {
       
                public List<Department> GetAllDepartments()
        {
            Query = "SELECT * FROM Department";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department>departments=new List<Department>();
            while (Reader.Read())
            {
                Department aDepartment=new Department();
                aDepartment.DepartmentId = (int) Reader["id"];
                aDepartment.Name = Reader["Name"].ToString();
                departments.Add(aDepartment);
            }
            Reader.Close();
            Connection.Close();
            return departments;
        }

        public List<Semester> GetAllSemester()
        {
            Query = "SELECT * FROM Semister";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Semester> semesters = new List<Semester>();
            while (Reader.Read())
            {
                Semester aSemester = new Semester();
                aSemester.Id = (int)Reader["id"];
                aSemester.Name = Reader["Semister"].ToString();
                semesters.Add(aSemester);
            }
            Reader.Close();
            Connection.Close();
            return semesters;
        }

        public int SaveCourse(Course course)
        {
            Query = "INSERT INTO Course VALUES(@name,@code,@credit,@description,@SemisterId,@DepartmentId)";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = course.Name;
            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = course.Code;
            Command.Parameters.Add("credit", SqlDbType.Decimal);
            Command.Parameters["credit"].Value = course.Credit;
            Command.Parameters.Add("description", SqlDbType.VarChar);
            Command.Parameters["description"].Value = course.Description;
            Command.Parameters.Add("SemisterId", SqlDbType.Int);
            Command.Parameters["SemisterId"].Value = course.Semester;
            Command.Parameters.Add("DepartmentId",SqlDbType.Int);
            Command.Parameters["DepartmentId"].Value = course.Department;
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsUnique(string code)
        {
            Query = "SELECT Code FROM Course WHERE Code=@code";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = code;
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Connection.Close();
                return true;
            }
            Connection.Close();
            return false;
        }
        public bool IsUniqueName(string name)
        {
            Query = "SELECT Name FROM Course WHERE Name=@name";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = name;
            
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
