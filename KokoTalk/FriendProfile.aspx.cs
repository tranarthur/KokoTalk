/*Author: Dennis Suarez
 *
 * Description: This code handles all the functionality for the
 * friendProfile page. This is mainly loading all the posts from
 * the database in the correct order and also the profile information
 * for the given friend.
 */

using KokoTalk.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KokoTalk
{
    public partial class FriendProfile : System.Web.UI.Page
    {
        /// <summary>
        /// This variable is here to keep track who is the user logged in
        /// </summary>
        private string id = "";

        /// <summary>
        /// This method call the helper method to create the profile and read
        /// the information. Then it travels through the profile, setting the 
        /// actual information displayed in the website for the user.
        /// It also loads all of the posts for the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];

            UserProfile profile = MakeProfile(id);

            name.Text = profile.Fullname;
            age.Text = profile.Age;
            status.Text = profile.Profile_status;
            province.Text = profile.Province;
            city.Text = profile.City;
            sex.Text = profile.Sex;
            work.Text = profile.Company;
            job.Text = profile.Job;
            school.Text = profile.School;
            email.Text = profile.Email;
            friends.Text = profile.Friends;
            Image1.ImageUrl = profile.Profile_pic;

            name2.Text = profile.Fullname;
            name1.Text = profile.Fullname;


            ServiceReference1.Service1Client result = new ServiceReference1.Service1Client();
            Post[] posts = result.GetPost(id);


            string start = "";
            Posts post = new Posts();

            for (int i = posts.Length - 1; i >= 0; i--)
            {
                post.SetPost(posts[i].PostText);
                post.SetTime(posts[i].PostTime);

                start += "<div style='background-color:white; padding: 10px;'>";
                start += "" + post.GetPost();
                start += "<p style='float: right; font-size: 8pt'>";
                start += "" + post.GetTime();
                start += "</p></br></br></div></br>";
            }

            Literal1.Text += start;
        }

        /// <summary>
        /// This method loads all the information for the user profile
        /// in a class UserProfile. ie name, photo..
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private UserProfile MakeProfile(string id)
        {
            UserProfile profile = new UserProfile();

            String query = "SELECT * FROM [dbo].[Profile] WHERE profile_id='" + id + "';";

            //Connecting to the DB
            SqlConnection connection = ConnectionSQL.connectDB();

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                profile.Fullname = reader.GetValue(1).ToString();
                profile.Email = reader.GetValue(3).ToString();
                profile.Age = reader.GetValue(5).ToString();
                profile.Sex = reader.GetValue(4).ToString();
                profile.Friends = reader.GetValue(6).ToString();
                profile.City = reader.GetValue(7).ToString();
                profile.Province = reader.GetValue(8).ToString();
                profile.Job = reader.GetValue(9).ToString();
                profile.Company = reader.GetValue(10).ToString();
                profile.School = reader.GetValue(11).ToString();
                profile.Profile_pic = reader.GetValue(12).ToString();
                profile.Profile_status = reader.GetValue(13).ToString();
            }

            connection.Close();

            return profile;
        }
    }
}