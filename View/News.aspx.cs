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
            if (!Page.IsPostBack) {
                int ID;
                if (Int32.TryParse(Request.QueryString["ID"], out ID)) 
                    PopulatePage(ID);
                else
                    Response.Redirect("~/Default.aspx");
            }
            RefreshFiles();

        }

        public void RefreshFiles()
        {
            attachedFiles.Refresh();
        }


        public void PopulatePage(int ID)
        {
            WorkOrdersNews wo = NewsWO.GetNewsWorkOrder(ID);
            if (wo != null)
            {
                lblID.Text = wo.wID.ToString();
                lblStatus.Text = wo.Workorder.Status1.status;
                lblProgramManager.Text = wo.Workorder.User.FullName;
                lblTitleTopic.Text = wo.Workorder.title;
                lblDateToIssue.Text = wo.Workorder.duedate.DisplayDate();
                lblDistributionOutlets.Text = wo.DistributionDetails == null ? wo.NewsDistroOutlet.Value : wo.DistributionDetails;
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

                RefreshFiles();

            }
            else Response.Redirect("~/Default.aspx");
        }
    }
}