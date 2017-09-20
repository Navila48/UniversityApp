using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UniversityApp.GateWay
{
    public class UnassignCourseGateway:Gateway
    {
        public int UnassignStudentCourse()
        {
            Query = "Update StudentCourse Set Status='Unassign'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public int UnassignTeacherCourse()
        {
            Query = "Update AssignCourse Set Status='Unassign'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }


    }
}