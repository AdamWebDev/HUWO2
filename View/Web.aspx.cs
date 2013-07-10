using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2.View
{
    public partial class Web : System.Web.UI.Page
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
            WorkOrdersWeb wo = WebWO.GetWebWorkOrder(ID);
            if (wo != null)
            {
                lblTypeWebWork.Text = wo.WebType.Value;
                lblCoordinator.Text = wo.Workorder.User.FullName;
                lblWebsite.Text = wo.Website.HasValue ? wo.WebSites.Value : String.Empty;
                lblLocation.Text = WebWO.DisplayLocations(wo.Location);
                lblAtoZLocation.Text = wo.AtoZLocation;
                lblAtoZPostingDate.Text = wo.AtoZPostingDate.DisplayDate();
                lblAtoZRemovalDate.Text = wo.AtoZRemovalDate.DisplayDate();
                lblAtoZHeading.Text = wo.AtoZHeading;
                lblAtoZContent.Text = wo.AtoZContent;
                lblCalEventName.Text = wo.CalEventName;
                lblCalEventLocation.Text = wo.CalEventLocation;
                lblCalStartDate.Text = wo.CalEventStartDate.DisplayDate();
                lblCalStartTime.Text = wo.CalEventStartTime;
                lblCalEndDate.Text = wo.CalEventEndDate.DisplayDate();
                lblCalEndTime.Text = wo.CalEventEndTime;
                lblContactName.Text = wo.ContactName;
                lblContactEmail.Text = wo.ContactEmail;
                lblEventDesc.Text = wo.EventDescription;
                lblDatePosted.Text = wo.DateToBePosted.DisplayDate();
                lblTypeOfUpdate.Text = wo.TypeOfUpdate.HasValue ? wo.WebUpdateType.Value : String.Empty;
                lblDateToBeChanged.Text = wo.DateToBeChanged.DisplayDate();
                lblURL.Text = wo.UpdateLocation;
                lblUpdateDescription.Text = wo.UpdateDescription;
                lblRequestedURL.Text = wo.RequestedURL + wo.RequestedDomain;
                lblWebAdPostDate.Text = wo.WebAdPostDate.DisplayDate();
                lblWebAdRemovalDate.Text = wo.WebAdEndDate.DisplayDate();
                lblWebAdURL.Text = wo.WebAdURL;
                lblWebAdContent.Text = wo.WebAdContent;
                lblFacebookPostDate.Text = wo.FacebookPostDate.DisplayDate();
                lblFacebookContent.Text = wo.FacebookContent;
                lblNotes.Text = wo.Notes;
                lblCoordinatorNotes.Text = wo.Workorder.coordinatorNotes;
                pnNotification.Visible = wo.pID.HasValue;
                lnkRelatedWO.NavigateUrl = "~/View/Default.aspx?type=1&ID=" + wo.pID.ToString();

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
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}