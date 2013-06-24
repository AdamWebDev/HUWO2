using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2.Designers
{
    public partial class OpenWorkOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Users.IsUserDesigner())
                {
                    rptWorkOrders.DataSource = WO.GetOpenWorkOrders();
                    rptWorkOrders.DataBind();
                    ltContentTitle.Text = ltPageTitle.Text = "Viewing Open Work Orders";
                }
                else
                    Response.Redirect("~/Default.aspx");
            }
        }

        protected void ddFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddFilters.SelectedValue.Equals("open")) 
            {
                rptWorkOrders.DataSource = WO.GetOpenWorkOrders();
                rptWorkOrders.DataBind();
            }
            else if (ddFilters.SelectedValue.Equals("unapproved")) 
            {
                rptWorkOrders.DataSource = WO.GetUnapprovedWorkOrders();
                rptWorkOrders.DataBind();
            }
            else if (ddFilters.SelectedValue.Equals("completed")) 
            {
                rptWorkOrders.DataSource = WO.GetCompletedWorkOrders();
                rptWorkOrders.DataBind();
            }
            else if (ddFilters.SelectedValue.Equals("deleted"))
            {
                rptWorkOrders.DataSource = WO.GetDeletedWorkOrders();
                rptWorkOrders.DataBind();
            }
        }

        public string GetUserName(string username)
        {
            return Users.GetUsername(username);
        }
    }
}