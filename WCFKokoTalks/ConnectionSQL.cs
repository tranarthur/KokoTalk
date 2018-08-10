﻿/*Author: Dennis Suarez
 *Student ID: 991 461 216
 *Date: 2018-07-09
 */
using System;
using System.Data.SqlClient;

namespace WCFKokoTalks
{
    public class ConnectionSQL
    {
        private static SqlConnection conn;

        public static SqlConnection connectDB(string userName)
        {
            string connectionString = "Data Source=" + userName + ";Initial Catalog=CarSalesDB;" 
                + " Integrated Security = SSPI; Persist Security Info = False";

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