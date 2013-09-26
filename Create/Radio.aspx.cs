using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using HNHUWO2.Classes;

namespace HNHUWO2.Create
{
    public partial class Radio : System.Web.UI.Page
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

                // populate Ad Type
                ddAdType.AddInitialItem();
                ddAdType.DataSource = RadioWO.GetRadioAdTypes();
                ddAdType.DataValueField = "ID";
                ddAdType.DataTextField = "Value";
                ddAdType.DataBind();

                // populate month dropdown
                ddAiringMonth.AddInitialItem();
                DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
                for (int i = 1; i < 13; i++)
                {
                    ddAiringMonth.Items.Add(new ListItem(info.GetMonthName(i), i.ToString()));
                    ddAiringMonth.DataBind();
                }

                // populate Radio Stations
                ddRadioStation.AddInitialItem();
                ddRadioStation.DataSource = RadioWO.GetRadioStations();
                ddRadioStation.DataValueField = "ID";
                ddRadioStation.DataTextField = "Value";
                ddRadioStation.DataBind();

                // populate Ad Length
                ddLengthOfAd.AddInitialItem();
                ddLengthOfAd.DataSource = RadioWO.GetRadioAdLengths();
                ddLengthOfAd.DataValueField = "ID";
                ddLengthOfAd.DataTextField = "Value";
                ddLengthOfAd.DataBind();

                // populate Recording Options
                ddRecordingOptions.AddInitialItem();
                ddRecordingOptions.DataSource = RadioWO.GetRecordingOptions();
                ddRecordingOptions.DataValueField = "ID";
                ddRecordingOptions.DataTextField = "Value";
                ddRecordingOptions.DataBind();

                // load the date comparison validator to make sure that dates are AFTER today
                cmpStartAiringDate.ValueToCompare = DateTime.Today.ToShortDateString();
            }
        }

        /// <summary>
        /// Conditional fields based on ad type
        /// </summary>
        protected void ddAdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddAdType.SelectedItem.Value.Equals("1")) // Monthly Sponsorship
            {
                Function.ShowControls(phMonthly);
                btnSubmit.Visible = true;
            }
            else if (ddAdType.SelectedItem.Value.Equals("2")) // Individual 
            {
                Function.ShowControls(phIndividual);
                Function.ClearControls(phMonthly, false);
                btnSubmit.Visible = true;
            }
            else
            {
                Function.ClearControls(phIndividual, false);
                Function.ClearControls(phMonthly, false);
                btnSubmit.Visible = false;
            }
        }


        /// <summary>
        /// Conditional fields based on Radio Station
        /// </summary>
        protected void ddRadioStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddRadioStation.SelectedItem.Text.Equals("Other")) Function.ShowControls(phRadioStationOther);
            else Function.ClearControls(phRadioStationOther, false);
        }

        /// <summary>
        /// Submit the form!
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false; // prevent double submission

            // from the information provided, create us a due date to store
            DateTime? duedate;
            if (ddAdType.SelectedValue.Equals("1"))
            {
                String strDate =  DateTime.Now.Year + "/" + ddAiringMonth.SelectedValue + "/01";
                duedate = strDate.ConvertToDate();
                if (duedate.HasValue && duedate < DateTime.Now)
                    duedate = duedate.Value.AddYears(1);
            }
            else
                duedate = (DateTime)txtStartAiringDate.Text.ConvertToDate();
            
            // submit!
            using (WOLinqClassesDataContext db = new WOLinqClassesDataContext())
            {
                // skip the approval process for designers and coordinators
                bool IsUserDesigner = Users.IsUserDesigner();
                bool NeedsApproval = !IsUserDesigner && !Users.IsUserCoordinator();
                Workorder w = new Workorder();
                w.submitted_date = DateTime.Now;
                w.submitted_by = Function.GetUserName();
                w.wotype = 3;
                w.duedate = duedate;
                w.ProgramManager = int.Parse(ddCoordinators.SelectedValue);
                w.title = "Radio Ad";
                w.status = NeedsApproval ? 1 : 2;
                db.Workorders.InsertOnSubmit(w);

                WorkOrdersRadio r = new WorkOrdersRadio();
                r.Workorder = w;
                r.AdType = int.Parse(ddAdType.SelectedValue);
                r.AiringMonth = ddAiringMonth.SelectedIndex > 0 ? int.Parse(ddAiringMonth.SelectedValue) : (int?)null;
                r.RadioStation = ddRadioStation.SelectedIndex > 0 ? int.Parse(ddRadioStation.SelectedValue) : (int?)null;
                r.RadioStationOther = txtRadioStationOther.Text;
                r.LengthOfAd = ddLengthOfAd.SelectedIndex > 0 ? int.Parse(ddLengthOfAd.SelectedValue) : (int?)null;
                r.StartAiringDate = txtStartAiringDate.Text.ConvertToDate();
                r.EndAiringDate = txtEndAiringDate.Text.ConvertToDate();
                r.Budget = txtBudget.Text;
                r.RecordingOptions = ddRecordingOptions.SelectedIndex > 0 ? int.Parse(ddRecordingOptions.SelectedValue) : (int?)null;
                r.Notes = txtNotes.Text;
                db.WorkOrdersRadios.InsertOnSubmit(r);
                db.SubmitChanges();
                int ID = w.ID;
                // upload attached files
                WO.UploadFiles(w.ID, AttachedFiles.UploadedFiles);
                // log the activity
                WO.LogAction(ID, "Work order created");
                // send notificaiton if needed
                WO.SendNewWONotification(ID, NeedsApproval, IsUserDesigner);
                // complete!
                Response.Redirect("~/MyWorkOrders.aspx?success=true&ID=" + ID + "&type=" + w.wotype);
            }
            
        }
    }
}