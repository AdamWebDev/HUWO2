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
            int ID;
            if (Int32.TryParse(Request.QueryString["ID"], out ID))
                PopulatePage(ID);
            else
                Response.Redirect("~/Default.aspx");
        }

        protected void PopulatePage(int ID)
        {
            WorkOrdersRadio wo = RadioWO.GetRadioWorkOrder(ID);
            lblAdType.Text = wo.RadioAdType.Value;
            lblCoordinator.Text = wo.Workorder.User.FullName;
            lblAiringMonth.Text = wo.AiringMonth.HasValue ? System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)wo.AiringMonth) : String.Empty;
            lblRadioStation.Text = wo.RadioStation.HasValue ? wo.RadioStations.Value : String.Empty;
            lblLengthOfAd.Text = wo.LengthOfAd.HasValue ? wo.RadioLength.Value : String.Empty;
            lblStartAiringDate.Text = wo.StartAiringDate.DisplayDate();
            lblEndAiringDate.Text = wo.EndAiringDate.DisplayDate();
            lblBudget.Text = wo.Budget;
            lblGLCode.Text = wo.GLCode;
            lblRecordingOptions.Text = wo.RecordingOptions.HasValue ? wo.RadioRecordingOption.Value : String.Empty;
            lblNotes.Text = wo.Notes;
        }
    }
}