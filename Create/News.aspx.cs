﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2.Create
{
    public partial class News : System.Web.UI.Page
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

                // populate distro outlets
                ddDistributionOutlets.AddInitialItem();
                ddDistributionOutlets.DataSource = NewsWO.GetDistroOutlets();
                ddDistributionOutlets.DataValueField = "ID";
                ddDistributionOutlets.DataTextField = "Value";
                ddDistributionOutlets.DataBind();

                // load the date comparison validator to make sure that dates are AFTER today
                cmpDateToIssue.ValueToCompare = DateTime.Today.ToShortDateString();
            }
        }

        /// <summary>
        /// Conditional fields based on distro outlets
        /// </summary>
        protected void ddDistributionOutlets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddDistributionOutlets.SelectedItem.Text.Equals("Other"))
                Function.ShowControls(phDistroOther);
            else
                Function.ClearControls(phDistroOther, false);
        }


        /// <summary>
        /// Submit the form!
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false; // prevent double submission
            using (WOLinqClassesDataContext db = new WOLinqClassesDataContext())
            {
                // if the user is a designer or coordinator, they don't need to go through the approval process
                bool IsUserDesigner = Users.IsUserDesigner();
                bool NeedsApproval = !IsUserDesigner && !Users.IsUserCoordinator();
                Workorder w = new Workorder();
                w.submitted_date = DateTime.Now;
                w.submitted_by = Function.GetUserName();
                w.wotype = 4;
                w.duedate = txtDateToIssue.Text.ConvertToDate();
                w.ProgramManager = int.Parse(ddCoordinators.SelectedValue);
                w.title = txtTitleTopic.Text;
                w.status = NeedsApproval ? 1 : 2;
                db.Workorders.InsertOnSubmit(w);
                WorkOrdersNews n = new WorkOrdersNews();
                n.Workorder = w;
                n.DistributionOutlets = int.Parse(ddDistributionOutlets.SelectedValue);
                n.DistributionDetails = txtDistributionOutletsOther.Text;
                n.Contact = txtContact.Text;
                n.AdditionalNotes = txtNotes.Text;
                db.WorkOrdersNews.InsertOnSubmit(n);
                db.SubmitChanges();
                int ID = w.ID;
                
                // look after the files
                WO.UploadFiles(w.ID, AttachedFiles.UploadedFiles);
                // log the work order
                WO.LogAction(ID, "Work order created");
                // send notification as needed
                WO.SendNewWONotification(ID, NeedsApproval, IsUserDesigner);
                
                // move on!
                Response.Redirect("~/MyWorkOrders.aspx?success=true&ID=" + ID + "&type=" + w.wotype);
            }
            
        }
    }
}