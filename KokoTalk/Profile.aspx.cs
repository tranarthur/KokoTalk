using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KokoTalk
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Session["userId"].ToString();

            UserProfile profile = makeProfile(id);

            string start = "<div id='posts'>< div style = 'background-color:white; padding: 10px;'>";
            string text = "";
            string end = "<p style = 'float: right'> Time, date </p></br></br></div></div> ";

            Literal1.Text += start;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        private UserProfile makeProfile(string id) {
            UserProfile profile = new UserProfile();

            String query = "SELECT * FROM [dbo].[Profile] WHERE profile_id='" + id + "';";

            //Connecting to the DB
            SqlConnection connection = ConnectionSQL.connectDB("DASUAREZ");

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                profile.fullname = reader.GetValue(2).ToString();
                profile.email = reader.GetValue(4).ToString();
                profile.age = reader.GetValue(5).ToString();
                profile.sex = reader.GetValue(6).ToString();
                profile.friends = reader.GetValue(7).ToString();
                profile.city = reader.GetValue(8).ToString();
                profile.province = reader.GetValue(9).ToString();
                profile.job = reader.GetValue(10).ToString();
                profile.company = reader.GetValue(11).ToString();
                profile.school = reader.GetValue(12).ToString();
                profile.profile_pic = reader.GetValue(13).ToString();
                profile.profile_status = reader.GetValue(14).ToString();
            }

            connection.Close();


            return profile;
        }
    }
}