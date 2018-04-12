using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ex1
{
    public partial class manager : System.Web.UI.Page
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
    

        protected void Button1_Click(object sender, EventArgs e)
        {
            // following code to logout and to unset the session so the user can securely sign out of their account
            Session["TheUser"] = null;
            Response.Redirect("login.aspx");
        }
    }
}