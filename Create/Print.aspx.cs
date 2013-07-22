using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using HNHUWO2.Classes;

namespace HNHUWO2.Create
{
    public partial class Print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // populate Drop Down boxes for the page
                ddCoordinators.AddInitialItem();
                ddCoordinators.DataSource = WO.GetCoordinators();
                ddCoordinators.DataValueField = "ID";
                ddCoordinators.DataTextField = "FullName";
                ddCoordinators.DataBind();

                ddTypeProject.AddInitialItem();
                ddTypeProject.DataSource = PrintWO.GetTypeOfProjects();
                ddTypeProject.DataTextField = "Value";
                ddTypeProject.DataValueField = "ID";
                ddTypeProject.DataBind();

                ddTypeOfDisplay.AddInitialItem();
                ddTypeOfDisplay.DataSource = PrintWO.GetTypeOfDisplays();
                ddTypeOfDisplay.DataTextField = "Value";
                ddTypeOfDisplay.DataValueField = "ID";
                ddTypeOfDisplay.DataBind();

                ddPrintingMethod.AddInitialItem();
                ddPrintingMethod.DataSource = PrintWO.GetPrintMethods();
                ddPrintingMethod.DataTextField = "Value";
                ddPrintingMethod.DataValueField = "ID";
                ddPrintingMethod.DataBind();

                ddPaperSize.AddInitialItem();
                ddPaperSize.DataSource = PrintWO.GetPaperSizes();
                ddPaperSize.DataTextField = "Value";
                ddPaperSize.DataValueField = "ID";
                ddPaperSize.DataBind();

                ddPaperType.AddInitialItem();
                ddPaperType.DataSource = PrintWO.GetPaperTypes();
                ddPaperType.DataTextField = "Value";
                ddPaperType.DataValueField = "ID";
                ddPaperType.DataBind();

                ddColourInfo.AddInitialItem();
                ddColourInfo.DataSource = PrintWO.GetColourInfo();
                ddColourInfo.DataTextField = "Value";
                ddColourInfo.DataValueField = "ID";
                ddColourInfo.DataBind();

                ddCredits.AddInitialItem();
                ddCredits.DataSource = PrintWO.GetCreditType();
                ddCredits.DataTextField = "Value";
                ddCredits.DataValueField = "ID";
                ddCredits.DataBind();

                cmpDueDate.ValueToCompare = DateTime.Today.ToShortDateString();

                // end of populating dropdown boxes

                // if requesting a quote (determinted by query string), set up form for commercial printing only
                if (Request.QueryString["quote"] != null && Request.QueryString["quote"].Equals("1"))
                {
                    ltPageTitle.Text = ltContentTitle.Text = "Get a Quote for Commercial Printing";
                    Function.ShowControls(phBudget);
                    notCommercialInfo.Visible = true;
                    Function.ShowControls(phCommercialPrint);
                    ddPrintingMethod.Items.FindByText("Commercial").Selected = true; // restrict printing method to commercial print
                    ddPrintingMethod.Enabled = false;
                }
                else // not a quote
                {
                    ltPageTitle.Text = ltContentTitle.Text = "Create a Print Work Order";
                }
            } 
        }

        protected void ddTypeProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            // show additional options depending on the type of project selected
            if (ddTypeProject.SelectedValue.Equals("3"))  // display
            {
                Function.ShowControls(phDisplay);
                Function.ClearControls(phProjectOther, false);
                Function.ClearControls(phPromoItem, false);
            }
            else if (ddTypeProject.SelectedValue.Equals("9")) // other
            {
                Function.ShowControls(phProjectOther);
                Function.ClearControls(phDisplay, false);
                Function.ClearControls(phPromoItem, false);
            }
            else if (ddTypeProject.SelectedValue.Equals("10")) // promotional item
            {
                Function.ShowControls(phPromoItem);
                Function.ClearControls(phProjectOther, false);
                Function.ClearControls(phDisplay, false);
            }
            else // hide additional options
            {
                Function.ClearControls(phPromoItem,false);
                Function.ClearControls(phProjectOther, false);
                Function.ClearControls(phDisplay, false);
            }

            checkDate(); // check the date to choose the appropriate due date notification
        }

        protected void ddTypeOfDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            // show additional options for the type of display selected
            if (ddTypeOfDisplay.SelectedValue.Equals("5")) // other
                Function.ShowControls(phDisplayOther);
            else
                Function.ClearControls(phDisplayOther, false);
        }

        protected void txtDueDate_TextChanged(object sender, EventArgs e)
        {
            checkDate(); // check the date to choose the appropriate due date notification
        }


        protected void checkDate()
        {
            // checks db to see if the selected project needs a specific length of time. 
            if (ddTypeProject.SelectedIndex > 0)
            {
                DateTime today = new DateTime();
                today = System.DateTime.Now;
                notDueDate.Type = Notification.Types.Attention;

                PrintDaysNotice dn = PrintWO.GetDaysNoticeAndMessage(Int32.Parse(ddTypeProject.SelectedValue));
                if (dn != null) // if the selected item has a minimum timeline
                {
                    int daysNoticeNeeded = dn.Days;
                    String additionalNotes = dn.AdditionalNotes;
                    String message = String.Empty;

                    DateTime minDate = today.AddDays(daysNoticeNeeded);
                    if (!txtDueDate.Text.Equals(String.Empty)) // if the user has input a date, compare the selected date with the minimum date
                    {
                        DateTime dueDate = Convert.ToDateTime(txtDueDate.Text);
                        if (dueDate.Date.CompareTo(minDate.Date) < 0)  // if the date selected doesn't meet the appropriate date guidelines...
                        {
                            message = "Warning: Please be aware that the timeline you have provided does not comply with our Minimum Lead-Time Requirements. We require  " + daysNoticeNeeded.ToString() + " days of advanced notice. To follow our guidelines, the due date should be " + minDate.ToString("MMMM dd, yyyy") + ".  You will still be able to submit your work order, but be aware that the deadline may not be met.";
                            notDueDate.Visible = true;
                        }
                        else
                            notDueDate.Visible = false;
                    }
                    else // if no date was selected, show the minimum date needed
                    {
                        message = "This project needs " + daysNoticeNeeded.ToString() + " days to work on. According to our Minimum Timelines Guidelines, your minimum due date should be " + minDate.ToString("MMMM dd, yyyy") + ". You can still submit this work order, but be aware that your deadline may not be met.";
                    }
                   
                    if (additionalNotes == null || additionalNotes.Length == 0) // if there are additional notes associated with the project...
                        notDueDate.Message = message;
                    else
                        notDueDate.Message = message + "<br /><br />" + additionalNotes;
                }
                else
                    notDueDate.Visible = false;  // if there are no minimum timelines...
            }
            else
                notDueDate.Visible = false; // if the type of project is not selected
       }

        protected void ddPrintingMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if commercial printing, show relevant options and reset the colour info dropdown to include "one colour"
            if (ddPrintingMethod.SelectedItem.Text.ToString().Equals("Commercial"))
            {
                Function.ShowControls(phBudget);
                notCommercialInfo.Visible = true;
                Function.ShowControls(phCommercialPrint);
                ddColourInfo.Items.Clear();
                ddColourInfo.DataSource = PrintWO.GetColourInfo();
                ddColourInfo.DataTextField = "Value";
                ddColourInfo.DataValueField = "ID";
                ddColourInfo.DataBind();
            }
            // if user doesn't select commercial, remove "one color" from options and hide commercial settings
            else
            {
                Function.ClearControls(phBudget, false);
                notCommercialInfo.Visible = false;
                Function.ClearControls(phCommercialPrint,false);
                ddColourInfo.Items.RemoveAt(3);
            }
        }

        protected void ddPaperSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddPaperSize.SelectedValue.Equals("5"))
                Function.ShowControls(phCustomPaperSize);
            else
                Function.ClearControls(phCustomPaperSize,false);
        }

        protected void ddCredits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddCredits.SelectedItem.Text.ToString().Equals("None") && !ddCredits.SelectedValue.ToString().Equals(String.Empty))
                Function.ShowControls(phCredits);
            else
                Function.ClearControls(phCredits, false);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false; // prevent double submission
            using (WOLinqClassesDataContext db = new WOLinqClassesDataContext())
            {
                bool IsDesigner = Users.IsUserDesigner();
                Workorder w = new Workorder();
                w.submitted_date = DateTime.Now;
                w.submitted_by = Function.GetUserName();
                if (Request.QueryString["quote"] != null && Request.QueryString["quote"].Equals("1"))
                    w.wotype = 5;
                else
                    w.wotype = 1;
                w.duedate = txtDueDate.Text.ConvertToDate();
                w.ProgramManager = int.Parse(ddCoordinators.SelectedValue);
                w.title = txtPubTitle.Text;
                w.status = IsDesigner ? 4 : 1;
                db.Workorders.InsertOnSubmit(w);

                WorkOrdersPrint p = new WorkOrdersPrint();
                p.Workorder = w;
                p.ProjectType = int.Parse(ddTypeProject.SelectedValue);
                p.ProjectTypeOther = txtProjectOther.Text;
                p.TypeOfDisplay = ddTypeOfDisplay.SelectedIndex > 0 ? int.Parse(ddTypeOfDisplay.SelectedValue) : (int?)null;
                p.TypeOfDisplayOther = txtDisplayOther.Text;
                p.PromoItem = txtPromoItem.Text;
                p.PrintingMethod = int.Parse(ddPrintingMethod.SelectedValue);
                p.Budget = txtBudget.Text;
                p.PaperSize = int.Parse(ddPaperSize.SelectedValue);
                p.CustomPaperSize = txtCustomPaperSize.Text;
                p.PaperType = int.Parse(ddPaperType.SelectedValue);
                p.ColourInfo = int.Parse(ddColourInfo.SelectedValue);
                p.NumberCopies = txtNumberCopies.Text;
                p.FullBleed = ddFullBleed.Value;
                p.Credit = int.Parse(ddCredits.SelectedValue);
                p.CreditName = txtCreditName.Text;
                p.Notes = txtNotes.Text;
                db.WorkOrdersPrints.InsertOnSubmit(p);
                db.SubmitChanges();
                int ID = p.wID;
                WO.UploadFiles(w.ID, AttachedFiles.UploadedFiles);
                Function.LogAction(ID, "Work order created");
                if (!IsDesigner) WO.SendNewWONotification(ID);
                if (ddAddToWebsite.Value == true) // if the user added the option to add to the website, transfer user to the page
                    Response.Redirect("~/Create/Web.aspx?AddTo=" + ID);
                else // if not, success!!
                    Response.Redirect("~/MyWorkOrders.aspx?success=true&ID=" + ID + "&type=" + w.wotype.ToString());
            }
        }
    }
}