using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApp.Models;

namespace UniversityApp.GateWay
{
    public class DepartmentHiraGateway : Gateway
    {
        public int SaveDepartment(DepartmentHira department)
        {
            Query = "INSERT INTO Department VALUES(@code,@name)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = department.Code;
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = department.Name;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }



        public bool IsCodeExist(string code)
        {
            Query = "SELECT Code FROM Department WHERE Code = LTRIM(RTRIM(@code))";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = code;
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Reader.Close();
                Connection.Close();
                return true;
            }
            Connection.Close();
            return false;
        }

        public bool IsDepartmentExist(string name)
        {
            Query = "SELECT Code FROM Department WHERE Name = LTRIM(RTRIM(@name))";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = name;
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Reader.Close();
                Connection.Close();
                return true;
            }
            Connection.Close();
            return false;
        }
    }
}