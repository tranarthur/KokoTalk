/**
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
        string sessionp;
        String chatp;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["userid"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            //Getting user sessions form the previous page
            sessionp = HttpContext.Current.Session["userid"].ToString();
            chatp = Request.QueryString["id"];

            Literal2.Text = "<span id=\"current-user\"><a href=\"Profile.aspx?id=" + sessionp + "\">" + HttpContext.Current.Session["username"] + "</a></span>";


            // This connection is to retrieve the name of the person you are chatting with
            SqlConnection conn = null;
            SqlCommand com;
            string queryString;

            try
            {

                conn = ConnectionSQL.connectDB();

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
            UpdateMessages();
        }
        //When the button is clicked the message is sent to the message table on the database and the new message field is updated on the Firends list
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(TextBox1.Text.ToString().Trim()))
            {


                SqlConnection conn = null;
                SqlCommand com;
                string queryString;
                try
                {

                    conn = ConnectionSQL.connectDB();

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
                UpdateMessages();
            }
        }
        // Timer ensures that messages are retrieved on a timely manner
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            UpdateMessages();
        }
        /// <summary>
        /// This method updates the messages, retireves them form the database and populates the message field;
        /// </summary>
        public void UpdateMessages()
        {

            //Getting messages from database, selecting by the relevant users.
            ArrayList inbox = new ArrayList();
            SqlConnection conn = null;
            SqlCommand com;
            string queryString;
            int x = 0;
            try
            {

                conn = ConnectionSQL.connectDB();

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