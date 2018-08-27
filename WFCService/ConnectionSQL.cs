using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WFCService
{
    public class ConnectionSQL
    {
        private static SqlConnection conn;

        public static SqlConnection connectDB()
        {
            string connectionString = "Data Source=den1.mssql2.gear.host; Initial Catalog=kokotalkdb;"
                + "User ID=kokotalkdb;Password=Ja9Q_-M786YH;";

            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot connect to the Database! " + e.Message);
            }
            return conn;
        }
    }
}