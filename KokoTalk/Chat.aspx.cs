using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KokoTalk
{
    public partial class Chat : System.Web.UI.Page
    {
        string sessionp = "Henrique";//HttpContext.Current.Session["currentUser"].ToString();
          string chatp = "Dennis";// HttpContext.Current.Session["chatUser"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "<div class='name'>" + chatp + "</div>" ;
           // Label1.Text = "<div class='name'> Dennis </div>";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Message[] inbox = new Message[15];
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
                 queryString = "INSERT INTO Messages VALUES(CURRENT_TIMESTAMP,'" + sessionp +"','"+ chatp +"','"+ TextBox1.Text+ "')" ;
                 com = new SqlCommand(queryString, conn);

                 com.ExecuteNonQuery();



             }
             catch ( SqlException ex)
             {
                 Response.Write(ex.Message);
             }
             finally {
                 if (conn != null) conn.Close();
                TextBox1.Text = "";
             }
            
         }

        

/*
           
try{
string chatter = HttpContext.Current.Session["chatUser"].ToString();
string queryString;
string id = "";
Message[] inbox = new Message[15];


conn.Open();
queryString = "UPDATE "+ receiver +"Friends SET (read=FALSE)";
com = new SqlCommand(queryString, conn);

com.ExecuteNonQuery();


                } catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally {
               if (conn != null) conn.Close();
          
        }

            */
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Message[] inbox = new Message[15];
            string connectionString = null;
            SqlConnection conn = null;
            SqlCommand com;
            string queryString;
            int x = 0;
            try
            {


                

                

                connectionString = "Data Source=MSI\\SQLEXPRESS; Initial Catalog=KokoTalksDB; Integrated Security=SSPI; Persist Security Info=false";
                conn = new SqlConnection(connectionString);
                conn.Open();
                    queryString = "SELECT * FROM Messages WHERE  (sender_id = '" + sessionp+ "' AND receriver_id = '" + chatp + "') OR (sender_id = '" + chatp + "' AND receriver_id = '" + sessionp + "') ORDER BY Time ASC";
                    com = new SqlCommand(queryString, conn);
                    SqlDataReader dr = com.ExecuteReader();
                   
                    while (dr.Read() && x < 15)
                    {
                    Message mes = new Message();
                    mes.sender = dr["sender_id"].ToString();
                    mes.receiver= dr["receriver_id"].ToString();
                    mes.time = dr["Time"].ToString();
                    mes.message = dr["Text"].ToString();
                    inbox[x] = mes;
                    x++;
                    }
                   

            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally {
               if (conn != null) conn.Close();
            }




            /*
       try{
      string session = HttpContext.Current.Session["currentUser"].ToString();
      string chatter = HttpContext.Current.Session["chatUser"].ToString();
      string queryString;
      string id = "";
      Message[] inbox = new Message[15];
      conn = ConectionFactory();

      conn.Open();
      queryString = "UPDATE "+ session +"Friends SET (read=TRUE)";
      com = new SqlCommand(queryString, conn);

      com.ExecuteNonQuery();
      */
       
          

           

                Literal1.Text = "";
            for (int i = 0; i < x; i++)
            {
                //this is testing code!!! Remove after!
                //iteral1.Text += "<div class='speech-bubble'> <div class='message'> Hey bro, how are you?</div><div class='time'>" + DateTime.Now + "</div></div>";
                //Literal1.Text += "<div class='speech-bubble2'>  <div class='message'> What???</div><div class='time'>" + DateTime.Now + "</div></div>";
                //Testing code ends here
                
                if (inbox[i].sender.Equals(sessionp))
                {
                    Literal1.Text += "<div class='speech-bubble'> <div class='message'> "+ inbox[i].message +"</div><div class='time'>"+ inbox[i].time+"</div></div>";
                }
                else
                {
                    Literal1.Text += "<div class='speech-bubble2'> <div class='name>" + inbox[i].sender + "</div> <div class='message'> "+ inbox[i].message +"</div><div class='time'>"+ inbox[i].time+"</div></div>";
                }
           
       
            }

        }
    }


}

