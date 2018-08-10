using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WCFKokoTalks
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : KokoService
    {

        public Post[] GetPost(string profileId)
        {
            Post[] posts = new Post[25];
            int counter = 0;

            String query = "SELECT * FROM [dbo].[Posts] WHERE profile_id='" + profileId + "'" +
                "ORDER BY postdate DESC;";

            //Connecting to the DB
            SqlConnection connection = ConnectionSQL.connectDB("DASUAREZ");

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read() && counter < 25)
            {
                Post post = new Post();
                post.PostTime = reader.GetValue(4).ToString();
                post.PostText = reader.GetValue(3).ToString();
                posts[counter] = post;
                counter++;
            }

            connection.Close();

            return posts;
        }

         public void PushPost(string query)
         {
            //Connecting to the DB
            SqlConnection connection = ConnectionSQL.connectDB("DASUAREZ");
    
            SqlCommand command = new SqlCommand(query, connection);

            int run = command.ExecuteNonQuery();

            connection.Close();
            if (run == 0)
            {
             MessageBox.Show("The user could not be created. Please check the inputs for duplicate user!");
            }
         }
    }
}