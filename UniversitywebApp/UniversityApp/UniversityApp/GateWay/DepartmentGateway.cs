using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApp.Models;

namespace UniversityApp.GateWay
{
    public class DepartmentGateway:Gateway
    {
        public int SaveDepartment(Department department)
        {
            Query = "INSERT INTO Department VALUES(@code,@name)";
           Command=new SqlCommand(Query,Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = department.Code;
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = department.Name;
            Connection.Open();
            int rowEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffected;
        }

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
                aDepartment.Code = Reader["Code"].ToString();
                aDepartment.Name = Reader["Name"].ToString();
                departments.Add(aDepartment);
            }
            Reader.Close();
            Connection.Close();
            return departments;
        }
    }
}