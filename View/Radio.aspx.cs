using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2.View
{
    public partial class Radio : System.Web.UI.Page
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
            WorkOrdersRadio wo = RadioWO.GetRadioWorkOrder(ID);
            if (wo != null)
            {
                lblID.Text = wo.wID.ToString();
                lblStatus.Text = wo.Workorder.Status1.status;
                lblAdType.Text = wo.RadioAdType.Value;
                lblProgramManager.Text = wo.Workorder.User.FullName;
                lblAiringMonth.Text = wo.AiringMonth.HasValue ? System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)wo.AiringMonth) : String.Empty;
                if (wo.RadioStation.HasValue) lblRadioStation.Text = String.IsNullOrEmpty(wo.RadioStationOther) ? wo.RadioStations.Value : wo.RadioStationOther;
                lblLengthOfAd.Text = wo.LengthOfAd.HasValue ? wo.RadioLength.Value : String.Empty;
                lblStartAiringDate.Text = wo.StartAiringDate.DisplayDate();
                lblEndAiringDate.Text = wo.EndAiringDate.DisplayDate();
                lblBudget.Text = wo.Budget;
                lblRecordingOptions.Text = wo.RecordingOptions.HasValue ? wo.RadioRecordingOption.Value : String.Empty;
                lblNotes.Text = wo.Notes;
                lblCoordinatorNotes.Text = wo.Workorder.coordinatorNotes;
                if (Page.IsPostBack) statusMessages.DisplayMessage(wo.Workorder.status);
                attachedFiles.UpdateFileList(wo.wID);
            }
            else Response.Redirect("~/Default.aspx");
        }
    }
}