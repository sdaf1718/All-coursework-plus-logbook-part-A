using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ex1.scripts;



namespace ex1
{
    public partial class forgotpassword : System.Web.UI.Page
    {
        // guidence from https://madskristensen.net/blog/generate-random-password-in-c/

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public string GenPwd()
        {
            string Passlen = "10"; // declares password length to ten
            string NewPwd = "";

            // allowed characters for password as it has been hashed we will generate a random password for the user 
            // we will allow numbers, uppercase letters, lowercase letters and certain speical keys like a comma and speach marks
            string allowedChars = "";
            allowedChars = "1,2,3,4,5,6,7,8,9,0";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";

            // below we using ascii and the random function to generate a new password

            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);


            string IDString = "";
            string temp = "";

            Random rand = new Random();

            for (int i = 0; i < Convert.ToInt32(Passlen); i++)
            {
                temp = arr[rand.Next(1, arr.Length)];
                IDString += temp;
                NewPwd = IDString;

            }
            return NewPwd;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strNewPassword = GenPwd().ToString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["logindetailsConnectionString"].ConnectionString); // connection string to connect to database
            conn.Open(); // open connection to database

            string str = string.Format("update usertable set Password='{0}' where Username='{1}';", PasswordHasher.GetPasswordHash(strNewPassword), TextBox1.Text);
            SqlCommand com = new SqlCommand(str, conn);
            com.ExecuteNonQuery();
            conn.Close();

            // to send the random password in email
            // following taken from lecturer worksheet 

            // smtp is used with creditentials to send an email 

            MailMessage msg = new MailMessage();
            NetworkCredential cred = new NetworkCredential("SDIAF1415@gmail.com", "Software1415");
            msg.From = new MailAddress("SDIAF1415@gmail.com");
            msg.To.Add(TextBox1.Text);
            msg.Subject = "Recover your Password";
            msg.Body = "Your password is: " + strNewPassword;
            msg.IsBodyHtml = true;
            SmtpClient smpt = new SmtpClient("smtp.gmail.com");
            smpt.UseDefaultCredentials = false;
            smpt.EnableSsl = true;
            smpt.Credentials = cred;
            smpt.Port = 587;

            smpt.Send(msg);
            Response.Write("you should receive an email shortly with your details");
            Response.Redirect("~/Login.aspx");
        }
    }
}