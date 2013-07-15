using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace HNHUWO2.Admin
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddRole.DataSource = HNHUWO2.Classes.Admin.GetRoles();
                ddRole.DataTextField = "Role";
                ddRole.DataValueField = "ID";
                ddRole.DataBind();

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // let's make sure the username exists in AD...
            if (Classes.Users.DoesUserExist(txtUsername.Text))
            {
                using (WOLinqClassesDataContext db = new WOLinqClassesDataContext())
                {
                    // next, let's make sure the user isn't already in the system...
                    if (db.Users.Any(u => u.Username == txtUsername.Text))
                    {
                        notSuccess.Type = Notification.Types.Error;
                        notSuccess.Message = "It looks like this user already exists in the system...";
                        notSuccess.Visible = true;
                    } 
                    else {
                        User u = new User();
                        u.Username = txtUsername.Text;
                        u.FullName = txtFullName.Text;
                        u.Email = txtEmail.Text;
                        u.Role = int.Parse(ddRole.SelectedValue);
                        db.Users.InsertOnSubmit(u);
                        db.SubmitChanges();
                        SendWelcomeEmail(u.Email);
                        notSuccess.Visible = true;

                    }
                }
            }
            else
            {
                notSuccess.Type = Notification.Types.Error;
                notSuccess.Message = "Sorry - it doesn't seem that this username exists...";
                notSuccess.Visible = true;
            }
        }

        

        protected void SendWelcomeEmail(string emailAddress)
        {
            String subject = "You now have access to the Health Unit Work Order System!";
            String message =    "Greetings!<br /><br />";
            message += "You now have additional priveleges on the Health Unit Work Order System! Woohoo!<br /><br />";
            message += "To access the Work Order System, just visit the follow link:<br /><br />";
            message += "<a href=\"http://huwo.hnhu.org\">http://huwo.hnhu.org</a>";
            message += "There's nothing special you need to do - you'll just notice that you have a few extra menu options to choose from!<br /><br />";
            message += "If you need any additional assistance, please contact the Communications Services Team!<br /><br />";
            message += "Thank you,<br /><br />Your friendly neighbourhood Work Order System";
            MailMessage mail = new MailMessage("no-reply@hnhu.org", emailAddress, subject, message);
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}