using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// This class is the code behind the contacts page
/// </summary>
/// <author>
/// Khoa Tran
/// </author>

namespace KokoTalk
{
    public partial class Contacts : System.Web.UI.Page
    {
        //connection variables
        SqlConnection conn = null;
        SqlCommand com;
        string queryString;
        string userId;

        protected void Page_Load(object sender, EventArgs e)
        {

            //if a user tries to go directly to the contacts page bypassing the login
            if (HttpContext.Current.Session["userid"] == null)
            {
                //redirect them to the login page
                Response.Redirect("Default.aspx");
            }

            userId = HttpContext.Current.Session["userid"].ToString();

            //point the profile link to go to the current users profile page using a query string
            //set the name in the nav menu as the user's full name
            Literal2.Text = "<span id=\"current-user\"><a href=\"Profile.aspx?id=" + userId + "\">" + HttpContext.Current.Session["username"] + "</a></span>";

            //use to store a script in case the user adds an invalid contact i.e. one that does not exist
            Literal3.Text = "";

            //retrieve the users contacts and display them
            UpdateContactList();


        }


        /// <summary>
        /// This method represents the button click event for when the user presses the add new contact button
        /// </summary>
        /// <author>
        /// Khoa Tran
        /// </author>
        protected void add_contact_btn_Click(object sender, EventArgs e)
        {
            //used to store if the contact the user tries to add exists or not
            Boolean match = false;
            int friend_id = 0;

            try
            {
                conn = ConnectionSQL.ConnectDB();
                queryString = "SELECT profile_id from Profile where email = @email";
                com = new SqlCommand(queryString, conn);
                com.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
                com.Parameters["@email"].Value = new_contact_txtbox.Text;
                SqlDataReader dr = com.ExecuteReader();

                //if the contact email the user entered matches one in the database
                //email is a unique field so one one record will be retrieved
                if (dr.HasRows)
                {
                    dr.Read();
                    friend_id = int.Parse(dr["profile_id"].ToString());
                    match = true;


                }
                //the contact email the user provided does not match one in the database
                else
                {
                    //alert the user using javascript that a match was not found
                    Literal3.Text = "<script>alert('No match found!');</script>";
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

            //a valid contact email was provided
            if (match)
            {
                // add the contact as a friend
                queryString = "INSERT INTO dbo.Friends (profile_id,friend_id) VALUES (@profile_id,@friend_id);";
                using (conn = ConnectionSQL.ConnectDB())
                {
                    com = new SqlCommand(queryString, conn);
                    com.Parameters.Add("@profile_id", System.Data.SqlDbType.Int);
                    com.Parameters["@profile_id"].Value = int.Parse(HttpContext.Current.Session["userid"].ToString());
                    com.Parameters.Add("@friend_id", System.Data.SqlDbType.Int);
                    com.Parameters["@friend_id"].Value = friend_id;

                    try
                    {
                        com.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                // add the user as a friend of the contact
                using (conn = ConnectionSQL.ConnectDB())
                {
                    com = new SqlCommand(queryString, conn);
                    com.Parameters.Add("@profile_id", System.Data.SqlDbType.Int);
                    com.Parameters["@profile_id"].Value = friend_id;
                    com.Parameters.Add("@friend_id", System.Data.SqlDbType.Int);
                    com.Parameters["@friend_id"].Value = int.Parse(HttpContext.Current.Session["userid"].ToString());
                    try
                    {

                        com.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

        }

        /// <summary>
        /// This method is used to retrieve and display all the users contacts 
        /// as well as their latest messages and message information 
        /// ex. message sent time, message status (sent, read, unread)
        /// </summary>
        /// <author>
        /// Khoa Tran
        /// </author>
        protected void UpdateContactList()
        {
            Literal1.Text = "";
            try
            {
                conn = ConnectionSQL.ConnectDB();
                queryString = "SELECT f.friend_id, f.newMessage, p.fullname, p.profile_pic, c3.sender_id, c3.text, c3.time FROM dbo.Friends f LEFT OUTER JOIN dbo.Profile p ON f.friend_id = p.profile_id LEFT OUTER JOIN (select c2.friend_id, c2.message_id, m.sender_id, m.text, m.time FROM (select c1.friend_id, max(c1.message_id) AS message_id from(select message_id, receiver_id AS friend_id from dbo.Messages where sender_id = " + userId + " UNION select message_id, sender_id AS friend_id from dbo.Messages where receiver_id = " + userId + ") c1 GROUP BY c1.friend_id) c2 INNER JOIN dbo.Messages m ON m.message_id = c2.message_id) c3 ON f.friend_id = c3.friend_id WHERE f.profile_id = " + userId + " ORDER BY time DESC;";
                com = new SqlCommand(queryString, conn);
                SqlDataReader dr = com.ExecuteReader();
                String readStatus = "";
                String message = "";
                String time = "";
                DateTime messageTime;
                DateTime currentDateTime = DateTime.Now;
                String profilePicture = "";
                TimeSpan timeSpan;
                String messageStatus = "";

                while (dr.Read())
                {
                    //reset readStatus and messageStatus for when user has multiple contacts
                    readStatus = "";
                    messageStatus = "";
                    // if the user is the sender of the message
                    if (!dr.IsDBNull(dr.GetOrdinal("sender_id")) && dr["sender_id"].ToString() == userId)
                    {
                        //show a check mark to show that the message was sent
                        messageStatus = "<i class=\"fas fa-check\"></i>";
                        //if the message has been read by the recipient
                        if (!dr.IsDBNull(dr.GetOrdinal("newMessage")) && dr["newMessage"].ToString() == "False")
                        {
                            readStatus = " read";
                        }
                    }
                    //the sender of the message is one of the users contacts
                    else
                    {
                        //if the user has not read the message yet
                        if (!dr.IsDBNull(dr.GetOrdinal("newMessage")) && dr["newMessage"].ToString() == "True")
                        {
                            readStatus = " unread";
                        }
                    }

                    //check if the user has had a chat conversation with this contact
                    if (!dr.IsDBNull(dr.GetOrdinal("text")))
                    {
                        //this is used to determine how the time should be shown
                        messageTime = DateTime.Parse(dr["time"].ToString());
                        timeSpan = currentDateTime.Subtract(messageTime);
                        //if message was sent less than a day ago
                        if (timeSpan.TotalDays < 1)
                        {
                            //only show the time as the hour and min (12:00 AM)
                            time = messageTime.ToString("hh:mm tt");
                        }
                        //if message was sent less than a week ago
                        else if (timeSpan.TotalDays < 7)
                        {
                            //Show the time as the day of the week (Monday)
                            time = messageTime.ToString("dddd");
                        }
                        //if message was sent less than a year ago
                        else if (timeSpan.TotalDays < 365)
                        {
                            //Show the time as month and day (June 10) 
                            time = messageTime.ToString("MMMM dd");
                        }
                        //if message was sent more than a year ago
                        else
                        {
                            //Show the full date (10/08/2018)
                            time = messageTime.ToString("dd/MM/yyyy");
                        }

                        message = dr["text"].ToString();

                        //if the message is too long to display
                        //cut the string and add an ellipses to show
                        //that the message is continued
                        if (message.Length > 100)
                        {
                            message = message.Substring(0, 100) + "...";
                        }


                    }
                    //there is no existing chat conversation between this user and the contact
                    else
                    {
                        message = "";
                        time = "";
                    }
                    //if the contact has a profile picture
                    if (!dr.IsDBNull(dr.GetOrdinal("profile_pic")))
                    {
                        profilePicture = dr["profile_pic"].ToString();
                    }
                    //assign them the default profile picture
                    else
                    {
                        profilePicture = "images/profile/default-profile-pic.png";
                    }
                    //create the html text that holds all the formatted contact information and add it to the literal tag
                    //to display in on the contact aspx page
                    Literal1.Text += "<div class=\"contact\"><a href=\"FriendProfile.aspx?id=" + dr["friend_id"].ToString() + "\"><div class=\"contact-pic\"><img src =\"" + profilePicture + "\" alt=\"Profile Picture\"/></div></a><div class=\"contact-info" + readStatus + "\"><a href=\"Chat.aspx?id=" + dr["friend_id"].ToString() + "\"><div class=\"contact-upper\"><span class=\"contact-name\">" + dr["fullname"].ToString() + "</span><span class=\"last-message-time\">" + time + "</span></div><div class=\"contact-lower\"><span class=\"last-message\">" + message + "</span><span class=\"message-status\">" + messageStatus + "</span></div></a></div></div>";

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
        }

        //timer to refresh the contact page to check for new messages, or if a contact added this user
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //update the contact list
            UpdateContactList();
        }
    }
}