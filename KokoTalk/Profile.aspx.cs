/*Author: Dennis Suarez
 *
 * Description: This code handles the profile of the current user
 * in the application. It allows for the profile to load all the posts
 * the user has made on his porfile and profile information. In addition,
 * it allows the user to create new posts.
 */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using KokoTalk.ServiceReference1;

namespace KokoTalk
{
    public partial class Profile : System.Web.UI.Page
    {
        /// <summary>
        /// This variable is used to save the id of the current user using the application
        /// </summary>
        private string id = "";

        /// <summary>
        /// This method call the helper method to create the profile and read
        /// the information. Then it travels through the profile,
        /// setting the 
        /// actual information displayed in the website for the user.
        /// It also loads all of the posts for the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            id = HttpContext.Current.Session["userid"].ToString();

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

        /// <summary>
        /// This method allows for the user to create new posts. by taking the users id
        /// and the text in the post label. Then it sends it to the WFC service.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (post.Text.ToString().Trim().Length > 0)
            {
                ServiceReference1.Service1Client result = new ServiceReference1.Service1Client();
                result.PushPost(id, post.Text);

                post.Text = "";

                Literal1.Text = "";

                Page_Load(sender, e);
            }
        }
    }
}