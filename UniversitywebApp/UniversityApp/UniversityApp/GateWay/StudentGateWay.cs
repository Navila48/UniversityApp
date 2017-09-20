using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApp.Models;

namespace UniversityApp.GateWay
{
    public class StudentGateWay:Gateway
    {
        public List<Department> GetAllDepartments()
        {
            Query = "SELECT * FROM Department";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> departments = new List<Department>();
            while (Reader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.DepartmentId = (int)Reader["id"];
                aDepartment.Name = Reader["Name"].ToString();
                departments.Add(aDepartment);
            }
            Reader.Close();
            Connection.Close();
            return departments;
        }

        public string GetStudentDepartmentCode(int id)
        {
            Query = "SELECT * FROM Department where id=@id";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("id",SqlDbType.Int);
            Command.Parameters["id"].Value = id;
            Reader = Command.ExecuteReader();
            string code=null;
          //  List<Department> departments = new List<Department>();
            if (Reader.Read())
            {
                 code = Reader["Code"].ToString();
            }
            Reader.Close();
            Connection.Close();
             return code;
        }

        public int GetCount(int id, string registerDate)
        {
            Query = "select count(RegistrationNo) as counting from Student where DepartmentId =@id AND RegistrationNo Like '%"+registerDate+"%'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;
            Reader = Command.ExecuteReader();
            int count=0;
            if (Reader.Read())
            {
                count =(int) Reader["counting"];
            }
            Connection.Close();
            return count;
        }

        public bool IsEmailUnique(string email)
        {
             Query = "select Email from Student where Email =@email";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = email;
            Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {
                Connection.Close();
                return true;
            }
            Connection.Close();
            return false;
        }

        public int SaveStudent(Student student)
        {
            Query = "INSERT INTO Student VALUES(@name,@email,@contactno,@date,@address,@regno,@deptno)";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = student.Name;
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = student.Email;
            Command.Parameters.Add("contactno", SqlDbType.VarChar);
            Command.Parameters["contactno"].Value = student.ContactNo;
            Command.Parameters.Add("date", SqlDbType.DateTime);
            Command.Parameters["date"].Value = student.Date;
            Command.Parameters.Add("address", SqlDbType.VarChar);
            Command.Parameters["address"].Value = student.Address;
            Command.Parameters.Add("regno", SqlDbType.VarChar);
            Command.Parameters["regno"].Value = student.RegistrationNo;
            Command.Parameters.Add("deptno", SqlDbType.Int);
            Command.Parameters["deptno"].Value = student.DepartmentId;
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public string GetDepartmentName(int departmentId)
        {
            Query = "SELECT * FROM Department where id=@id";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = departmentId;
            Reader = Command.ExecuteReader();
            string Name = null;
           
            if (Reader.Read())
            {
                Name = Reader["Name"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return Name;
        }
    }
}