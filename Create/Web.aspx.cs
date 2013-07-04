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
            /****************************************
                   Populating dropdown boxes
            ****************************************/

            if (!Page.IsPostBack)
            {
                ddCoordinators.DataSource = WO.GetCoordinators();
                ddCoordinators.DataValueField = "ID";
                ddCoordinators.DataTextField = "FullName";
                ddCoordinators.DataBind();

                chkLocation.DataSource = WebWO.GetLocations();
                chkLocation.DataTextField = "Value";
                chkLocation.DataValueField = "ID";
                chkLocation.DataBind();

                ddTypeWebWork.DataSource = WebWO.GetTypes();
                ddTypeWebWork.DataValueField = "ID";
                ddTypeWebWork.DataTextField = "Value";
                ddTypeWebWork.DataBind();

                ddTypeOfUpdate.DataSource = WebWO.GetUpdateTypes();
                ddTypeOfUpdate.DataValueField = "ID";
                ddTypeOfUpdate.DataTextField = "Value";
                ddTypeOfUpdate.DataBind();

                ddWebsite.DataSource = WebWO.GetWebSites();
                ddWebsite.DataValueField = "ID";
                ddWebsite.DataTextField = "Value";
                ddWebsite.DataBind();

                // if user is being redirected from a successful print work order, let them know!
                if (Request.QueryString["AddTo"] != null)
                {
                    notMain.Message = "Your print work order has been created! Now, just let us know some details about adding this to the website. Note - if you uploaded related already to the print work order, you don't have to upload them again here.";
                    notMain.Type = Notification.Types.Success;
                    notMain.Visible = true;
                }
            }
        }

        protected void ddTypeWebWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSubmit.Visible = true;
            if (ddTypeWebWork.SelectedValue.Equals("1")) // new content
            {
                Function.ShowControls(phNewContent);
                Function.ShowControls(phAdditionalInfo);
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
                Function.ShowControls(phAdditionalInfo);
                Function.ClearControls(phNewContent, false);
                Function.ClearControls(phNewWebsite, false);
                Function.ClearControls(phCD989WebAd, false);
                Function.ClearControls(phFacebookStatus, false);
            }
            else if (ddTypeWebWork.SelectedValue.Equals("3")) // new website
            {
                Function.ShowControls(phNewWebsite);
                Function.ShowControls(phAdditionalInfo);
                Function.ClearControls(phWebsite, false);
                Function.ClearControls(phNewContent, false);
                Function.ClearControls(phUpdateContent, false);
                Function.ClearControls(phCD989WebAd, false);
                Function.ClearControls(phFacebookStatus, false);
            }
            else if (ddTypeWebWork.SelectedValue.Equals("4")) // cd989
            {
                Function.ShowControls(phCD989WebAd);
                Function.ShowControls(phAdditionalInfo);
                Function.ClearControls(phWebsite, false);
                Function.ClearControls(phNewContent, false);
                Function.ClearControls(phUpdateContent, false);
                Function.ClearControls(phNewWebsite, false);
                Function.ClearControls(phFacebookStatus, false);
            }
            else if (ddTypeWebWork.SelectedValue.Equals("5")) // facebook status update
            {
                Function.ShowControls(phFacebookStatus);
                Function.ShowControls(phAdditionalInfo);
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
                Function.ClearControls(phAdditionalInfo, false);
            }
        }

        protected void ddWebsite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddWebsite.SelectedValue.Equals("7")) // other
                Function.ShowControls(phWebsiteOther);
            else
                Function.ClearControls(phWebsiteOther);
        }

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

        protected void btnCheckAvailable_OnClick(object sender, EventArgs e)
        {
            WebResponse response = null;
            String data = String.Empty;
            String url = "http://www." + txtRequestedURL.Text + ddDomain.SelectedValue;

            try
            {
                WebRequest request = WebRequest.Create(url);
                response = request.GetResponse();

                // domain exists, valid domain
                notURLAvailable.Type = Notification.Types.Error;
                notURLAvailable.Message = "Domain name is taken. Please try again.";
                notURLAvailable.Visible = true;
            }
            catch (WebException ee)
            {
                // return false, most likely this domain doesn't exists
                notURLAvailable.Type = Notification.Types.Success;
                notURLAvailable.Message = "Domain name is available!";
                notURLAvailable.Visible = true;
                ee.ToString();
            }
            catch (Exception ee)
            {
                notURLAvailable.Type = Notification.Types.Error;
                notURLAvailable.Message = "There was an error - not sure if this domain name exists.";
                notURLAvailable.Visible = true;
                ee.ToString();
            }
            finally
            {
                if (response != null) response.Close();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false; // prevent double submission
            int ID = 0;
            using (WOLinqClassesDataContext db = new WOLinqClassesDataContext())
            {
                Workorder w = new Workorder();
                w.submitted_date = DateTime.Now;
                w.submitted_by = Function.GetUserName();
                w.wotype = 2;

                // decide on the duedate based on which web work order selected
                switch (Int32.Parse(ddTypeWebWork.SelectedValue))
                {
                    case 1: // new content
                        w.duedate = Function.FormatDate(txtAtoZPostingDate.Text); break;
                    case 2: // update content
                        w.duedate = Function.FormatDate(txtDateToBeChanged.Text); break;
                    case 4: // cd989 web ad
                        w.duedate = Function.FormatDate(txtWebAdPostDate.Text); break;
                    case 5: // facebook status
                        w.duedate = Function.FormatDate(txtFacebookPostDate.Text); break;
                    default:
                    case 3: // new website
                        w.duedate = DateTime.Today; break;
                }
                w.coordinator = int.Parse(ddCoordinators.SelectedValue);
                w.title = "Website Update";
                w.status = 1;
                db.Workorders.InsertOnSubmit(w);
                WorkOrdersWeb wow = new WorkOrdersWeb();
                wow.Workorder = w;
                wow.TypeWebWork = ddTypeWebWork.SelectedIndex > 0 ? int.Parse(ddTypeWebWork.SelectedValue) : (int?)null;
                wow.Website = ddWebsite.SelectedIndex > 0 ? int.Parse(ddWebsite.SelectedValue) : (int?)null;
                wow.WebsiteOther = txtWebsiteOther.Text;
                wow.Location = Function.GetChecklistItems(chkLocation);
                wow.AtoZLocation = txtAtoZLocation.Text;
                wow.AtoZPostingDate = Function.FormatDate(txtAtoZPostingDate.Text);
                wow.AtoZRemovalDate = Function.FormatDate(txtAtoZRemovalDate.Text);
                wow.AtoZHeading = txtAtoZHeading.Text;
                wow.AtoZContent = txtAtoZContent.Text;
                wow.CalEventName = txtCalEventName.Text;
                wow.CalEventLocation = txtCalEventLocation.Text;
                wow.CalEventStartDate = Function.FormatDate(txtCalStartDate.Text);
                wow.CalEventStartTime = txtCalStartTime.Text;
                wow.CalEventEndDate = Function.FormatDate(txtCalEndDate.Text);
                wow.CalEventEndTime = txtCalEndTime.Text;
                wow.ContactName = txtContactName.Text;
                wow.ContactEmail = txtContactEmail.Text;
                wow.EventDescription = txtEventDesc.Text;
                wow.DateToBePosted = Function.FormatDate(txtDatePosted.Text);
                wow.TypeOfUpdate = ddTypeOfUpdate.SelectedIndex > 0 ? int.Parse(ddTypeOfUpdate.SelectedValue) : (int?)null;
                wow.DateToBeChanged = Function.FormatDate(txtDateToBeChanged.Text);
                wow.UpdateLocation = txtURL.Text;
                wow.UpdateDescription = txtUpdateDesc.Text;
                wow.RequestedURL = txtRequestedURL.Text;
                wow.RequestedDomain = ddDomain.SelectedValue;
                wow.WebAdPostDate = Function.FormatDate(txtWebAdPostDate.Text);
                wow.WebAdEndDate = Function.FormatDate(txtWebAdEndDate.Text);
                wow.WebAdURL = txtWebAdURL.Text;
                wow.WebAdContent = txtWebAdContent.Text;
                wow.FacebookPostDate = Function.FormatDate(txtFacebookPostDate.Text);
                wow.FacebookContent = txtFacebookContent.Text;
                wow.Notes = txtNotes.Text;

                int pID;
                if (int.TryParse(Request.QueryString["AddTo"], out pID))
                    wow.pID = pID;
                else
                    wow.pID = null;
                db.WorkOrdersWebs.InsertOnSubmit(wow);
                db.SubmitChanges();
                ID = w.ID;
            }
            
            Function.LogAction(ID, "Work order created.");
            Response.Redirect("~/MyWorkOrders.aspx?success=true");
            
        }
    }
}