using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KokoTalk
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {

            string connectionString = null;
            SqlConnection conn = null;
            SqlCommand com;
            string queryString;
            string pass = "";
            try
            {

                connectionString = "Data Source=MSI\\SQLEXPRESS; Initial Catalog=KokoTalksDB; Integrated Security=SSPI; Persist Security Info=false";
                conn = new SqlConnection(connectionString);
                conn.Open();
              //  queryString = "INSERT INTO Messages VALUES(CURRENT_TIMESTAMP,'" + sessionp + "','" + "','" + "', 1)";
                //com = new SqlCommand(queryString, conn);
                //com.ExecuteNonQuery();

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