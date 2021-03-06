﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNHUWO2
{
    public partial class CreateWorkOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // populate the dropdown
                ddWoTypes.AddInitialItem();
                ddWoTypes.DataSource = HNHUWO2.Classes.WO.GetWorkOrderTypes();
                ddWoTypes.DataTextField = "type";
                ddWoTypes.DataValueField = "ID";
                ddWoTypes.DataBind();
            }
            else {
                // redirect the user based on the work order type they have selected
                if (ddWoTypes.SelectedIndex > 0)
                {
                    switch (int.Parse(ddWoTypes.SelectedValue))
                    {
                        case 1: // Print
                            Response.Redirect("~/Create/Print.aspx");
                            break;
                        case 2: //Web
                            Response.Redirect("~/Create/Web.aspx");
                            break;
                        case 3: // Radio Ad
                            Response.Redirect("~/Create/Radio.aspx");
                            break;
                        case 4: // Media Release
                            Response.Redirect("~/Create/News.aspx");
                            break;
                        case 5: // Quote for Commercial Print
                            Response.Redirect("~/Create/Print.aspx?quote=1");
                            break;
                        case 6: // Video
                            Response.Redirect("~/Create/Video.aspx");
                            break;
                        default:
                            notError.Type = Notification.Types.Error;
                            notError.Message = "Please select a work order type to get started.";
                            notError.Visible = true;
                            break;
                    }
                }
            }
        }
    }
}