using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WFCService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public Post[] GetPost(string profileId)
        {

            String query = "SELECT * FROM [dbo].[Posts] WHERE profile_id='" + profileId + "'" +
                "ORDER BY postdate ASC;";

            String count = "SELECT * FROM [dbo].[Posts] WHERE profile_id='" + profileId + "'" +
                "ORDER BY postdate ASC;";
            int counter = 0;

            //Connecting to the DB
            SqlConnection connection = ConnectionSQL.connectDB();

            SqlCommand command = new SqlCommand(count, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                counter++;
            }

            connection.Close();

            connection = ConnectionSQL.connectDB();


            Post[] posts = new Post[counter];

            command = new SqlCommand(query, connection);
            reader = command.ExecuteReader();

            counter = 0;

            while (reader.Read())
            {
                Post post = new Post();
                post.PostTime = reader.GetValue(3).ToString();
                post.PostText = reader.GetValue(2).ToString();
                posts[counter] = post;
                counter++;
            }

            connection.Close();

            return posts;
        }

        public void PushPost(string id, string text)
        {
            //Connecting to the DB

            SqlConnection connection = ConnectionSQL.connectDB();

            string query = "INSERT INTO Posts(profile_id,post,postdate) VALUES(@ID, @Text, CURRENT_TIMESTAMP)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", id);
            command.Parameters.AddWithValue("@Text", text);
            int run = command.ExecuteNonQuery();

            connection.Close();
            if (run == 0)
            {
                Console.WriteLine("The user could not be created. Please check the inputs for duplicate user!");
            }
        }
    }
}
