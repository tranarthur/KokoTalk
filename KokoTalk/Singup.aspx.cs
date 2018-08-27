//@Author: Richard McKay
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KokoTalk
{
    public partial class Singup : System.Web.UI.Page
    {
        /// <summary>
        /// On page load the dropdown menu is loaded with counters so the user can select there age
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 19; i <= 100; i++)
            {
                DropDownAge.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

        }
        /// <summary>
        /// creates an account and check whether the email is already used and then redirects the user to their profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_SignUp_Click(object sender, EventArgs e)
        {
            try
            {

                //creating a sqlConnection object through one of our classes
                SqlConnection conn = ConnectionSQL.ConnectDB();
                SqlCommand com;
                //query string that will help validate if an email is already taken
                string validateInfo = "SELECT COUNT(profile_id) FROM Profile WHERE email = @email";

                com = new SqlCommand(validateInfo, conn);
                com.Parameters.AddWithValue("@email", txtEmail.Text);
                //had to use executeScalar instead of executeNonQuery() since execute returns first column but as a object
                //so we had to cast it into int. If it 0 thats how we know that email is not taken
                int x = (int)com.ExecuteScalar();
                if (x == 0)
                {
                    //once everything checks out the user account is created/inserted into the database
                    string queryString = "INSERT INTO Profile(num_of_friends, job, company, school, profile_pic, profile_status, sex,  email, password,city, province, age, fullname) VALUES(@num_of_friends, @job, @company, @school,@profile_pic, @profile_status, @gender, @email,@password,@city,@prov, @age,@name)";
                    com = new SqlCommand(queryString, conn);
                    //arguments were adding to the query 
                    com.Parameters.AddWithValue("@num_of_friends", 0);
                    com.Parameters.AddWithValue("@job", txtJob.Text);

                    com.Parameters.AddWithValue("@company", txtComp.Text);
                    com.Parameters.AddWithValue("@school", txtSchool.Text);
                    com.Parameters.AddWithValue("@profile_pic", txtImg.Text);
                    com.Parameters.AddWithValue("@profile_status", txtStatus.Value);
                    com.Parameters.AddWithValue("@gender", GenderDropDown.Text);

                    com.Parameters.AddWithValue("@name", txtName.Text);
                    com.Parameters.AddWithValue("@password", txtPassword.Text);
                    com.Parameters.AddWithValue("@email", txtEmail.Text);
                    com.Parameters.AddWithValue("@city", txtCity.Text);
                    com.Parameters.AddWithValue("@prov", txtProv.Text);
                    com.Parameters.AddWithValue("@age", DropDownAge.Text);
                    int i = com.ExecuteNonQuery();
                    //if i is greater than 1 than we know that the account has been inserted/created and we then go to the user account
                    //else we prompt the user that issue has occur with their account creation
                    if (i > 0)
                    {


                        try
                        {

                            conn = ConnectionSQL.ConnectDB();

                            //select the nearly created account using the where clause with email as a condition
                            queryString = "SELECT profile_id, fullname, password FROM Profile WHERE email = @email";
                            com = new SqlCommand(queryString, conn);
                            com.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
                            com.Parameters["@email"].Value = txtEmail.Text;
                            SqlDataReader dr = com.ExecuteReader();


                            dr.Read();
                            //storing profile id and fullname into session and redirecting the user to their profile page
                            HttpContext.Current.Session["userid"] = dr["profile_id"].ToString();
                            HttpContext.Current.Session["username"] = dr["fullname"].ToString();
                            Response.Redirect("Profile.aspx");

                        }
                        //this catches any sqlExceptions that occurs and lets the user know what has happened
                        catch (SqlException ex)
                        {
                            Response.Write(ex.Message);
                        }
                        //closes the database connection
                        finally
                        {
                            conn.Close();
                        }
                    }
                    //this occurs when the query to create an account returns less than 1. The user is prompted to what has happened
                    else
                    {
                        //label is then put to visible showing the error
                        Label4.Visible = true;
                        Label4.Text = "Unable to create an account try again";
                    }
                }
                //this error occurs when the user enters an email that is already taken
                else
                {
                    //label is then put to visible showing the error
                    Label4.Visible = true;
                    Label4.Text = "Account already exist";
                }
            }
            catch (SqlException ex)
            {
                //label is then put to visible showing the error
                string error = ex.Message;
                Label4.Visible = true;
                Label4.Text = error;

            }

        }
    }
}