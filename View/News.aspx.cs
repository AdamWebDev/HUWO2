using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2.View
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID;
            if (Int32.TryParse(Request.QueryString["ID"], out ID)) 
                PopulatePage(ID);
            else
                Response.Redirect("~/Default.aspx");
        }

        protected void PopulatePage(int ID)
        {
            WorkOrdersNews wo = NewsWO.GetNewsWorkOrder(ID);
            lblCoordinator.Text = wo.Workorder.User.FullName;
            lblTitleTopic.Text = wo.Workorder.title;
            lblDateToIssue.Text = wo.Workorder.duedate.DisplayDate();
            lblDistributionOutlets.Text = wo.NewsDistroOutlet.Value;
            lblDistributionOutletsOther.Text = wo.DistributionDetails;
            lblContact.Text = wo.Contact;
            lblNotes.Text = wo.AdditionalNotes;

            if (wo.Workorder.status == 1 && (Users.IsUserCoordinator() || Users.IsUserAdmin()))
            {
                CoordinatorRevisions.Visible = true;
            }
            else
            {
                CoordinatorRevisions.Visible = false;
            }

            attachedFiles.Refresh();
        }
    }
}