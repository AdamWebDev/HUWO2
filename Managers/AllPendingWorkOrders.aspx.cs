using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2.Coordinators
{
    public partial class AllPendingWorkOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Users.IsUserCoordinator())
            {
                // populates the repeater with all open work orders assigned to the logged in user
                rptWorkOrders.DataSource = WO.GetUnapprovedWorkOrders();
                rptWorkOrders.DataBind();
            }
            else
                Response.Redirect("~/Default.aspx");
        }

        public string GetUserName(string username)
        {
            return Users.GetUsername(username);
        }
    }
}