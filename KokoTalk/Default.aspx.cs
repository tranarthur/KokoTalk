using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// This class is the code behind the login page
/// </summary>
/// <author>
/// Khoa Tran
/// </author>

namespace KokoTalk
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //clears the current session
            //this is for when the user clicks the logout link and is redirected to the login page
            HttpContext.Current.Session.Clear();
        }

        /// <summary>
        /// This method represents the button click event for when the user presses the login button
        /// </summary>
        /// <author>
        /// Khoa Tran
        /// </author>
        protected void submit_Click(object sender, EventArgs e)
        {
            //connection variables
            SqlConnection conn = null;
            SqlCommand com;
            string queryString;

            try
            {

                conn = ConnectionSQL.ConnectDB();
                //retrive profile id, user fullname, password based on the username textbox to compare with
                queryString = "SELECT profile_id, fullname, password FROM Profile WHERE email = @email";
                com = new SqlCommand(queryString, conn);
                com.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
                com.Parameters["@email"].Value = loginTxtBox.Text;
                SqlDataReader dr = com.ExecuteReader();

                //if the email provided matches with the one in the database
                if (dr.HasRows)
                {
                    dr.Read();
                    //if the password matches with the one in the database
                    //successful login
                    if (dr["Password"].ToString().Equals(passwordTxtBox.Text))
                    {
                        //set the userid,username session to the profile_id and fullname fields
                        HttpContext.Current.Session["userid"] = dr["profile_id"].ToString();
                        HttpContext.Current.Session["username"] = dr["fullname"].ToString();
                        //redirect the contact list page
                        Response.Redirect("Contacts.aspx");
                    }
                    else //if the password does not match 
                    {
                        //show message to the user that password is incorrect
                        CustomValidator2.IsValid = false;
                    }

                }
                //if the email cannot be found
                else
                {
                    //show message to the user that email is incorrect
                    CustomValidator1.IsValid = false;
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
    }
}