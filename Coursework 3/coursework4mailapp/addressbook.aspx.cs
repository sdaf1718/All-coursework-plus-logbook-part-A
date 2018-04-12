using System;
using System.Data;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using Google.Contacts;
using Google.GData.Client;
using Google.GData.Contacts;
using Google.GData.Extensions;

namespace coursework4mailapp
{

    // guidence from https://www.youtube.com/watch?v=DYAwYxVs2TI
    // guidence from https://www.youtube.com/watch?v=HvQ6fbNFxO4
    // gudience from https://www.youtube.com/watch?v=WsRyvWvo4EI
    // guidence from https://www.youtube.com/watch?v=CtDE9gTwmyo

    // the following website helped me to understand Oauth2parameters and I have learnt something new which I can use later on in life website https://developers.google.com/identity/protocols/OAuth2WebServer


    // the videos have been a great step by step help in creating this there was the aspone method but after research i felt the gdata method was easier for me to understand
    public partial class addressbook : Page
    {
        private readonly OAuth2Parameters _oAuth2Parameters = new OAuth2Parameters
        {
            ClientId = "641646083232-is46s4sj4jr92resqrpk129h848hnh82.apps.googleusercontent.com",
            //acquire from google api app
            ClientSecret = "F8f1vfmcHgM3UgiKwweOVh85", //acquire from google api app it is the secret code needed for the program to access the contacts
            //normally it is hashed to prevent hackers
            RedirectUri = "http://localhost:60035/addressbook.aspx", //add to credentials in google api app
            Scope = "https://www.googleapis.com/auth/contacts", //allow through google api app
            AccessType = "offline",
            TokenType = "refresh"
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!String.IsNullOrWhiteSpace(Request.QueryString["code"]) && Session["token"] == null)
                {
                    _oAuth2Parameters.AccessCode = Request.QueryString["code"];

                    OAuthUtil.GetAccessToken(_oAuth2Parameters);

                    Session["token"] = _oAuth2Parameters;

                    ListContacts();
                }
                else if (Session["token"] == null)
                {
                    string url = OAuthUtil.CreateOAuth2AuthorizationUrl(_oAuth2Parameters);

                    Response.Redirect(url);
                }

                ListContacts();
            }
        }

        private void ListContacts()
        {
            var cr = new ContactsRequest(new RequestSettings("myapp", (OAuth2Parameters) Session["token"]){PageSize = int.MaxValue, AutoPaging = false});
            Feed<Contact> f = cr.GetContacts();

            var table = new DataTable();
            table.Columns.Add("EmailID");

            foreach (Contact contact in f.Entries)
            {
                foreach (EMail email in contact.Emails)
                {
                    DataRow row = table.NewRow();
                    row["EmailID"] = email.Address;
                    table.Rows.Add(row);
                }

                // following contacts will be shown in a data grid vieww with the number of contacts the user has
                grdEmails.DataSource = table;
                grdEmails.DataBind();
                lblInfo.Text = "total contacts: " + table.Rows.Count;
            }
        }

        private void ListContacts(ContactsRequest cr)
        {
            Feed<Contact> f = cr.GetContacts();

            var table = new DataTable();
            table.Columns.Add("EmailID");

            foreach (Contact contact in f.Entries)
            {
                foreach (EMail email in contact.Emails)
                {
                    DataRow row = table.NewRow();
                    row["EmailID"] = email.Address;
                    table.Rows.Add(row);
                }

                // following contacts will be shown in a data grid vieww with the number of contacts the user has
                grdEmails.DataSource = table;
                grdEmails.DataBind();
                lblInfo.Text = "total contacts: " + table.Rows.Count;
            }
        }

        protected void grdEmails_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            grdEmails.EditIndex = e.NewEditIndex;

            ListContacts();
        }

        protected void grdEmails_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdEmails.EditIndex = -1;

        }

        protected void grdEmails_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // first of we select the email contact and then delete it 
            var selectedEmail = ((HiddenField) grdEmails.Rows[e.RowIndex].FindControl("hdEmailID")).Value;

            var cr = new ContactsRequest(new RequestSettings("myapp", (OAuth2Parameters)Session["token"]) { PageSize = int.MaxValue, AutoPaging = false });
            Feed<Contact> f = cr.GetContacts();
            foreach (Contact contact in f.Entries)
            {
                foreach (EMail email in contact.Emails)
                {
                    if (selectedEmail == email.Address)
                    {
                        cr.Delete(contact);
                        Response.Write(
                            "please wait for a few seconds then refresh for changes to take place due to the google server thank you");

                        break;
                    }
                }
            }
            ListContacts(cr);
        }

        protected void grdEmails_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var selectedEmail = ((HiddenField) grdEmails.Rows[e.RowIndex].FindControl("hdEmailID")).Value;

            var cr = new ContactsRequest(new RequestSettings("myapp", (OAuth2Parameters)Session["token"]) { PageSize = int.MaxValue, AutoPaging = false });
            Feed<Contact> f = cr.GetContacts();
            foreach (Contact contact in f.Entries)
            {
                foreach (EMail email in contact.Emails)
                {
                    if (selectedEmail == email.Address)
                    {
                        email.Address = ((TextBox) grdEmails.Rows[e.RowIndex].FindControl("txtEmailID")).Text;
                        cr.Update(contact);
                        Response.Write(
                            "please wait for a few seconds then refresh for changes to take place due to the google server thank you");
                        break;
                    }
                }
            }
            grdEmails.EditIndex = -1;
            ListContacts(cr);
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            var newEnt = new Contact
            {
                Name = new Name
                {
                    FullName = txtFirst.Text + " " + txtLast.Text,
                    GivenName = txtFirst.Text,
                    FamilyName = txtLast.Text,
                }
            };
            // Set the contact's name.
            // Set the contact's e-mail addresses.
            newEnt.Emails.Add(new EMail
            {
                Primary = true,
                Rel = ContactsRelationships.IsHome,
                Address = txtEmail.Text
            });

            newEnt.IMs.Add(new IMAddress
            {
                Address = txtEmail.Text,
                Primary = true,
                Rel = ContactsRelationships.IsHome,
                Protocol = ContactsProtocols.IsGoogleTalk,
            });

            var cr = new ContactsRequest(new RequestSettings("myapp", (OAuth2Parameters)Session["token"]) { PageSize = int.MaxValue, AutoPaging = false });

            cr.Insert(cr.GetContacts(), newEnt);

            ListContacts(cr);
            Response.Write("please refresh the page for the add to happen");
        }
    }
}