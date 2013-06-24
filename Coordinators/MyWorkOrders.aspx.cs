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

        
        public bool IsUnapproved(object _status)
        {
            return (int)_status == 1 ? true : false;
        }

        protected void ddFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddFilters.SelectedValue.Equals("unapproved"))
            {
                rptWorkOrders.DataSource = WO.GetMyStaffUnapprovedWorkOrders();
                rptWorkOrders.DataBind();
            }
            else if (ddFilters.SelectedValue.Equals("inprogress"))
            {
                rptWorkOrders.DataSource = WO.GetMyStaffInProgressWorkOrders();
                rptWorkOrders.DataBind();
            }
            else if (ddFilters.SelectedValue.Equals("completed"))
            {
                rptWorkOrders.DataSource = WO.GetMyStaffCompletedWorkOrders();
                rptWorkOrders.DataBind();
            }
            else if (ddFilters.SelectedValue.Equals("deleted"))
            {
                rptWorkOrders.DataSource = WO.GetMyStaffDeletedWorkOrders();
                rptWorkOrders.DataBind();
            }
        }

        public string GetUserName(string username)
        {
            return Users.GetUsername(username);
        }
    }

}