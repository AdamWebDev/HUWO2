using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2.View
{
    public partial class Video : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int ID;
                if (Int32.TryParse(Request.QueryString["ID"], out ID))
                    PopulatePage(ID);
                else
                    Response.Redirect("~/Default.aspx");
            }
        }

       

        public void PopulatePage(int ID)
        {
            WorkOrdersVideo wo = VideoWO.GetVideoWorkOrder(ID);
            if (wo != null)
            {
                lblID.Text = wo.wID.ToString();
                lblStatus.Text = wo.Workorder.Status1.status;
                lblTitleVideo.Text = wo.Workorder.title;
                lblProgramManager.Text = wo.Workorder.User.FullName;
                lblVideoSource.Text = wo.VideoSource.HasValue ? wo.VideoSources.Value : String.Empty;
                lblVideoDestination.Text = VideoWO.DisplayFormats(wo.VideoDestination);
                lblVideoDestinationOther.Text = wo.DestinationURL;
                lblNumberDVDs.Text = wo.NumberDVDs;
                lblVideoLength.Text = wo.VideoLength;
                lblDueDate.Text = wo.Workorder.duedate.DisplayDate();
                lblBackgroundMusic.Text = wo.BackgroundMusic.ToYesNoString();
                lblSongChoices.Text = wo.SongChoices;
                lblNarrationRequired.Text = wo.NarrationReqd.ToYesNoString();
                lblNarrator.Text = wo.Narrator.HasValue ? wo.VideoNarration.Value : String.Empty;
                lblVideoDescription.Text = wo.VideoDescription;
                lblCreditsRequired.Text = wo.CreditsRequired.ToYesNoString();
                lblNotes.Text = wo.Notes;
                lblCoordinatorNotes.Text = wo.Workorder.coordinatorNotes;
                statusMessages.DisplayMessage(wo.Workorder.status);
                attachedFiles.UpdateFileList(wo.wID);
            }
            else Response.Redirect("~/Default.aspx");
        }
    }
}