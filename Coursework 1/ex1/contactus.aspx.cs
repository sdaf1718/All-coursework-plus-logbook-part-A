using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ex1
{
    // guidence from https://www.youtube.com/watch?v=Smud1bxrQhc
    public partial class contactus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "some name",
                 // below code will fill in email address and subject line and the body of our message for the user to send to us and they can add to it
                 "parent.location='mailto:ucp@somename.com?Subject=contactus &body=Dear who this may concern,'", true);

        }
    }
}