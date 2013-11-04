using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2.Admin
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Classes.Users.IsUserDesigner())
                {
                    int ID;
                    // make sure the user ID is valid, then populate the form
                    if (int.TryParse(Request.QueryString["ID"], out ID))
                    {
                        User u = Classes.Admin.GetUser(ID);
                        txtUsername.Text = u.Username;
                        txtFullName.Text = u.FullName;
                        txtEmail.Text = u.Email;

                        ddRole.DataSource = Classes.Admin.GetRoles();
                        ddRole.DataTextField = "Role";
                        ddRole.DataValueField = "ID";
                        ddRole.DataBind();

                        ddRole.SelectedValue = u.Role.ToString();
                    }
                    // if user ID is invalid, send them back to the users page
                    else
                    {
                        Response.Redirect("~/Admin/Users.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        /// <summary>
        /// Saves changes to the user account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (WOLinqClassesDataContext db = new WOLinqClassesDataContext())
            {
                int ID = int.Parse(Request.QueryString["ID"]);
                User u = db.Users.Single(z => z.ID == ID);
                u.Username = txtUsername.Text;
                u.FullName = txtFullName.Text;
                u.Email = txtEmail.Text;
                u.Role = int.Parse(ddRole.SelectedValue);
                db.SubmitChanges();
                notSuccess.Visible = true;
            }

        }
    }
}