using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HNHUWO2.Classes;

namespace HNHUWO2.Reports
{
    public partial class ByProjectType : System.Web.UI.Page
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
            rptReport.DataSource = Classes.Reports.ByProjectType(txtStartDate.Text.ConvertToDate(), txtEndDate.Text.ConvertToDate());
            rptReport.DataBind();
            rptPrintReport.DataSource = Classes.Reports.ByPrintType(txtStartDate.Text.ConvertToDate(), txtEndDate.Text.ConvertToDate());
            rptPrintReport.DataBind();
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

        // used for a total count of print work orders
        public int print_sum = 0;

        /// <summary>
        /// Count the total number of print work orders and display them
        /// </summary>
        protected void rptPrintReport_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                print_sum += Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Count"));
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                Literal ltTotal = e.Item.FindControl("ltTotal") as Literal;
                ltTotal.Text = print_sum.ToString();
            }
        }
    }
}