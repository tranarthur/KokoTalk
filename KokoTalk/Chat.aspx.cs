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
       // string session = HttpContext.Current.Session["currentUser"].ToString();
       // string receiver = HttpContext.Current.Session["chatUser"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label1.Text = "<div class='name'>" + inbox[i].sender + "</div>" ;
            Label1.Text = "<div class='name'> Dennis </div>";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /* try
             {

                 /*

                 string queryString;
                 string id = "";
                 Message[] inbox = new Message[15];
                 conn = ConectionFactory();

                 conn.Open();
                 queryString = "INSERT INTO Mesages(Sender,Receiver,Message,Time) VALUES('"+ session +"','"+ chatter +"','"+ TextBox1.Text +"','"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")+"') ;
                 com = new SqlCommand(queryString, conn);

                 com.ExecuteNonQuery();



             }
             catch ( SqlException ex)
             {
                 Response.Write(ex.Message);
             }
             finally {
                 if (conn != null) conn.Close();
             }
         }*/




            /*
try{
string session = HttpContext.Current.Session["currentUser"].ToString();
string chatter = HttpContext.Current.Session["chatUser"].ToString();
string queryString;
string id = "";
Message[] inbox = new Message[15];
conn = ConectionFactory();

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
           */
        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {/*
            try
            {


                

                string queryString;
                string id = "";
                Message[] inbox = new Message[15]; 
                conn = ConectionFactory();

                    conn.Open();
                    queryString = "SELECT * FROM Messages WHERE  (Sender = '"+sender+ "' AND Receiver = '" + receiver + "') OR (Sender = '" + receiver + "' AND Receiver = '" + sender + "') ORDER BY Time";
                    com = new SqlCommand(queryString, conn);
                    SqlDataReader dr = com.ExecuteReader();
                    int x = 0;
                    while (dr.Read() && x < 15)
                    {
                    Message mes = new Message();
                    mes.sender = dr["Sender"].ToString();
                    mes.receiver= dr["Receiver"].ToString();
                    mes.time = dr["Time"].ToString();
                    mes.message = dr["Message"].ToString();
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
         */



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
            for (int i = 0; i < 5; i++)
            {
                //this is testing code!!! Remove after!
                Literal1.Text += "<div class='speech-bubble'> <div class='message'> Hey bro, how are you?</div><div class='time'>" + DateTime.Now + "</div></div>";
                Literal1.Text += "<div class='speech-bubble2'>  <div class='message'> What???</div><div class='time'>" + DateTime.Now + "</div></div>";
                //Testing code ends here
                /*
                if (inbox[i].sender == sender)
                {
                    Literal1.Text += "<div class='speech-bubble'> <div class='message'> "+ inbox[i].message +"</div><div class='time'>"+ inbox[i].time+"</div></div>";
                }
                else
                {
                    Literal1.Text += "<div class='speech-bubble2'> <div class='name>" + inbox[i].sender + "</div> <div class='message'> "+ inbox[i].message +"</div><div class='time'>"+ inbox[i].time+"</div></div>";
                }
                } catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally {
               if (conn != null) conn.Close();
            }
             */
            }

        }
    }


}

