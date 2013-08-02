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
                // populate the page!
                if (Int32.TryParse(Request.QueryString["ID"], out ID))
                {
                    PopulatePage(ID);
                    attachedFiles.UpdateFileList(ID);
                }
                else
                    Response.Redirect("~/Default.aspx");
            }
        }

        /// <summary>
        /// Populate the page with the appropriate information
        /// </summary>
        /// <param name="ID">Work order ID</param>
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
                lblDistributionOutlets.Text = wo.DistributionDetails.Equals(String.Empty) ? wo.NewsDistroOutlet.Value : wo.DistributionDetails;
                lblContact.Text = wo.Contact;
                lblNotes.Text = wo.AdditionalNotes;
                lblCoordinatorNotes.Text = wo.Workorder.coordinatorNotes;
                // if the page is posted, the status was changed - so let's confirm!
                if (Page.IsPostBack) statusMessages.DisplayMessage(wo.Workorder.status);
                // show attached files
                attachedFiles.UpdateFileList(wo.wID);

            }
            else Response.Redirect("~/Default.aspx");
        }
    }
}