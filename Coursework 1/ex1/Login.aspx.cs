using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ex1.scripts;

namespace ex1
{
    public partial class login : System.Web.UI.Page
    {
        // helpufl notes taken from my Final project module created last year
        // using scripts for the hashed password abvoe 
        // roles can be used for multiple logins for diferent users who have set permissions like a user, paid user or manager giving them access to certain permissions


        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Database.UserInfo ui = Database.GetUser(txtuser.Text, txtpassword.Text);
            if (ui != null)
            {
                Session["TheUser"] = ui; // session used to check if user logged or manager page logged in
                string redirect = ui.Role == "manager" ? "~/adminpage.aspx" : "~/userpage.aspx"; // redirects to the followign page via roles 
                Response.Redirect(redirect, false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Write("Username or Password is incorrect"); // else if information correct display message 
            }
        }
    }
}