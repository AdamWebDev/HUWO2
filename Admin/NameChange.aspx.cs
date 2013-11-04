using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNHUWO2.Admin
{
    public partial class NameChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // ensure user has permission to access the page!
            if (!Classes.Users.IsUserDesigner())
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnLookupUsername_Click(object sender, EventArgs e)
        {
            txtNewUserName.Text = String.Empty;
            phResults.Visible = true;
            int woCount = Classes.WO.WorkOrderCount(txtOldUserName.Text);
            ltResultCount.Text = woCount.ToString();
            int actCount = Classes.WO.ActivityCount(txtOldUserName.Text);
            ltActivityCount.Text = actCount.ToString();

            // allow username to be changed if there are results 
            phNewUserName.Visible = (woCount + actCount > 0);
        }

        protected void btnChangeName_Click(object sender, EventArgs e)
        {
            Classes.WO.ChangeUserName(txtOldUserName.Text, txtNewUserName.Text, int.Parse(ltResultCount.Text), int.Parse(ltActivityCount.Text));
            notSuccess.Visible = true;
        }
    }
}