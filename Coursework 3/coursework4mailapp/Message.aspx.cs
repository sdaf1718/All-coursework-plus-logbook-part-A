using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpenPop.Pop3;
using OpenPop.Mime;
using System.Data;

namespace coursework4mailapp
{
    public partial class Message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // this is to display the message when clicked on the hyperlink in the datagrid view
            if (!IsPostBack)

            {

                Pop3Client pop3protocol = (Pop3Client)Session["Pop3Client"];

                int Messageorder = int.Parse(Request.QueryString["Messageorder"]);

                OpenPop.Mime.Message mgs = pop3protocol.GetMessage(Messageorder);

                MessagePart messagePart = mgs.MessagePart.MessageParts[0];

                lblFrom.Text = mgs.Headers.From.Address;

                lblSubject.Text = mgs.Headers.Subject;

                lblBody.Text = messagePart.BodyEncoding.GetString(messagePart.Body);

            }
        }
    }
}