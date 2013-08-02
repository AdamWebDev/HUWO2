using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;
using System.Net;

namespace HNHUWO2.Create
{
    public partial class Web : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                // Populating dropdown boxes
                ddCoordinators.AddInitialItem();
                ddCoordinators.DataSource = WO.GetCoordinators();
                ddCoordinators.DataValueField = "ID";
                ddCoordinators.DataTextField = "FullName";
                ddCoordinators.DataBind();

                chkLocation.DataSource = WebWO.GetLocations();
                chkLocation.DataTextField = "Value";
                chkLocation.DataValueField = "ID";
                chkLocation.DataBind();

                ddTypeWebWork.AddInitialItem();
                ddTypeWebWork.DataSource = WebWO.GetTypes();
                ddTypeWebWork.DataValueField = "ID";
                ddTypeWebWork.DataTextField = "Value";
                ddTypeWebWork.DataBind();

                ddTypeOfUpdate.AddInitialItem();
                ddTypeOfUpdate.DataSource = WebWO.GetUpdateTypes();
                ddTypeOfUpdate.DataValueField = "ID";
                ddTypeOfUpdate.DataTextField = "Value";
                ddTypeOfUpdate.DataBind();

                ddWebsite.AddInitialItem();
                ddWebsite.DataSource = WebWO.GetWebSites();
                ddWebsite.DataValueField = "ID";
                ddWebsite.DataTextField = "Value";
                ddWebsite.DataBind();

                // load the date comparison validator to make sure that dates are AFTER today
                cmpAtoZPostingDate.ValueToCompare = cmpCalStartDate.ValueToCompare = cmpDatePosted.ValueToCompare = cmpDateToBeChanged.ValueToCompare = cmpWebAdPostDate.ValueToCompare = cmpFacebookPostDate.ValueToCompare = DateTime.Today.ToShortDateString();

                // if user is being redirected from a successful print work order, let them know!
                if (Request.QueryString["AddTo"] != null)
                {
                    notMain.Message = "Your print work order has been created! Now, just let us know some details about adding this to the website. Note - if you uploaded some related files already to the print work order, you don't have to upload them again here.";
                    notMain.Type = Notification.Types.Success;
                    notMain.Visible = true;

                    // if the user is coming from a print work order, let's help them out and automatically pick the same
                    // ProgramManager as the print work order.
                    int wID;
                    if (int.TryParse(Request.QueryString["AddTo"],out wID)) {
                        Workorder w = WO.GetWorkOrder(wID);
                        ddCoordinators.SelectedValue = w.ProgramManager.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Shows the relevant information based on the Type of Work Order created
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddTypeWebWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddTypeWebWork.SelectedValue.Equals("1")) // new content
            {
                Function.ShowControls(phNewContent,false);
                Function.ClearControls(phOtherLocation, false);
                Function.ClearControls(phWebsite, false);
                Function.ClearControls(phUpdateContent, false);
                Function.ClearControls(phNewWebsite, false);
                Function.ClearControls(phCD989WebAd, false);
                Function.ClearControls(phFacebookStatus, false);
            }
            else if (ddTypeWebWork.SelectedValue.Equals("2")) // update content
            {
                Function.ShowControls(phWebsite);
                Function.ShowControls(phUpdateContent);
                Function.ClearControls(phNewContent, false);
                Function.ClearControls(phNewWebsite, false);
                Function.ClearControls(phCD989WebAd, false);
                Function.ClearControls(phFacebookStatus, false);
            }
            else if (ddTypeWebWork.SelectedValue.Equals("3")) // new website
            {
                Function.ShowControls(phNewWebsite);
                Function.ClearControls(phWebsite, false);
                Function.ClearControls(phNewContent, false);
                Function.ClearControls(phUpdateContent, false);
                Function.ClearControls(phCD989WebAd, false);
                Function.ClearControls(phFacebookStatus, false);
            }
            else if (ddTypeWebWork.SelectedValue.Equals("4")) // cd989
            {
                Function.ShowControls(phCD989WebAd);
                Function.ClearControls(phWebsite, false);
                Function.ClearControls(phNewContent, false);
                Function.ClearControls(phUpdateContent, false);
                Function.ClearControls(phNewWebsite, false);
                Function.ClearControls(phFacebookStatus, false);
            }
            else if (ddTypeWebWork.SelectedValue.Equals("5")) // facebook status update
            {
                Function.ShowControls(phFacebookStatus);
                Function.ClearControls(phWebsite, false);
                Function.ClearControls(phNewContent, false);
                Function.ClearControls(phUpdateContent, false);
                Function.ClearControls(phNewWebsite, false);
                Function.ClearControls(phCD989WebAd, false);
            }
            else // nothing selected
            {
                Function.ClearControls(phWebsite, false);
                Function.ClearControls(phNewContent, false);
                Function.ClearControls(phUpdateContent, false);
                Function.ClearControls(phNewWebsite, false);
                Function.ClearControls(phCD989WebAd, false);
                Function.ClearControls(phFacebookStatus, false);
            }
        }

        /// <summary>
        /// Show the releveant fields based on where the user wants their information posted.
        /// </summary>
        protected void chkLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool showNewContent = false;
            bool showCalendarInfo = false;
            bool showOtherLocation = false;
            foreach (ListItem li in chkLocation.Items)
            {
                if (li.Selected && (li.Value.Equals("1") || li.Value.Equals("3"))) // A to Z Directory, homepage
                {
                    showNewContent = true;
                }
                else if (li.Selected && li.Value.Equals("2")) // calendar
                {
                    showCalendarInfo = true;
                }
                else if (li.Selected && li.Value.Equals("4")) // other
                {
                    showOtherLocation = true;
                    showNewContent = true;
                }
            }
            if (showNewContent)
                Function.ShowControls(phAtoZ);
            else
                Function.ClearControls(phAtoZ, false);
            if (showCalendarInfo)
                Function.ShowControls(phCalendar);
            else
                Function.ClearControls(phCalendar, false);
            if (showOtherLocation)
                Function.ShowControls(phOtherLocation);
            else
                Function.ClearControls(phOtherLocation, false);
        }

        
        /// <summary>
        /// Submitting the form!
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false; // prevent double submission
            using (WOLinqClassesDataContext db = new WOLinqClassesDataContext())
            {
                // skip the approval process for designers and program managers
                bool NeedsApproval = Users.IsUserDesigner() || Users.IsUserCoordinator();
                Workorder w = new Workorder();
                w.submitted_date = DateTime.Now;
                w.submitted_by = Function.GetUserName();
                w.wotype = 2;

                // decide on the duedate based on which web work order selected
                switch (Int32.Parse(ddTypeWebWork.SelectedValue))
                {
                    case 1: // new content
                        w.duedate = txtAtoZPostingDate.Text.ConvertToDate(); break;
                    case 2: // update content
                        w.duedate = txtDateToBeChanged.Text.ConvertToDate(); break;
                    case 4: // cd989 web ad
                        w.duedate = txtWebAdPostDate.Text.ConvertToDate(); break;
                    case 5: // facebook status
                        w.duedate = txtFacebookPostDate.Text.ConvertToDate(); break;
                    default:
                    case 3: // new website
                        w.duedate = DateTime.Today; break;
                }
                w.ProgramManager = int.Parse(ddCoordinators.SelectedValue);
                w.title = "Website Update";
                w.status = NeedsApproval ? 4 : 1;
                db.Workorders.InsertOnSubmit(w);

                WorkOrdersWeb wow = new WorkOrdersWeb();
                wow.Workorder = w;
                wow.TypeWebWork = ddTypeWebWork.SelectedIndex > 0 ? int.Parse(ddTypeWebWork.SelectedValue) : (int?)null;
                wow.Website = ddWebsite.SelectedIndex > 0 ? int.Parse(ddWebsite.SelectedValue) : (int?)null;
                wow.Location = Function.GetChecklistItems(chkLocation);
                wow.AtoZLocation = txtAtoZLocation.Text;
                wow.AtoZPostingDate = txtAtoZPostingDate.Text.ConvertToDate();
                wow.AtoZRemovalDate = txtAtoZRemovalDate.Text.ConvertToDate();
                wow.AtoZHeading = txtAtoZHeading.Text;
                wow.AtoZContent = txtAtoZContent.Text;
                wow.CalEventName = txtCalEventName.Text;
                wow.CalEventLocation = txtCalEventLocation.Text;
                wow.CalEventStartDate = txtCalStartDate.Text.ConvertToDate();
                wow.CalEventStartTime = txtCalStartTime.Text;
                wow.CalEventEndDate = txtCalEndDate.Text.ConvertToDate();
                wow.CalEventEndTime = txtCalEndTime.Text;
                wow.ContactName = txtContactName.Text;
                wow.ContactEmail = txtContactEmail.Text;
                wow.EventDescription = txtEventDesc.Text;
                wow.DateToBePosted = txtDatePosted.Text.ConvertToDate();
                wow.TypeOfUpdate = ddTypeOfUpdate.SelectedIndex > 0 ? int.Parse(ddTypeOfUpdate.SelectedValue) : (int?)null;
                wow.DateToBeChanged = txtDateToBeChanged.Text.ConvertToDate();
                wow.UpdateLocation = txtURL.Text;
                wow.UpdateDescription = txtUpdateDesc.Text;
                wow.Budget = txtBudget.Text;
                wow.Timeframe = txtTimeFrame.Text;
                wow.Goals = txtGoals.Text;
                wow.Explanation = txtExplanation.Text;
                wow.Audience = txtAudience.Text;
                wow.NumberOfPages = txtNumberOfPages.Text;
                wow.WebAdPostDate = txtWebAdPostDate.Text.ConvertToDate();
                wow.WebAdEndDate = txtWebAdEndDate.Text.ConvertToDate();
                wow.WebAdURL = txtWebAdURL.Text;
                wow.WebAdContent = txtWebAdContent.Text;
                wow.FacebookPostDate = txtFacebookPostDate.Text.ConvertToDate();
                wow.FacebookContent = txtFacebookContent.Text;
                wow.Notes = txtNotes.Text;

                // if this was added on to a Print work order, let's link this to it!
                int pID = 0;
                if (int.TryParse(Request.QueryString["AddTo"], out pID))
                {
                    wow.pID = pID;
                }
                else
                    wow.pID = null;
                db.WorkOrdersWebs.InsertOnSubmit(wow);
                db.SubmitChanges();
                int ID = w.ID;

                // if we're linking print and web work orders, let's add the link to the print work order too so we can go back and forth easily
                if (pID != 0)
                {
                    WorkOrdersPrint p = db.WorkOrdersPrints.Single(u => u.wID == pID);
                    p.webID = ID;
                    db.SubmitChanges();
                }
                // upload attached files
                WO.UploadFiles(ID, AttachedFiles.UploadedFiles);
                // log actions
                WO.LogAction(ID, "Work order created.");
                // send notifications if necessary
                if (!NeedsApproval) WO.SendNewWONotification(ID);
                // redirect! hooray!
                Response.Redirect("~/MyWorkOrders.aspx?success=true&ID=" + ID + "&type=" + w.wotype);
            }
        }
    }
}