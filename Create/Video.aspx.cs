using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using HNHUWO2.Classes;

namespace HNHUWO2.Create
{
    public partial class Video : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // populate Coordinators Drop Down
                ddCoordinators.AddInitialItem();
                ddCoordinators.DataSource = WO.GetCoordinators();
                ddCoordinators.DataValueField = "ID";
                ddCoordinators.DataTextField = "FullName";
                ddCoordinators.DataBind();

                // populate Video Sources
                ddVideoSource.AddInitialItem();
                ddVideoSource.DataSource = VideoWO.GetVideoSources();
                ddVideoSource.DataValueField = "ID";
                ddVideoSource.DataTextField = "Value";
                ddVideoSource.DataBind();

                // populate Video Destinations
                chkVideoDestination.DataSource = VideoWO.GetVideoDestinations();
                chkVideoDestination.DataValueField = "ID";
                chkVideoDestination.DataTextField = "Value";
                chkVideoDestination.DataBind();

                // populate Narration
                ddNarrator.AddInitialItem();
                ddNarrator.DataSource = VideoWO.GetNarration();
                ddNarrator.DataValueField = "ID";
                ddNarrator.DataTextField = "Value";
                ddNarrator.DataBind();

                cmpDueDate.ValueToCompare = DateTime.Today.ToShortDateString();

                CheckDate();
            }

        }

        protected void chkVideoDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool showOtherWebsite = false;
            bool showDVD = false;

            foreach (ListItem li in chkVideoDestination.Items)
            {
                if (li.Selected && li.Value.Equals("3")) // Other website
                    showOtherWebsite = true;
                else if (li.Selected && li.Value.Equals("4"))
                    showDVD = true;
            }
            if (showOtherWebsite)
                Function.ShowControls(phOtherWebsite);
            else
                Function.ClearControls(phOtherWebsite, false);
            if (showDVD)
                Function.ShowControls(phNumberDVDs);
            else
                Function.ClearControls(phNumberDVDs, false);
        }

        protected void ddBackgroundMusic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddBackgroundMusic.Value == true)
                Function.ShowControls(phBackgroundMusic);
            else
                Function.ClearControls(phBackgroundMusic, false);
        }

        protected void ddNarrationRequired_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddNarrationRequired.Value == true)
                Function.ShowControls(phNarration);
            else
                Function.ClearControls(phNarration, false);
        }

        protected void ddCreditsRequired_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddCreditsRequired.Value == true)
            {
                notDisclaimer.Type = Notification.Types.Information;
                notDisclaimer.Message = "Please attach the credit information at the bottom of this work order.";
                notDisclaimer.Visible = true;
            }
            else if (ddCreditsRequired.Value == false)
            {
                notDisclaimer.Type = Notification.Types.Attention;
                notDisclaimer.Message = "Please note: Communications Services is not responsible if video footage is being distributed without proper permissions.";
                notDisclaimer.Visible = true;
            }
            else
                notDisclaimer.Visible = false;
        }

        protected void dddDueDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckDate();
        }

        protected void CheckDate()
        {
            int? daysNoticeNeeded = VideoWO.GetDaysNotice();
            if (daysNoticeNeeded.HasValue)
            {
                DateTime today = new DateTime();
                today = System.DateTime.Now;
                DateTime minDate = today.AddDays((int)daysNoticeNeeded);

                if (!txtDueDate.Text.Equals(String.Empty))
                {
                    DateTime dueDate = Convert.ToDateTime(txtDueDate.Text);
                    if (dueDate.Date.CompareTo(minDate.Date) < 0)
                    {
                        notDueDate.Type = Notification.Types.Attention;
                        notDueDate.Message = "Warning: Please be aware that the timeline you have provided does not comply with our Minimum Timelines guidelines. We require  " + daysNoticeNeeded.ToString() + " days of advanced notice. To follow our guidelines, the due date should be " + minDate.ToString("MMMM dd, yyyy") + ".  You will still be able to submit your work order, but be aware that the deadline may not be met.";
                        notDueDate.Visible = true;
                    }
                    else
                        notDueDate.Visible = false;
                }
                else
                {
                    notDueDate.Type = Notification.Types.Information;
                    notDueDate.Message = "This project needs " + daysNoticeNeeded.ToString() + " days to work on. According to our Minimum Timelines Guidelines, your minimum due date should be " + minDate.ToString("MMMM dd, yyyy") + ". You can still submit this work order, but be aware that your deadline may not be met.";
                    notDueDate.Visible = true;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;
            int ID = 0;
            using (WOLinqClassesDataContext db = new WOLinqClassesDataContext())
            {
                Workorder w = new Workorder();
                w.submitted_date = DateTime.Now;
                w.submitted_by = Function.GetUserName();
                w.wotype = 6;
                w.duedate = txtDueDate.Text.ConvertToDate();
                w.coordinator = int.Parse(ddCoordinators.SelectedValue);
                w.title = txtTitleVideo.Text;
                w.status = 1;
                db.Workorders.InsertOnSubmit(w);

                WorkOrdersVideo v = new WorkOrdersVideo();
                v.Workorder = w;
                v.VideoSource = int.Parse(ddVideoSource.SelectedValue);
                v.VideoDestination = Function.GetChecklistItems(chkVideoDestination);
                v.DestinationURL = txtDestinationURL.Text;
                v.NumberDVDs = txtNumberDVDs.Text;
                v.VideoLength = txtVideoLength.Text;
                v.BackgroundMusic = ddBackgroundMusic.Value;
                v.SongChoices = txtSongChoices.Text;
                v.NarrationReqd = ddNarrationRequired.Value;
                v.Narrator = ddNarrator.SelectedIndex;
                v.VideoDescription = txtVideoDescription.Text;
                v.CreditsRequired = ddCreditsRequired.Value;
                v.Notes = txtNotes.Text;
                db.WorkOrdersVideos.InsertOnSubmit(v);
                db.SubmitChanges();
                ID = w.ID;
                Function.LogAction(ID, "Work order created");
                WO.UploadFiles(w.ID, AttachedFiles.UploadedFiles);
                Response.Redirect("~/MyWorkOrders.aspx?success=true&ID=" + ID + "&type=" + w.wotype);
            }
            
         }
    }
}