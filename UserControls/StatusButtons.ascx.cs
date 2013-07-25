using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using HNHUWO2.Classes;

namespace HNHUWO2.UserControls
{
    public partial class StatusButtons : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // find out the status of the current WO, and show the action buttons accordingly
            int ID = int.Parse(Request.QueryString["ID"]);
            Workorder wo = WO.GetWorkOrder(ID);
            ShowActionButtons(wo.status);
        }

        // unapprove the current work order
        protected void btnUnapprove_OnClick(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["ID"]);
            WO.Unapprove(ID);
            UpdatePage();
        }

        // approve the current work order
        protected void btnApprove_OnClick(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["ID"]);
            WO.Approve(ID);
            UpdatePage();
        }

        // mark the work order as "in progress"
        protected void btnMarkInProgress_OnClick(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["ID"]);
            WO.MarkInProgress(ID);
            UpdatePage();
        }

        // mark the work order as "proof sent"
        protected void btnProofSent_OnClick(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["ID"]);
            WO.MarkProofSent(ID);
            UpdatePage();
        }

        // mark the work order as "complete"
        protected void btnMarkComplete_OnClick(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["ID"]);
            WO.MarkComplete(ID);
            UpdatePage();
        }

        // deletes the work order (in the case of duplication or other odd circumstances)
        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["ID"]);
            WO.Delete(ID);
            UpdatePage();
        }

        // shows and hides the action buttons depending on the permissions of the logged in user and the status of the current work order
        public void ShowActionButtons(int status)
        {
            if (status == 1) // not approved
            {
                if (Users.IsUserCoordinator())
                {
                    btnApprove.Visible = true;
                    //btnApproveWithChanges.Visible = true;
                }
            }
            else // if approved...
            {
                btnApprove.Visible = false;
                //btnApproveWithChanges.Visible = false;

                if (Users.IsUserDesigner()) // if the user is one of the designers, show the controls
                {
                    btnMarkInProgress.Visible = true;
                    btnProofSent.Visible = true;
                    btnMarkComplete.Visible = true;
                    btnDelete.Visible = true;
                    if(Users.IsUserAdmin()) {
                        btnApprove.Visible = true;
                        //btnApproveWithChanges.Visible = true;
                        btnUnapprove.Visible = true;
                    }
                }
                else // if not a designer, hide it all!
                {
                    btnMarkInProgress.Visible = false;
                    btnProofSent.Visible = false;
                    btnMarkComplete.Visible = false;
                    btnDelete.Visible = false;
                }
            }
        }

        /// <summary>
        /// In order to have the buttons updated the content in the parent page, we use this fancy workaround to fire a method from this user control
        /// From: http://www.aspsnippets.com/Articles/Calling-Parent-Page-method-from-Child-Usercontrol-using-Reflection-in-ASP.Net.aspx
        /// </summary>
        private void UpdatePage()
        {
            int ID = int.Parse(Request.QueryString["ID"]);
            this.Page.GetType().InvokeMember("PopulatePage", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { ID });
        }
    }
}