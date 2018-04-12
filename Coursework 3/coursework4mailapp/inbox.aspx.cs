using System;
using System.Data;
using System.Web.UI;
using OpenPop.Pop3;

namespace coursework4mailapp
{
    // pop3 or imap is uesd to read mail learnt in NSE with Hugh Chadwick in great details with the INET D demons and configue files 
    // from the NSE module network services enginering I took what I learnt and applied it to this 
    // guidence from https://www.codeproject.com/Articles/188349/Read-Gmail-Inbox-Message-in-ASP-NET
    // guidence from https://www.aspsnippets.com/Articles/Fetch-and-read-email-messages-with-attachments-from-GMAIL-POP3-mail-server-in-ASPNet.aspx
    public partial class inbox : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ReadEmails_Click(object sender, EventArgs e)
        {
            Pop3Client pop3protocol; // using the POP3 client which is used in email you can use IMAP as well or SMTP

            if (Session["Pop3Client"] == null) // session to check POP3 client server

            {
                pop3protocol = new Pop3Client();

                pop3protocol.Connect(txtServer.Text, int.Parse(txtPort.Text), chkSSL.Checked);

                pop3protocol.Authenticate(txtEmail.Text, txtpwd.Text);

                Session["Pop3Client"] = pop3protocol;
            }

            else

            {
                pop3protocol = (Pop3Client) Session["Pop3Client"];
            }

            var count = pop3protocol.GetMessageCount();

            var dtmsg = new DataTable();

            dtmsg.Columns.Add("Messageorder");

            dtmsg.Columns.Add("From");

            dtmsg.Columns.Add("Subject");

            dtmsg.Columns.Add("DateSent");

            dtmsg.Columns.Add("Body");

            var counter = 0;

            for (var i = count; i >= 1; i--)

            {
                try
                {
                    // gets the messages when clicked to display in window
                    var mgs = pop3protocol.GetMessage(i);

                    dtmsg.Rows.Add();

                    dtmsg.Rows[dtmsg.Rows.Count - 1]["Messageorder"] = i;

                    dtmsg.Rows[dtmsg.Rows.Count - 1]["From"] = mgs.Headers.From.Address;

                    dtmsg.Rows[dtmsg.Rows.Count - 1]["Subject"] = mgs.Headers.Subject;

                    dtmsg.Rows[dtmsg.Rows.Count - 1]["DateSent"] = mgs.Headers.DateSent.ToLocalTime();

                    dtmsg.Rows[dtmsg.Rows.Count - 1]["Body"] = mgs.MessagePart.GetBodyAsText();

                    counter++;

                    if (counter > 4)

                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
            GvEmails.DataSource = dtmsg;
            GvEmails.DataBind();
        }
    }
}