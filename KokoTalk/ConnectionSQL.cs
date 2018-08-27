
///Author Richard
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KokoTalk
{
    public class ConnectionSQL
    {
        private static SqlConnection conn;
        /// <summary>
        /// This method purpose is to create a Sqlconnection to our database, we return the sqlConnection so we can pass it as an
        /// argument for commands 
        /// </summary>
        /// <returns></returns>
        public static SqlConnection ConnectDB()
        {
            //connection string to hold the database
            string connectionString = "Data Source=den1.mssql2.gear.host; Initial Catalog=kokotalkdb;"
                + "User ID=kokotalkdb;Password=Ja9Q_-M786YH;";
            //initializing the sqlConnection object
            conn = new SqlConnection(connectionString);
            try
            {
                //opening the connection
                conn.Open();
            }
            catch (Exception e)
            {
                //if any error occurs the user is let known they cannot connect to the database
                Console.WriteLine("Cannot connect to the Database! ");
            }
            //returns the sqlConnection
            return conn;
        }
    }
}