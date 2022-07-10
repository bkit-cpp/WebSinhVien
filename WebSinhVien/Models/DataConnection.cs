using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace WebSinhVien.Models
{
    public class DataConnection
    {
        string strCon;
        public DataConnection()
        {
            strCon = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;

        }
        public SqlConnection getConnection()
        {
            return new SqlConnection(strCon);
        }
    }
}