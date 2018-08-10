<<<<<<< HEAD
﻿/**
 * Author Henrique
 * 
 * */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KokoTalk
{
    public partial class Chat : System.Web.UI.Page
    {
        //Getting user sessions form the previous page
        string sessionp = "1";//HttpContext.Current.Session["currentUser"].ToString();
        string chatp = "2";// HttpContext.Current.Session["chatUser"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

            // This connection is to retrieve the name of the person you are chatting with
      
            SqlConnection conn = null;
            SqlCommand com;
            string queryString;

            try
            {
                
                conn = ConnectionSQL.connectDB("MSI\\SQLEXPRESS");
        
                queryString = "SELECT * FROM Profile WHERE profile_id ='" + chatp + "  '";
                com = new SqlCommand(queryString, conn);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                Label1.Text = dr["fullname"].ToString();
                Page.Title = "Chat with " + dr["fullname"].ToString(); ;
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }

        }
        //When the button is clicked the message is sent to the message table on the database and the new message field is updated on the Firends list
        protected void Button1_Click(object sender, EventArgs e)
        {

       
            SqlConnection conn = null;
            SqlCommand com;
            string queryString;
            try
            {

                conn = ConnectionSQL.connectDB("MSI\\SQLEXPRESS");

                queryString = "INSERT INTO Messages(time,sender_id,receiver_id,text) VALUES(CURRENT_TIMESTAMP,'" + sessionp + "','" + chatp + "',@Text)";
                com = new SqlCommand(queryString, conn);
                com.Parameters.AddWithValue("@Text", TextBox1.Text);
                com.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();

            }
            TextBox1.Text = "";



            //Updating the new message value on the Friends table
            try
            {

                conn.Open();
                queryString = "UPDATE Friends SET NewMessage=1 WHERE (profile_id = '" + chatp + "' AND friend_id = '" + sessionp + "') ";
                com = new SqlCommand(queryString, conn);

                com.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();

            }

        }
        // Timer ensures that messages are retrieved on a timely manner
        protected void Timer1_Tick(object sender, EventArgs e)
        {

            //Getting messages from database, selecting by the relevant users.
            ArrayList inbox = new ArrayList();
            string connectionString = null;
            SqlConnection conn = null;
            SqlCommand com;
            string queryString;
            int x = 0;
            try
            {

                conn = ConnectionSQL.connectDB("MSI\\SQLEXPRESS");

                queryString = "SELECT * FROM Messages WHERE (sender_id = '" + sessionp + "' AND receiver_id = '" + chatp + "') OR (sender_id = '" + chatp + "' AND receiver_id = '" + sessionp + "') ORDER BY Time DESC";
                com = new SqlCommand(queryString, conn);
                SqlDataReader dr = com.ExecuteReader();
                //Creating message objects to hold values and inputing them in to an arraylist (necessary to be flexible with the number of messages)
                while (dr.Read() && x <= 50)
                {
                    Message mes = new Message();
                    mes.sender = dr["sender_id"].ToString();
                    mes.receiver = dr["receiver_id"].ToString();
                    mes.time = dr["Time"].ToString();
                    mes.message = dr["Text"].ToString();
                    inbox.Add(mes);
                    x++;
                }

            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            //Literal is used to display messages, the message class creates the div so the page can be updated with messages accordingly
            Literal1.Text = "";
            for (int i = x - 1; i >= 0; i--)
            {
                //this is testing code!!! Remove after!
                //iteral1.Text += "<div class='speech-bubble'> <div class='message'> Hey bro, how are you?</div><div class='time'>" + DateTime.Now + "</div></div>";
                //Literal1.Text += "<div class='speech-bubble2'>  <div class='message'> What???</div><div class='time'>" + DateTime.Now + "</div></div>";
                //Testing code ends here
                Message mes = (Message)inbox[i];
                if (mes.sender.Equals(sessionp))
                {
                    Literal1.Text += mes.PostSender();
                }
                else
                {
                    Literal1.Text += mes.PostReceiver();
                }


            }

            //Updating new message fields
            try
            {

                conn.Open();
                queryString = "UPDATE Friends SET NewMessage=0 WHERE (profile_id = '" + sessionp + "' AND friend_id = '" + chatp + "') ";
                com = new SqlCommand(queryString, conn);

                com.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();

            }

        }
    }


}
=======
﻿/**
 * Author Henrique
 * 
 * */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KokoTalk
{
    public partial class Chat : System.Web.UI.Page
    {
        //Getting user sessions form the previous page
        string sessionp = "1";//HttpContext.Current.Session["currentUser"].ToString();
        string chatp = "2";// HttpContext.Current.Session["chatUser"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

            // This connection is to retrieve the name of the person you are chatting with
            string connectionString = null;
            SqlConnection conn = null;
            SqlCommand com;
            string queryString;

            try
            {

                connectionString = "Data Source=MSI\\SQLEXPRESS; Initial Catalog=KokoTalkDB; Integrated Security=SSPI; Persist Security Info=false";
                conn = new SqlConnection(connectionString);
                conn.Open();
                queryString = "SELECT * FROM Profile WHERE profile_id ='" + chatp + "  '";
                com = new SqlCommand(queryString, conn);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                Label1.Text = dr["fullname"].ToString();
                Page.Title = "Chat with " + dr["fullname"].ToString(); ;
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }

        }
        //When the button is clicked the message is sent to the message table on the database and the new message field is updated on the Firends list
        protected void Button1_Click(object sender, EventArgs e)
        {

            string connectionString = null;
            SqlConnection conn = null;
            SqlCommand com;
            string queryString;
            try
            {

                connectionString = "Data Source=MSI\\SQLEXPRESS; Initial Catalog=KokoTalkDB; Integrated Security=SSPI; Persist Security Info=false";
                conn = new SqlConnection(connectionString);
                conn.Open();
                queryString = "INSERT INTO Messages(time,sender_id,receiver_id,text) VALUES(CURRENT_TIMESTAMP,'" + sessionp + "','" + chatp + "',@Text)";
                com = new SqlCommand(queryString, conn);
                com.Parameters.AddWithValue("@Text", TextBox1.Text);
                com.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();

            }
            TextBox1.Text = "";



            //Updating the new message value on the Friends table
            try
            {

                conn.Open();
                queryString = "UPDATE Friends SET NewMessage=1 WHERE (profile_id = '" + chatp + "' AND friend_id = '" + sessionp + "') ";
                com = new SqlCommand(queryString, conn);

                com.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();

            }

        }
        // Timer ensures that messages are retrieved on a timely manner
        protected void Timer1_Tick(object sender, EventArgs e)
        {

            //Getting messages from database, selecting by the relevant users.
            ArrayList inbox = new ArrayList();
            string connectionString = null;
            SqlConnection conn = null;
            SqlCommand com;
            string queryString;
            int x = 0;
            try
            {

                connectionString = "Data Source=MSI\\SQLEXPRESS; Initial Catalog=KokoTalkDB; Integrated Security=SSPI; Persist Security Info=false";
                conn = new SqlConnection(connectionString);
                conn.Open();
                queryString = "SELECT * FROM Messages WHERE (sender_id = '" + sessionp + "' AND receiver_id = '" + chatp + "') OR (sender_id = '" + chatp + "' AND receiver_id = '" + sessionp + "') ORDER BY Time DESC";
                com = new SqlCommand(queryString, conn);
                SqlDataReader dr = com.ExecuteReader();
                //Creating message objects to hold values and inputing them in to an arraylist (necessary to be flexible with the number of messages)
                while (dr.Read() && x <= 50)
                {
                    Message mes = new Message();
                    mes.sender = dr["sender_id"].ToString();
                    mes.receiver = dr["receiver_id"].ToString();
                    mes.time = dr["Time"].ToString();
                    mes.message = dr["Text"].ToString();
                    inbox.Add(mes);
                    x++;
                }

            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            //Literal is used to display messages, the message class creates the div so the page can be updated with messages accordingly
            Literal1.Text = "";
            for (int i = x - 1; i >= 0; i--)
            {
                //this is testing code!!! Remove after!
                //iteral1.Text += "<div class='speech-bubble'> <div class='message'> Hey bro, how are you?</div><div class='time'>" + DateTime.Now + "</div></div>";
                //Literal1.Text += "<div class='speech-bubble2'>  <div class='message'> What???</div><div class='time'>" + DateTime.Now + "</div></div>";
                //Testing code ends here
                Message mes = (Message)inbox[i];
                if (mes.sender.Equals(sessionp))
                {
                    Literal1.Text += mes.PostSender();
                }
                else
                {
                    Literal1.Text += mes.PostReceiver();
                }


            }

            //Updating new message fields
            try
            {

                conn.Open();
                queryString = "UPDATE Friends SET NewMessage=0 WHERE (profile_id = '" + sessionp + "' AND friend_id = '" + chatp + "') ";
                com = new SqlCommand(queryString, conn);

                com.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();

            }

        }
    }


}
>>>>>>> fb7496b26fdc96f6e9022d58e8b38ca91e0ff80f
