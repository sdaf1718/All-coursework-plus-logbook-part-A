using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Xml.Linq;
using ex1.scripts;

namespace ex1
{
    public partial class changepassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (Session["TheUser"] != null) // checks to see if user is logged in if so display welcome message
                {
                    lblwelcome.Text += Session["TheUser"].ToString();
                }
                else
                {
                    Response.Redirect("login.aspx"); // else it redirects to the login page informing user not logged in 

                }

            }

        

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            // gets the user info and the password hash which is stored in the database to match to change
            Database.UserInfo ui = (Database.UserInfo)Session["TheUser"];
			if (ui != null)
			{
				if (ui.Password == PasswordHasher.GetPasswordHash(txtold.Text))
				{
					Database.ChangePassword(ui, PasswordHasher.GetPasswordHash(txtnew.Text));
					Response.Write("Password Changed!");
                    Response.Redirect("userpage.aspx");
				}
				else
				{
					Response.Write("Old password doesn't match"); // message displayed to inform user that password is incorrect 
                }
			}
        }
    }
}

