using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Users.IsUserDesigner())
                Response.Redirect("~/Designers/OpenWorkOrders.aspx");
            else if (Users.IsUserCoordinator())
                Response.Redirect("~/Managers/MyWorkOrders.aspx");
            else
                Response.Redirect("~/MyWorkOrders.aspx");
        }
    }
}