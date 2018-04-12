using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace coursework4mailapp
{
    public partial class compose : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // asp.net which restores values 
                txtTo.Text = Request["To"];
        }

        protected void SendEmailClick(object sender, EventArgs e)
        {
            using (MailMessage mailmessege = new MailMessage(txtEmail.Text, txtTo.Text))
            {
                // below is how to send an email whilst using smtp.
                
                // guidence from lecture notes, worksheets and https://www.aspsnippets.com/Articles/Send-email-using-Gmail-SMTP-Mail-Server-in-ASPNet.aspx

                // following code below declares the message contents for example to, cc, the main body of the message and the subject accoridng to the form textboxes

                mailmessege.CC.Add(txtccemail.Text); // cc carbon copy to someone declares the text box used 
                mailmessege.Subject = txtSubject.Text;
                mailmessege.Body = txtBody.Text;
                if (fuAttachment.HasFile) // code for attach a file
                {
                    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                    mailmessege.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
                }

                // mail code to send the mail with credentials needed we can only use google as this is what has been set as default by me
                mailmessege.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential netcr = new NetworkCredential(txtEmail.Text, txtPassword.Text);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = netcr;
                smtp.Port = 587; // smtp port which is needed by the google server to send mail without won't work
                smtp.Send(mailmessege);
                ClientScript.RegisterStartupScript(GetType(), "pleasenote", "important('Email has been sent successfully you may close this page now.');", true);
            }
        }
    }
}

