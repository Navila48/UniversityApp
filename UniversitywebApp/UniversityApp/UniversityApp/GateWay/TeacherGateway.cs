using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApp.Models;

namespace UniversityApp.GateWay
{
    public class TeacherGateway:Gateway
    {
        public List<Designation> GetAllDesignation()
        {
            Query = "SELECT * FROM Designation";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Designation> designation = new List<Designation>();
            while (Reader.Read())
            {
                Designation aDesignation=new Designation();
                aDesignation.Id = (int)Reader["id"];
                aDesignation.Name = Reader["Designation"].ToString();
                designation.Add(aDesignation);
            }
            Reader.Close();
            Connection.Close();
            return designation;
        }

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
                aDepartment.Id = (int)Reader["id"];
                aDepartment.Name = Reader["Name"].ToString();
                departments.Add(aDepartment);
            }
            Reader.Close();
            Connection.Close();
            return departments;
        }

        public int Saveteacher(Teacher teacher)
        {

            Query = "INSERT INTO Teacher VALUES(@name,@address,@email,@contactNo,@desigationId,@departmentId,@creditToBeTaken)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = teacher.Name;
            Command.Parameters.Add("address", SqlDbType.VarChar);
            Command.Parameters["address"].Value = teacher.Address;
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = teacher.Email;
            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = teacher.ContactNo;
            Command.Parameters.Add("desigationId", SqlDbType.VarChar);
            Command.Parameters["desigationId"].Value = teacher.Designation;
            Command.Parameters.Add("departmentId", SqlDbType.VarChar);
            Command.Parameters["departmentId"].Value = teacher.Department;
            Command.Parameters.Add("creditToBeTaken", SqlDbType.VarChar);
            Command.Parameters["creditToBeTaken"].Value = teacher.CreditToBeTaken;
            Connection.Open();
            int rowEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffected;
        }

        public bool IsUnique(string email)
        {
            Query = "SELECT Email FROM Teacher WHERE Email=@email";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value =email;
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Reader.Close();
                Connection.Close();
                return true;
            }
            else
            {
                Reader.Close();
                Connection.Close();
                return false;
            }

        }
    }
}