using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.Security;
using ex1.scripts;

namespace ex1
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                // used set of tutuiorals with code for guidence to help with creating register,login, redirect pages for user and admin with sessions
                // webiste is youtube video https://www.youtube.com/watch?v=KVlXccl-XBA&list=PLS1QulWo1RIaM8-S7kTHgWd_pGNu-CyQS
                // below is a way built in using configuration manager to access the database via a connection string instead of usign a data source which is better to use in some instances if accessing a external  database 

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["logindetailsConnectionString"].ConnectionString);
                conn.Open(); // opens connection to database

                // string used to select from the table called user tables 
                string checkuser = "select count(*) from usertable where username = '" + txtusername.Text + "'";
                
                // checking to see if the user already exisits in the database if so inform user to avoid duplicates

                SqlCommand com = new SqlCommand(checkuser, conn);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                if (temp == 1)
                {
                    Response.Write("user already taken please chose another");
                }

                conn.Close();


            }

        }

        protected void btnregister_Click(object sender, EventArgs e)
        {
            try
            {
                Guid newguid = Guid.NewGuid();

                string pwd = PasswordHasher.GetPasswordHash(txtpassword.Text);


                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["logindetailsConnectionString"].ConnectionString);
                conn.Open();
                string insert = "insert into usertable (Id,Username,password,role,email,secretquestion,secretanwser) values (@Id,@uname,@password,@role,@email,@sq,@sa) ";

                // insert into database using parameterised query
                SqlCommand com = new SqlCommand(insert, conn);
                com.Parameters.AddWithValue("@Id", newguid.ToString());
                com.Parameters.AddWithValue("@uname", txtusername.Text);
                com.Parameters.AddWithValue("@password", pwd);
                com.Parameters.AddWithValue("@role", txtrole.Text);
                com.Parameters.AddWithValue("@email", txtemail.Text);
                com.Parameters.AddWithValue("@sq", txtsq.Text);
                com.Parameters.AddWithValue("@sa", txta.Text);

                // below i tried to implement a hash salt but after research found a better way of implementating it via a script
                /*
                                string salthashreturned = passwordhash.createhash(txtpassword.Text);
                                int commaindex = salthashreturned.IndexOf(":");
                                string extractstring = salthashreturned.Substring(0, commaindex);
                                commaindex = salthashreturned.IndexOf(":");
                                extractstring = salthashreturned.Substring(commaindex + 1);
                                commaindex = extractstring.IndexOf(":");
                                string salt = extractstring.Substring(0, commaindex);

                                commaindex = extractstring.IndexOf(":");
                                extractstring = extractstring.Substring(commaindex + 1);
                                string hash = extractstring;
                                com.Parameters.AddWithValue("?slowhashsalt",salt);

                    */
                com.ExecuteNonQuery();

                Response.Write("registered successful");
                Response.Redirect("login.aspx");

                conn.Close();
            }

            catch (Exception ex)

            {
                Response.Write("error:" + ex.ToString());
            }

        }

    }
}