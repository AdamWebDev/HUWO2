using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HNHUWO2.Reports
{
    public partial class ByProjectType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            rptReport.DataSource = HNHUWO2.Classes.Reports.ByProjectType(txtStartDate.Text.ConvertToDate(), txtEndDate.Text.ConvertToDate());
            rptReport.DataBind();
            rptPrintReport.DataSource = HNHUWO2.Classes.Reports.ByPrintType(txtStartDate.Text.ConvertToDate(), txtEndDate.Text.ConvertToDate());
            rptPrintReport.DataBind();
        }

        public int sum = 0;

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

        public int print_sum = 0;
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