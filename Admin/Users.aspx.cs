﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // populate the table if the user has appropriate permissions
                if (Classes.Users.IsUserDesigner())
                {
                    rptUsers.DataSource = Classes.Admin.GetUsers();
                    rptUsers.DataBind();
                }
                // if the user doesn't have permission, kick them out!
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        // show the appropriate commands based on if the user is active or not
        protected void rptUsers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnID = (HiddenField)e.Item.FindControl("hdnID");
                HiddenField hdnActive = (HiddenField)e.Item.FindControl("hdnActive");
                Button btnActive = (Button)e.Item.FindControl("btnActive");
                int ID = int.Parse(hdnID.Value);
                bool Active = hdnActive.Value.Equals("True");
                btnActive.Text = Active ? "Active" : "Inactive";
                btnActive.CssClass = Active ? "button" : "button inactive";
                
                
            }
        }

        // toggles the users status - active or inactive
        protected void btnActive_Click(object sender, EventArgs e)
        {
            Button btnActive = sender as Button;
            int ID = int.Parse(btnActive.CommandArgument);
            RepeaterItem item = btnActive.NamingContainer as RepeaterItem;
            HiddenField hdnActive = (HiddenField)item.FindControl("hdnActive");
            Classes.Admin.SetUserStatus(ID);
            rptUsers.DataSource = Classes.Admin.GetUsers();
            rptUsers.DataBind();
        }
    }
}