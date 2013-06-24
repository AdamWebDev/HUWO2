﻿using System;
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
            
            string user = Function.GetUserName();
            if(Users.IsUserDesigner(user))
                Response.Redirect("~/Designers/OpenWorkOrders.aspx");
            else if (Users.IsUserCoordinator(user))
                Response.Redirect("~/Coordinators/MyWorkOrders.aspx");
            else
                Response.Redirect("~/MyWorkOrders.aspx");
        }
    }
}