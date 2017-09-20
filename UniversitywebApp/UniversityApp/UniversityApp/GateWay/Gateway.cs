using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityApp.GateWay
{
    public class Gateway
    {
        public string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityConnectionDB"].ConnectionString;

        public string Query { get; set; }
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }

        public Gateway()
        {
            Connection=new SqlConnection(connectionString);
        }
    }
}