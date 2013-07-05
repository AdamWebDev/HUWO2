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
                Function.AddInitialItem(ddCoordinators);
                ddCoordinators.DataSource = WO.GetCoordinators();
                ddCoordinators.DataValueField = "ID";
                ddCoordinators.DataTextField = "FullName";
                ddCoordinators.DataBind();

                // populate Ad Type
                Function.AddInitialItem(ddAdType);
                ddAdType.DataSource = RadioWO.GetRadioAdTypes();
                ddAdType.DataValueField = "ID";
                ddAdType.DataTextField = "Value";
                ddAdType.DataBind();

                // populate month dropdown
                Function.AddInitialItem(ddAiringMonth);
                DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
                for (int i = 1; i < 13; i++)
                {
                    ddAiringMonth.Items.Add(new ListItem(info.GetMonthName(i), i.ToString()));
                    ddAiringMonth.DataBind();
                }

                // populate Radio Stations
                Function.AddInitialItem(ddRadioStation);
                ddRadioStation.DataSource = RadioWO.GetRadioStations();
                ddRadioStation.DataValueField = "ID";
                ddRadioStation.DataTextField = "Value";
                ddRadioStation.DataBind();

                // populate Ad Length
                Function.AddInitialItem(ddLengthOfAd);
                ddLengthOfAd.DataSource = RadioWO.GetRadioAdLengths();
                ddLengthOfAd.DataValueField = "ID";
                ddLengthOfAd.DataTextField = "Value";
                ddLengthOfAd.DataBind();

                // populate Recording Options
                Function.AddInitialItem(ddRecordingOptions);
                ddRecordingOptions.DataSource = RadioWO.GetRecordingOptions();
                ddRecordingOptions.DataValueField = "ID";
                ddRecordingOptions.DataTextField = "Value";
                ddRecordingOptions.DataBind();
            }
        }

        protected void ddAdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddAdType.SelectedItem.Value.Equals("1")) // Monthly Sponsorship
            {
                Function.ShowControls(phMonthly);
                Function.ShowControls(phAdditionalInfo);
                Function.ClearControls(phIndividual, false);
                btnSubmit.Visible = true;
            }
            else if (ddAdType.SelectedItem.Value.Equals("2")) // Individual 
            {
                Function.ShowControls(phAdditionalInfo);
                Function.ShowControls(phIndividual);
                Function.ClearControls(phMonthly, false);
                btnSubmit.Visible = true;
            }
            else
            {
                Function.ClearControls(phAdditionalInfo, false);
                Function.ClearControls(phIndividual, false);
                Function.ClearControls(phMonthly, false);
                btnSubmit.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // from the information provided, create us a due date to store
            DateTime duedate;
            if (ddAdType.SelectedValue.Equals("1"))
            {
                String strDate = "01/" + ddAiringMonth.SelectedValue + "/" + DateTime.Now.Year;
                duedate = DateTime.ParseExact(strDate, "dd/M/yyyy", CultureInfo.InvariantCulture);
                if (duedate < DateTime.Now)
                    duedate = duedate.AddYears(1);
            }
            else
                duedate = DateTime.ParseExact(txtStartAiringDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            
            btnSubmit.Enabled = false;

            // submit!
            int ID;
            using (WOLinqClassesDataContext db = new WOLinqClassesDataContext())
            {
                Workorder w = new Workorder();
                w.submitted_date = DateTime.Now;
                w.submitted_by = Function.GetUserName();
                w.wotype = 3;
                w.duedate = duedate;
                w.coordinator = int.Parse(ddCoordinators.SelectedValue);
                w.title = "Radio Ad";
                w.status = 1;
                db.Workorders.InsertOnSubmit(w);

                WorkOrdersRadio r = new WorkOrdersRadio();
                r.Workorder = w;
                r.AdType = int.Parse(ddAdType.SelectedValue);
                r.AiringMonth = ddAiringMonth.SelectedIndex > 0 ? int.Parse(ddAiringMonth.SelectedValue) : (int?)null;
                r.RadioStation = ddRadioStation.SelectedIndex > 0 ? int.Parse(ddRadioStation.SelectedValue) : (int?)null;
                r.LengthOfAd = ddLengthOfAd.SelectedIndex > 0 ? int.Parse(ddLengthOfAd.SelectedValue) : (int?)null;
                r.StartAiringDate = txtStartAiringDate.Text.ConvertToDate();
                r.EndAiringDate = txtEndAiringDate.Text.ConvertToDate();
                r.Budget = txtBudget.Text;
                r.GLCode = txtGLCode.Text;
                r.RecordingOptions = ddRecordingOptions.SelectedIndex > 0 ? int.Parse(ddRecordingOptions.SelectedValue) : (int?)null;
                r.Notes = txtNotes.Text;
                db.WorkOrdersRadios.InsertOnSubmit(r);
                db.SubmitChanges();
                ID = w.ID;
            }
            Function.LogAction(ID, "Work order created");
            Response.Redirect("~/MyWorkOrders.aspx?success=true");
        }
    }
}