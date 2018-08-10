using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KokoTalk
{
    public partial class Signup : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
               
        }
     
        protected void btn_SignUp_Click(object sender, EventArgs e)
        {
            string connectionString = Environment.MachineName;
            string agestr = txtAge.Text;
            SqlConnection conn = ConnectionSQL.connectDB(connectionString);
            SqlCommand com;
            string queryString = "INSERT INTO Profile(sex, email, password,city, province, age, fullname) VALUES(@gender, @email,@password,@city,@prov, @age,@name)";
            com = new SqlCommand(queryString, conn);
            com.Parameters.AddWithValue("@gender", GenderDropDown.Text);

            com.Parameters.AddWithValue("@name", txtName.Text);
            com.Parameters.AddWithValue("@password", txtPassword.Text);
            com.Parameters.AddWithValue("@email", txtEmail.Text);
            com.Parameters.AddWithValue("@city", txtCity.Text);
            com.Parameters.AddWithValue("@prov", txtProv.Text);
            com.Parameters.AddWithValue("@age", int.Parse(agestr));
           int i= com.ExecuteNonQuery();
            if(i > 0)
            {
                Response.Redirect("Profile.aspx");
            }
            else
            {
                Label4.Text = "Unable to create an account try again";
            }
        }
    }
}