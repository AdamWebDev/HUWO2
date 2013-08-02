using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;


namespace HNHUWO2.Coordinators
{
    public partial class MyWorkOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Users.IsUserCoordinator())
            {
                // populates the repeater with all open work orders assigned to the logged in user
                rptWorkOrders.DataSource = WO.GetMyStaffUnapprovedWorkOrders();
                rptWorkOrders.DataBind();
            }
            else
                Response.Redirect("~/Default.aspx");
        }

        /// <summary>
        /// Check if a work order is not approved (used in display table)
        /// </summary>
        /// <param name="_status">Status</param>
        /// <returns>True/False</returns>
        public bool IsUnapproved(object _status)
        {
            return (int)_status == 1 ? true : false;
        }

        /// <summary>
        /// Filter for showing work orders in various stages of completion
        /// </summary>
        protected void ddFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddFilters.SelectedValue)
            {
                case "unapproved":
                    rptWorkOrders.DataSource = WO.GetMyStaffUnapprovedWorkOrders();
                    rptWorkOrders.DataBind();
                    break;
                case "inprogress":
                    rptWorkOrders.DataSource = WO.GetMyStaffInProgressWorkOrders();
                    rptWorkOrders.DataBind();
                    break;
                case "completed":
                    rptWorkOrders.DataSource = WO.GetMyStaffCompletedWorkOrders();
                    rptWorkOrders.DataBind();
                    break;
                case "deleted":
                    rptWorkOrders.DataSource = WO.GetMyStaffDeletedWorkOrders();
                    rptWorkOrders.DataBind();
                    break;
                case "all":
                    rptWorkOrders.DataSource = WO.GetMyStaffWorkOrders();
                    rptWorkOrders.DataBind();
                    break;
            }
        }

        /// <summary>
        /// Shows display name instead of user name
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Display name</returns>
        public string GetUserName(string username)
        {
            return Users.GetUsername(username);
        }
    }

}