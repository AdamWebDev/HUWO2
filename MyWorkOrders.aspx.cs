using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2
{
    public partial class MyWorkOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RefreshPage();
                if (Request.QueryString["success"] != null && Request.QueryString["success"].Equals("true"))
                {
                    pnSuccess.Visible = true;
                    int ID, type;
                    if (Request.QueryString["ID"] != null && int.TryParse(Request.QueryString["ID"], out ID) && Request.QueryString["type"] != null && int.TryParse(Request.QueryString["type"],out type))
                    {
                        lnkWorkOrder.NavigateUrl = "~/View/Default.aspx?ID=" + ID + "&type=" + type;
                    }
                }
            }
        }

        public void RefreshPage()
        {
            IEnumerable<WO.WorkOrderWithDetails> data = WO.GetMyWorkOrders(Function.GetUserName()); // get all of the users's work orders
            switch (ddFilters.SelectedValue) // filter the data based on the dropdown based on status
            {
                case "open":
                    data = data.Where(w => w.status < 6);
                    ltMessage.Text = "You currently don't have any open work orders.";
                    break;
                case "unapproved":
                    data = data.Where(w => w.status == 1);
                    ltMessage.Text = "You currently don't have any unapproved work orders.";
                    break;
                case "completed":
                    data = data.Where(w => w.status == 6);
                    ltMessage.Text = "You currently don't have any completed work orders.";
                    break;
                case "deleted":
                    data = data.Where(w => w.status == 7);
                    ltMessage.Text = "You currently don't have any deleted work orders.";
                    break;
            }

            // populate!
            
            rptWorkOrders.DataSource = data;
            rptWorkOrders.DataBind();
            ltMessage.Visible = rptWorkOrders.Items.Count == 0;
            
        }

        protected void ddFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPage();
        }
    }
}