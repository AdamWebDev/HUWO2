﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2.View
{
    public partial class Print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int ID;
                // ensure that there's an ID set in the query string
                if (Int32.TryParse(Request.QueryString["ID"], out ID))
                    PopulatePage(ID);
                else
                    Response.Redirect("~/Default.aspx");
            }
        }

        public void PopulatePage(int ID)
        {
            // populate the work order request
            WorkOrdersPrint wo = PrintWO.GetPrintWorkOrder(ID);
            if (wo != null)
            {
                if (wo.Workorder.wotype == 5) // quote only
                {
                    notQuote.Visible = true;
                    ltContentTitle.Text = ltPageTitle.Text = "View Quote for Commercial Print";
                }
                lblID.Text = wo.wID.ToString();
                lblSubmittedBy.Text = Users.GetUsername(wo.Workorder.submitted_by);
                lblStatus.Text = wo.Workorder.Status1.status;
                lblPubTitle.Text = wo.Workorder.title;
                lblDueDate.Text = wo.Workorder.duedate.DisplayDate();
                lblProgramManager.Text = wo.Workorder.User.FullName;
                lblTypeOfProject.Text = wo.ProjectType.HasValue ? wo.PrintTypeOfProject.Value : String.Empty;
                lblProjectOther.Text = wo.ProjectTypeOther;
                lblTypeOfDisplay.Text = wo.TypeOfDisplay.HasValue ? wo.PrintTypeOfDisplay.Value : String.Empty;
                lblDisplayOther.Text = wo.TypeOfDisplayOther;
                lblPromoItem.Text = wo.PromoItem;
                lblPrintingMethod.Text = wo.PrintingMethod.HasValue ? wo.PrintMethod.Value : String.Empty;
                lblBudget.Text = wo.Budget;
                lblPaperSize.Text = wo.PaperSize.HasValue ? wo.PrintPaperSize.Value : String.Empty;
                lblCustomPaperSize.Text = wo.CustomPaperSize;
                lblPaperType.Text = wo.PaperType.HasValue ? wo.PrintPaperType.Value : String.Empty;
                lblColourInfo.Text = wo.ColourInfo.HasValue ? wo.PrintColourInfo.Value : String.Empty;
                lblNumberCopies.Text = wo.NumberCopies;
                lblFullBleed.Text = wo.FullBleed.ToYesNoString();
                lblCredits.Text = wo.Credit.HasValue ? wo.PrintCreditType.Value : String.Empty;
                lblCreditName.Text = wo.CreditName;
                lblAddToWebsite.Text = PrintWO.HasWebWorkOrder(wo.ID) ? "Yes" : "No";
                lblNotes.Text = wo.Notes.IncludeLineBreaks();
                lblCoordinatorNotes.Text = wo.Workorder.coordinatorNotes;

                // if this is connected to a web work order, give the user a link to switch to it
                lnkRelatedWO.NavigateUrl = "~/View/Web.aspx?ID=" + wo.webID.ToString();
                pnLinkedWebWO.Visible = wo.webID.HasValue;

                // if the status has changed, let's show a confirmation
                if (Page.IsPostBack) statusMessages.DisplayMessage(wo.Workorder.status);
                // show attached files
                attachedFiles.UpdateFileList(wo.wID);
            }
            else Response.Redirect("~/Default.aspx");
        }
    }
}