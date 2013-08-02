using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2.Reports
{
    public partial class ByCoordinator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // only give access to designers and program managers
            if (!Users.IsUserDesigner() && !Users.IsUserCoordinator()) Response.Redirect("~/Default.aspx");
        }

        /// <summary>
        /// Show report with relevant dates
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            rptReport.DataSource = HNHUWO2.Classes.Reports.ByCoordinator(txtStartDate.Text.ConvertToDate(),txtEndDate.Text.ConvertToDate());
            rptReport.DataBind();
            var items = rptReport.Items.Count;
            rptReport.Visible = items > 0;
            ltEmpty.Visible = items == 0;
        }

        // used for a total count of work orders
        public int sum = 0;

        /// <summary>
        /// Count the total number of work orders and display them
        /// </summary>
        protected void rptReport_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                sum += Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Count"));
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                Literal ltTotal = e.Item.FindControl("ltTotal") as Literal;
                ltTotal.Text = sum.ToString();
            }
        }
    }
}